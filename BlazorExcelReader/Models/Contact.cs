using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorExcelReader.Models
{
    public class Contact
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Telephone { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string CompanyId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string CityTown { get; set; }
        public string StateCounty { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string CustomField1 { get; set; }
        public string CustomField2 { get; set; }
    }
}
