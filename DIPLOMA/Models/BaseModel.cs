using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DIPLOMA.Models
{
    public class BaseModel
    {
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Created Date")]
        public DateTime UpdatedDate { get; set; }
    }
}
