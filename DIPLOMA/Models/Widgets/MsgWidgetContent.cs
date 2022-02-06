using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DIPLOMA.Models
{
    public class MsgWidgetContent
    {
        public int? ID { get; set; }
        public Guid? MsgWidgetID { get; set; }
        [Display(Name = "Amination")]
        public Guid? AminationFileId { get; set; }
        [Display(Name = "Sound")]
        public Guid? SoundFileId { get; set; }

        public MsgWidget MsgWidget { get; set; }
        [Display(Name = "Amination")]
        public UploadFile Amination { get; set; }
        [Display(Name = "Sound")]

        public UploadFile Sound { get; set; }

    }
}
