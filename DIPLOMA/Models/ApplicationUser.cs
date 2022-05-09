using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIPLOMA.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }
        [StringLength(20)]
        //[Unique(ErrorMessage = "This already exist !!")]
        public string NickName { get; set; }
        
        public UserProfile UserProfile { get; set; }
        public virtual ICollection<DonateMsg> DonateMsgs { get; set; }
        public virtual ICollection<MsgWidget> MsgWidgets { get; set; }
        public virtual ICollection<StatisticWidget> StatisticWidgets { get; set; }
        public virtual ICollection<FundraisingWidget> FundraisingWidgets { get; set; }
    }
}
