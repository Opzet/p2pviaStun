# STUN (Simple Transversal of UDP through NATs) p2p - serverless peer to peer communication

The STUN probing process requires a STUN server with a public IP address, and the clients behind the NAT must cooperate with this server to send several UDP packets to each other.

This repository contains 2 apps 

1.  A simple peer messenger app (launched on different pc)
    Communicates with the STUN server (https://raw.githubusercontent.com/pradt2/always-online-stun/master/valid_hosts_tcp.txt), punches an UDP hole inside the other peer's NAT, and starts messaging. 

   

3.  A Simple Server for p2p Register / Rendevous
  Records like a DNS look up of each peer's temporarily public IP address and port number to another peer in group 
