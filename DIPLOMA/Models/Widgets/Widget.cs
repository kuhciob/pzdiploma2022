using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DIPLOMA.Models
{
    public class Widget : BaseModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        //public int ID { get; set; }
        [Required]
        [Display(Name = "UserID")]

        public string UserID { get; set; }
        [Display(Name = "Name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Display(Name = "Url")]
        [MaxLength(2000)]
        public string Url { get; set; }
        [Display(Name = "User")]
        public ApplicationUser User { get; set; }
    }
}
