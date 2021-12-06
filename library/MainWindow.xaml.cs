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
using library.pages.home;
using library.pages.authors;
using library.pages.books;
using library.pages.readers;
using library.pages.subscriptions;
using library.pages.fines;

namespace library
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Сбросить стиль всех кнопок
        /// </summary>
        private void setNotActiveButton()
        {
            Home_Button.Style = (Style)Home_Button.FindResource("notActiveButton");
            Author_Button.Style = (Style)Author_Button.FindResource("notActiveButton");
            Book_Button.Style = (Style)Book_Button.FindResource("notActiveButton");
            Reader_Button.Style = (Style)Reader_Button.FindResource("notActiveButton");
            Subscription_Button.Style = (Style)Subscription_Button.FindResource("notActiveButton");
            Fine_Button.Style = (Style)Fine_Button.FindResource("notActiveButton");
        }
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new HomePage();
            Manager.MainFrame = MainFrame;
        }
        private void Home_Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new HomePage();
            setNotActiveButton();
            Home_Button.Style = (Style)Home_Button.FindResource("isActiveButton");
        }
        private void Author_Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new AuthorsPage();
            setNotActiveButton();
            Author_Button.Style = (Style)Author_Button.FindResource("isActiveButton");
        }

        private void Book_Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new BooksPage();
            setNotActiveButton();
            Book_Button.Style = (Style)Book_Button.FindResource("isActiveButton");
        }

        private void Reader_Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new ReadersPage();
            setNotActiveButton();
            Reader_Button.Style = (Style)Reader_Button.FindResource("isActiveButton");
        }

        private void Subscription_Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new SubscriptionsPage();
            setNotActiveButton();
            Subscription_Button.Style = (Style)Subscription_Button.FindResource("isActiveButton");
        }

        private void Fine_Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new FinesPage();
            setNotActiveButton();
            Fine_Button.Style = (Style)Subscription_Button.FindResource("isActiveButton");
        }
    }
}
