using Microsoft.EntityFrameworkCore;
using MobileConnection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

namespace MobileConnection.Pages
{
    /// <summary>
    /// Логика взаимодействия для RecoveryPage.xaml
    /// </summary>
    public partial class RecoveryPage : Page
    {
        private static string _key;
        private static string _email;
        private static Client _client;

        ApplicationContext db;
        public RecoveryPage()
        {
            InitializeComponent();
            db = DBConnection.getConnection();
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow win = (AuthorizationWindow) Window.GetWindow(this);
            win.btnBack_Click_Back();
        }

        private void Button_Click_Send_Key(object sender, RoutedEventArgs e)
        {
            _key = GetRandomString();
            _email = "OrexKashtan@gmail.com";
            _client = db.Clients.FirstOrDefault(x => x.Client_Email.Equals(_email));

            if (_client != null)
                SendEmailAsync();
            else
                MessageBox.Show("Вы не регистрированны");
           
        }

        private void Button_Click_LogIn(object sender, RoutedEventArgs e)
        {
            string key = txbKey.Text;
            if (key.Equals(_key))
            {
                AuthorizationWindow win = (AuthorizationWindow)Window.GetWindow(this);

                Private_Client private_Client = db.Private_Clients
                    .Include(x => x.Client)
                    .FirstOrDefault(x => x.Client.ID_Client == _client.ID_Client);

                Corporate_Client corporate_Client = db.Corporate_Clients
                   .Include(x => x.Client)
                   .FirstOrDefault(x => x.Client.ID_Client == _client.ID_Client);

                if (private_Client != null)
                    win.setPage("Pages/PrivateClientPage.xaml");

                if (corporate_Client != null)
                    win.setPage("Pages/CorporateClientPage.xaml");
            }
        }

        private static async Task SendEmailAsync()
        {
            MailAddress from = new MailAddress("OrexKashtan@gmail.com", "Compamy name");
            MailAddress to = new MailAddress(_email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Восстановление доступа к аккаунту";
            m.Body = "Ключ: " + _key;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("OrexKashtan@gmail.com", "HXJ4p65COnfW");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);
            MessageBox.Show("Письмо отправленно");
        }

        public static string GetRandomString()
        {
            string bigString = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890";

            Random rnd = new Random();
            string str = "";

            for (int i = 0; i < 25; i++)
            {
                str += bigString[rnd.Next(0, bigString.Length - 1)];
            }
            return str;
        }
    }
}
