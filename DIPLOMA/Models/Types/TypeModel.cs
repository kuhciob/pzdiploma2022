using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIPLOMA.Models
{
    public class TypeModel : BaseModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }

        [Display(Name = "Type")]
        public string CD { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
