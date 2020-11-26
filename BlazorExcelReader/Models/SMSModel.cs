using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorExcelReader.Models
{
    public class SMSModel
    {
        [Required]
        public string ToNumber { get; set; }
        [Required]
        public string SMSText { get; set; }
    }
}
