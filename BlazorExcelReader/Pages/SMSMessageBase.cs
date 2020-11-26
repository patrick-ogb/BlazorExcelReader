using BlazorExcelReader.Models;
using BlazorExcelReader.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorExcelReader.Pages
{
    public class SMSMessageBase : ComponentBase
    {
        [Inject]
        public SmsService SmsService { get; set; }
        [Inject]
        IJSRuntime JS { get; set; }
        public SMSModel SmsModel { get; set; } = new SMSModel();

        protected string To;
        protected string From;
        protected string Text;
        protected string MessageId;
        protected string ConfirmationMessage;
        protected async Task SendSms()
        {
            var response = SmsService.SendSms(SmsModel);
            MessageId = response.Messages[0].MessageId;
           ConfirmationMessage = response.Messages.ToString();
            await JS.InvokeAsync<object>("alert", "Successful login!");
        }


        public EmailModel model { get; set; } = new EmailModel();
        protected async Task SendEmail()
        {
            await JS.InvokeAsync<object>("alert", "Successful login!");
        }
    }
}
