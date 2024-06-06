using Microsoft.WindowsAPICodePack.Dialogs;
using Spire.Doc;
using System.IO;
using System.Windows;
using System.Windows.Documents;

namespace Word_Excel
{
    public partial class WordWindow : Window
    {
        public string path;
        public WordWindow(string path)
        {
            InitializeComponent();
            this.path = path;
        }

        private void sendEmail_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();

            SendEmail sendEmail = new SendEmail(path);
            sendEmail.Show();
        }

        private void saveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }

        private bool SaveFile()
        {
            CommonSaveFileDialog dialog = new CommonSaveFileDialog();
            dialog.Filters.Add(new CommonFileDialogFilter("Word файл", "*.docx"));

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string fileName = dialog.FileName;

                if (!fileName.EndsWith(".docx"))
                {
                    fileName += ".docx";
                }

                var range = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                using (var fs = new FileStream(fileName, FileMode.Create))
                {
                    range.Save(fs, DataFormats.Rtf);
                }

                Document document = new Document();
                document.LoadFromFile(fileName);
                document.SaveToFile(fileName, FileFormat.Docx);

                path = fileName;

                return true;
            }

            return false;
        }

        public void LoadRtfFile(string filePath)
        {
            var range = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
            var fs = new FileStream(filePath, FileMode.OpenOrCreate);
            range.Load(fs, DataFormats.Rtf);
            fs.Close ();
            
        }
    }
}