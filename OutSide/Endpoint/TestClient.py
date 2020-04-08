# coding: utf8

import socket

HOST = "symp.fr"
PORT = 1072

connexion = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

try:
    connexion.connect((HOST, PORT))
except socket.error:
    print("Connexion error...")
    exit()

print("Connexion successful !")

connexion.send("sendMessage/-/Salut".encode("Utf8"))

print(connexion.recv(1028).decode("Utf8"))
