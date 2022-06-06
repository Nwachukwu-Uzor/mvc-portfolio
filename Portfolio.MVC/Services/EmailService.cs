using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Portfolio.MVC.Contracts;
using Portfolio.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.MVC.Services
{
    public class EmailService : IEmailService
    {
        private readonly MailJetConfig _options;

        public EmailService(IOptions<MailJetConfig> options)
        {
            _options = options.Value;
        }

        public async Task SendMail(EmailViewModel model)
        {
            MailjetClient client = new MailjetClient(_options.ApiKey, _options.Secret);
            MailjetRequest request = new MailjetRequest
            {
                Resource = SendV31.Resource,
            }
                .Property(Send.Messages, new JArray {
                new JObject {
                 {"From", new JObject {
                  {"Email", "uzor.nwachukwu@thebulbafrica.institute"},
                  {"Name", "Portfolio Website"}
                  }},
                 {"To", new JArray {
                  new JObject {
                   {"Email", "uzor1997@gmail.com"},
                   {"Name", "User"}
                   }
                  }},
                 {"Subject", model.Subject},
                 {"TextPart", "New Request From Portfolio"},
                 {"HTMLPart", $"<h3>From : {model.Name} <br /> Details: {model.Phone},  {model.Email}  <br /> Message : {model.Message} </h3>"}
                 }
                });
            MailjetResponse response = await client.PostAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                throw new ArgumentException("Unable to send mail");
            }
        }
    }
}
