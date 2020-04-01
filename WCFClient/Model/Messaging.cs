using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WCFClient.ViewModel;

namespace WCFClient.Model
{
    public class Messaging
    {
        readonly InstanceContext context;
        readonly Proxy.ServiceClient server;

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
            try
            {
                this.userName = userName;
                server.ClientLogIntoServer(userName);
            }
            catch (System.ServiceModel.Security.SecurityNegotiationException)
            {
                var result = MessageBox.Show("Der Server hat den Zugriff nicht gestattet.\nStarte diesen gegebenfalls erneutmit Administratorrechten. \nErneut versuchen ?","Exit",MessageBoxButton.YesNo);
                if(result == MessageBoxResult.Yes)
                {
                    LogInAndSaveUserName(userName);
                }
                else
                {
                    System.Windows.Application.Current.Shutdown();
                }            
            }
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
            var date = DateTime.Now;
            string hm = date.Hour + ":" + date.Minute;
            this.fullMessage = hm + " von " + userName + " : " + userMessage;
            SendFullMessageToInterfaces();
        }

        public void SendFullMessageToInterfaces()
        {
            try
            {
                server.ServerGetMessageFromClient(fullMessage);
            }
            catch (System.ServiceModel.CommunicationObjectFaultedException)
            {

                var result = MessageBox.Show("Es konnte nicht mit dem Service kommuniziert werden, evtl ist dieser in ein TimeOut gelaufen \n Erneut versuchen ?", "", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                server.ServerGetMessageFromClient(fullMessage);

                }
                else
                {
                    System.Windows.Application.Current.Shutdown();
                }
            }
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
            try
            {
                server.ClientLogOutOfServer(userName);
                this.userName = null;
            }
            catch (System.ServiceModel.CommunicationObjectFaultedException)
            {
                
                var result = MessageBox.Show("Es konnte nicht mit dem Service kommuniziert werden, weil diser sich  im Faulted-Status befindet.\n Erneut versuchen ?","",MessageBoxButton.YesNo);
                if(result == MessageBoxResult.Yes)
                {
                    LogOutFromServer();
                }
                else
                {
                    System.Windows.Application.Current.Shutdown();
                }
            }
        }
        #endregion LogOutCo
    }
}
