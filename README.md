# DDoS attack protection for the NGINX
This is training project to try most popular DDoS type of attacks to NGINX and set up config in a way to protect an application from attackers.

## Infrastructure
APS.NET Core Application + MySQL as a target application;
NGINX as a proxy server and the layer of our protection;
Docker Compose for containerization;

### Problems that I met
Password didn't set for the root user even if I had passed the MYSQL_ROOT_PASSWORD environment;
Solution: create another user with MYSQL_USER, MYSQL_PASSWORD environments;