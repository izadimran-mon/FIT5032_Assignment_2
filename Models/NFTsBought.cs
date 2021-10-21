using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FIT5032_Assignment_2.Models
{
    [Table("NFTsBought")]
    public class NFTsBought
    {
        [Key]
        [Display(Name = "Transaction Hash")]
        public string Tx_Hash { get; set; }

        [Required(ErrorMessage = "Please key in the address you bought with.")]
        [Display(Name = "Buyer's ETH Address")]
        public string Buyer_Address { get; set; }

        [MaxLength(450)]
        public string OrgId { get; set; }

        [ForeignKey("OrgId")]
        public virtual IdentityUser User { get; set; }

        public string NFT_URL { get; set; }

        [Display(Name = "Bought For (ETH)")]
        public float Sold_For { get; set; }

    }
}
