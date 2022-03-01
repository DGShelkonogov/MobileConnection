﻿using MobileConnection.Models;
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
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        ApplicationContext db;
        public ObservableCollection<Employee> Employees { get; set; }

        public List<Post> posts { get; set; }


        public EmployeePage()
        {
            InitializeComponent();

            db = DBConnection.getConnection();
            Employees = new(db.Employees.ToList());
            posts = new(db.Posts.ToList());

            cmbPosts.ItemsSource = posts;
            dtg.ItemsSource = Employees;
        }


        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            AdminHomeWindow win = (AdminHomeWindow)Window.GetWindow(this);
            win.btnBack_Click_Back();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            Post post = cmbPosts.SelectedItem as Post;

            Employee employee = new Employee
            {
                Employee_Surname = tbxSurname.Text,
                Employee_Email = tbxEmail.Text,
                Employee_Name = tbxName.Text,
                Employee_Patronymic = tbxPatronymic.Text,
                Password = tbxPassword.Password,
                Post = db.Posts.FirstOrDefault(x => x.ID_Post == post.ID_Post)
            };

            Employees.Add(employee);
            db.Employees.Add(employee);
            db.SaveChanges();
            clearRows();
        }


        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            Employee employee = Employees[dtg.SelectedIndex];
            if (employee != null)
            {
                Post post = cmbPosts.SelectedItem as Post;
                employee = new Employee
                {
                    Employee_Surname = tbxSurname.Text,
                    Employee_Email = tbxEmail.Text,
                    Employee_Name = tbxName.Text,
                    Employee_Patronymic = tbxPatronymic.Text,
                    Password = tbxPassword.Password,
                    Post = db.Posts.FirstOrDefault(x => x.ID_Post == post.ID_Post)
                };

                db.Employees.Update(employee);
                db.SaveChanges();
                clearRows();
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            Employee employee = Employees[dtg.SelectedIndex];
            if (employee != null)
            {
                Employees.Remove(employee);
                db.Employees.Remove(employee);
                db.SaveChanges();
            }
        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            Employee employee = e.Row.Item as Employee;


            if (employee != null)
            {
                db.Employees.Update(employee);
                db.SaveChanges();
            }
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Employee employee = Employees[dtg.SelectedIndex];
            if (employee != null)
            {
                tbxSurname.Text = employee.Employee_Surname;
                tbxEmail.Text = employee.Employee_Email;
                tbxName.Text = employee.Employee_Name;
                tbxPatronymic.Text = employee.Employee_Patronymic;
                tbxPassword.Password = employee.Password;
                cmbPosts.SelectedItem = employee.Post;
            }
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            string search = txbSearch.Text;
            if (search == null)
            {
                Employees = new(db.Employees.ToList());
                dtg.ItemsSource = Employees;
                return;
            }
            Employees = new(db.Employees
                .Where(
                x => x.Employee_Name.Contains(search) 
                || x.Employee_Surname.Contains(search)
                || x.Employee_Email.Contains(search)
                || x.Employee_Patronymic.Contains(search))
                .ToList());
            dtg.ItemsSource = Employees;
        }

        public void clearRows()
        {
            tbxSurname.Text = "";
            tbxEmail.Text = "";
            tbxName.Text = "";
            tbxPatronymic.Text = "";
            tbxPassword.Password = "";
            cmbPosts.SelectedItem = null;
        }
    }
}
