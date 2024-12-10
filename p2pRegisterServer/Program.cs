using System.Net;
using System.Net.Sockets;
using System.Text;
using Spectre.Console;

var successMessage = Encoding.UTF8.GetBytes("successful");

AnsiConsole.Write(
    new FigletText("STUN Rendevous - Registratoin Server")
        .Centered()
        .Color(Color.Cyan1)); // Using predefined color Cyan1
AnsiConsole.MarkupLine("[bold cyan]Version 1.0.0[/]");

//Change to an api endpoint? 

Console.Write("enter listening port (default: 8080): ");
var listeningPort = Convert.ToInt32(ReadInputWithDefault("8080", TimeSpan.FromSeconds(5)));
using var udpClient = new UdpClient(listeningPort);
AnsiConsole.MarkupLine($"[bold green]started listening on port {listeningPort}...[/]");

var peersData = new Dictionary<string, IList<IPEndPoint>>();

while (true)
{
    try
    {
        var (endPoint, group) = ReadData();
        AnsiConsole.MarkupLine($"[bold yellow]received {group} from {endPoint}[/]");

        if (!peersData.ContainsKey(group))
        {
            peersData[group] = new List<IPEndPoint>();
        }
        peersData[group].Add(endPoint);
        udpClient.Send(successMessage, endPoint);

        if (peersData[group].Count == 2)
        {
            InformClient(peersData[group][0], peersData[group][1]);
            InformClient(peersData[group][1], peersData[group][0]);
            peersData.Remove(group);
            AnsiConsole.MarkupLine($"[bold green]removed group {group}[/]");
        }
    }
    catch (Exception ex)
    {
        AnsiConsole.MarkupLine($"[bold red]Error: {ex.Message}[/]");
    }
}

void InformClient(IPEndPoint destinationEndPoint, IPEndPoint sourceEndPoint)
{
    try
    {
        var dataString = $"{sourceEndPoint.Address} {sourceEndPoint.Port}";
        var dataBytes = Encoding.UTF8.GetBytes(dataString);
        AnsiConsole.MarkupLine($"[bold blue]sending \"{dataString}\"\n  to {destinationEndPoint}...[/]");
        udpClient.Send(dataBytes, destinationEndPoint);
    }
    catch (Exception ex)
    {
        AnsiConsole.MarkupLine($"[bold red]Error sending data to {destinationEndPoint}: {ex.Message}[/]");
    }
}

(IPEndPoint, string) ReadData()
{
    var endPoint = new IPEndPoint(IPAddress.Any, 0);
    var receivedData = udpClient.Receive(ref endPoint);
    var group = Encoding.UTF8.GetString(receivedData);

    return (endPoint, group);
}

string ReadInputWithDefault(string defaultValue, TimeSpan timeout)
{
    var inputTask = Task.Run(() => Console.ReadLine());
    if (inputTask.Wait(timeout))
    {
        var input = inputTask.Result;
        return string.IsNullOrEmpty(input) ? defaultValue : input;
    }
    else
    {
        return defaultValue;
    }
}
