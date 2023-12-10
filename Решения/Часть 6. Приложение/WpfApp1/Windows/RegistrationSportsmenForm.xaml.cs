using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для RegistrationSportsmenForm.xaml
    /// </summary>
    public partial class RegistrationSportsmenForm : Window
    {
        private GarnizonEntities dbContext;
        public RegistrationSportsmenForm()
        {
            InitializeComponent();
            dbContext = GarnizonEntities.GetContext();
            SportsmenDataGrid.ItemsSource = dbContext.Cпортсмен.ToList();
            TagerDataGrid.ItemsSource = dbContext.Тагер.ToList();
            TeamsDataGrid.ItemsSource = dbContext.Команда.ToList();
            TrainingDataGrid.ItemsSource = dbContext.Тренировка.ToList();
        }

        private void SnapBackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            int sportsmenID;
            int tagerID;
            int teamID;
            int trainingID;

            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите отправить данные?",
                                                     "Подтверждение сохранения", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (string.IsNullOrEmpty(SportsmenIDTextBox.Text))
                {
                    MessageBox.Show("Значение поля ID спортсмена оказалось пустым");
                    return;
                }

                if (string.IsNullOrEmpty(TagerIDTextBox.Text))
                {
                    MessageBox.Show("Значение поля ID тагера оказалось пустым");
                    return;
                }

                if (string.IsNullOrEmpty(TeamIDTextBox.Text))
                {
                    MessageBox.Show("Значение поля ID команды оказалось пустым");
                    return;
                }

                if (string.IsNullOrEmpty(TrainingIDTextBox.Text))
                {
                    MessageBox.Show("Значение поля ID команды оказалось пустым");
                    return;
                }

                sportsmenID = int.Parse(SportsmenIDTextBox.Text);
                tagerID = int.Parse(TagerIDTextBox.Text);
                teamID = int.Parse(TeamIDTextBox.Text);
                trainingID = int.Parse(TrainingIDTextBox.Text);

                Cпортсмен_Тренировка training = new Cпортсмен_Тренировка()
                {
                    Код_команды = teamID,
                    Код_спортсмена = sportsmenID,
                    Код_тагера = tagerID,
                    Код_тренировки = trainingID
                };
                try
                {
                    dbContext.Cпортсмен_Тренировка.Add(training);
                    dbContext.SaveChanges();
                    MessageBox.Show("Данные сохранены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}");
                }
            }
            else
            {
                return;
            }

        }
        private void NumericTextBox_OnPreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Запрет на введение чего-то кроме чисел
            Regex regex = new Regex("[^0-9]+");
            bool isNumeric = !regex.IsMatch(e.Text);
            if (!isNumeric)
            {
                // Отображаем сообщение об ошибке через MessageBox
                MessageBox.Show("Для данного поля доступен ввод только числовых значений", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // Обрабатываем ввод, только если это не число
            e.Handled = !isNumeric;
        }
    }
}
