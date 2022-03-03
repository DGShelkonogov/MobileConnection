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

        private static ClientMessage _saveClientMessage;


        public MessageLogPage()
        {
            InitializeComponent();

            db = DBConnection.getConnection();

            ClientMessages = new(db.ClientMessages
                .Include(x => x.Client)
                .Include(x => x.Message)
                .ToList());
            dtg.ItemsSource = ClientMessages;

            Messages = new(db.Messages.ToList());
            Clients = new(db.Clients.ToList());

            cmbMessages.ItemsSource = Messages;
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
                Message message = cmbMessages.SelectedItem as Message;

                ClientMessage clientMessage = new ClientMessage
                {
                    Client = db.Clients.FirstOrDefault(x => x.ID_Client == client.ID_Client),
                    Message = db.Messages.FirstOrDefault(x => x.ID_Message == message.ID_Message),
                };

                if (ApplicationContext.validData(client) && ApplicationContext.validData(message))
                {
                    ClientMessages.Add(clientMessage);
                    db.ClientMessages.Add(clientMessage);
                    db.SaveChanges();
                    clearRows();
                }
            }
            catch(Exception ex) { }
        }


        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            try
            {
                ClientMessage clientMessage = ClientMessages[dtg.SelectedIndex];
                if (clientMessage != null)
                {
                    Client client = cmbClients.SelectedItem as Client;
                    Message message = cmbMessages.SelectedItem as Message;

                    clientMessage.Client = db.Clients.FirstOrDefault(x => x.ID_Client == client.ID_Client);
                    clientMessage.Message = db.Messages.FirstOrDefault(x => x.ID_Message == message.ID_Message);

                    if (ApplicationContext.validData(client) && ApplicationContext.validData(message))
                    {
                        db.ClientMessages.Update(clientMessage);
                        db.SaveChanges();
                        clearRows();

                        ClientMessages = new(db.ClientMessages
                            .Include(x => x.Client)
                            .Include(x => x.Message)
                            .ToList());
                        dtg.ItemsSource = ClientMessages;
                    }
                    else
                    {
                        clientMessage.Message.Subscriber_Number = _saveClientMessage.Message.Subscriber_Number;
                        clientMessage.Client.Phone_Number = _saveClientMessage.Client.Phone_Number;
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                ClientMessage clientMessage = ClientMessages[dtg.SelectedIndex];
                if (clientMessage != null)
                {
                    ClientMessages.Remove(clientMessage);
                    db.ClientMessages.Remove(clientMessage);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {

            }
            catch (Exception ex) { }

            ClientMessage clientMessage = e.Row.Item as ClientMessage;

            if (clientMessage != null)
            {
                if (ApplicationContext.validData(clientMessage.Message) && ApplicationContext.validData(clientMessage.Client))
                {
                    db.ClientMessages.Update(clientMessage);
                    db.SaveChanges();
                }
                else
                {
                    clientMessage.Message.Subscriber_Number = _saveClientMessage.Message.Subscriber_Number;
                    clientMessage.Client.Phone_Number = _saveClientMessage.Client.Phone_Number;
                }
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

        private void dtg_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var item = ClientMessages[dtg.SelectedIndex];
                _saveClientMessage = new ClientMessage(item);
                setData(item);
            }
            catch (Exception ex) { }
        }

        public void setData(ClientMessage clientMessage)
        {
            cmbMessages.SelectedItem = clientMessage.Message;
            cmbClients.SelectedItem = clientMessage.Client;
        }
    }
}
