using MobileConnection.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
using System.Windows.Shapes;


namespace MobileConnection
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
            setPage("Pages/AuthorizationPage.xaml");
        }


        public void setPage(string tag)
        {
            Frame.Source = new Uri(tag, UriKind.Relative);
        }


        public void openPrivateClient(int id)
        {
            PrivateClientPage page = new PrivateClientPage(id);
            Frame.Navigate(page);
        }


        public void openCorporateClient(int id)
        {
            CorporateClientPage page = new CorporateClientPage(id);
            Frame.Navigate(page);
        }


        public void openService(int id)
        {
            ServicePage page = new ServicePage(id);
            Frame.Navigate(page);
        }


        /// <summary>
        /// возврат на предыдушю страницу
        /// </summary>
        public void btnBack_Click_Back()
        {
            try
            {
                Frame.GoBack();
            }
            catch (Exception ex)
            {

            }
        }

      
    }
}
