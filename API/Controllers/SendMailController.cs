using API.Services.SendMailService;
using Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMailController : ControllerBase
    {
        private readonly IMailService emailSender;
        public SendMailController(IMailService emailSender)
        {
            this.emailSender = emailSender;
        }

        [HttpPost]
        public async Task<IActionResult> SendMail([FromForm]MailRequest request)
        {
            try
            {
                await emailSender.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex) {
                throw;
            }
        }

    }
}
