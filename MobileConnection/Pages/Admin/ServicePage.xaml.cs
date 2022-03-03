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
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        ApplicationContext db;
        public ObservableCollection<Service> Services { get; set; }
        public List<Employee> Employees { get; set; }

        private static Service _saveService;


        /// <summary>
        /// Импорт данных из БД, заполнение DataGrid и Combobox
        /// </summary>
        public ServicePage()
        {
            InitializeComponent();

            db = DBConnection.getConnection();

            Services = new(db.Services
                .Include(x => x.Employee)
                .ToList());
            dtg.ItemsSource = Services;
            Employees = new(db.Employees.ToList());

            cmbEmployees.ItemsSource = Employees;
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
                Employee employee = cmbEmployees.SelectedItem as Employee;

                var status = (cmbStatuses.SelectedItem as ComboBoxItem).Tag.ToString();

                Service service = new Service
                {
                    Cost = Decimal.Parse(txbCost.Text),
                    Service_Name = txbService_Name.Text,
                    Service_Status = Boolean.Parse(status),
                    Employee = db.Employees.FirstOrDefault(x => x.ID_Employee == employee.ID_Employee)
                };

                if (ApplicationContext.validData(employee) && ApplicationContext.validData(service))
                {
                    Services.Add(service);
                    db.Services.Add(service);
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
                Service service = Services[dtg.SelectedIndex];
                if (service != null)
                {
                    Employee employee = cmbEmployees.SelectedItem as Employee;
                    var status = (cmbStatuses.SelectedItem as Label).Tag.ToString();

                    service.Cost = Decimal.Parse(txbCost.Text);
                    service.Service_Name = txbService_Name.Text;
                    service.Service_Status = Boolean.Parse(status);
                    service.Employee = db.Employees.FirstOrDefault(x => x.ID_Employee == employee.ID_Employee);

                    if (ApplicationContext.validData(employee) && ApplicationContext.validData(service))
                    {
                        db.Services.Update(service);
                        db.SaveChanges();
                        clearRows();

                        Services = new(db.Services
                            .Include(x => x.Employee)
                            .ToList());
                        dtg.ItemsSource = Services;
                    }
                    else
                    {
                        service.Cost = _saveService.Cost;
                        service.Service_Name = _saveService.Service_Name;
                        service.Service_Status = _saveService.Service_Status;
                        service.Employee.Employee_Name = _saveService.Employee.Employee_Name;
                    }
                }
            }
            catch (Exception ex) { }
        }


        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                Service service = Services[dtg.SelectedIndex];
                if (service != null)
                {
                    Services.Remove(service);
                    db.Services.Remove(service);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }


        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                Service service = e.Row.Item as Service;

                if (service != null)
                {
                    if (ApplicationContext.validData(service.Employee) && ApplicationContext.validData(service))
                    {
                        db.Services.Update(service);
                        db.SaveChanges();
                    }
                    else
                    {
                        service.Cost = _saveService.Cost;
                        service.Service_Name = _saveService.Service_Name;
                        service.Service_Status = _saveService.Service_Status;
                        service.Employee.Employee_Name = _saveService.Employee.Employee_Name;
                    }
                }
            }
            catch (Exception ex) { }

           
        }


        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            string search = txbSearch.Text;
            if (search.Length < 0)
            {
                Services = new(db.Services
                    .Include(x => x.Employee)
                    .ToList());
                dtg.ItemsSource = Services;
                return;
            }
            Services = new(db.Services
                .Include(x => x.Employee)
                .Where(x => x.Service_Name.Contains(search))
                .ToList());
            dtg.ItemsSource = Services;
        }


        /// <summary>
        /// отчиска UI эелементов
        /// </summary>
        public void clearRows()
        {
            txbCost.Text = "";
            txbService_Name.Text = "";
            cmbStatuses.SelectedItem = null;
            cmbEmployees.SelectedItem = null;
        }


        private void dtg_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var item = Services[dtg.SelectedIndex];
                _saveService = new Service(item);
                setData(item);
            }
            catch (Exception ex) { }
        }


        /// <summary>
        /// заполнение UI элементов данными существующего обьекта
        /// </summary>
        /// <param name="service">источник даных</param>
        public void setData(Service service)
        {
            txbCost.Text = service.Cost.ToString();
            txbService_Name.Text = service.Service_Name;
            cmbStatuses.SelectedItem = service.Service_Status;
            cmbEmployees.SelectedItem = service.Employee;
        }
    }
}
