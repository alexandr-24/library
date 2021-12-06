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

namespace library.pages.fines
{
    /// <summary>
    /// Логика взаимодействия для FinesPage.xaml
    /// </summary>
    public partial class FinesPage : Page
    {
        public FinesPage()
        {
            InitializeComponent();
            DG.ItemsSource = libraryEntities.GetContext().Fine.ToList();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new Select_Sub_FinesPage();
        }
    }
}
