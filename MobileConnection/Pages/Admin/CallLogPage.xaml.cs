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
    /// Логика взаимодействия для CallLogPage.xaml
    /// </summary>
    public partial class CallLogPage : Page
    {
        ApplicationContext db;
        public ObservableCollection<ClientCall> ClientCalls { get; set; }

        public List<Call> Calls { get; set; }
        public List<Client> Clients { get; set; }

        private static ClientCall _SaveClientCall;

        public CallLogPage()
        {
            InitializeComponent();
            db = DBConnection.getConnection();

            ClientCalls = new(db.ClientCalls
                .Include(x => x.Client)
                .Include(x => x.Call)
                .ToList());

            Calls = new(db.Calls.ToList());
            Clients = new(db.Clients.ToList());

            cmbCall.ItemsSource = Calls;
            cmbClients.ItemsSource = Clients;
            dtg.ItemsSource = ClientCalls;

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
                Call call = cmbCall.SelectedItem as Call;

                if (ApplicationContext.validData(client) && ApplicationContext.validData(call))
                {
                    ClientCall clientCall = new ClientCall
                    {
                        Client = db.Clients.FirstOrDefault(x => x.ID_Client == client.ID_Client),
                        Call = db.Calls.FirstOrDefault(x => x.ID_Call == call.ID_Call),
                    };

                    ClientCalls.Add(clientCall);
                    db.ClientCalls.Add(clientCall);
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
                ClientCall clientCall = ClientCalls[dtg.SelectedIndex];
                if (clientCall != null)
                {
                    Client client = cmbClients.SelectedItem as Client;
                    Call call = cmbCall.SelectedItem as Call;

                    if (ApplicationContext.validData(client) && ApplicationContext.validData(call))
                    {
                        clientCall.Client = db.Clients.FirstOrDefault(x => x.ID_Client == client.ID_Client);
                        clientCall.Call = db.Calls.FirstOrDefault(x => x.ID_Call == call.ID_Call);


                        db.ClientCalls.Update(clientCall);
                        db.SaveChanges();
                        clearRows();

                        ClientCalls = new(db.ClientCalls
                            .Include(x => x.Client)
                            .Include(x => x.Call)
                            .ToList());
                        dtg.ItemsSource = ClientCalls;
                    }
                    else
                    {
                        clientCall.Client.Phone_Number = _SaveClientCall.Client.Phone_Number;
                        clientCall.Call.Subscriber_Called_Number = _SaveClientCall.Call.Subscriber_Called_Number;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                ClientCall clientCall = ClientCalls[dtg.SelectedIndex];
                if (clientCall != null)
                {
                    ClientCalls.Remove(clientCall);
                    db.ClientCalls.Remove(clientCall);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                ClientCall clientCall = e.Row.Item as ClientCall;

                if (clientCall != null)
                {
                    if (ApplicationContext.validData(clientCall.Call)
                        && ApplicationContext.validData(clientCall.Client))
                    {
                        db.ClientCalls.Update(clientCall);
                        db.SaveChanges();
                    }
                    else
                    {
                        clientCall.Client.Phone_Number = _SaveClientCall.Client.Phone_Number;
                        clientCall.Call.Subscriber_Called_Number = _SaveClientCall.Call.Subscriber_Called_Number;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            string search = txbSearch.Text;
            if (search == null)
            {
                ClientCalls = new(db.ClientCalls
                    .Include(x => x.Client)
                    .Include(x => x.Call)
                    .ToList());

                dtg.ItemsSource = ClientCalls;
                return;
            }
            ClientCalls = new(db.ClientCalls
                    .Include(x => x.Client)
                    .Include(x => x.Call)
                    .Where(x => x.Client.Phone_Number.Contains(search) 
                    || x.Call.Subscriber_Called_Number.Contains(search))
                    .ToList());

            dtg.ItemsSource = ClientCalls;
        }


        public void clearRows()
        {
            cmbCall.SelectedItem = null;
            cmbClients.SelectedItem = null;
        }


        private void dtg_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var item = ClientCalls[dtg.SelectedIndex];
                _SaveClientCall = new ClientCall(item);
                setData(item);
            }
            catch (Exception ex)
            {

            }
        }

        public void setData(ClientCall clientCall)
        {
            cmbCall.SelectedItem = clientCall.Call;
            cmbClients.SelectedItem= clientCall.Client;
        }
    }
}
