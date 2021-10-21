﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT5032_Assignment_2.Models
{
    public class OrganisationPage
    {
        public string OrgId { get; set; }
        public string ProjectTitle { get; set; }
        public string Organisation { get; set; }
        public string Organisation_URL { get; set; }
        public string Description { get; set; }
        public float AmountFunded { get; set; }
        public int TargetAmount { get; set; }
        public int RemainingDays { get; set; }
        public Dictionary <String, String> NFT_URL_Donor { get; set; }
    }
}
