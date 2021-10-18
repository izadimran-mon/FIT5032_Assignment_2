using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT5032_Assignment_2.Models
{
    public class DataGrid
    {
        public string OrgId { get; set; }
        public string ProjectTitle { get; set; }
        public string Organisation { get; set; }
        public string Organisation_URL { get; set; }
        public float AmountFunded { get; set; }
        public int TargetAmount { get; set; }

        public DateTime Dateline { get; set; }
    }
}
