using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plebis.Identity.Services
{
    public class FakeEmailSender : IEmailSender
    {
        readonly ILogger<FakeEmailSender> logger;
        public FakeEmailSender(ILogger<FakeEmailSender> logger)
        {
            this.logger = logger;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            logger.LogInformation("Sending email to {email} with subject {subject} and content {content}", email, subject, htmlMessage);
            return Task.CompletedTask;
        }
    }
}
