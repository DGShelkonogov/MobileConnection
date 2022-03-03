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

        private static Post _saveEditPost;

        /// <summary>
        /// Импорт данных из БД, заполнение DataGrid
        /// </summary>
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
            try
            {
                Post post = new Post
                {
                    Post_Name = tbxTitle.Text.ToString(),
                };

                if (ApplicationContext.validData(post))
                {
                    Posts.Add(post);
                    db.Posts.Add(post);
                    db.SaveChanges();
                    tbxTitle.Text = "";
                }
            }
            catch (Exception ex) { }
        }


        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            try
            {
                Post post = Posts[dtg.SelectedIndex];
                if (post != null)
                {
                    post.Post_Name = tbxTitle.Text.ToString();

                    if (ApplicationContext.validData(post))
                    {
                        db.Posts.Update(post);
                        db.SaveChanges();
                        tbxTitle.Text = "";

                        Posts = new(db.Posts.ToList());
                        dtg.ItemsSource = Posts;
                    }
                    else
                    {
                        post.Post_Name = _saveEditPost.Post_Name;
                    }
                }
            }
            catch (Exception ex) { }
        }


        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                Post post = Posts[dtg.SelectedIndex];
                if (post != null)
                {
                    Posts.Remove(post);
                    db.Posts.Remove(post);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }


        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                Post post = e.Row.Item as Post;
                if (post != null)
                {
                    if (ApplicationContext.validData(post))
                    {
                        db.Posts.Update(post);
                        db.SaveChanges();
                    }
                    else
                    {
                        post.Post_Name = _saveEditPost.Post_Name;
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
                Posts = new(db.Posts.ToList());
                dtg.ItemsSource = Posts;
                return;
            }
            Posts = new(db.Posts
                .Where(x => x.Post_Name.Contains(search))
                .ToList());
             dtg.ItemsSource = Posts;
        }


        private void dtg_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var item = Posts[dtg.SelectedIndex];
                _saveEditPost = new Post(item);
                setData(item);
            }
            catch (Exception ex) { }
        }


        /// <summary>
        /// заполнение UI элементов данными существующего обьекта
        /// </summary>
        /// <param name="post">источник даных</param>
        public void setData(Post post)
        {
            tbxTitle.Text = post.Post_Name;
        }
    }
}
