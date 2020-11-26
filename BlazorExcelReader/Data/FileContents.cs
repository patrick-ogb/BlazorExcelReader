using BlazorExcelReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorExcelReader.Data
{
    public class FileContents
    {
        public string Filename { get; set; }
        public long Filesize { get; set; }
    }
}
