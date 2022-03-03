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

        private static Message _saveMessage;


        /// <summary>
        /// Импорт данных из БД, заполнение DataGrid и Combobox
        /// </summary>
        public MessagePage()
        {
            InitializeComponent();

            db = DBConnection.getConnection();
            Messages = new(db.Messages.ToList());
            dtg.ItemsSource = Messages;
            Type_Of_Calls_And_Messages = new(db.Type_Of_Calls_And_Messages.ToList());

            cmbTypeMessage.ItemsSource = Type_Of_Calls_And_Messages;
            
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
                Type_Of_Call_And_Message type = cmbTypeMessage.SelectedItem as Type_Of_Call_And_Message;

                Message message = new Message
                {
                    Message_Date = DateOnly.Parse(tbxMessage_Date.Text),
                    Sending_Time = TimeOnly.Parse(tbxSending_Time.Text),
                    Type = db.Type_Of_Calls_And_Messages
                        .FirstOrDefault(x => x.ID_Type_Of_Call_And_Message == type.ID_Type_Of_Call_And_Message),
                    Subscriber_Number = tbxSubscriber_Number.Text,
                };

                if (ApplicationContext.validData(type) && ApplicationContext.validData(message))
                {
                    Messages.Add(message);
                    db.Messages.Add(message);
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
                Message message = Messages[dtg.SelectedIndex];
                if (message != null)
                {
                    Type_Of_Call_And_Message type = cmbTypeMessage.SelectedItem as Type_Of_Call_And_Message;

                    message.Message_Date = DateOnly.Parse(tbxMessage_Date.Text);
                    message.Sending_Time = TimeOnly.Parse(tbxSending_Time.Text);
                    message.Type = db.Type_Of_Calls_And_Messages
                          .FirstOrDefault(x => x.ID_Type_Of_Call_And_Message == type.ID_Type_Of_Call_And_Message);
                    message.Subscriber_Number = tbxSubscriber_Number.Text;

                    if (ApplicationContext.validData(type) && ApplicationContext.validData(message))
                    {
                        db.Messages.Update(message);
                        db.SaveChanges();
                        clearRows();

                        Messages = new(db.Messages.ToList());
                        dtg.ItemsSource = Messages;
                    }
                    else
                    {
                        message.Type.Type_Name = _saveMessage.Type.Type_Name;
                        message.Subscriber_Number = _saveMessage.Subscriber_Number;
                        message.Message_Date = _saveMessage.Message_Date;
                        message.Subscriber_Number = _saveMessage.Subscriber_Number;
                        message.Subscriber_Number = _saveMessage.Subscriber_Number;
                    }
                }
            }
            catch (Exception ex) { }
        }


        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                Message message = Messages[dtg.SelectedIndex];
                if (message != null)
                {
                    Messages.Remove(message);
                    db.Messages.Remove(message);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }


        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                Message message = e.Row.Item as Message;

                if (message != null)
                {
                    if (ApplicationContext.validData(message.Type) && ApplicationContext.validData(message))
                    {
                        db.Messages.Update(message);
                        db.SaveChanges();
                    }
                    else
                    {
                        message.Type.Type_Name = _saveMessage.Type.Type_Name;
                        message.Subscriber_Number = _saveMessage.Subscriber_Number;
                        message.Message_Date = _saveMessage.Message_Date;
                        message.Subscriber_Number = _saveMessage.Subscriber_Number;
                        message.Subscriber_Number = _saveMessage.Subscriber_Number;
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
                Messages = new(db.Messages.ToList());
                dtg.ItemsSource = Messages;
                return;
            }
            Messages = new(db.Messages
                .Where(x => x.Subscriber_Number.Contains(search))
                .ToList());
            dtg.ItemsSource = Messages;
        }


        /// <summary>
        /// отчиска UI эелементов
        /// </summary>
        public void clearRows()
        {
            tbxMessage_Date.Text = "";
            tbxSending_Time.Text = "";
            tbxSubscriber_Number.Text = "";
            cmbTypeMessage.SelectedItem = null;
        }


        private void dtg_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                 var item = Messages[dtg.SelectedIndex];
                 _saveMessage = new Message(item);
                 setData(item);
            }
            catch (Exception ex) { }
        }


        /// <summary>
        /// заполнение UI элементов данными существующего обьекта
        /// </summary>
        /// <param name="message">источник даных</param>
        public void setData(Message message)
        {
            tbxMessage_Date.Text = message.Message_Date.ToString();
            tbxSending_Time.Text = message.Sending_Time.ToString();
            tbxSubscriber_Number.Text = message.Subscriber_Number;
            cmbTypeMessage.SelectedItem = message.Type;
        }
    }
}
