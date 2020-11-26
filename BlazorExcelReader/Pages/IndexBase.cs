using BlazorExcelReader.Data;
using BlazorExcelReader.Models;
using BlazorExcelReader.Services;
using BlazorInputFile;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Radzen;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorExcelReader.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        public NotificationService notificationService { get; set; }
        public List<Student> students { get; set; } = new List<Student>();
        [Inject]
        public ISaveToDB saveToDB { get; set; }
        [Inject]
        public IRetrieveExcel retrieveExcel { get; set; }
        [Inject]
        public IFileUpload FileUpload { get; set; }

        public Student Student { get; set; } = new Student();
        public ResponseVM response { get; set; }
        public bool IsTrue { get; set; } = false;
        public bool UnChoose {get;set;} = false;
        [Inject]
        public FileContents FileContents { get; set; }

        protected void ReadExcel()
        {
            students =  retrieveExcel.ReadExcel();
            IsTrue = true;
        }

        protected IFileListEntry file;
        protected void HandleFileUpload(IFileListEntry[] files)
        {
            UnChoose = files.Any() ? true : false;
            if (files.Any())
            {
               file = files.FirstOrDefault();
                FileUpload.UploadAsync(file);
                FileContents.Filesize = file.Size;
                FileContents.Filename = file.Name;
            }
        }
        protected void Cancel()
        {
            bool delete = true;
            FileUpload.DeleteAsync(delete, FileContents.Filename);
            navigationManager.NavigateTo("/", true);
            IsTrue = false;
        }
        protected async Task UploadLoad()
        {
            NotificationMessage message = new NotificationMessage();
            var result = await saveToDB.Save();
            message = NotificationMessageHelper.Failure();
            if (result.IsSuccess)
            {
                IsTrue = false;
                bool delete = true;
                message = NotificationMessageHelper.CreateSuccess();
               await FileUpload.DeleteAsync(delete, FileContents.Filename);
                navigationManager.NavigateTo("/", true);
            }
            notificationService.Notify(message);
        }
    }
}
