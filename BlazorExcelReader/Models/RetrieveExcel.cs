using BlazorExcelReader.Data;
using Microsoft.AspNetCore.Hosting;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BlazorExcelReader.Models
{
    public class RetrieveExcel : IRetrieveExcel
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public string fileContentName { get; set; }
        public FileContents _fileContents { get; }

        public RetrieveExcel(FileContents fileContents,
            IWebHostEnvironment webHostEnvironment)
        {
            _fileContents = fileContents;
            this.webHostEnvironment = webHostEnvironment;
        }

        public  List<Student> ReadExcel()
        {
            ResponseVM response = new ResponseVM();
            FileInfo existingFile = new FileInfo(_fileContents.Filename);
            var path = Path.GetFullPath(existingFile.FullName);
            var fileDir = path.Split("\\");
            string fullDir = "";
            for (int i = 0; i < fileDir.Length - 1; i++)
            {
                fullDir = fullDir + fileDir[i] + "/";
            }
            fullDir = fullDir + "Files/" + _fileContents.Filename;

            var ext = existingFile.Extension;
             List<Student> students = new List<Student>();

            if(ext == ".xlsx")
            {
                FileInfo existingfile = new FileInfo(fullDir);

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage(existingfile))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    var sheets = package.Workbook.Worksheets;
                    
                    int colCount = worksheet.Dimension.End.Column;
                    int rowCount = worksheet.Dimension.End.Row;

                    //bool result = true;
                    string error = string.Empty;
                    ExcelWorksheet worksheet1 = package.Workbook.Worksheets.First();
                    int totalRows = worksheet1.Dimension == null ? -1 : worksheet.Dimension.End.Row; //worksheet total rows
                    int totalCols = worksheet1.Dimension == null ? -1 : worksheet.Dimension.End.Column; // total columns


                    for (int row = 1; row <= rowCount; row++)
                    {
                        Student student = new Student();
                        for (int col = 1; col <= colCount; col++)
                        {
                           
                           if (col == 1)
                               if(worksheet.Cells[row,col] != null)
                                {
                                    student.FirstName = worksheet.Cells[row, col].Value == null ? "a" : worksheet.Cells[row, col].Value.ToString();
                                }

                           else if (col == 2)
                                    if(worksheet.Cells[row,col] != null)
                                    {
                                        student.LastName = worksheet.Cells[row, col].Value == null ? "b" : worksheet.Cells[row, col].Value.ToString();
                                    }
                            bool RowIsEmpty = true;

                            
                                //check if the cell is empty or not
                                if (worksheet.Cells[row, col].Value != null)
                                {
                                    RowIsEmpty = false;
                                }

                        }
                        students.Add(student);
                    }
                }
            }
                return students;
        }
    }
}
