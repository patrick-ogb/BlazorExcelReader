using BlazorExcelReader.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vonage.Messaging;
using Vonage.Request;

namespace BlazorExcelReader.Services
{
    public class SmsService
    {
        public IConfiguration Configuration { get; set; }
        public SmsService(IConfiguration config)
        {
            Configuration = config;
        }

        public SendSmsResponse SendSms(SMSModel model)
        {
                var creds = Credentials.FromApiKeyAndSecret("e6ed1f15", "Msv2IF8QTTnOYzkN");
                var client = new SmsClient(creds);
            SendSmsRequest request = new SendSmsRequest();
            if (!string.IsNullOrWhiteSpace(model.ToNumber) || !string.IsNullOrWhiteSpace(model.SMSText)){
                request = new SendSmsRequest
                {
                    To = model.ToNumber,
                    From = "Sir Noble LTD",
                    Text = model.SMSText
                };
            }
                return client.SendAnSms(request);
        }

    }
}
