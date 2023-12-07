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
    /// Логика взаимодействия для ChangeResultsDataWindow.xaml
    /// </summary>
    public partial class ChangeResultsDataWindow : Window
    {
        public GarnizonEntities dbContext;
        public ChangeResultsDataWindow()
        {
            InitializeComponent();
            dbContext = GarnizonEntities.GetContext();
        }

        private void AddResultButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите добавить новый результат?",
                                                     "Подтверждение сохранения", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Результат_тренировки resultData = new Результат_тренировки()
                {
                   Код_тренировки = 1,
                   Код_спортсмена = 1,
                   Количество_попаданий = 0,
                   Количество_захваченных_точек = 0,
                   Количество_устранений = 0,
                   Перенесено = false
                };
                dbContext.Результат_тренировки.Add(resultData);
                try
                {
                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}");
                    {
                        MessageBox.Show("Команда добавлена");
                    }
                }
                ResultsDataGrid.ItemsSource = null;
                ResultsDataGrid.ItemsSource = dbContext.Результат_тренировки.ToList();
            }
            else
            {
                return;
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            ResultsDataGrid.IsReadOnly = false;
            ResultsDataGrid.BeginEdit();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = ResultsDataGrid.SelectedItems.Cast<Результат_тренировки>().ToList();

            if (selectedItems.Count > 0)
            {
                string confirmationMessage = $"Вы уверены, что хотите удалить {selectedItems.Count} записей?";

                // Отображаем диалоговое окно для подтверждения удаления
                MessageBoxResult result = MessageBox.Show(confirmationMessage, "Подтверждение удаления",
                                                          MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                            // Помечаем записи на удаление
                            foreach (var selectedItem in selectedItems)
                            {
                                dbContext.Результат_тренировки.Attach(selectedItem);
                                dbContext.Результат_тренировки.Remove(selectedItem);
                            }

                            // Сохраняем изменения в базе данных
                            dbContext.SaveChanges();
                        

                        // Обновляем DataGrid
                        ResultsDataGrid.ItemsSource = null;
                        ResultsDataGrid.ItemsSource = dbContext.Результат_тренировки.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении записей: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите записи для удаления.");
            }
        }

        private void SnapBackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите сохранить изменения?",
                                                  "Подтверждение сохранения", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}");
                }
                MessageBox.Show("Изменения сохранены");
                ResultsDataGrid.IsReadOnly = true;

            }
            else
            {
                return;
            }
        }
    }
}
