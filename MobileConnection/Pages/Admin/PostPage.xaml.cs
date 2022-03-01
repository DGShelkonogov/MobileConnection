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
    /// Логика взаимодействия для PostPage.xaml
    /// </summary>
    public partial class PostPage : Page
    {
        ApplicationContext db;
        public ObservableCollection<Post> Posts { get; set; }
        public PostPage()
        {
            InitializeComponent();

            db = DBConnection.getConnection();

            Posts = new(db.Posts.ToList());
            dtg.ItemsSource = Posts;
        }

       
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            AdminHomeWindow win = (AdminHomeWindow)Window.GetWindow(this);
            win.btnBack_Click_Back();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            Post post = new Post
            {
                Post_Name = tbxTitle.Text.ToString(),
            };
            Posts.Add(post);
            db.Posts.Add(post);
            db.SaveChanges();
            tbxTitle.Text = "";
        }

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            Post post = Posts[dtg.SelectedIndex];
            if (post != null)
            {
                post.Post_Name = tbxTitle.Text.ToString();
                db.Posts.Update(post);
                db.SaveChanges();
                tbxTitle.Text = "";
            }      
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            Post post = Posts[dtg.SelectedIndex];
            if (post != null)
            {
                Posts.Remove(post);
                db.Posts.Remove(post);
                db.SaveChanges();
            }
        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            Post post = e.Row.Item as Post;
            
            if (post != null)
            {
                db.Posts.Update(post);
                db.SaveChanges();
            }
        }



        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Post post = Posts[dtg.SelectedIndex];
            if (post != null)
                tbxTitle.Text = post.Post_Name;
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            string search = txbSearch.Text;
            if (search == null)
            {
                Posts = new(db.Posts.ToList());
                dtg.ItemsSource = Posts;
                return;
            }
            Posts = new(db.Posts
                .Where(x => x.Post_Name.Contains(search))
                .ToList());
             dtg.ItemsSource = Posts;
        }
    }
}
