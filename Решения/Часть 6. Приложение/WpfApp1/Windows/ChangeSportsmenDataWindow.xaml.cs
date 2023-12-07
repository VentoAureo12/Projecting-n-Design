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
    /// Логика взаимодействия для ChangeSportsmenDataWindow.xaml
    /// </summary>
    public partial class ChangeSportsmenDataWindow : Window
    {
        public GarnizonEntities dbContext;
        public ChangeSportsmenDataWindow()
        {
            InitializeComponent();
            dbContext = GarnizonEntities.GetContext();
            SportsmenDataGrid.ItemsSource = dbContext.Cпортсмен.ToList();
        }

        private void AddSportsmenButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите добавить нового спортсмена?",
                                                     "Подтверждение сохранения", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Cпортсмен sportsmanData = new Cпортсмен()
                {
                    Имя = "Иван",
                    Фамилия = "Иванов",
                    Отчество = "Иванович",
                    Дата_рождения = DateTime.Parse("1999/09/09"),
                    Телефон = 123456789
                };
                dbContext.Cпортсмен.Add(sportsmanData);
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
                SportsmenDataGrid.ItemsSource = null;
                SportsmenDataGrid.ItemsSource = dbContext.Cпортсмен.ToList();
            }
            else
            {
                return;
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            SportsmenDataGrid.IsReadOnly = false;
            SportsmenDataGrid.BeginEdit();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = SportsmenDataGrid.SelectedItems.Cast<Cпортсмен>().ToList();

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
                            dbContext.Cпортсмен.Attach(selectedItem);
                            dbContext.Cпортсмен.Remove(selectedItem);
                        }

                        // Сохраняем изменения в базе данных
                        dbContext.SaveChanges();


                        // Обновляем DataGrid
                        SportsmenDataGrid.ItemsSource = null;
                        SportsmenDataGrid.ItemsSource = dbContext.Тагер.ToList();
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
                SportsmenDataGrid.IsReadOnly = true;
            }
            else
            {
                return;
            }
        }



        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchTerm = SearchTextBox.Text.ToLower(); // Преобразуйте введенный текст в нижний регистр для регистронезависимого поиска

            // Получите данные из вашей EDM модели
            var data = dbContext.Cпортсмен.ToList(); // Замените YourEntity на реальное имя вашей сущности

            // Выполните поиск по всем полям сущности
            var filteredData = data.Where(item =>
                item.Фамилия.ToLower().Contains(searchTerm) ||
                item.Телефон.ToString().Contains(searchTerm)
                ).ToList();

            // Обновите ItemsSource вашего DataGrid
            SportsmenDataGrid.ItemsSource = filteredData;
        }
    }
}
