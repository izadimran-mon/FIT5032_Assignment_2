using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FIT5032_Assignment_2.Models
{
    [Table("NFTsDonated")]
    public class NFTsDonated
    {
        [Key]
        public string Tx_Hash { get; set; }

        [Required(ErrorMessage = "Please key in the address you bought with.")]
        public string Donor_Address { get; set; }

        [MaxLength(450)]
        public string OrgId { get; set; }

        [ForeignKey("OrgId")]
        public virtual IdentityUser User { get; set; }

        [Required]
        public string NFT_URL { get; set; }

        [ForeignKey("NFTsBought")]
        public virtual string Bought_Tx { get; set; }
        public virtual NFTsBought NFTsBought { get; set; }

        [Required]
        public float List_Price { get; set; }
    }
}
