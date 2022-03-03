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
    /// Логика взаимодействия для TypeOfCallsAndMessagesPage.xaml
    /// </summary>
    public partial class TypeOfCallsAndMessagesPage : Page
    {
        ApplicationContext db;
        public ObservableCollection<Type_Of_Call_And_Message> Type_Of_Calls_And_Messages { get; set; }

        private static Type_Of_Call_And_Message _saveType_Of_Call_And_Message;
        public TypeOfCallsAndMessagesPage()
        {
            InitializeComponent();
            db = DBConnection.getConnection();
            Type_Of_Calls_And_Messages = new(db.Type_Of_Calls_And_Messages.ToList());
            dtg.ItemsSource = Type_Of_Calls_And_Messages;
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
                Type_Of_Call_And_Message type = new Type_Of_Call_And_Message
                {
                    Type_Name = tbxTitle.Text.ToString(),
                };

                if (ApplicationContext.validData(type))
                {
                    Type_Of_Calls_And_Messages.Add(type);
                    db.Type_Of_Calls_And_Messages.Add(type);
                    db.SaveChanges();
                    tbxTitle.Text = "";
                }
            }
            catch(Exception ex) { }
        }

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            try
            {
                Type_Of_Call_And_Message type = Type_Of_Calls_And_Messages[dtg.SelectedIndex];
                if (type != null)
                {
                    type.Type_Name = tbxTitle.Text.ToString();

                    if (ApplicationContext.validData(type))
                    {
                        db.Type_Of_Calls_And_Messages.Update(type);
                        db.SaveChanges();
                        tbxTitle.Text = "";

                        Type_Of_Calls_And_Messages = new(db.Type_Of_Calls_And_Messages.ToList());
                        dtg.ItemsSource = Type_Of_Calls_And_Messages;
                    }
                    else
                    {
                        type.Type_Name = _saveType_Of_Call_And_Message.Type_Name;
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                Type_Of_Call_And_Message type = Type_Of_Calls_And_Messages[dtg.SelectedIndex];
                if (type != null)
                {
                    Type_Of_Calls_And_Messages.Remove(type);
                    db.Type_Of_Calls_And_Messages.Remove(type);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                Type_Of_Call_And_Message type = e.Row.Item as Type_Of_Call_And_Message;

                if (type != null)
                {
                    if (ApplicationContext.validData(type))
                    {
                        db.Type_Of_Calls_And_Messages.Update(type);
                        db.SaveChanges();
                    }
                    else
                    {
                        type.Type_Name = _saveType_Of_Call_And_Message.Type_Name;
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
                Type_Of_Calls_And_Messages = new(db.Type_Of_Calls_And_Messages.ToList());
                dtg.ItemsSource = Type_Of_Calls_And_Messages;
                return;
            }
            Type_Of_Calls_And_Messages = new(db.Type_Of_Calls_And_Messages
                .Where(x => x.Type_Name.Contains(search))
                .ToList());
            dtg.ItemsSource = Type_Of_Calls_And_Messages;
        }

        private void dtg_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var item = Type_Of_Calls_And_Messages[dtg.SelectedIndex];
                _saveType_Of_Call_And_Message = new Type_Of_Call_And_Message(item);
                setData(item);
            }
            catch (Exception ex) { }
        }

        public void setData(Type_Of_Call_And_Message type)
        {
            tbxTitle.Text = type.Type_Name;
        }
    }
}
