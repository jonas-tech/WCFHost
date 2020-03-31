using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFClient.Model;

namespace WCFClient.ViewModel
{
    public class ViewModelMessaging
    {
        public Messaging messaging;
        public MainWindow window;
        public ViewModelMessaging()
        {
            messaging = new Messaging { viewModelMessageing = this };
        }
        #region LogIn
        public void LogIn(string userName)
        {
            messaging.LogInAndSaveUserName(userName);
        }
        #endregion
        #region SendMessage
        public void SendMessage(string userMessage)
        {
            messaging.GetUserMessage(userMessage);
        }
        #endregion
        #region ReceiveMessage
        string Message = "";
        public void PrintServerMessageInChatroom()
        {
            this.Message = messaging.serverMessage;
            window.PrintMessage();
        }

        public string ReturnServerMessageInViewModel()
        {
            return Message;
        }
        #endregion
        #region LogOut
        public void LogOut()
        {
            messaging.LogOutFromServer();
        }

        #endregion
    }
}
