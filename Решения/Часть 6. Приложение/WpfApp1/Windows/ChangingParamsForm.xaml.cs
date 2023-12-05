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
using System.Windows.Shapes;
using WpfApp1.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ChangingParamsForm.xaml
    /// </summary>
    public partial class ChangingParamsForm : Window
    {
        public ChangingParamsForm()
        {
            InitializeComponent();
        }

        private void ChangeTagersDataButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeTagersDataWindow window = new ChangeTagersDataWindow();
            window.Show();
            this.Close();
        }

        private void ChangeResultsDataButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeResultsDataWindow window = new ChangeResultsDataWindow();
            window.Show();
            this.Close();
        }

        private void ChangeSportsmenDataButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeSportsmenDataWindow window = new ChangeSportsmenDataWindow();
            window.Show();
            this.Close();
        }

        private void ChangeTeamsDataButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeTeamsDataWindow window = new ChangeTeamsDataWindow();
            window.Show();
            this.Close();
        }
    }
}
