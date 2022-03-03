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

        private static Corporate_Client _saveCorporate_Client;

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
            try
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

                if (ApplicationContext.validData(client) && ApplicationContext.validData(corporate_Client))
                {
                    Corporate_Clients.Add(corporate_Client);
                    db.Corporate_Clients.Add(corporate_Client);
                    db.SaveChanges();
                    clearRows();
                }
            }
            catch (Exception ex) { }
        }
    
        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            try
            {
                Corporate_Client corporate_Client = Corporate_Clients[dtg.SelectedIndex];
                if (corporate_Client != null)
                {
                    Client client = cmbClients.SelectedItem as Client;

                    corporate_Client.Company_Name = txbCompany_Name.Text;
                    corporate_Client.INN = txbINN.Text;
                    corporate_Client.Legal_Adsress = txbLegal_Adsress.Text;
                    corporate_Client.Physical_Adsress = txbPhysical_Adsress.Text;
                    corporate_Client.Personal_Account_Number = txbPersonal_Account_Number.Text;
                    corporate_Client.Client = db.Clients.FirstOrDefault(x => x.ID_Client == client.ID_Client);


                    if (ApplicationContext.validData(client) && ApplicationContext.validData(corporate_Client))
                    {
                        db.Corporate_Clients.Update(corporate_Client);
                        db.SaveChanges();
                        clearRows();

                        Corporate_Clients = new(db.Corporate_Clients
                            .Include(x => x.Client)
                            .ToList());
                        dtg.ItemsSource = Corporate_Clients;
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                Corporate_Client corporate_Client = Corporate_Clients[dtg.SelectedIndex];
                if (corporate_Client != null)
                {
                    Corporate_Clients.Remove(corporate_Client);
                    db.Corporate_Clients.Remove(corporate_Client);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                Corporate_Client corporate_Client = e.Row.Item as Corporate_Client;

                if (corporate_Client != null)
                {
                    if (ApplicationContext.validData(corporate_Client.Client)
                        && ApplicationContext.validData(corporate_Client))
                    {
                        db.Corporate_Clients.Update(corporate_Client);
                        db.SaveChanges();
                    }
                    else
                    {
                        corporate_Client.Company_Name = _saveCorporate_Client.Company_Name;
                        corporate_Client.INN = _saveCorporate_Client.Company_Name;
                        corporate_Client.Legal_Adsress = _saveCorporate_Client.Company_Name;
                        corporate_Client.Physical_Adsress = _saveCorporate_Client.Company_Name;
                        corporate_Client.Personal_Account_Number = _saveCorporate_Client.Company_Name;
                        corporate_Client.Client.Account_Number = _saveCorporate_Client.Client.Account_Number;
                    }
                }
            }
            catch (Exception ex) { }
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

        private void dtg_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var item = Corporate_Clients[dtg.SelectedIndex];
                _saveCorporate_Client = new Corporate_Client(item);
                setData(item);
            }
            catch (Exception ex) { }
        }

        public void setData(Corporate_Client client)
        {
            txbCompany_Name.Text = client.Company_Name;
            txbINN.Text = client.INN;
            txbLegal_Adsress.Text = client.Legal_Adsress;
            txbPhysical_Adsress.Text = client.Physical_Adsress;
            txbPersonal_Account_Number.Text = client.Personal_Account_Number;
            cmbClients.SelectedItem = client.Client;
        }
    }
}
