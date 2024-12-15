using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using STUN.Client;
using System.Threading.Tasks;
using Dns.Net.Abstractions;
using STUN.StunResult;
using STUN;
using Dns.Net.Clients;
using STUN.Enums;
using System.Net.Http;
using System.Windows;


namespace p2pClientApp
{
    public partial class Form1 : Form
    {

        private static UdpClient udpClient;
        private static IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
        private static readonly IDnsClient _dnsClient = new DefaultDnsClient();
        private static readonly IPEndPoint Any = new(IPAddress.Any, 0);
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnGetPublicAddress_Click(object sender, EventArgs e)
        {
            IPAddress ip = await _dnsClient.QueryAsync(@"stun.hot-chilli.net");
            using IStunClient5389 client = new StunClient5389UDP(new IPEndPoint(ip, StunServer.DefaultPort), Any);

            StunResult5389 response = await client.BindingTestAsync();

            if (response.BindingTestResult != BindingTestResult.Success)
            {
                txtPublicEndPoint.Text = "An error occurred while connecting to STUN server";
                return;
            }

            if (response.MappingBehavior == MappingBehavior.Unknown)
                ;

            if (response.FilteringBehavior == FilteringBehavior.Unknown)
                ;

            txtPublicEndPoint.Text = response.PublicEndPoint.ToString();
            txtLocalEndPoint.Text = response.LocalEndPoint.ToString();
            ;
            txtOtherEndPoint.Text = response.OtherEndPoint.ToString();
            ;

        }

        private async void button1_Click(object sender, EventArgs e)
        {

            IPAddress ip = await _dnsClient.QueryAsync(@"stun.hot-chilli.net");
            using IStunClient5389 client = new StunClient5389TCP(new IPEndPoint(ip, StunServer.DefaultPort), Any);

            StunResult5389 response = await client.BindingTestAsync();


            if (response.BindingTestResult != BindingTestResult.Success)
            {
                txtPublicEndPoint.Text = "An error occurred while connecting to STUN server";
                return;
            }

            if (response.MappingBehavior == MappingBehavior.Unknown)
                ;

            if (response.FilteringBehavior == FilteringBehavior.Unknown)
                ;

            txtPublicEndPoint.Text = response.PublicEndPoint.ToString();
            txtLocalEndPoint.Text = response.LocalEndPoint.ToString();
            ;
            txtOtherEndPoint.Text = response.OtherEndPoint.ToString();
            ;
        }

        private async void btnGetStunServerList_Click(object sender, EventArgs e)
        {
            //"https://raw.githubusercontent.com/pradt2/always-online-stun/master/valid_hosts_tcp.txt";

            txtProgress.Text = txtSTUNServerList.Text = "";
            StunServer stunServer = new();

            var progress = new Progress<string>(message => txtProgress.Text += message + "\r\n");
            string[] validServers = await stunServer.GetSTUNServerListAsync(progress);


            foreach (string host in validServers)
            {
                try
                {
                    txtSTUNServerList.Text += $"{host} \r\n"; //.Append

                    if (!HostnameEndpoint.TryParse(host, out HostnameEndpoint? hostEndpoint, StunServer.DefaultPort))
                    {
                        txtSTUNServerList.Text += "No Host List ??";
                        continue;
                    }


                    //Test here with valid server
                    IPAddress ip = _dnsClient.Query(hostEndpoint.Hostname);
                    using IStunClient5389 client = new StunClient5389UDP(new IPEndPoint(ip, hostEndpoint.Port), null);


                    await client.QueryAsync();
                    //txtSTUNServerList.Text += client.State.MappingBehavior.ToString() + "\r\n";
                    if (client.State.MappingBehavior is MappingBehavior.AddressAndPortDependent or MappingBehavior.AddressDependent or MappingBehavior.EndpointIndependent or MappingBehavior.Direct)
                    {
                        //Valid servers
                        txtSTUNServerList.Text += $"UDP OK: {host} \r\n"; //.Append
                    }
                }
                catch
                {
                    // ignored
                    //txtSTUNServerList.Text += "error..\r\n";
                }
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtSTUNServerList_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnRendevousRegister_Click(object sender, EventArgs e)
        {
            // Register on Rendevous Server

           
            // Get Public IP Address

            // Get Public Port

            // Register on Rendevous Server
            /*
            using HttpClient httpClient = new();
            var content = new FormUrlEncodedContent(new[]
            {
                        new KeyValuePair<string, string>("ip", publicIp),
                        new KeyValuePair<string, string>("port", publicPort.ToString())
            });

            HttpResponseMessage result = await httpClient.PostAsync($"http://{server}/register", content);
            string resultContent = await result.Content.ReadAsStringAsync();

            txtSTUNServerList.Text += $"Registered on {server}: {resultContent}\r\n";

            */
        }

    }
}