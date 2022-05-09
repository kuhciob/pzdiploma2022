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
    public class UserProfile
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [Display(Name = "Profile Url")]
        [MaxLength(2000)]
        [NotMapped]
        [JsonIgnore]
        public string ProfileUrl { get; set; }
        [Display(Name = "Instagram")]
        public string Instagram { get; set; }
        [Display(Name = "Discord")]
        public string Discord { get; set; }
        [Display(Name = "Twitter")]
        public string Twitter { get; set; }
        [Display(Name = "Facebook")]
        public string Facebook { get; set; }
        [Display(Name = "Youtube")]
        public string Youtube { get; set; }
        [Display(Name = "Twitch")]
        public string Twitch { get; set; }
        [Display(Name = "Telegram")]
        public string Telegram { get; set; }
        [Display(Name = "Bio")]
        public string Bio { get; set; }
        #region Background Image
        [Display(Name = "Background Image")]
        public Guid? BackgroundImgId { get; set; }
        [Display(Name = "Background Image")]
        public UploadFile BackgroundImg { get; set; }

        [Display(Name = "Background Image")]
        [NotMapped]
        [JsonIgnore]
        public IFormFile BackgroundImgFormFile { get; set; }
        [Display(Name = "Background Image")]
        [NotMapped]
        [JsonIgnore]
        public string BackgroundImgSrc { get; set; }
        #endregion
        #region Profile Pictures
        [Display(Name = "Profile Pictures")]
        public Guid? ProfilePicId { get; set; }
        [Display(Name = "Profile Pictures")]
        public UploadFile ProfilePic { get; set; }

        [Display(Name = "Profile Pictures")]
        [NotMapped]
        [JsonIgnore]
        public IFormFile ProfilePicFormFile { get; set; }
        [Display(Name = "Profile Pictures")]
        [NotMapped]
        [JsonIgnore]
        public string ProfilePicImgSrc { get; set; }
        #endregion

        public string UserID { get; set; }
        public ApplicationUser User { get; set; }
    }
}
