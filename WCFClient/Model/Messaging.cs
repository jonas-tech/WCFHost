using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFClient.ViewModel;

namespace WCFClient.Model
{
    public class Messaging
    {
        InstanceContext context;
        Proxy.ServiceClient server;

        string userMessage;
        string fullMessage;
        public ViewModelMessaging viewModelMessageing;

        public Messaging()
        {
            context = new InstanceContext(new ChatClient() { messaging = this} );
            server = new Proxy.ServiceClient(context);
        }

        #region LogIn
        string userName;
        public void LogInAndSaveUserName(string userName)
        {

            this.userName = userName;
            server.ClientLogIntoServer(userName);
        }
        #endregion
        #region SenduserMessage
        public void GetUserMessage(string userMessage)
        {
            this.userMessage = userMessage;
            CreateFullMessage();
        }

        public void CreateFullMessage()
        {
            string dateTime = DateTime.Now.ToString();
            this.fullMessage = dateTime + " von " + userName + " : " + userMessage;
            SendFullMessageToInterfaces();
        }

        public void SendFullMessageToInterfaces()
        {
            server.ServerGetMessageFromClient(fullMessage);
        }
        #endregion
        #region ReceiveMessageFromServer
        public string serverMessage;

        public void PrintMessageInChatRoom(string serverMessage)
        {
            this.serverMessage = serverMessage;
            viewModelMessageing.PrintServerMessageInChatroom();
        }
        #endregion
        #region LogOut
        public void LogOutFromServer()
        {
            server.ClientLogOutOfServer(userName);
            this.userName = null;
        }
        #endregion LogOutCo
    }
}
