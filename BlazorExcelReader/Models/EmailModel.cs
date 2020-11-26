using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorExcelReader.Models
{
    public class EmailModel
    {
        [Required]
        public string ToEmail { get; set; }
        [Required]
        public string   FromEmail { get; set; }
        [Required]
        public string EmailContent { get; set; }
        [Required]
        public string Subject { get; set; }
    }
}
