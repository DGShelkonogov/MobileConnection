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
    /// Логика взаимодействия для MessageLogPage.xaml
    /// </summary>
    public partial class MessageLogPage : Page
    {
        ApplicationContext db;
        public ObservableCollection<ClientMessage> ClientMessages { get; set; }

        public List<Message> Messages { get; set; }
        public List<Client> Clients { get; set; }


        public MessageLogPage()
        {
            InitializeComponent();

            db = DBConnection.getConnection();

            ClientMessages = new(db.ClientMessages
                .Include(x => x.Client)
                .Include(x => x.Message)
                .ToList());

            Messages = new(db.Messages.ToList());
            Clients = new(db.Clients.ToList());

            cmbMessages.ItemsSource = Messages;
            cmbClients.ItemsSource = Clients;
            dtg.ItemsSource = ClientMessages;
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            AdminHomeWindow win = (AdminHomeWindow)Window.GetWindow(this);
            win.btnBack_Click_Back();
        }


        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            Client client = cmbClients.SelectedItem as Client;
            Message message = cmbMessages.SelectedItem as Message;

            ClientMessage clientMessage = new ClientMessage
            {
                Client = db.Clients.FirstOrDefault(x => x.ID_Client == client.ID_Client),
                Message = db.Messages.FirstOrDefault(x => x.ID_Message == message.ID_Message),
            };

            ClientMessages.Add(clientMessage);
            db.ClientMessages.Add(clientMessage);
            db.SaveChanges();
            clearRows();
        }


        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            ClientMessage clientMessage = ClientMessages[dtg.SelectedIndex];
            if (clientMessage != null)
            {
                Client client = cmbClients.SelectedItem as Client;
                Message message = cmbMessages.SelectedItem as Message;
                clientMessage = new ClientMessage
                {
                    Client = db.Clients.FirstOrDefault(x => x.ID_Client == client.ID_Client),
                    Message = db.Messages.FirstOrDefault(x => x.ID_Message == message.ID_Message),
                };

                db.ClientMessages.Update(clientMessage);
                db.SaveChanges();
                clearRows();
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            ClientMessage clientMessage = ClientMessages[dtg.SelectedIndex];
            if (clientMessage != null)
            {
                ClientMessages.Remove(clientMessage);
                db.ClientMessages.Remove(clientMessage);
                db.SaveChanges();
            }
        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            ClientMessage clientMessage = e.Row.Item as ClientMessage;

            if (clientMessage != null)
            {
                db.ClientMessages.Update(clientMessage);
                db.SaveChanges();
            }
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            string search = txbSearch.Text;
            if (search == null)
            {
                ClientMessages = new(db.ClientMessages
                    .Include(x => x.Client)
                    .Include(x => x.Message)
                    .ToList());

                dtg.ItemsSource = ClientMessages;
                return;
            }
            ClientMessages = new(db.ClientMessages
                    .Include(x => x.Client)
                    .Include(x => x.Message)
                    .Where(x => x.Client.Phone_Number.Contains(search)
                    || x.Message.Subscriber_Number.Contains(search))
                    .ToList());

            dtg.ItemsSource = ClientMessages;
        }

        public void clearRows()
        {
            cmbMessages.SelectedItem = null;
            cmbClients.SelectedItem = null;
        }
    }
}
