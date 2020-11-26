using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorExcelReader.Data
{
    public class ResponseVM
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int NumberOfRowsInserted { get; set; }
        public bool Status { get; set; }
    }
}
