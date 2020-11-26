using OfficeOpenXml;
using OfficeOpenXml.DataValidation;
using OfficeOpenXml.DataValidation.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorExcelReader.Validation
{
    public class DatavalidationList
    {
        public void ExcelDataValidation()
        {
            using (var package = new ExcelPackage())
            {
                var sheet = package.Workbook.Worksheets.Add("Validation");

                var list1 = sheet.Cells["C7"].DataValidation.AddListDataValidation();
                list1.Formula.Values.Add("Apples");
                list1.Formula.Values.Add("Oranges");
                list1.Formula.Values.Add("Lemons");

                // Or load from another sheet
                //package.Workbook.Worksheets.Add("OtherSheet");
                //list1.Formula.ExcelFormula = "OtherSheet!A1:A4";

                list1.ShowErrorMessage = true;
                list1.Error = "We only have those available :(";

                list1.ShowInputMessage = true;
                list1.PromptTitle = "Choose your juice";
                list1.Prompt = "Apples, oranges or lemons?";

                list1.AllowBlank = true;

                sheet.Cells["C7"].Value = "Pick";
                package.SaveAs(new FileInfo(@""));
            }

        }
        public void DataVList()
        {
            string path = "";
            using (var package = new ExcelPackage(new FileInfo(path)))
            {
                var sheet = package.Workbook.Worksheets[1];
                var validations = sheet.DataValidations;
                foreach (var validation in validations)
                {
                    var list = validation as ExcelDataValidationList;
                    if (list != null)
                    {
                        var range = sheet.Cells[list.Formula.ExcelFormula];
                        var rowStart = range.Start.Row;
                        var rowEnd = range.End.Row;
                        // allowed values probably only in one column....
                        var colStart = range.Start.Column;
                        var colEnd = range.End.Column;
                        for (int row = rowStart; row <= rowEnd; ++row)
                        {
                            for (int col = colStart; col <= colEnd; col++)
                            {
                                Console.WriteLine(sheet.Cells[row, col].Value);
                            }
                        }
                    }
                }
            }
        }
        public void IntegerValidation()
        {
            using (var package = new ExcelPackage())
            {
                var sheet = package.Workbook.Worksheets.Add("intsAndSuch");

                // Integer validation
                IExcelDataValidationInt intValidation = sheet.DataValidations.AddIntegerValidation("A1");
                intValidation.Prompt = "Value between 1 and 5";
                intValidation.Operator = ExcelDataValidationOperator.between;
                intValidation.Formula.Value = 1;
                intValidation.Formula2.Value = 5;

                // DateTime validation
                IExcelDataValidationDateTime dateTimeValidation = sheet.DataValidations.AddDateTimeValidation("A2");
                dateTimeValidation.Prompt = "A date greater than today";
                dateTimeValidation.Operator = ExcelDataValidationOperator.greaterThan;
                dateTimeValidation.Formula.Value = DateTime.Now.Date;

                // Time validation
                IExcelDataValidationTime timeValidation = sheet.DataValidations.AddTimeValidation("A3");
                timeValidation.Operator = ExcelDataValidationOperator.greaterThan;
                var time = timeValidation.Formula.Value;
                time.Hour = 13;
                time.Minute = 30;
                time.Second = 10;

                // Existing validations
                var validations = package.Workbook.Worksheets.SelectMany(sheet1 => sheet1.DataValidations);

                package.SaveAs(new FileInfo(@""));
            }
        }
    }
}
