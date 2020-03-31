using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IService
    {
        Dictionary<IServiceClient, string> clientUsernames = new Dictionary<IServiceClient, string>();

        string clientMessagecontent = "";

        public void ClientLogIntoServer(string userName)
        {
            IServiceClient clientConnection = OperationContext.Current.GetCallbackChannel<IServiceClient>();

            clientUsernames[clientConnection] = userName;
        }

        public string ServerSendMessageToClient()
        {
            return clientMessagecontent;
        }

        public void ServerGetMessageFromClient(string clientMessage)
        {
            IsClientMessageNull(clientMessage);

            IServiceClient clientConnection = OperationContext.Current.GetCallbackChannel<IServiceClient>();

            foreach (IServiceClient otherClients in clientUsernames.Keys)
            {
                //if (otherClients == clientConnection)
                //{
                //    continue;

                //}
                otherClients.ServerSendMessageToClient(clientMessage);
            }
        }

        public void ClientLogOutOfServer(string userName)
        {
            IServiceClient clientConnection = OperationContext.Current.GetCallbackChannel<IServiceClient>();

            clientUsernames.Remove(clientConnection);
        }

        private void IsClientMessageNull(string clientMessage)
        {
            if (clientMessage == null)
            {
                return;
            }
            else
            {
                ServerSendMessageToClient();
            }
        }
    }

