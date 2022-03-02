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
    /// Логика взаимодействия для CorporateClientPage.xaml
    /// </summary>
    public partial class CorporateClientPage : Page
    {
        ApplicationContext db;
        private static Corporate_Client corporate_Client;

        public CorporateClientPage(int? idClient)
        {
            InitializeComponent();

            db = DBConnection.getConnection();

            corporate_Client = db.Corporate_Clients
                .Include(x => x.Client)
                .ThenInclude(x => x.Services)
                .FirstOrDefault(x => x.ID_Corporate_Client == idClient);

            setData();
        }

        public void setData()
        {
            if (corporate_Client != null)
            {
                txbAccount_Number.Text = corporate_Client.Client.Account_Number;
                txbContract_Number.Text = corporate_Client.Client.Contract_Number.ToString();
                txbContract_Conclusion_Date.Text = corporate_Client.Client.Contract_Conclusion_Date.ToString();
                txbPhone_Number.Text = corporate_Client.Client.Phone_Number;

                txbINN.Text = corporate_Client.INN;
                txbCompany_Name.Text = corporate_Client.Company_Name;
                txbLegal_Adsress.Text = corporate_Client.Legal_Adsress;
                txbPhysical_Adsress.Text = corporate_Client.Physical_Adsress;
                txbPersonal_Account_Number.Text = corporate_Client.Personal_Account_Number;
                
               
                decimal amount = 0;
                foreach (var item in corporate_Client.Client.Services)
                {
                    amount += item.Cost;
                }
                txbAmountServise.Text = amount.ToString();
            }
        }


        private void Button_Click_Open_Service_Page(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow win = (AuthorizationWindow)Window.GetWindow(this);
            win.openService(corporate_Client.Client.ID_Client);
        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow win = (AuthorizationWindow)Window.GetWindow(this);
            win.setPage("Pages/AuthorizationPage.xaml");
        }

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            
            corporate_Client.INN = txbINN.Text;
            corporate_Client.Company_Name = txbCompany_Name.Text;
            corporate_Client.Legal_Adsress = txbLegal_Adsress.Text;
            corporate_Client.Physical_Adsress = txbPhysical_Adsress.Text;
            corporate_Client.Personal_Account_Number = txbPersonal_Account_Number.Text;

            if (ApplicationContext.validData(corporate_Client))
            {
                if (ApplicationContext.checkEmail(corporate_Client.Client.Client_Email))
                {
                    db.SaveChanges();
                    MessageBox.Show("Обновление успешно");
                }
                else
                    MessageBox.Show("Почта занята");
            }
           
        }
    }
}
