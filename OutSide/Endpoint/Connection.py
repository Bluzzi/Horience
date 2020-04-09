# encoding: utf-8

import threading

from Api import getDate
from MessageSender import MessageSender
from Variables import *

SEPARATOR = "/-/"


class Connection(threading.Thread):

    def __init__(self, ip, port, clientSocket):
        self.ip = ip
        self.port = port
        self.clientSocket = clientSocket

        threading.Thread.__init__(self)
        self.start()

    """
    Receive and treat the socket:
    """
    def run(self):
        # Check message received:
        msg = self.clientSocket.recv(4000).decode("utf-8")

        # Manage data:
        self.dataManager(msg)

        # Close the connexion:
        self.clientSocket.close()

    """
    Decode the request and executes the methods in consequence.
    """
    def dataManager(self, data):
        if SEPARATOR not in data:
            return

        data = data.split(SEPARATOR)

        if data[0] == "connect":
            self.connect()
        elif data[0] == "sendMessage":
            self.sendMessage(data[1])
        elif data[0] == "getMessages":
            self.getMessages()

    """
    Register IP of client and send the message history.
    """
    def connect(self):
        print(getDate() + " {0}:{1} is connected, the message list has been sent".format(self.ip, self.port))

        self.clientSocket.send(SEPARATOR.join(messagesHistory).encode("utf-8"))

        if self.ip not in connectedIPs:
            connectedIPs[self.ip] = []

    """
    Save the message and save it to all connected clients data.
    """
    def sendMessage(self, message):
        # Check if the client is connected:
        if self.ip not in connectedIPs:
            self.clientSocket.send("Error: Your client is not connected".encode("utf-8"))
            return

        # Log message:
        print(getDate() + " {0}:{1} send message \"{2}\", this message is saved in {3} connected clients data"
              .format(self.ip, self.port, message, len(connectedIPs)))

        # Add message and clear message history if it is more than 100:
        messagesHistory.append(message)

        if len(messagesHistory) > 100:
            messagesHistory.pop(0)

        # Send the message to all connected clients and remove disconnected clients:
        for clientIP in connectedIPs:
            connectedIPs[clientIP].append(message)

    """
    Send new messages received by the server to the client.
    """
    def getMessages(self):
        # Check if the client is connected:
        if self.ip not in connectedIPs:
            self.clientSocket.send("Error: Your client is not connected".encode("utf-8"))
            return

        # Send messages list and remove it in server data:
        # print(getDate() + " {0}:{1} asks for the list of messages, it was sent to her".format(self.ip, self.port))

        self.clientSocket.send(SEPARATOR.join(connectedIPs[self.ip]).encode("utf-8"))
        connectedIPs[self.ip] = []
