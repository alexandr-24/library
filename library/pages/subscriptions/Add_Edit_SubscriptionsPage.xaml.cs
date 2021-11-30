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

namespace library.pages.subscriptions
{
    /// <summary>
    /// Логика взаимодействия для Add_Edit_SubscriptionsPage.xaml
    /// </summary>
    public partial class Add_Edit_SubscriptionsPage : Page
    {
        private Subscription _currentSubscriprtion = new Subscription();
        bool add = false;

        public Add_Edit_SubscriptionsPage(Subscription selectedSubscription)
        {
            InitializeComponent();
            Book_CB.ItemsSource = libraryEntities.GetContext().Book.ToList();
            Reader_CB.ItemsSource = libraryEntities.GetContext().Reader.ToList();

            if (selectedSubscription != null)
                _currentSubscriprtion = selectedSubscription;
            else add = true;

            DataContext = _currentSubscriprtion;
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentSubscriprtion.Book == null)
                errors.AppendLine("Выберете книгу");
            if (_currentSubscriprtion.Reader == null)
                errors.AppendLine("Выберете читателя");
            if (_currentSubscriprtion.Date_of_issue == null)
                errors.AppendLine("Выберете дату выдачи");
            if (string.IsNullOrWhiteSpace (Convert.ToString (_currentSubscriprtion.Return_period)))
                errors.AppendLine("Введите срок возврата");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (add == true)
            {
                libraryEntities.GetContext().Subscription.Add(_currentSubscriprtion);
            }

            try
            {
                libraryEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.Content = new SubscriptionsPage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new SubscriptionsPage();
        }
    }
}
