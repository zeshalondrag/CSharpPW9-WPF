using System.Net;
using System.Net.Mail;
using System.Windows;

namespace Word_Excel
{
    public partial class SendEmail : Window
    {
        public string path;
        public SendEmail(string path)
        {
            InitializeComponent();
            this.path = path;
            
        }

        private void send_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MailMessage message = new MailMessage(from.Text, to.Text, subject.Text, "Круто!");
                message.Attachments.Add(new Attachment(path));
            
                string smtpServer = string.Empty;
                int port;
            
                if (from.Text.EndsWith("@gmail.com"))
                {
                    smtpServer = "smtp.gmail.com";
                    port = 587;
                }
                else if (from.Text.EndsWith("@mail.ru") || from.Text.EndsWith("@xmail.ru"))
                {
                    smtpServer = "smtp.mail.ru";
                    port = 587;
                }
                else if (from.Text.EndsWith("@rambler.ru"))
                {
                    smtpServer = "smtp.rambler.ru";
                    port = 25;
                }
                else if (from.Text.EndsWith("@yandex.ru"))
                {
                    smtpServer = "smtp.yandex.ru";
                    port = 25;
                }
                else
                {
                    MessageBox.Show("Неизвестный домен почтового сервиса.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            
                SmtpClient client = new SmtpClient(smtpServer, port);
                client.Credentials = new NetworkCredential(from.Text, password.Text);
                client.EnableSsl = true;
                client.Send(message);
            
                MessageBox.Show("Письмо успешно отправлено!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отправке письма: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}