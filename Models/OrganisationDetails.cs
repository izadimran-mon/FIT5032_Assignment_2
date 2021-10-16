using Microsoft.AspNetCore.Identity;
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

        [ForeignKey("UserId")]
        public virtual IdentityUser User { get; set; }

        [Required(ErrorMessage = "Please enter the organisation's URL.")]
        [Display(Name = "Organisation URL")]
        [MaxLength(100)]
        public string Org_URL { get; set; }

        [Required(ErrorMessage = "Please enter a dateline for the fund raising.")]
        public DateTime Dateline { get; set; }

        [Required(ErrorMessage = "Please enter the organisation's name.")]
        [Display(Name = "Organisation Name")]
        [MaxLength(60)]
        public string Org_Name { get; set; }

        [Required(ErrorMessage = "Please enter the project's title.")]
        [Display(Name = "Project Title")]
        [MaxLength(40)]
        public string Project_Title{ get; set; }

        [Required(ErrorMessage = "Please enter the description of the project.")]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter the target amount to be raised.")]
        [Display(Name = "Target Amount")]
        public int Target_Amount { get; set; }

    }
}
