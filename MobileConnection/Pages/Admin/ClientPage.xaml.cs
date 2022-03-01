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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {

        ApplicationContext db;
        public ObservableCollection<Client> Clients { get; set; }
        public ClientPage()
        {
            InitializeComponent();

            db = DBConnection.getConnection();

            Clients = new(db.Clients.ToList());
            dtg.ItemsSource = Clients;
        }

        private void Button_Click_SetPage(object sender, RoutedEventArgs e)
        {
            AdminHomeWindow win = (AdminHomeWindow)Window.GetWindow(this);
            win.setPage((sender as Button).Tag.ToString());
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            AdminHomeWindow win = (AdminHomeWindow)Window.GetWindow(this);
            win.btnBack_Click_Back();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {

            Client client = new Client
            {
                Account_Number = txbAccount_Number.Text,
                Client_Email = txbClient_Email.Text,
                Client_Password = txbClient_Password.Password,
                Contract_Conclusion_Date = DateOnly.Parse(txbContract_Conclusion_Date.Text),
                Phone_Number = txbPhone_Number.Text,
                Tariff_Cost = Decimal.Parse(txbTariff_Cost.Text),
                Contract_Number = Convert.ToInt32(txbContract_Number.Text),
            };

            Clients.Add(client);
            db.Clients.Add(client);
            db.SaveChanges();
            clearRows();
        }

    


        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            Client client = Clients[dtg.SelectedIndex];
            if (client != null)
            {
                client = new Client
                {
                    Account_Number = txbAccount_Number.Text,
                    Client_Email = txbClient_Email.Text,
                    Client_Password = txbClient_Password.Password,
                    Contract_Conclusion_Date = DateOnly.Parse(txbContract_Conclusion_Date.Text),
                    Phone_Number = txbPhone_Number.Text,
                    Tariff_Cost = Decimal.Parse(txbTariff_Cost.Text),
                    Contract_Number = Convert.ToInt32(txbContract_Number.Text),
                };

                db.Clients.Update(client);
                db.SaveChanges();
                clearRows();
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            Client client = Clients[dtg.SelectedIndex];
            if (client != null)
            {
                Clients.Remove(client);
                db.Clients.Remove(client);
                db.SaveChanges();
            }
        }


        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            Client client = e.Row.Item as Client;


            if (client != null)
            {
                db.Clients.Update(client);
                db.SaveChanges();
            }
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            string search = txbSearch.Text;
            if (search == null)
            {
                Clients = new(db.Clients.ToList());
                dtg.ItemsSource = Clients;
                return;
            }
            Clients = new(db.Clients
                .Where(
                x => x.Account_Number.Contains(search)
                || x.Client_Email.Contains(search)
                || x.Contract_Number.ToString().Contains(search))
                .ToList());
            dtg.ItemsSource = Clients;
        }



        public void clearRows()
        {
            txbAccount_Number.Text = "";
            txbClient_Email.Text = "";
            txbClient_Password.Password = "";
            txbContract_Conclusion_Date.Text = "";
            txbPhone_Number.Text = "";
            txbTariff_Cost.Text = "";
            txbContract_Number.Text = "";
        }
    }
}
