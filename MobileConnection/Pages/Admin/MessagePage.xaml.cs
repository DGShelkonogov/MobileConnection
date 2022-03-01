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
    /// Логика взаимодействия для MessagePage.xaml
    /// </summary>
    public partial class MessagePage : Page
    {
        ApplicationContext db;
        public ObservableCollection<Message> Messages { get; set; }

        public List<Type_Of_Call_And_Message> Type_Of_Calls_And_Messages { get; set; }

        public MessagePage()
        {
            InitializeComponent();

            db = DBConnection.getConnection();
            Messages = new(db.Messages.ToList());
            Type_Of_Calls_And_Messages = new(db.Type_Of_Calls_And_Messages.ToList());

            cmbTypeMessage.ItemsSource = Type_Of_Calls_And_Messages;
            dtg.ItemsSource = Messages;
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            AdminHomeWindow win = (AdminHomeWindow)Window.GetWindow(this);
            win.btnBack_Click_Back();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            Type_Of_Call_And_Message type = cmbTypeMessage.SelectedItem as Type_Of_Call_And_Message;

            Message message = new Message
            {
                Message_Date = DateOnly.Parse(tbxMessage_Date.Text),
                Sending_Time = TimeOnly.Parse(tbxSending_Time.Text),
                Type = db.Type_Of_Calls_And_Messages
                .FirstOrDefault(x => x.ID_Type_Of_Call_And_Message == type.ID_Type_Of_Call_And_Message),
                Subscriber_Number = tbxSubscriber_Number.Text,
            };

            Messages.Add(message);
            db.Messages.Add(message);
            db.SaveChanges();
            clearRows();
        }

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            Message message = Messages[dtg.SelectedIndex];
            if (message != null)
            {
                Type_Of_Call_And_Message type = cmbTypeMessage.SelectedItem as Type_Of_Call_And_Message;
                message = new Message
                {
                    Message_Date = DateOnly.Parse(tbxMessage_Date.Text),
                    Sending_Time = TimeOnly.Parse(tbxSending_Time.Text),
                    Type = db.Type_Of_Calls_And_Messages
               .FirstOrDefault(x => x.ID_Type_Of_Call_And_Message == type.ID_Type_Of_Call_And_Message),
                    Subscriber_Number = tbxSubscriber_Number.Text,
                };

                db.Messages.Update(message);
                db.SaveChanges();
                clearRows();
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            Message message = Messages[dtg.SelectedIndex];
            if (message != null)
            {
                Messages.Remove(message);
                db.Messages.Remove(message);
                db.SaveChanges();
            }
        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            Call call = e.Row.Item as Call;

            if (call != null)
            {
                db.Calls.Update(call);
                db.SaveChanges();
            }
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            string search = txbSearch.Text;
            if (search == null)
            {
                Messages = new(db.Messages.ToList());
                dtg.ItemsSource = Messages;
                return;
            }
            Messages = new(db.Messages
                .Where(x => x.Subscriber_Number.Contains(search))
                .ToList());
            dtg.ItemsSource = Messages;
        }


        public void clearRows()
        {
            tbxMessage_Date.Text = "";
            tbxSending_Time.Text = "";
            tbxSubscriber_Number.Text = "";
            cmbTypeMessage.SelectedItem = null;
        }
    }
}
