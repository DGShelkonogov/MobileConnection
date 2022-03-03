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
    /// Логика взаимодействия для PrivateClientPage.xaml
    /// </summary>
    public partial class PrivateClientPage : Page
    {
        ApplicationContext db;
        public ObservableCollection<Private_Client> Private_Clients { get; set; }

        public List<Client> Clients { get; set; }

        private static Private_Client _savePrivate_Client;

        public PrivateClientPage()
        {
            InitializeComponent();

            db = DBConnection.getConnection();

            Private_Clients = new(db.Private_Clients
                .Include(x => x.Client)
                .ToList());
            dtg.ItemsSource = Private_Clients;
            
            Clients = new(db.Clients.ToList());
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

                Private_Client private_Client = new Private_Client
                {
                    Client_Surname = txbClient_Surname.Text,
                    Client_Name = txbClient_Name.Text,
                    Client_Patronymic = txbClient_Patronymic.Text,
                    Adsress = txbAdsress.Text,
                    Passport_Series = Convert.ToInt32(txbPassport_Series.Text),
                    Passport_Number = Convert.ToInt32(txbPassport_Number.Text),
                    Date_Of_Birth = DateOnly.Parse(txbDate_Of_Birth.Text),
                    Client = db.Clients.FirstOrDefault(x => x.ID_Client == client.ID_Client),
                };

                if (ApplicationContext.validData(client) && ApplicationContext.validData(private_Client))
                {
                    Private_Clients.Add(private_Client);
                    db.Private_Clients.Add(private_Client);
                    db.SaveChanges();
                    clearRows();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            try
            {
                Private_Client private_Client = Private_Clients[dtg.SelectedIndex];

                if (private_Client != null)
                {
                    Client client = cmbClients.SelectedItem as Client;

                    private_Client.Client_Surname = txbClient_Surname.Text;
                    private_Client.Client_Name = txbClient_Name.Text;
                    private_Client.Client_Patronymic = txbClient_Patronymic.Text;
                    private_Client.Adsress = txbAdsress.Text;
                    private_Client.Passport_Series = Convert.ToInt32(txbPassport_Series.Text);
                    private_Client.Passport_Number = Convert.ToInt32(txbPassport_Number.Text);
                    private_Client.Date_Of_Birth = DateOnly.Parse(txbDate_Of_Birth.Text);
                    private_Client.Client = db.Clients.FirstOrDefault(x => x.ID_Client == client.ID_Client);

                    if (ApplicationContext.validData(client) && ApplicationContext.validData(private_Client))
                    {
                        db.Private_Clients.Update(private_Client);
                        db.SaveChanges();
                        clearRows();

                        Private_Clients = new(db.Private_Clients
                            .Include(x => x.Client)
                            .ToList());
                        dtg.ItemsSource = Private_Clients;
                    }
                    else
                    {
                        private_Client.Client.Account_Number = _savePrivate_Client.Client.Account_Number;
                        private_Client.Client_Surname = _savePrivate_Client.Client_Surname;
                        private_Client.Client_Name = _savePrivate_Client.Client_Name;
                        private_Client.Client_Patronymic = _savePrivate_Client.Client_Patronymic;
                        private_Client.Adsress = _savePrivate_Client.Adsress;
                        private_Client.Passport_Series = _savePrivate_Client.Passport_Series;
                        private_Client.Passport_Number = _savePrivate_Client.Passport_Number;
                        private_Client.Date_Of_Birth = _savePrivate_Client.Date_Of_Birth;
                    }
                }
            }
            catch (Exception ex){}
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                Private_Client private_Client = Private_Clients[dtg.SelectedIndex];

                if (private_Client != null)
                {
                    Private_Clients.Remove(private_Client);
                    db.Private_Clients.Remove(private_Client);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                Private_Client private_Client = e.Row.Item as Private_Client;

                if (private_Client != null)
                {
                    if (ApplicationContext.validData(private_Client.Client) && ApplicationContext.validData(private_Client))
                    {
                        db.Private_Clients.Update(private_Client);
                        db.SaveChanges();
                    }
                    else
                    {
                        private_Client.Client.Account_Number = _savePrivate_Client.Client.Account_Number;
                        private_Client.Client_Surname = _savePrivate_Client.Client_Surname;
                        private_Client.Client_Name = _savePrivate_Client.Client_Name;
                        private_Client.Client_Patronymic = _savePrivate_Client.Client_Patronymic;
                        private_Client.Adsress = _savePrivate_Client.Adsress;
                        private_Client.Passport_Series = _savePrivate_Client.Passport_Series;
                        private_Client.Passport_Number = _savePrivate_Client.Passport_Number;
                        private_Client.Date_Of_Birth = _savePrivate_Client.Date_Of_Birth;
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
                Private_Clients = new(db.Private_Clients
                     .Include(x => x.Client)
                     .ToList());
                dtg.ItemsSource = Private_Clients;
                return;
            }
            Private_Clients = new(db.Private_Clients
                .Include(x => x.Client)
                .Where(
                x => x.Adsress.Contains(search)
                || x.Client.Account_Number.Contains(search)
                || x.Client_Name.Contains(search)
                || x.Client_Surname.Contains(search)
                || x.Client_Patronymic.Contains(search))
                .ToList());
            dtg.ItemsSource = Private_Clients;
        }

        public void clearRows()
        {
            txbClient_Surname.Text = "";
            txbClient_Name.Text = "";
            txbClient_Patronymic.Text = "";
            txbAdsress.Text = "";
            txbPassport_Series.Text = "";
            txbPassport_Number.Text = "";
            txbDate_Of_Birth.Text = "";
            cmbClients.SelectedItem = null;
        }


        private void dtg_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var item = Private_Clients[dtg.SelectedIndex];
                _savePrivate_Client = new Private_Client(item);
                setData(item);
            }
            catch (Exception ex) { }
        }

        public void setData(Private_Client client)
        {
            txbClient_Surname.Text = client.Client_Surname;
            txbClient_Name.Text = client.Client_Name;
            txbClient_Patronymic.Text = client.Client_Patronymic;
            txbAdsress.Text = client.Adsress;
            txbPassport_Series.Text = client.Passport_Series.ToString();
            txbPassport_Number.Text = client.Passport_Number.ToString();
            txbDate_Of_Birth.Text = client.Date_Of_Birth.ToString();
            cmbClients.SelectedItem = client.Client;
        }
    }
}
