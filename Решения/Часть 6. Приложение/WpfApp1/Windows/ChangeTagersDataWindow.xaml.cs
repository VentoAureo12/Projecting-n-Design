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
        public GarnizonEntities dbContext;
        public ChangeTagersDataWindow()
        {
            InitializeComponent();
            dbContext = GarnizonEntities.GetContext();
            TaggerDataGrid.ItemsSource = dbContext.Тагер.ToList();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            TaggerDataGrid.IsReadOnly = false;
            TaggerDataGrid.BeginEdit();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = TaggerDataGrid.SelectedItems.Cast<Тагер>().ToList();

            if (selectedItems.Count > 0)
            {
                string confirmationMessage = $"Вы уверены, что хотите удалить {selectedItems.Count} записей ?";

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
                            dbContext.Тагер.Attach(selectedItem);
                            dbContext.Тагер.Remove(selectedItem);
                        }

                        // Сохраняем изменения в базе данных
                        dbContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении записей: {ex.Message}");
                    }
                    TaggerDataGrid.ItemsSource = null;
                    TaggerDataGrid.ItemsSource = dbContext.Тагер.ToList();
                }
                else
                {
                    MessageBox.Show("Выберите записи для удаления.");
                }
            }
        }
        private void AddTaggerButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите добавить новый тагер?",
                                                     "Подтверждение сохранения", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Тагер tagerData = new Тагер()
                {
                    Наименование = "Введите название"
                };
                dbContext.Тагер.Add(tagerData);
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
                TaggerDataGrid.ItemsSource = null;
                TaggerDataGrid.ItemsSource = dbContext.Тагер.ToList();
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
            var data = dbContext.Тагер.ToList(); // Замените YourEntity на реальное имя вашей сущности

            // Выполните поиск по всем полям сущности
            var filteredData = data.Where(item =>
                item.Наименование.ToLower().Contains(searchTerm)
                ).ToList();

            // Обновите ItemsSource вашего DataGrid
            TaggerDataGrid.ItemsSource = filteredData;
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
                TaggerDataGrid.IsReadOnly = true;
            }
            else
            {
                return;
            }
        }
    }
}
