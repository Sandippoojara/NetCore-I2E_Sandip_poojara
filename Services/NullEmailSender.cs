using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace NetCore_I2E_Sandip_poojara.Services
{
    public class NullEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Do nothing for development
            return Task.CompletedTask;
        }
    }
}
