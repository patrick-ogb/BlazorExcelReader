using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace BlazorExcelReader.Models
{
    public class Student
    {
        public  string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string FullName => $"{this.FirstName} {this.LastName}";
        
        public IWebHostEnvironment webHostEnvironment { get; }
        public IFormFile File { get; }

        
    }
}
