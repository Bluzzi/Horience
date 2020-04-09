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
            sender.connect((self.ip, 8211))
        except socket.error:
            if self.ip in connectedIPs:
                print(getDate() + " {0} is disconnected".format(self.ip))
                connectedIPs.remove(self.ip)

            return

        sender.send(self.message.encode("utf-8"))
        sender.close()
