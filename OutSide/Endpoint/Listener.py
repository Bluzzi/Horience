# encoding: utf8
# coding: utf8

import socket
from Connection import Connection


# Server's IP and Port:
HOST = "symp.fr"
PORT = 1073

# Create server listener:
listener = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

# Try to launch the server:
try:
    listener.bind((HOST, PORT))
except socket.error:
    print("Socket server could not be launched.")
    exit()

print("Server has been launched !")

# Define the number of accepted connexion in a specific interval:
listener.listen(20)

# Connexion checker loop:
print("Listen connections...")

while True:
    # Checker loop:
    clientSocket, (ip, port) = listener.accept()

    # Start connexion session:
    Connection(ip, port, clientSocket)
