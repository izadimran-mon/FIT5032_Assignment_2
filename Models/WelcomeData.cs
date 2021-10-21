using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT5032_Assignment_2.Models
{
    public class WelcomeData
    {
        public double AppRating { get; set; }

        public Dictionary<DateTime, float> ChartData { get; set; }
    }
}
