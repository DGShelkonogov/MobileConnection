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
    /// Логика взаимодействия для CallPage.xaml
    /// </summary>
    public partial class CallPage : Page
    {
        ApplicationContext db;
        public ObservableCollection<Call> Calls { get; set; }

        public List<Type_Of_Call_And_Message> Type_Of_Calls_And_Messages { get; set; }

        private static Call _saveCall;

        public CallPage()
        {
            InitializeComponent();

            db = DBConnection.getConnection();
            Calls = new(db.Calls.ToList());
            Type_Of_Calls_And_Messages = new(db.Type_Of_Calls_And_Messages.ToList());

            cmbTypeCall.ItemsSource = Type_Of_Calls_And_Messages;
            dtg.ItemsSource = Calls;
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
                Type_Of_Call_And_Message type = cmbTypeCall.SelectedItem as Type_Of_Call_And_Message;

                Call call = new Call
                {
                    Call_Date = DateOnly.Parse(tbxCall_Date.Text),
                    Call_Start_Time = TimeOnly.Parse(tbxCall_Start_Time.Text),
                    Duration = tbxDuration.Text,
                    Subscriber_Called_Number = tbxSubscriber_Called_Number.Text,
                    Type = db.Type_Of_Calls_And_Messages
                    .FirstOrDefault(x => x.ID_Type_Of_Call_And_Message == type.ID_Type_Of_Call_And_Message)
                };

                if (ApplicationContext.validData(call) && ApplicationContext.validData(type))
                {
                    Calls.Add(call);
                    db.Calls.Add(call);
                    db.SaveChanges();
                    clearRows();
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Проверьте правильность заполнения полей");
            }
        }

      

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            Call call = Calls[dtg.SelectedIndex];
            if (call != null)
            {
                Type_Of_Call_And_Message type = cmbTypeCall.SelectedItem as Type_Of_Call_And_Message;

                call.Call_Date = DateOnly.Parse(tbxCall_Date.Text);
                call.Call_Start_Time = TimeOnly.Parse(tbxCall_Start_Time.Text);
                call.Duration = tbxDuration.Text;
                call.Subscriber_Called_Number = tbxSubscriber_Called_Number.Text;
                call.Type = db.Type_Of_Calls_And_Messages
                    .FirstOrDefault(x => x.ID_Type_Of_Call_And_Message 
                    == type.ID_Type_Of_Call_And_Message);


                if (ApplicationContext.validData(call) && ApplicationContext.validData(type))
                {
                    db.Calls.Update(call);
                    db.SaveChanges();
                    clearRows();

                    Calls = new(db.Calls.ToList());
                    dtg.ItemsSource = Calls;
                }
                else
                {
                    call.Type = _saveCall.Type;
                    call.Call_Date = _saveCall.Call_Date;
                    call.Call_Start_Time = _saveCall.Call_Start_Time;
                    call.Duration = _saveCall.Duration;
                    call.Subscriber_Called_Number = _saveCall.Subscriber_Called_Number;
                }
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            Call call = Calls[dtg.SelectedIndex];
            if (call != null)
            {
                Calls.Remove(call);
                db.Calls.Remove(call);
                db.SaveChanges();
            }
        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            Call call = e.Row.Item as Call;

            if (call != null)
            {
                if (ApplicationContext.validData(call) && ApplicationContext.validData(call.Type))
                {
                    db.Calls.Update(call);
                    db.SaveChanges();
                }
                else
                {
                    call.Type = _saveCall.Type;
                    call.Call_Date = _saveCall.Call_Date;
                    call.Call_Start_Time = _saveCall.Call_Start_Time;
                    call.Duration = _saveCall.Duration;
                    call.Subscriber_Called_Number = _saveCall.Subscriber_Called_Number;
                }
                   
            }
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            string search = txbSearch.Text;
            if (search == null)
            {
                Calls = new(db.Calls.ToList());
                dtg.ItemsSource = Calls;
                return;
            }
            Calls = new(db.Calls
                .Where(x => x.Duration.Equals(TimeOnly.Parse(search)))
                .ToList());
            dtg.ItemsSource = Calls;
        }

        public void clearRows()
        {
            tbxCall_Date.Text = "";
            tbxCall_Start_Time.Text = "";
            tbxDuration.Text = "";
            tbxSubscriber_Called_Number.Text = "";
            cmbTypeCall.SelectedItem = null;
        }


        private void dtg_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var item = Calls[dtg.SelectedIndex];
            _saveCall = new Call(item);
            setData(item);
        }

        public void setData(Call call)
        {
            tbxCall_Date.Text = call.Call_Date.ToString();
            tbxCall_Start_Time.Text = call.Call_Start_Time.ToString();
            tbxDuration.Text = call.Duration.ToString();
            tbxSubscriber_Called_Number.Text = call.Subscriber_Called_Number.ToString();
            cmbTypeCall.SelectedItem = call.Type;
        }
    }
}
