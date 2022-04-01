using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DIPLOMA.Models
{
    public class DonateMsg : BaseModel
    {
        public int? ID { get; set; }
        [Required]
        public string UserID { get; set; }
        [Display(Name = "Amount")]
        [DataType(DataType.Currency)]
        [Required]
        public decimal? Amount { get; set; }

        [Display(Name = "Donator name")]
        [Required]
        [DefaultValue("")]
        public string DonatorName { get; set; }
        [Display(Name = "Message")]
        public string Message { get; set; }
        [Display(Name = "Read")]
        public bool Read { get; set; }


        public ApplicationUser User { get; set; }
    }
}
