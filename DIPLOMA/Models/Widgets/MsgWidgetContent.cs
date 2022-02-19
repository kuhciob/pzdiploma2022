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
    public class MsgWidgetContent
    {
        public int? ID { get; set; }
        public Guid? MsgWidgetID { get; set; }
        [Display(Name = "Animation")]
        public Guid? AnimationFileId { get; set; }
        [Display(Name = "Sound")]
        public Guid? SoundFileId { get; set; }

        public MsgWidget MsgWidget { get; set; }
        [Display(Name = "Amination")]
        public UploadFile Animation { get; set; }
        [Display(Name = "Sound")]

        public UploadFile Sound { get; set; }

        [Display(Name = "Animation")]
        [NotMapped]
        [JsonIgnore]
        public IFormFile AnimFormFile { get; set; }
        [Display(Name = "Animation")]
        [NotMapped]
        [JsonIgnore]
        public string AnimSrc { get; set; }
        [Display(Name = "Sound")]
        [NotMapped]
        [JsonIgnore]
        public IFormFile SoundFormFile { get; set; }
        [Display(Name = "Sound")]
        [NotMapped]
        [JsonIgnore]
        public string SoundSrc { get; set; }
    }
}
