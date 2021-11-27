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
    }
}
