import threading
from Messages import messages


class Connection(threading.Thread):

    def __init__(self, ip, port, clientSocket):
        self.ip = ip
        self.port = port
        self.clientSocket = clientSocket

        threading.Thread.__init__(self)
        self.start()

    def run(self):
        # Check message received:
        msg = self.clientSocket.recv(4000).decode("Utf8")
        data = msg.split(":!")

        # Data manager:
        if len(data) == 2:
            if data[0] == "send":
                print("{0}:{1} -> Message receive and saved : {2}".format(self.ip, self.port, data[1]))

                messages.append(data[1])

                if len(messages) > 100:
                    messages.pop(0)
        elif len(data) == 1:
            if data[0] == "messages":
                print("{0}:{1} -> The message list has been sent".format(self.ip, self.port))

                self.clientSocket.send(":!".join(messages).encode("Utf8"))

        # Close the connexion:
        self.clientSocket.close()
