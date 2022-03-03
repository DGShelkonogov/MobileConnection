using Microsoft.EntityFrameworkCore;
using MobileConnection.Models;
using System;
using System.Collections.Generic;
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

namespace MobileConnection.Pages
{
    /// <summary>
    /// Логика взаимодействия для PrivateClientPage.xaml
    /// </summary>
    public partial class PrivateClientPage : Page
    {
        ApplicationContext db; 
        private static Private_Client privateClient;

        /// <summary>
        /// Импорт данных из БД
        /// </summary>
        public PrivateClientPage(int? idClient)
        {
            InitializeComponent();
            db = DBConnection.getConnection();

            privateClient = db.Private_Clients
                .Include(x => x.Client)
                .ThenInclude(x => x.Services)
                .FirstOrDefault(x => x.ID_Private_Client == idClient);

            setData();
        }


        /// <summary>
        /// заполнение UI элементов данными существующего обьекта
        /// </summary>
        public void setData()
        {
            if(privateClient != null)
            {
                txbAccount_Number.Text = privateClient.Client.Account_Number;
                txbContract_Number.Text = privateClient.Client.Contract_Number.ToString();
                txbContract_Conclusion_Date.Text = privateClient.Client.Contract_Conclusion_Date.ToString();
                txbPhone_Number.Text = privateClient.Client.Phone_Number;
                txbClient_Surname.Text = privateClient.Client_Surname;
                txbClient_Name.Text = privateClient.Client_Name;
                txbClient_Patronymic.Text = privateClient.Client_Patronymic;
                txbDate_Of_Birth.Text = privateClient.Date_Of_Birth.ToString();
                txbPassport_Series.Text = privateClient.Passport_Series.ToString();
                txbPassport_Number.Text = privateClient.Passport_Number.ToString();
                txbAdsress.Text = privateClient.Adsress;
                txbClient_Email.Text = privateClient.Client.Client_Email;
                txbClient_Password.Text = privateClient.Client.Client_Password;

                decimal amount = 0;
                foreach(var item in privateClient.Client.Services)
                {
                    amount += item.Cost;
                }
                txbAmountServise.Text = amount.ToString();
            }
        }


        private void Button_Click_Open_Service_Page(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow win = (AuthorizationWindow)Window.GetWindow(this);
            win.openService(privateClient.Client.ID_Client);
        }


        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow win = (AuthorizationWindow)Window.GetWindow(this);
            win.setPage("Pages/AuthorizationPage.xaml");
        }


        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            try
            {
                privateClient.Client_Surname = txbClient_Surname.Text;
                privateClient.Client_Name = txbClient_Name.Text;
                privateClient.Client_Patronymic = txbClient_Patronymic.Text;
                privateClient.Date_Of_Birth = DateOnly.Parse(txbDate_Of_Birth.Text);
                privateClient.Passport_Series = Convert.ToInt32(txbPassport_Series.Text);
                privateClient.Passport_Number = Convert.ToInt32(txbPassport_Number.Text);
                privateClient.Adsress = txbAdsress.Text;
                privateClient.Client.Client_Email = txbClient_Email.Text;
                privateClient.Client.Client_Password = txbClient_Password.Text;

                if (ApplicationContext.validData(privateClient))
                {
                    if (ApplicationContext.checkEmail(privateClient.Client.Client_Email))
                    {
                        db.SaveChanges();
                        MessageBox.Show("Обновление успешно");
                    }
                    else
                        MessageBox.Show("Почта занята");
                }
            }
            catch (Exception ex) { }
        }
    }
}
