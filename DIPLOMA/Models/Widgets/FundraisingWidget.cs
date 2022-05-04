using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DIPLOMA.Models
{
    public class FundraisingWidget : Widget
    {
        [Display(Name = "Header Text")]
        public string HeaderText { get; set; }

        [Display(Name = "Initial Amount")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:f}", ApplyFormatInEditMode = true)]
        public decimal? InitialAmt { get; set; }

        [Display(Name = "Target Amount")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:f}", ApplyFormatInEditMode = true)]
        public decimal? TargetAmt { get; set; }

        [Display(Name = "Collected Amount")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:f}", ApplyFormatInEditMode = true)]

        public decimal? CollectedAmt { get; set; }

        [Display(Name = "Hide initial and target amounts")]
        public bool HideInitAndTargetAmounts { get; set; }

        [Display(Name = "Active")]
        public bool Active { get; set; }


        #region Style
        [Display(Name = "Indicator color")]
        public string IndicatorColorHex { get; set; }

        [Display(Name = "Indicator background color")]
        public string IndicatorBackgroundColorHex { get; set; }
        [Display(Name = "Border Color")]
        public string BorderColorHex { get; set; }

        [Display(Name = "Digits Color")]
        public string DigitsColorHex { get; set; }

        [Display(Name = "Border Syze")]
        [Range(0, 10, ErrorMessage = "The field {0} must be greater than {1}.")]
        public int BorderSize { get; set; }
        [Display(Name = "Height")]
        [Range(0, 300, ErrorMessage = "The field {0} must be greater than {1}.")]
        public int Height { get; set; }
        [Display(Name = "Radius")]
        [Range(0, 60, ErrorMessage = "The field {0} must be greater than {1}.")]
        public int Radius { get; set; }

        #endregion
        #region NotMapped
        [NotMapped]
        [JsonIgnore]
        public string DigitsStyle { get; set; }
        [NotMapped]
        [JsonIgnore]
        public string IndicatorStyle { get; set; }
        [NotMapped]
        [JsonIgnore]
        public string IndicatorGotStyle { get; set; }
        [NotMapped]
        [JsonIgnore]
        public string IndicatorLeftStyle { get; set; }
        [NotMapped]
        [JsonIgnore]
        public int ProgressPercent { get; set; }
        [NotMapped]
        [JsonIgnore]
        public int IndicatorPercent { get; set; }
        #endregion

    }
}
