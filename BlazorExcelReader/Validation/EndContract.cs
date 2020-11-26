using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorExcelReader.Validation
{
    public class EndContract
    {
            [Key]
            public string iRow { get; set; }
            public string Customer { get; set; }
            public string Item { get; set; }
            public string CustomerItem { get; set; }
            public string ItemType { get; set; }
            public DateTime ContractDate { get; set; }
            public Nullable<decimal> cost { get; set; }
            public Nullable<decimal> price { get; set; }
            public Nullable<decimal> gm { get; set; }
            public string Currency { get; set; }
            public int seqCnt { get; set; }
            public Nullable<decimal> TotalShipped { get; set; }

        public class vmEndContracts
        {
            public List<EndContract> EndContract_List { get; set; }
        }
    }
}



