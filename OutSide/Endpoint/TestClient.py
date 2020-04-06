import socket

HOST = "symp.fr"
PORT = 1072

connexion = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

try:
    connexion.connect((HOST, PORT))
except socket.error:
    print("Connection error...")
    exit()

print("Connection successful !")

connexion.send("messages".encode("Utf8"))

print(connexion.recv(2000).decode("Utf8"))