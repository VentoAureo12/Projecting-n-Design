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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChangeParamsButton_Click(object sender, RoutedEventArgs e)
        {
            ChangingParamsForm window = new ChangingParamsForm();
            window.Show();
            this.Close();
        }

        private void RegistrationOnTrainingButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationSportsmenForm window = new RegistrationSportsmenForm();
            window.Show();
            this.Close();
        }

        private void EndingOfTrainingButton_Click(object sender, RoutedEventArgs e)
        {
            EndOfTrainingForm window = new EndOfTrainingForm();
            window.Show();
            this.Close();
        }

        private void ReportFormingButton_Click(object sender, RoutedEventArgs e)
        {
            ReportForm window = new ReportForm();
            window.Show();
            this.Close();
        }

        private void ResultSendButton_Click(object sender, RoutedEventArgs e)
        {
            ResultsToTableForm window = new ResultsToTableForm();
            window.Show();
            this.Close();
        }
    }
}
