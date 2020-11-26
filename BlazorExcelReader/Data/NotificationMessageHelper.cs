using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorExcelReader.Data
{
    public class NotificationMessageHelper
    {
        public static NotificationMessage CreateSuccess()
        {
            return new NotificationMessage
            {
                Severity = NotificationSeverity.Success,
                Detail = "Data Saved Successfully",
                Duration = 4000,
                Summary = "Success",
            };
        }
        public static NotificationMessage Failure()
        {
            return new NotificationMessage
            {
                Severity = NotificationSeverity.Error,
                Detail = $"Unable to save into database",
                Duration = 4000,
                Summary = "Delete",
            };
        }
    }
}
