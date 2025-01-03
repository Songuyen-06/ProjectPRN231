
namespace EduCore.Web.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            //var emailMessage = new MimeMessage();
            //emailMessage.From.Add(new MailboxAddress("Your App Name", _configuration["EmailSettings:Username"]));
            //emailMessage.To.Add(new MailboxAddress("", email));
            //emailMessage.Subject = subject;
            //emailMessage.Body = new TextPart("html") { Text = message };

            //using (var client = new SmtpClient())
            //{
            //    // Kết nối đến SMTP server
            //    await client.ConnectAsync(_configuration["EmailSettings:SmtpServer"],
            //                              int.Parse(_configuration["EmailSettings:Port"]),
            //                              MailKit.Security.SecureSocketOptions.StartTls);

            //    // Xác thực người dùng
            //    await client.AuthenticateAsync(_configuration["EmailSettings:Username"],
            //                                    _configuration["EmailSettings:Password"]);

            //    // Gửi email
            //    await client.SendAsync(emailMessage);
            //    await client.DisconnectAsync(true);
            }
        }
    }
