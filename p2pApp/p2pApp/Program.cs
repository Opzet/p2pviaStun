using System.Net;
using System.Net.Sockets;
using System.Text;
using Spectre.Console;
using STUN.Client;
using System.Threading.Tasks;

namespace p2pApp
{
    internal class Program
    {
        private static UdpClient udpClient;
        private static IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

        static async Task Main(string[] args)
        {
            AnsiConsole.Write(
                new FigletText("Peer Client")
                    .Centered()
                    .Color(Color.Cyan1));
            AnsiConsole.MarkupLine("[bold cyan]Version 1.0.0[/]");

            Console.Write("Enter STUN server endpoint (default: stun.l.google.com:19302): ");
            var stunEndPoint = ReadInputWithDefault("stun.l.google.com:19302");
            var stunServer = new IPEndPoint(IPAddress.Parse(stunEndPoint.Split(':')[0]), int.Parse(stunEndPoint.Split(':')[1]));

            udpClient = new UdpClient(0); // Use any available port
            var stunClient = new StunClient5389UDP(stunServer, new IPEndPoint(IPAddress.Any, 0));
           
            await stunClient.QueryAsync();
            var result = stunClient.State;

            if (result.QueryError != StunError.None)
            {
                AnsiConsole.MarkupLine("[bold red]An error occurred while connecting to STUN server[/]");
                return;
            }

            AnsiConsole.MarkupLine("[bold green]Connected to STUN server[/]");
            AnsiConsole.MarkupLine($"[bold yellow]Public endpoint: {result.PublicEndPoint}[/]");

            Console.Write("Enter peer IP: ");
            var peerIp = IPAddress.Parse(Console.ReadLine());
            Console.Write("Enter peer port: ");
            var peerPort = int.Parse(Console.ReadLine());
            var peerEndPoint = new IPEndPoint(peerIp, peerPort);

            AnsiConsole.MarkupLine("[bold blue]Punching UDP hole...[/]");
            udpClient.Send(Array.Empty<byte>(), peerEndPoint);

            var listenerThread = new Thread(Listen);
            listenerThread.Start();

            while (true)
            {
                Console.Write("> ");
                var message = Console.ReadLine();
                if (!string.IsNullOrEmpty(message))
                {
                    var messageDataBytes = Encoding.UTF8.GetBytes(message);
                    udpClient.Send(messageDataBytes, peerEndPoint);
                }
            }
        }

        private static void Listen()
        {
            while (true)
            {
                var messageBytes = udpClient.Receive(ref remoteEndPoint);
                var message = Encoding.UTF8.GetString(messageBytes);

                if (string.IsNullOrEmpty(message))
                    continue;

                ConsoleHelper.ClearCurrentLine();
                Console.Write($"peer: {message}\n> ");
            }
        }

        private static string ReadInputWithDefault(string defaultValue)
        {
            var input = Console.ReadLine();
            return string.IsNullOrEmpty(input) ? defaultValue : input;
        }
    }

    internal class ConsoleHelper
    {
        public static void ClearCurrentLine()
        {
            var currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
