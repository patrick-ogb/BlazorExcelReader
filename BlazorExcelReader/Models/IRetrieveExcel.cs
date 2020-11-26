using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorExcelReader.Models
{
    public interface IRetrieveExcel
    {
        List<Student> ReadExcel();
    }
}
