using BlazorInputFile;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorExcelReader.Services
{
   public interface IFileUpload
    {
        Task UploadAsync(IFileListEntry file);
        Task DeleteAsync(bool delete, string fileName);
    }
}
