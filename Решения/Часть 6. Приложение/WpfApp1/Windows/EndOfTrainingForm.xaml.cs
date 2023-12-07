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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для EndOfTrainingForm.xaml
    /// </summary>
    public partial class EndOfTrainingForm : Window
    {
        public GarnizonEntities dbContext;
        public EndOfTrainingForm()
        {
            InitializeComponent();
            dbContext = GarnizonEntities.GetContext();
            SportsmenDataGrid.ItemsSource = dbContext.Cпортсмен.ToList();
            TrainingDataGrid.ItemsSource = dbContext.Тренировка.ToList();
        }

        private void SendDataButton_Click(object sender, RoutedEventArgs e)
        {
            int trainingID;
            int sportsmenID;
            string reason;
            string time = DateTime.Now.ToString("HH:mm");

            if (string.IsNullOrEmpty(SportsmenIDTextBox.Text))
            {
                MessageBox.Show("Значение поля ID спортсмена оказалось пустым");
                return;
            }
            if (string.IsNullOrEmpty(TrainingIDTextBox.Text))
            {
                MessageBox.Show("Значение поля ID тренировки оказалось пустым");
                return;
            }
            if (string.IsNullOrEmpty(ReasonTextBox.Text))
            {
                MessageBox.Show("Значение поля причины оказалось пустым");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите отправить данные?",
                                                     "Подтверждение сохранения", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                sportsmenID = int.Parse(SportsmenIDTextBox.Text);
                trainingID = int.Parse(TrainingIDTextBox.Text);
                TimeSpan? formattedTime = TimeSpan.Parse(time);
                reason = ReasonTextBox.Text;

                var existingSportsman = dbContext.Cпортсмен.FirstOrDefault(s => s.Код_спортсмена == sportsmenID);

                if (existingSportsman == null)
                {
                    MessageBox.Show("Спортсмен с указанным ID не найден.");
                    return;
                }

                var existingTraining = dbContext.Cпортсмен.FirstOrDefault(s => s.Код_спортсмена == trainingID);

                if (existingTraining == null)
                {
                    MessageBox.Show("Тренировка с указанным ID не найден.");
                    return;
                }



                Окончанная_тренировка endTraining = new Окончанная_тренировка()
                {
                    Код_тренировки = trainingID,
                    Код_спортсмена = sportsmenID,
                    Время_окончания = formattedTime,
                    Причина = reason
                };
                try
                {
                    dbContext.Окончанная_тренировка.Add(endTraining);
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

        private void SnapBackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
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

        private void TextBoxButton_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    e.Handled = true; // Отменить ввод
                    MessageBox.Show("Для данного поля доступны только буквы и пробел.");
                    return;
                }
            }
        }
    }
}
