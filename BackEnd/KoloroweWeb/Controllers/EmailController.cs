namespace KoloroweWeb.Controllers
{
    using System.Net;
    using System.Net.Mail;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        [HttpPost("send")]
        public IActionResult SendEmail([FromBody] EmailRequest emailRequest)
        {
            if (emailRequest == null || string.IsNullOrWhiteSpace(emailRequest.Message))
            {
                return BadRequest("Invalid email request.");
            }

            try
            {
                var smtpClient = new SmtpClient("smtp.your-email-provider.com")
                {
                    Port = 587, 
                    Credentials = new NetworkCredential("your-email@example.com", "your-email-password"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("your-email@example.com"),
                    Subject = emailRequest.Subject,
                    Body = emailRequest.Message,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add("your-destination-email@example.com");

                smtpClient.Send(mailMessage);

                return Ok("Email sent successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

    public class EmailRequest
    {
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
