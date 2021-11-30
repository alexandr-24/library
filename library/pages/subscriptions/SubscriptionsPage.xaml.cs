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
    /// Логика взаимодействия для SubscriptionsPage.xaml
    /// </summary>
    public partial class SubscriptionsPage : Page
    {
        public SubscriptionsPage()
        {
            InitializeComponent();
            DG.ItemsSource = libraryEntities.GetContext().Subscription.ToList();
        }
        private void Grid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                libraryEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DG.ItemsSource = libraryEntities.GetContext().Subscription.ToList();
            }
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new Add_Edit_SubscriptionsPage(null);
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new Add_Edit_SubscriptionsPage((sender as Button).DataContext as Subscription);
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var subscriptionsToRemove = DG.SelectedItems.Cast<Subscription>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {subscriptionsToRemove.Count()} элементов?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    libraryEntities.GetContext().Subscription.RemoveRange(subscriptionsToRemove);
                    libraryEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DG.ItemsSource = libraryEntities.GetContext().Subscription.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
