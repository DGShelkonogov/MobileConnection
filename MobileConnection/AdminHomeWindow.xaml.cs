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
using System.Windows.Shapes;

namespace MobileConnection
{
    /// <summary>
    /// Логика взаимодействия для AdminHomeWindow.xaml
    /// </summary>
    public partial class AdminHomeWindow : Window
    {
        ApplicationContext db;
        public AdminHomeWindow()
        {
            InitializeComponent();
            db = DBConnection.getConnection();
        }


        public void setPage(string tag)
        {
            Frame.Source = new Uri(tag, UriKind.Relative);
        }


        /// <summary>
        /// навигация по страницам
        /// </summary>
        private void Button_Click_Page_Navigation(object sender, RoutedEventArgs e)
        {
            setPage((sender as Button).Tag.ToString());
        }


        /// <summary>
        /// выход из аккаунта
        /// </summary>
        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow window = new AuthorizationWindow();
            window.Show();
            this.Close();
        }


        /// <summary>
        /// возврат на предыдушю страницу
        /// </summary>
        public void btnBack_Click_Back()
        {
            try
            {
                Frame.GoBack();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
