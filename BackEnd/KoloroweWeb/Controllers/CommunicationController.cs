using KoloroweWeb.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace KoloroweWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommunicationController : ControllerBase
    {
        [HttpPost]
        public IActionResult Send([FromBody] EmailRequest emailRequest)
        {
            SendEmail("warwelong@gmail.com", emailRequest.Subject, emailRequest.Message);
            return Ok("Success");
        }

        private void SendEmail(string email, string subject, string messageBody)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("FromName", "warwelong@gmail.com"));
            message.To.Add(new MailboxAddress("ToName", email));
            message.Subject = subject;
            message.Body = new TextPart("plain") { Text = messageBody };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate("warwelong@gmail.com", "vjtf akka choy ldou");
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
