using System.Net;
using System.Net.Sockets;
using System.Text;
using Spectre.Console;
using STUN.Client;
using System.Threading.Tasks;
using Dns.Net.Abstractions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using STUN.StunResult;
using STUN;
using Dns.Net.Clients;
using STUN.Enums;

namespace p2pApp
{
    internal class Program
    {
        private static UdpClient udpClient;
        private static IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
        private static readonly IDnsClient _dnsClient = new DefaultDnsClient();

        private static readonly IPEndPoint Any = new(IPAddress.Any, 0);
        static async Task Main(string[] args)
        {
            AnsiConsole.Write(
                new FigletText("Peer Client- StunClient5389UDP")
                    .Centered()
                    .Color(Color.Cyan1));
            AnsiConsole.MarkupLine("[bold cyan]Version 1.0.0[/]");

          
            Console.Write("STUN server endpoint (stun.hot-chilli.net) ");
            
            IPAddress ip = await _dnsClient.QueryAsync(@"stun.hot-chilli.net");
            using IStunClient5389 client = new StunClient5389UDP(new IPEndPoint(ip, StunServer.DefaultPort), Any);

            StunResult5389 response = await client.BindingTestAsync();

            if (response.BindingTestResult != BindingTestResult.Success)
            {
                AnsiConsole.MarkupLine("[bold red]An error occurred while connecting to STUN server[/]");
                return;
            }
                
            if(response.MappingBehavior== MappingBehavior.Unknown);

            if (response.FilteringBehavior == FilteringBehavior.Unknown) ;

            var PublicEndPoint = response.PublicEndPoint;
            var LocalEndPoint = response.LocalEndPoint;
            var OtherEndPoint = response.OtherEndPoint;

            AnsiConsole.MarkupLine("[bold green]Connected to STUN server[/]");
            AnsiConsole.MarkupLine($"[bold yellow]Public endpoint: {PublicEndPoint}[/]");
            AnsiConsole.MarkupLine($"[bold yellow]Local endpoint: {LocalEndPoint}[/]");


            //Register with Rendevous server
            AnsiConsole.MarkupLine($"[bold green]Contacting Rendevous server...[/]");


            // QUery Rendevous server for peer
            //var peerEndPoint = new IPEndPoint(peerIp, peerPort);

            AnsiConsole.MarkupLine("[bold blue]Punching UDP hole...[/]");
           // udpClient.Send(Array.Empty<byte>(), peerEndPoint);

            var listenerThread = new Thread(Listen);
            listenerThread.Start();

            while (true)
            {
                Console.Write("> ");
                var message = Console.ReadLine();
                if (!string.IsNullOrEmpty(message))
                {
                    var messageDataBytes = Encoding.UTF8.GetBytes(message);
                //    udpClient.Send(messageDataBytes, peerEndPoint);
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
