# coding: utf8

import socket

HOST = "symp.fr"
PORT = 1093

connexion = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

try:
    connexion.connect((HOST, PORT))
except socket.error:
    print("Connexion error...")
    exit()

print("Connexion successful !")

#connexion.send("sendMessage/¤/faction/¤/Bluzzi/¤/Nan sérieux il est vraiment nul !!".encode("utf8"))
connexion.send("getMessage/¤/19132".encode("utf8"))

print(connexion.recv(1028).decode("utf8"))
