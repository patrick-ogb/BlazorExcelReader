using BlazorExcelReader.Data;
using BlazorExcelReader.Services;
using BlazorInputFile;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;

namespace BlazorExcelReader.Models
{
    public  class SaveToDB : ISaveToDB, IFileUpload
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        public IFileListEntry fileEnt { get; set; }
        public static SqlConConfig conn;
        private readonly IRetrieveExcel retrieveExcel;
        SqlConnection connection;
        public SaveToDB(SqlConConfig connect, IRetrieveExcel retrieveExcel,
            IWebHostEnvironment webHostEnvironment)
        {
            conn = connect;
            this.retrieveExcel = retrieveExcel;
            connection = new SqlConnection(conn.Value);
            this.webHostEnvironment = webHostEnvironment;
        }

        ResponseVM response = new ResponseVM();
        public async Task<ResponseVM> Save()
        {
            List<Student> students = new List<Student>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "sptblStdnt_Insert";
                cmd.CommandType = CommandType.StoredProcedure;
                students = retrieveExcel.ReadExcel();
                connection.Open();

                SqlBulkCopy objbulk = new SqlBulkCopy(connection);
                DataTable Extbl = new DataTable();
                Extbl.Columns.Add("FirstName");
                Extbl.Columns.Add("LastName");


                foreach (Student stu in students)
                {
                    DataRow dr = Extbl.NewRow();
                    dr["FirstName"] = stu.FirstName;
                    dr["LastName"] = stu.LastName;
                    Extbl.Rows.Add(dr);

                    string fName = "";
                    switch (fName)
                    {
                        case "a":
                            response.Status = false;
                            break;
                        case "b":
                            response.Status = false;
                            break;
                        default:
                            response.Status = true;
                            break;
                    }
                }

                objbulk.DestinationTableName = "tblStdnt";
                objbulk.ColumnMappings.Add("FirstName", "FirstName");
                objbulk.ColumnMappings.Add("LastName", "LastName");

               if(students != null)
                {
                    await objbulk.WriteToServerAsync(Extbl);
                    response.IsSuccess = true;
                }
            }
            catch (System.Exception e)
            {
                e.ToString();
                response.Message = e.Message;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return response;
        }

        public async Task UploadAsync(IFileListEntry file)
        {
            var path = Path.Combine(webHostEnvironment.ContentRootPath, "Files", file.Name);
            var ms = new MemoryStream();
            await file.Data.CopyToAsync(ms);
            using (FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                ms.WriteTo(filestream);
            }
            fileEnt = file;
        }

        public async Task DeleteAsync(bool delete, string fileName)
        {
            if (delete)
            {
                var path = Path.Combine(webHostEnvironment.ContentRootPath, "Files", fileName);
                var uri = new Uri(path);
                System.IO.File.Delete(uri.LocalPath);
                await fileEnt.Data.DisposeAsync();

            }
        }
    }
}
