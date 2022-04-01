using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DIPLOMA.Models
{
    public class MsgWidget : Widget
    {
        
        [Display(Name = "Min. Amount")]
        [DataType(DataType.Currency)]
        public decimal? MinAmt { get; set; }
        [Display(Name = "Max. Amount")]
        [DataType(DataType.Currency)]
        public decimal? MaxAmt { get; set; }

        [Display(Name = "Header Text")]
        public string HeaderText { get; set; }

        [Display(Name = "Max. Symbols")]
        [DefaultValue(100)]
        public int MaxSymbols { get; set; }

        [Display(Name = "Display Time")]
        public int DisplayTimeSec { get; set; }

        [Display(Name = "Random (Animation and Sound)")]
        public bool RandomContent { get; set; }
        [Display(Name = "Read the title")]
        public bool ReadHeader { get; set; }
        [Display(Name = "Read the Message")]
        public bool ReadMessage { get; set; }
        [Display(Name = "Animation and Sound")]
        public List<MsgWidgetContent> MsgWidgetContent { get; set; }


    }
}
