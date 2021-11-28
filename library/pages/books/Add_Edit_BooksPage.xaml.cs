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
    /// Логика взаимодействия для Add_Edit_BooksPage.xaml
    /// </summary>
    public partial class Add_Edit_BooksPage : Page
    {
        private Book _currentBook = new Book();

        public Add_Edit_BooksPage(Book selectedBook)
        {
            InitializeComponent();
            Author_TB.ItemsSource = libraryEntities.GetContext().Author.ToList();

            if (selectedBook != null)
                _currentBook = selectedBook;

            DataContext = _currentBook;
        }
        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new BooksPage();
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentBook.Author == null)
                errors.AppendLine("Выберете автора");
            if (string.IsNullOrWhiteSpace(_currentBook.Name))
                errors.AppendLine("Введите название книги");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentBook.Year_of_publishing)))
                errors.AppendLine("Введите год публикации");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentBook.Number_of_pages)))
                errors.AppendLine("Введите количество страниц");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentBook.Publisher)))
                errors.AppendLine("Введите издание");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentBook.ID_Book == 0)
                libraryEntities.GetContext().Book.Add(_currentBook);

            try
            {
                libraryEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.Content = new BooksPage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
