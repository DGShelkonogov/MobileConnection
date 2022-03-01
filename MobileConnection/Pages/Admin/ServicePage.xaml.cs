﻿using Microsoft.EntityFrameworkCore;
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

        public ServicePage()
        {
            InitializeComponent();

            db = DBConnection.getConnection();

            Services = new(db.Services
                .Include(x => x.Employee)
                .ToList());

            Employees = new(db.Employees.ToList());

            cmbEmployees.ItemsSource = Employees;
            dtg.ItemsSource = Services;
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            AdminHomeWindow win = (AdminHomeWindow)Window.GetWindow(this);
            win.btnBack_Click_Back();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
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


            Services.Add(service);
            db.Services.Add(service);
            db.SaveChanges();
            clearRows();
        }

       

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            Service service = Services[dtg.SelectedIndex];
            if (service != null)
            {
                Employee employee = cmbEmployees.SelectedItem as Employee;
                var status = (cmbStatuses.SelectedItem as Label).Tag.ToString();

                service = new Service
                {
                    Cost = Decimal.Parse(txbCost.Text),
                    Service_Name = txbService_Name.Text,
                    Service_Status = Boolean.Parse(status),
                    Employee = db.Employees.FirstOrDefault(x => x.ID_Employee == employee.ID_Employee)
                };

                db.Services.Update(service);
                db.SaveChanges();
                clearRows();
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            Service service = Services[dtg.SelectedIndex];
            if (service != null)
            {
                Services.Remove(service);
                db.Services.Remove(service);
                db.SaveChanges();
            }
        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            Service service = e.Row.Item as Service;

            if (service != null)
            {
                db.Services.Update(service);
                db.SaveChanges();
            }
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


        public void clearRows()
        {
            txbCost.Text = "";
            txbService_Name.Text = "";
            cmbStatuses.SelectedItem = null;
            cmbEmployees.SelectedItem = null;
        }
    }
}
