using Microsoft.EntityFrameworkCore;
using MobileConnection.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        public ObservableCollection<Service> Services { get; set; }


        ApplicationContext db;
        private static Client client;
        private static Private_Client private_Client;
        private static Corporate_Client corporate_Client;


        public ServicePage(int? id)
        {
            InitializeComponent();

            db = DBConnection.getConnection();


            client = db.Clients.FirstOrDefault(x => x.ID_Client == id);

            private_Client = db.Private_Clients
                .Include(x => x.Client)
                .FirstOrDefault(x => x.Client.ID_Client == id);

             corporate_Client = db.Corporate_Clients
              .Include(x => x.Client)
              .FirstOrDefault(x => x.Client.ID_Client == id);

               
       
            Services = new(db.Services.ToList());
            dtg.ItemsSource = Services;
            cmbServices.ItemsSource = Services;
        }


        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            try
            {
                AuthorizationWindow win = (AuthorizationWindow)Window.GetWindow(this);

                if (private_Client != null)
                    win.openPrivateClient(private_Client.ID_Private_Client);
                else
                    win.openCorporateClient(corporate_Client.ID_Corporate_Client);
            }
            catch (Exception ex) { }
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                Service service = cmbServices.SelectedItem as Service;
                if (service != null)
                {
                    if (!client.Services.Contains(service))
                    {
                        client.Services.Add(service);
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("У вас уже есть выбранный сервис");
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                Service service = cmbServices.SelectedItem as Service;
                if (service != null)
                {
                    if (client.Services.Contains(service))
                    {
                        client.Services.Remove(service);
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("У вас нет такого сервиса");
                    }
                }
            }
            catch(Exception ex) { }
        }

        private void cmbServices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Service service = cmbServices.SelectedItem as Service;
            if (service != null)
                lblAmount.Content = service.Cost.ToString();
        }
    }
}
