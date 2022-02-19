using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DIPLOMA.Models
{
    public class UploadFile : BaseModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [Display(Name = "Name")]
        [MaxLength(200)]
        public string Name { get; set; }
        [Display(Name = "Extension")]
        [MaxLength(20)]
        public string Extension { get; set; }
        [Display(Name = "Data")]
        public byte[] Data { get; set; }
        
        public virtual ICollection<MsgWidgetContent> MsgWidgetContentSound { get; set; }
        public virtual ICollection<MsgWidgetContent> MsgWidgetContentAnimation{ get; set; }

       

    }
}
