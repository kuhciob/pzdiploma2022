using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DIPLOMA.Models
{
    public class TextStyle : BaseModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Text color")]
        public string TextColorHex { get; set; }


        [Display(Name = "Bold")]
        public bool Bold { get; set; }
        [Display(Name = "Italic")]
        public bool Italic { get; set; }
        [Display(Name = "Underline")]
        public bool Underline { get; set; }
        

        [Display(Name = "Letter spacing")]
        public int? LetterSpacing { get; set; }
        [Display(Name = "Word Spacing")]
        public int? WordSpacing { get; set; }
        [Display(Name = "Font Size")]
        public int? FontSize { get; set; }


        [Display(Name = "FontFamily")]
        public string FontFamily { get; set; }
        [Display(Name = "Font")]
        public string Font { get; set; }
        [Display(Name = "Animation Name")]
        public string AnimationName { get; set; }

        public ICollection<StatisticWidget> StatisticWidgets { get; set; }
        public ICollection<FundraisingWidget> FundraisingWidgets { get; set; }
        public ICollection<MsgWidget> MsgWidgets { get; set; }

        string _TextStyleCss;
        [NotMapped]
        [JsonIgnore]
        public string TextStyleCss
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append($"letter-spacing: {this.LetterSpacing}px;");
                stringBuilder.Append($"word-spacing: {this.WordSpacing}px;");
                stringBuilder.Append($"font-size: {this.FontSize}px;");
                stringBuilder.Append($"font-family: {this.Font}, {this.FontFamily};");

                stringBuilder.Append($"color: {this.TextColorHex};");


                if (this.Italic == true)
                {
                    stringBuilder.Append($"font-style: italic;");
                }
                if (this.Bold == true)
                {
                    stringBuilder.Append($"font-weight: bold;");
                }
                if (this.Underline == true)
                {
                    stringBuilder.Append($"text-decoration-line: underline;");
                }
                
                _TextStyleCss = stringBuilder.ToString();

                return _TextStyleCss;
            }
            set
            {
                _TextStyleCss = value;
            }
        }
    }
}
