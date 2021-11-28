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

using library.classes;

namespace library.pages.books
{
    /// <summary>
    /// Логика взаимодействия для BooksPage.xaml
    /// </summary>
    public partial class BooksPage : Page
    {
        public BooksPage()
        {
            InitializeComponent();
            DG.ItemsSource = libraryEntities.GetContext().Book.ToList();
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                libraryEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DG.ItemsSource = libraryEntities.GetContext().Book.ToList();
            }
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new Add_Edit_BooksPage(null);
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new Add_Edit_BooksPage((sender as Button).DataContext as Book);
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var booksToRemove = DG.SelectedItems.Cast<Book>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {booksToRemove.Count()} элементов?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    libraryEntities.GetContext().Book.RemoveRange(booksToRemove);
                    libraryEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
