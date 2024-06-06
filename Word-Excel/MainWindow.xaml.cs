using System.Windows;
using Microsoft.WindowsAPICodePack.Dialogs;
using Spire.Doc;

namespace Word_Excel
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void createWordFile_Click(object sender, RoutedEventArgs e)
        {
            WordWindow wordWindow = new WordWindow("");
            wordWindow.Show();
        }

        private void openWordFile_Click(object sender, RoutedEventArgs e)
        {
            OpenWordFile();
        }

        private void OpenWordFile()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.Filters.Add(new CommonFileDialogFilter("Word файл", "*.docx;*.doc"));
            dialog.Title = "Выберите Word-файл";

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string path = dialog.FileName;
                Document doc = new Document();
                doc.LoadFromFile(dialog.FileName);
                doc.SaveToFile(dialog.FileName, FileFormat.Rtf);

                WordWindow wordWindow = new WordWindow(path);
                wordWindow.LoadRtfFile(dialog.FileName);
                wordWindow.Show();
            }
        }

        private void createExcelFile_Click(object sender, RoutedEventArgs e)
        {
            ExcelWindow excelWindow = new ExcelWindow();
            excelWindow.Show();
        }

        private void openExcelFile_Click(object sender, RoutedEventArgs e)
        {
            ExcelWindow excelWindow = new ExcelWindow();
            excelWindow.Show();
        }
    }
}