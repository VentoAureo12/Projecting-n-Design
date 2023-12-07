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
    /// Логика взаимодействия для ResultsToTableForm.xaml
    /// </summary>
    public partial class ResultsToTableForm : Window
    {
        public GarnizonEntities dbContext;
        public ResultsToTableForm()
        {
            InitializeComponent();
            dbContext = GarnizonEntities.GetContext();
            SportsmenDataGrid.ItemsSource = dbContext.Cпортсмен.ToList();
            ResultsDataGrid.ItemsSource = dbContext.Результат_тренировки.Where(u => u.Перенесено == false).ToList();

        }

        private void SendDataButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите отправить данные?",
                                                     "Подтверждение сохранения", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    int sportsmenID;
                    int resultID;

                    if (string.IsNullOrEmpty(SportsmenID_Box.Text))
                    {
                        MessageBox.Show("Значение поля ID спортсмена оказалось пустым");
                        return;
                    }

                    if (string.IsNullOrEmpty(ResultID_Box.Text))
                    {
                        MessageBox.Show("Значение поля ID результата оказалось пустым");
                        return;
                    }

                    sportsmenID = int.Parse(SportsmenID_Box.Text);

                    var existingSportsman = dbContext.Cпортсмен.FirstOrDefault(s => s.Код_спортсмена == sportsmenID);

                    if (existingSportsman == null)
                    {
                        MessageBox.Show("Спортсмен с указанным ID не найден.");
                        return;
                    }


                    resultID = int.Parse(ResultID_Box.Text);

                    var existingResult = dbContext.Результат_тренировки.FirstOrDefault(s => s.Код_результата_тренировки == resultID);

                    if (existingSportsman == null)
                    {
                        MessageBox.Show("Результат с указанным ID не найден.");
                        return;
                    }

                    var результатПеренесено = dbContext.Результат_тренировки.Find(resultID);

                    if (результатПеренесено.Перенесено == true)
                    {
                        MessageBox.Show("Данный результат уже был перенесён в таблицу результатов. Повторно переносит один и тот же результат запрещено");
                        return;
                    }

                    var результатыТренировки = dbContext.Результат_тренировки
                    .Where(р => р.Код_спортсмена == sportsmenID && р.Код_результата_тренировки == resultID)
                    .ToList();

                    // Подготовьте переменные для хранения суммарных значений
                    int общееКоличествоПопаданий = 0;
                    int общееКоличествоЗахваченныхТочек = 0;
                    int общееКоличествоУстранений = 0;

                    foreach (var результат in результатыТренировки)
                    {
                        общееКоличествоПопаданий += результат.Количество_попаданий ?? 0;
                        общееКоличествоЗахваченныхТочек += результат.Количество_захваченных_точек ?? 0;
                        общееКоличествоУстранений += результат.Количество_устранений ?? 0;
                    }

                    var спортсменНомер = dbContext.Таблица_результатов.Where(p => p.Код_спортсмена == sportsmenID).FirstOrDefault();

                    спортсменНомер.Общее_количество_попаданий += общееКоличествоПопаданий;
                    спортсменНомер.Общее_количество_захваченных_точек += общееКоличествоЗахваченныхТочек;
                    спортсменНомер.Общее_количество_устранений += общееКоличествоУстранений;

                    // Если запись найдена, изменяем атрибут и сохраняем изменения.
                    if (результатПеренесено != null)
                    {
                        if (результатПеренесено.Перенесено == false)
                        {
                            результатПеренесено.Перенесено = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Результат оказался пустым");
                        return;
                    }

                    MessageBox.Show("Изменения сохранены");
                    dbContext.SaveChanges();
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

        private void SnapBackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
