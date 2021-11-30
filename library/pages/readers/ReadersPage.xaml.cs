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

namespace library.pages.readers
{
    /// <summary>
    /// Логика взаимодействия для ReadersPage.xaml
    /// </summary>
    public partial class ReadersPage : Page
    {
        public ReadersPage()
        {
            InitializeComponent();
            DG.ItemsSource = libraryEntities.GetContext().Reader.ToList();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new Add_Edit_ReadersPage(null);
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var ReadersToRemove = DG.SelectedItems.Cast<Reader>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {ReadersToRemove.Count()} элементов?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    libraryEntities.GetContext().Reader.RemoveRange(ReadersToRemove);
                    libraryEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DG.ItemsSource = libraryEntities.GetContext().Reader.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new Add_Edit_ReadersPage((sender as Button).DataContext as Reader);
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                libraryEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DG.ItemsSource = libraryEntities.GetContext().Reader.ToList();
            }
        }
    }
}
