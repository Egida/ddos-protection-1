# DDoS attack protection for the NGINX
This is training project to try most popular DDoS type of attacks to NGINX and set up config in a way to protect an application from attackers.

## Infrastructure
APS.NET Core Application + MySQL as a target application;
NGINX as a proxy server and the layer of our protection;
Docker Compose for containerization;

### Problems that I met
Password didn't set for the root user even if I had passed the MYSQL_ROOT_PASSWORD environment;
Solution: create another user with MYSQL_USER, MYSQL_PASSWORD environments;

## DDoS
# HTTP Flood
HTTP floods are designed to overwhelm web servers’ resources by continuously requesting single or multiple URL’s from many source attacking machines, which simulate a HTTP clients

Command: `docker run utkudarilmaz/hping3:latest --rand-source --flood localhost -p 8080`

After, the DDoS started, the metrics like db cpu, and network input for app and nginx were increased.
712770 packets transmitted, 712690 packets received, 1% packet loss