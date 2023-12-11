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
    /// Логика взаимодействия для ChangeTeamsDataWindow.xaml
    /// </summary>
    public partial class ChangeTeamsDataWindow : Window
    {
        public GarnizonEntities dbContext;
        public ChangeTeamsDataWindow()
        {
            InitializeComponent();
            dbContext = GarnizonEntities.GetContext();
            TeamsDataGrid.ItemsSource = dbContext.Команда.ToList();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = TeamsDataGrid.SelectedItems.Cast<Команда>().ToList();

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
                            dbContext.Команда.Attach(selectedItem);
                            dbContext.Команда.Remove(selectedItem);
                        }

                        // Сохраняем изменения в базе данных
                        dbContext.SaveChanges();


                        // Обновляем DataGrid
                        TeamsDataGrid.ItemsSource = null;
                        TeamsDataGrid.ItemsSource = dbContext.Команда.ToList();
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

        private void AddTeamButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите добавить команду?",
                                                    "Подтверждение сохранения", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Команда teamData = new Команда()
                {
                    Наименование_команды = "Введите название"
                };
                dbContext.Команда.Add(teamData);
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
                TeamsDataGrid.ItemsSource = null;
                TeamsDataGrid.ItemsSource = dbContext.Команда.ToList();
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
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            TeamsDataGrid.IsReadOnly = false;
            TeamsDataGrid.BeginEdit();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchTerm = SearchTextBox.Text.ToLower();

            var data = dbContext.Команда.ToList(); 

            var filteredData = data.Where(item =>
                item.Наименование_команды.ToLower().Contains(searchTerm)
                ).ToList();

            // Обновите ItemsSource вашего DataGrid
            TeamsDataGrid.ItemsSource = filteredData;
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
                TeamsDataGrid.IsReadOnly = true;
                
            }
            else
            {
                return;
            }
        }
    }
}