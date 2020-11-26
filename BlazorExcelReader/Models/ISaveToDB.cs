using BlazorExcelReader.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorExcelReader.Models
{
    public interface ISaveToDB
    {
        Task<ResponseVM> Save();
    }
}
