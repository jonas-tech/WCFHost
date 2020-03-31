using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WCFClient.ViewModel;

namespace WCFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly ViewModelMessaging viewModel;

        public MainWindow()
        {
            this.InitializeComponent();
            viewModel = new ViewModelMessaging { window = this };
        }


        private void LogOffButton_Click(object sender, RoutedEventArgs e)
        {
            LogINScreen.Visibility = Visibility.Visible;
            Chatroom.Visibility = Visibility.Hidden;
            viewModel.LogOut();
        }
        public void PrintMessage()
        {
            string Zeilenumbruch = "\n";
            ChatroomTextBlock.Text = viewModel.ReturnServerMessageInViewModel() + Zeilenumbruch + ChatroomTextBlock.Text;
        }
        private void SendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }
        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            LoginIn();
        }

        private void LogInButton_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                LoginIn();
            }
        }

        private void LoginIn()
        {
            viewModel.LogIn(UserNameTextBox.Text);
            LogINScreen.Visibility = Visibility.Hidden;
            Chatroom.Visibility = Visibility.Visible;
            SendMessageTextBox.Focus();
        }

        private void SendMessage()
        {
            string userMessage;
            userMessage = SendMessageTextBox.Text;
            SendMessageTextBox.Text = "";
            viewModel.SendMessage(userMessage);
        }

        private void SendMessageButton_KeyDown(object sender, KeyEventArgs e)
        {
            SendMessage();
        }
    }
}
