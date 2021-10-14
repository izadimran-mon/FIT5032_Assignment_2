using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FIT5032_Assignment_2.Models
{
    [Table("OrganisationDetails")]
    public class OrganisationDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        [MaxLength(450)]
        public string UserId { get; set; }

        [MaxLength(100)]
        public string Org_URL { get; set; }

        public DateTime? Dateline { get; set; }

        [MaxLength(60)]
        public string Org_Name { get; set; }

        [MaxLength(40)]
        public string Project_Title{ get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public int Target_Amount { get; set; }

    }
}
