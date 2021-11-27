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
    }
}
