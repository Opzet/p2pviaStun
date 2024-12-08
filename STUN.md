## STUN: NAT type detection method
STUN (Simple Transversal of UDP through NATs) [21] is a NAT traversal method specified by RFC3489 that uses an auxiliary method to detect the IP and port of the NAT.

The STUN probing process requires a STUN server with a public IP address, and the clients behind the NAT must cooperate with this server to send several UDP packets to each other.

The UDP package contains information that the client needs to know, such as NAT, public IP, port, etc. The client determines its NAT type by whether it gets the UDP packet and the data in the packet.

Prerequisites: There is a public server and two public IP addresses (IP1 and IP2) are bound. This server does UDP snooping (IP1, Port1), (IP2, Port2) and responds according to the client's requirements.

![image](https://github.com/user-attachments/assets/25631738-b3a2-42cf-8d3e-e16d9e901a72)








 

### Step 1: 
Detect if the client has the ability to communicate UDP and if the client is behind the NAT. The client creates a UDP socket and uses this socket to send the server's (IP1, Port1)

Sending packets requires the server to return the client's IP and Port, and the client starts accepting packets immediately after sending the request, and the socketTimeout (300ms) is set to prevent infinite blockages, and repeats this process several times.

If the server cannot receive a response every time, the client is unable to communicate with UDP, or the firewall or NAT may be blocking UDP communication, and the client cannot establish a P2P connection.

When the client can receive the response from the server, it needs to compare the client (IP, Port) returned by the server with the socket (LocalIP, LocalPort) of the client.

If the client is identical, the client is not behind the NAT, and the client has a public IP address that can directly listen to the UDP port to receive data for communication (detection stops).

Otherwise, the client needs to do further NAT type detection after NAT (detection continues).

![image](https://github.com/user-attachments/assets/112c8e8b-4411-40c0-8b93-15264462990d)

### Step 2:
Check if the client NAT is Full Cone NAT. The client establishes a UDP socket and then uses that socket to send packets to the server (IP1, Port 1).

Ask the server to send a packet back with another pair (IP2, Port2) in response to the client's request, and the client will start accepting the packet immediately after sending the request, and set the socket timeout (300ms) to prevent infinite congestion. Repeat this process several times.

If the server cannot receive a response every time, the client's NAT is not a Full Cone NAT, and the specific type needs to be detected in the next step.

If the client is able to receive a reply UDP packet from (IP2, Port2), then the client is a Full Cone NAT, and the client is able to communicate UDP-P2P and detect the stop.


### Step 3: 
Check if the client NAT is Symmetric NAT. The client establishes a UDP socket and then uses this socket to send packets to the server (IP1, Port1) and asks the server to return the client's IP and Port.

Since the first step ensures that the client can communicate with UDP, then the returned data will definitely be obtained.

In the same way, a packet is sent to the server (IP2, Port2) with a socket and the server is asked to return the client's IP and Port.

Compare the client (IP, Port) returned by the above two procedures from the server, if there is a different pair of (IP, Port) returned by the two procedures, then the client is Symmetric NAT,

Such a client cannot communicate with UDP-P2P. Otherwise, it is a Restricted Cone NAT, and whether it is a Port Restricted Cone NAT remains to be detected.
![image](https://github.com/user-attachments/assets/b32c9a6b-807f-4f5a-896c-6f9e1cbc5ee5)

 

### Step 4: 
Detect if the client NAT is a Restricted Cone NAT or a Port Restricted ConeNAT.

The client establishes a UDP socket and then uses this socket to send a packet to the server (IP1, Port1) and asks the server to send a UDP packet with IP1 and a port different from Port1 to respond to the client.

The client starts accepting packets as soon as the request is sent, and the socket timeout (300ms) should be set to prevent infinite congestion. Repeat this process several times.

If the server cannot receive a response every time, the client is a Port Restricted Cone NAT, and if it can receive a response from the server, the client is a Restricted Cone NAT.

Both types of NAT are capable of UDP-P2P communication.

Note: The above detection process only explains whether UDP-P2P hole-making communication can be carried out, and the specific communication generally requires the help of another intermediate server.

In addition, for Symmetric NAT, it does not mean that UDP-P2P tunneling communication cannot be carried out at all, and port prediction tunneling can be performed, but there is no guarantee of success.


![image](https://github.com/user-attachments/assets/aec812d2-1758-47ff-94f9-9315dd248054)

 https://www.junyi.dev/posts/rfc5389-stun/

https://www.cnblogs.com/shangdawei/p/3701864.html

 



 

 
