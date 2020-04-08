# encoding: utf-8

import threading
import socket

from Api import getDate
from Variables import *


class MessageSender(threading.Thread):

    def __init__(self, ip, message):
        self.ip = ip
        self.message = message

        threading.Thread.__init__(self)
        self.start()

    """
    Send the message
    """
    def run(self):
        sender = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

        try:
            sender.connect((self.ip, 1070))
        except socket.error:
            if self.ip in connectedIPs:
                print(getDate() + " {0} is disconnected".format(self.ip))
                connectedIPs.remove(self.ip)

        print(sender.recv(2000).decode("Utf8"))
        sender.send(self.message.encode("Utf8"))
        sender.close()
