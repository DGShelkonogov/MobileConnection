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

        private static Client _saveClient;

        /// <summary>
        /// Импорт данных из БД, заполнение DataGrid
        /// </summary>
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
            try
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

                 if (ApplicationContext.validData(client))
                 {
                    if (ApplicationContext.checkEmail(client.Client_Email))
                    {
                        Clients.Add(client);
                        db.Clients.Add(client);
                        db.SaveChanges();
                        clearRows();
                    }
                    else
                        MessageBox.Show("Почта занята");
                 }
            }
            catch (Exception we) { }
        }
        

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            try
            {
                Client client = Clients[dtg.SelectedIndex];
                if (client != null)
                {
                    client.Account_Number = txbAccount_Number.Text;
                    client.Client_Email = txbClient_Email.Text;
                    client.Client_Password = txbClient_Password.Password;
                    client.Contract_Conclusion_Date = DateOnly.Parse(txbContract_Conclusion_Date.Text);
                    client.Phone_Number = txbPhone_Number.Text;
                    client.Tariff_Cost = Decimal.Parse(txbTariff_Cost.Text);
                    client.Contract_Number = Convert.ToInt32(txbContract_Number.Text);

                    if (ApplicationContext.validData(client))
                    {
                        if (ApplicationContext.checkEmail(client.Client_Email))
                        {
                            db.Clients.Update(client);
                            db.SaveChanges();
                            clearRows();

                            Clients = new(db.Clients.ToList());
                            dtg.ItemsSource = Clients;
                        }
                        else
                            MessageBox.Show("Почта занята");
                    }
                    else
                    {
                        client.Account_Number = _saveClient.Account_Number;
                        client.Client_Email = _saveClient.Client_Email;
                        client.Client_Password = _saveClient.Client_Password;
                        client.Contract_Conclusion_Date = _saveClient.Contract_Conclusion_Date;
                        client.Phone_Number = _saveClient.Phone_Number;
                        client.Tariff_Cost = _saveClient.Tariff_Cost;
                        client.Contract_Number = _saveClient.Contract_Number;
                    }
                }
            }
            catch (Exception we) { }
        }

        
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                Client client = Clients[dtg.SelectedIndex];
                if (client != null)
                {
                    Clients.Remove(client);
                    db.Clients.Remove(client);
                    db.SaveChanges();
                }
            }
            catch (Exception we) { }
        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                Client client = e.Row.Item as Client;
                if (client != null)
                {
                    if (ApplicationContext.validData(client))
                    {
                        if (ApplicationContext.checkEmail(client.Client_Email))
                        {
                            db.Clients.Update(client);
                            db.SaveChanges();
                            return;
                        }
                        else
                            MessageBox.Show("Почта занята");
                    }
                    client.Account_Number = _saveClient.Account_Number;
                    client.Client_Email = _saveClient.Client_Email;
                    client.Client_Password = _saveClient.Client_Password;
                    client.Contract_Conclusion_Date = _saveClient.Contract_Conclusion_Date;
                    client.Phone_Number = _saveClient.Phone_Number;
                    client.Tariff_Cost = _saveClient.Tariff_Cost;
                    client.Contract_Number = _saveClient.Contract_Number;
                }
            }
            catch (Exception we) { }
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


        /// <summary>
        /// отчиска UI эелементов
        /// </summary>
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


        private void dtg_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var item = Clients[dtg.SelectedIndex];
                _saveClient = new Client(item);
                setData(item);
            }
            catch (Exception ex) { }
        }


        /// <summary>
        /// заполнение UI элементов данными существующего обьекта
        /// </summary>
        /// <param name="client">источник даных</param>
        public void setData(Client client)
        {
            txbAccount_Number.Text = client.Account_Number;
            txbClient_Email.Text = client.Client_Email;
            txbClient_Password.Password = client.Client_Password;
            txbContract_Conclusion_Date.Text = client.Contract_Conclusion_Date.ToString();
            txbPhone_Number.Text = client.Phone_Number;
            txbTariff_Cost.Text = client.Tariff_Cost.ToString();
            txbContract_Number.Text = client.Tariff_Cost.ToString();
        }
    }
}
