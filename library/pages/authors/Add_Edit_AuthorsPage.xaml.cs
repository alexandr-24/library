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

namespace library.pages.authors
{
    /// <summary>
    /// Логика взаимодействия для Add_Edit_AuthorsPage.xaml
    /// </summary>
    public partial class Add_Edit_AuthorsPage : Page
    {
        private Author _currentAuthor = new Author();

        public Add_Edit_AuthorsPage(Author selectedAuthor)
        {
            InitializeComponent();
            if (selectedAuthor != null)
                _currentAuthor = selectedAuthor;

            DataContext = _currentAuthor;
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new AuthorsPage();
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentAuthor.Surname))
                errors.AppendLine("Введите фамилию");
            if (string.IsNullOrWhiteSpace(_currentAuthor.Name))
                errors.AppendLine("Введите имя");
            if (_currentAuthor.Birthday.Date == null)
                errors.AppendLine("Введите дату рождения");
            if (string.IsNullOrWhiteSpace(_currentAuthor.Nationality))
                errors.AppendLine("Введите национальность");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentAuthor.ID_Author == 0)
                libraryEntities.GetContext().Author.Add(_currentAuthor);

            try
            {
                libraryEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.Content = new AuthorsPage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
