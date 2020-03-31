using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFClient.Model
{
    public class ChatClient : Proxy.IServiceCallback
    {
        public Messaging messaging;

        public void ServerSendMessageToClient(string serverMessage)
        {
            messaging.PrintMessageInChatRoom(serverMessage);
        }
    }
}
