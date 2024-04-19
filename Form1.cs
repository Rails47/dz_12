using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace EmailSender
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string fromEmail = txtFrom.Text.Trim();
                string toEmail = txtTo.Text.Trim();
                string subject = txtSubject.Text.Trim();
                string body = txtBody.Text.Trim();
                string smtpServer = "your_smtp_server";
                int smtpPort = 587; 
                string smtpUsername = "your_smtp_username";
                string smtpPassword = "your_smtp_password";

                using (MailMessage mail = new MailMessage(fromEmail, toEmail))
                {
                    mail.Subject = subject;
                    mail.Body = body;

                    using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
                    {
                        smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                        smtpClient.EnableSsl = true;

                        smtpClient.Send(mail);
                    }
                }

                MessageBox.Show("Email sent successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
