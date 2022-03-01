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

            Calls.Add(call);
            db.Calls.Add(call);
            db.SaveChanges();
            clearRows();
        }

      

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            Call call = Calls[dtg.SelectedIndex];
            if (call != null)
            {
                Type_Of_Call_And_Message type = cmbTypeCall.SelectedItem as Type_Of_Call_And_Message;
                call = new Call
                {
                    Call_Date = DateOnly.Parse(tbxCall_Date.Text),
                    Call_Start_Time = TimeOnly.Parse(tbxCall_Start_Time.Text),
                    Duration = tbxDuration.Text,
                    Subscriber_Called_Number = tbxSubscriber_Called_Number.Text,
                    Type = db.Type_Of_Calls_And_Messages
                 .FirstOrDefault(x => x.ID_Type_Of_Call_And_Message == type.ID_Type_Of_Call_And_Message)
                };

                db.Calls.Update(call);
                db.SaveChanges();
                clearRows();
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
                db.Calls.Update(call);
                db.SaveChanges();
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

    }
}
