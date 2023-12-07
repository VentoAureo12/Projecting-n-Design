using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Win32;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ReportForm.xaml
    /// </summary>
    public partial class ReportForm : Window
    {
        public GarnizonEntities dbContext;
        public ReportForm()
        {
            InitializeComponent();
            dbContext = GarnizonEntities.GetContext();
            SportsmenDataGrid.ItemsSource = dbContext.Cпортсмен.ToList();
            TrainingDataGrid.ItemsSource = dbContext.Тренировка.ToList();
        }

        private void SnapBackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
        public void CreateReportButton_Click(object sender, RoutedEventArgs e)
        {
            string formattedDate;
            string tempFilePath = "ReportTemp.docx";
            int sportsmanID;
            int trainingID;

            if (string.IsNullOrEmpty(SportsmanIDTextBox.Text))
            {
                MessageBox.Show("Значение поля ID спортсмена оказалось пустым");
                return;
            }

            if (string.IsNullOrEmpty(TrainingIDTextBox.Text))
            {
                MessageBox.Show("Значение поля ID результата оказалось пустым");
                return;
            }

            sportsmanID = int.Parse(SportsmanIDTextBox.Text);
            trainingID = int.Parse(TrainingIDTextBox.Text);

            // Получение данных из базы данных
            var sportsman = dbContext.Cпортсмен.FirstOrDefault(s => s.Код_спортсмена == sportsmanID);

            if (sportsman == null)
            {
                Console.WriteLine("Спортсмен не найден");
                return;
            }

            var results = dbContext.Результат_тренировки
                .Where(r => r.Код_спортсмена == sportsmanID && r.Код_тренировки == trainingID)
                .ToList();

            if (results.Count == 0)
            {
                Console.WriteLine("Результаты тренировки не найдены");
                return;
            }

            using (WordprocessingDocument doc = WordprocessingDocument.Create(tempFilePath, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = doc.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());

                // Добавление заголовка
                Paragraph titleParagraph = body.AppendChild(new Paragraph());
                Run titleRun = titleParagraph.AppendChild(new Run());
                titleRun.AppendChild(new Text("Отчёт о результатах спортсмена"));

                // Добавление данных о спортсмене
                Paragraph sportsmanInfoParagraph = body.AppendChild(new Paragraph());
                Run sportsmanInfoRun = sportsmanInfoParagraph.AppendChild(new Run());
                sportsmanInfoRun.AppendChild(new Text($"Фамилия: {sportsman.Фамилия} Имя: {sportsman.Имя} Отчество: {sportsman.Отчество}"));

                // Добавление данных о тренировке
                var firstResult = results.FirstOrDefault(); // Берем данные из первого результата
                Paragraph trainingInfoParagraph = body.AppendChild(new Paragraph());
                Run trainingInfoRun = trainingInfoParagraph.AppendChild(new Run());
                formattedDate = string.Format("{0:dd.MM.yyyy}", firstResult.Тренировка.Дата_тренировки);
                trainingInfoRun.AppendChild(new Text($"Дата тренировки: {formattedDate} Время тренировки: {firstResult.Тренировка.Время_тренировки}"));

                // Добавление данных о результатах тренировок
                foreach (var result in results)
                {
                    Paragraph resultParagraph = body.AppendChild(new Paragraph());
                    Run resultRun = resultParagraph.AppendChild(new Run());
                    resultRun.AppendChild(new Text($"Количество попаданий: {result.Количество_попаданий} попаданий"));
                    resultRun.AppendChild(new Break());
                    resultRun.AppendChild(new Text($"Количество захваченных точек: {result.Количество_захваченных_точек} точек"));
                    resultRun.AppendChild(new Break());
                    resultRun.AppendChild(new Text($"Количество устранений: {result.Количество_устранений} устранений"));
                    resultRun.AppendChild(new Break());
                }
                doc.Close();
                string filePath = GetSavePath(sportsman.Фамилия, sportsman.Имя, sportsman.Отчество, formattedDate);
                if (filePath != null)
                {
                    // Сохранение документа по указанному пути
                    File.Copy(tempFilePath, filePath, true);
                    Console.WriteLine("Отчёт успешно создан и сохранен.");
                }
                else
                {
                    Console.WriteLine("Создание отчёта отменено.");
                }
            }
            File.Delete(tempFilePath);
        }
        private string GetSavePath(string surname, string name, string patronic, string date)
        {
            surname = surname.Trim();
            name = name.Trim();
            patronic = patronic.Trim();
            date = date.Trim();
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Word Documents|*.docx",
                DefaultExt = "docx",
                AddExtension = true,
                FileName = $"Отчёт по спортсмену {surname} {name} {patronic} от {date}"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                return saveFileDialog.FileName;
            }

            return null;
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
