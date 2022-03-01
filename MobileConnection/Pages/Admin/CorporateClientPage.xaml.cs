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

namespace MobileConnection.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для CorporateClientPage.xaml
    /// </summary>
    public partial class CorporateClientPage : Page
    {
        ApplicationContext db;
        public ObservableCollection<Corporate_Client> Corporate_Clients { get; set; }

        public List<Client> Clients { get; set; }

        public CorporateClientPage()
        {
            InitializeComponent();

            db = DBConnection.getConnection();

            Corporate_Clients = new(db.Corporate_Clients
                .Include(x => x.Client)
                .ToList());
            Clients = new(db.Clients.ToList());

            dtg.ItemsSource = Corporate_Clients;
            cmbClients.ItemsSource = Clients;
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            AdminHomeWindow win = (AdminHomeWindow)Window.GetWindow(this);
            win.btnBack_Click_Back();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            Client client = cmbClients.SelectedItem as Client;

            Corporate_Client corporate_Client = new Corporate_Client
            {
                Company_Name = txbCompany_Name.Text,
                INN = txbINN.Text,
                Legal_Adsress = txbLegal_Adsress.Text,
                Physical_Adsress = txbPhysical_Adsress.Text,
                Personal_Account_Number = txbPersonal_Account_Number.Text,
                Client = db.Clients.FirstOrDefault(x => x.ID_Client == client.ID_Client),
            };


            Corporate_Clients.Add(corporate_Client);
            db.Corporate_Clients.Add(corporate_Client);
            db.SaveChanges();
            clearRows();
        }
    
        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            Corporate_Client corporate_Client = Corporate_Clients[dtg.SelectedIndex];
            if (corporate_Client != null)
            {
                Client client = cmbClients.SelectedItem as Client;


                corporate_Client = new Corporate_Client
                {
                    Company_Name = txbCompany_Name.Text,
                    INN = txbINN.Text,
                    Legal_Adsress = txbLegal_Adsress.Text,
                    Physical_Adsress = txbPhysical_Adsress.Text,
                    Personal_Account_Number = txbPersonal_Account_Number.Text,
                    Client = db.Clients.FirstOrDefault(x => x.ID_Client == client.ID_Client),
                };

                db.Corporate_Clients.Update(corporate_Client);
                db.SaveChanges();
                clearRows();
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            Corporate_Client corporate_Client = Corporate_Clients[dtg.SelectedIndex];
            if (corporate_Client != null)
            {
                Corporate_Clients.Remove(corporate_Client);
                db.Corporate_Clients.Remove(corporate_Client);
                db.SaveChanges();
            }
        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            Corporate_Client corporate_Client = e.Row.Item as Corporate_Client;

            if (corporate_Client != null)
            {
                db.Corporate_Clients.Update(corporate_Client);
                db.SaveChanges();
            }
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            string search = txbSearch.Text;
            if (search == null)
            {
                Corporate_Clients = new(db.Corporate_Clients
                     .Include(x => x.Client)
                     .ToList());
                dtg.ItemsSource = Corporate_Clients;
                return;
            }
            Corporate_Clients = new(db.Corporate_Clients
                .Include(x => x.Client)
                .Where(
                x => x.INN.Contains(search)
                || x.Client.Account_Number.Contains(search)
                || x.Personal_Account_Number.Contains(search)
                || x.Legal_Adsress.Contains(search)
                || x.Physical_Adsress.Contains(search))
                .ToList());
            dtg.ItemsSource = Corporate_Clients;
        }


        public void clearRows()
        {
            txbCompany_Name.Text = "";
            txbINN.Text = "";
            txbLegal_Adsress.Text = "";
            txbPhysical_Adsress.Text = "";
            txbPersonal_Account_Number.Text = "";
            cmbClients.SelectedItem = null;
        }
    }
}
