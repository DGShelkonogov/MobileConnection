using Microsoft.EntityFrameworkCore;
using MobileConnection.Models;
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

namespace MobileConnection.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        ApplicationContext db;
        public AuthorizationPage()
        {
            InitializeComponent();
            db = DBConnection.getConnection();
        }

        private void Button_Click_LogIn(object sender, RoutedEventArgs e)
        {
            string email = txbEmail.Text; 
            string password = txbPassword.Password;
            AuthorizationWindow win = (AuthorizationWindow)Window.GetWindow(this);

            if (email.Equals("admin") && password.Equals("admin"))
            {
                AdminHomeWindow adminHome = new AdminHomeWindow();
                adminHome.Show();
                win.Close();
                return;
            }


            Client client = db.Clients.FirstOrDefault(x => x.Client_Email.Equals(email)
                && x.Client_Password.Equals(password));
            if(client == null)
            {
                MessageBox.Show("Invalid email or password");
                return;
            }

            Private_Client private_Client = db.Private_Clients
                .Include(x => x.Client)
                .FirstOrDefault(x => x.Client.ID_Client == client.ID_Client);

         

            Corporate_Client corporate_Client = db.Corporate_Clients
               .Include(x => x.Client)
               .FirstOrDefault(x => x.Client.ID_Client == client.ID_Client);

            if (private_Client != null)
                win.openPrivateClient(private_Client.ID_Private_Client);

            if (corporate_Client != null)
                win.openCorporateClient(corporate_Client.ID_Corporate_Client);
        }

        private void Button_Click_RecoveryPassword(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow win = (AuthorizationWindow)Window.GetWindow(this);
            win.setPage("Pages/RecoveryPage.xaml");
        }
    }
}
