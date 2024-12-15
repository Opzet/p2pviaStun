using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Sockets;
using static System.Runtime.InteropServices.JavaScript.JSType;
using STUN.Client;
using STUN.Enums;

using Dns.Net.Abstractions;
using Dns.Net.Clients;

namespace STUN;

public class StunServer
{
    private readonly IDnsClient _dnsClient = new DefaultDnsClient();

    public string Hostname
    {
        get;
    }
    public ushort Port
    {
        get;
    }

    public const ushort DefaultPort = 3478;
    public const ushort DefaultTlsPort = 5349;

    public StunServer()
    {
        // Change to a retry mechanism of stun servers
        Hostname = @"stun.syncthing.net";
        Port = DefaultPort;
    }

    public async Task<string[]> GetSTUNServerListAsync(IProgress<string> progress = null)
    {
        const string url = @"https://raw.githubusercontent.com/pradt2/always-online-stun/master/valid_hosts_tcp.txt";
        HttpClient httpClient = new();

        string listRaw = await httpClient.GetStringAsync(url);
        progress?.Report("Fetched STUN server list.");

        string[] list = listRaw.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        List<string> validServers = new();

        await Parallel.ForEachAsync(list, async (host, cancellationToken) =>
        {
            try
            {
                progress?.Report($"Processing host: {host}");

                if (!HostnameEndpoint.TryParse(host, out HostnameEndpoint? hostEndpoint, StunServer.DefaultPort))
                {
                    progress?.Report($"Failed to parse host: {host}");
                    return;
                }

                IPAddress ip = await _dnsClient.QueryAsync(hostEndpoint.Hostname);
                using IStunClient5389 client = new StunClient5389TCP(new IPEndPoint(ip, hostEndpoint.Port), null);

                await client.QueryAsync(cancellationToken);

                if (client.State.MappingBehavior is MappingBehavior.AddressAndPortDependent or MappingBehavior.AddressDependent or MappingBehavior.EndpointIndependent or MappingBehavior.Direct)
                {
                    lock (validServers)
                    {
                        validServers.Add(host);
                    }
                    progress?.Report($"Valid server found: {host}");
                }
                else
                {
                    progress?.Report($"Invalid server: {host}");
                }
            }
            catch (Exception ex)
            {
                progress?.Report($"Error processing host {host}: {ex.Message}");
            }
        });

        progress?.Report("Completed processing STUN server list.");
        return validServers.ToArray();
    }

    private StunServer(string hostname, ushort port)
    {
        Hostname = hostname;
        Port = port;
    }

    public static bool TryParse(string s, [NotNullWhen(true)] out StunServer? result, ushort defaultPort = DefaultPort)
    {
        if (!HostnameEndpoint.TryParse(s, out HostnameEndpoint? host, defaultPort))
        {
            result = null;
            return false;
        }

        result = new StunServer(host.Hostname, host.Port);
        return true;
    }

    public override string ToString()
    {
        if (Port is DefaultPort)
        {
            return Hostname;
        }
        if (IPAddress.TryParse(Hostname, out IPAddress? ip) && ip.AddressFamily is AddressFamily.InterNetworkV6)
        {
            return $@"[{ip}]:{Port}";
        }
        return $@"{Hostname}:{Port}";
    }
}
