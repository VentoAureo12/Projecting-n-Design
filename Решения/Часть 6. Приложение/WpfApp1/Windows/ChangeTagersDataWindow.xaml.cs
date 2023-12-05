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

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для ChangeTagersDataWindow.xaml
    /// </summary>
    public partial class ChangeTagersDataWindow : Window
    {
        public ChangeTagersDataWindow()
        {
            InitializeComponent();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // Логика редактирования
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Логика удаления
        }

        private void AddTaggerButton_Click(object sender, RoutedEventArgs e)
        {
            // Логика добавления нового тагера
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
