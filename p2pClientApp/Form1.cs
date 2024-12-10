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


namespace p2pClientApp
{
    public partial class Form1 : Form
    {

        private static UdpClient udpClient;
        private static IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
        private static readonly IDnsClient _dnsClient = new DefaultDnsClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetPublicAddress_Click(object sender, EventArgs e)
        {
            IPAddress ip = await _dnsClient.QueryAsync(@"stun.hot-chilli.net");
            using IStunClient5389 client = new StunClient5389UDP(new IPEndPoint(ip, StunServer.DefaultPort), Any);

            StunResult5389 response = await client.BindingTestAsync();

            if (response.BindingTestResult != BindingTestResult.Success)
            {
              //  AnsiConsole.MarkupLine("[bold red]An error occurred while connecting to STUN server[/]");
                return;
            }

            if (response.MappingBehavior == MappingBehavior.Unknown)
                ;

            if (response.FilteringBehavior == FilteringBehavior.Unknown)
                ;

            var PublicEndPoint = response.PublicEndPoint;
            var LocalEndPoint = response.LocalEndPoint;
            var OtherEndPoint = response.OtherEndPoint;

        }
    }
}
