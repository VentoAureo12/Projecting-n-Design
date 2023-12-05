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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ResultsToTableForm.xaml
    /// </summary>
    public partial class ResultsToTableForm : Window
    {
        private GarnizonEntities dbContext;
        public ResultsToTableForm()
        {
            InitializeComponent();
            dbContext = GarnizonEntities.GetContext();
            SportsmenDataGrid.ItemsSource = dbContext.Cпортсмен.ToList();
            
        }

        private void SendDataButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
