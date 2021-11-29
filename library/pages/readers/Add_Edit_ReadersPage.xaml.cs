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
    /// Логика взаимодействия для Add_Edit_ReadersPage.xaml
    /// </summary>
    public partial class Add_Edit_ReadersPage : Page
    {
        private Reader _currentReader = new Reader();
        public Add_Edit_ReadersPage(Reader selectedReader)
        {
            InitializeComponent();
            if (selectedReader != null)
                _currentReader = selectedReader;

            DataContext = _currentReader;
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new ReadersPage();
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentReader.Surname))
                errors.AppendLine("Введите фамилию");
            if (string.IsNullOrWhiteSpace(_currentReader.Name))
                errors.AppendLine("Введите имя");
            if (string.IsNullOrWhiteSpace(_currentReader.Middle_name))
                errors.AppendLine("Введите отчество");
            if (_currentReader.Birthday == null)
                errors.AppendLine("Введите дату рождения");
            if (string.IsNullOrWhiteSpace(_currentReader.Passport_data))
                errors.AppendLine("Введите паспортные данные");
            if (string.IsNullOrWhiteSpace(_currentReader.Address))
                errors.AppendLine("Введите адрес");
            if (string.IsNullOrWhiteSpace(_currentReader.Contact_number))
                errors.AppendLine("Введите контактный телефон");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentReader.ID_Reader == 0)
                libraryEntities.GetContext().Reader.Add(_currentReader);

            try
            {
                libraryEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.Content = new ReadersPage();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
                
        }
    }
}
