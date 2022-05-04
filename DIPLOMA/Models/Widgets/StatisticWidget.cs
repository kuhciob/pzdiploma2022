using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DIPLOMA.Models
{
    public class StatisticWidget : Widget
    {
        [Display(Name = "Header Text")]
        public string HeaderText { get; set; }     

        [Display(Name = "Elements Count")]
        [DefaultValue(5)]
        public int ElementsCount { get; set; }

        [Display(Name = "Scrolling speed")]
        [DefaultValue(5)]
        public int ScrollingSpeed { get; set; }

        [Display(Name = "Display mode")]
        public int DisplayModeID { get; set; }
        [Display(Name = "Widget type")]
        public int WidgetTypeID { get; set; }
        [Display(Name = "Direction")]
        public int DirectionID { get; set; }
        [Display(Name = "Time interval")]
        public int TimeIntervalID { get; set; }


        [Display(Name = "Display mode")]
        public StatWidgetDisplayModeType DisplayMode { get; set; }
        [Display(Name = "Widget type")]
        public StatWidgetType WidgetType { get; set; }
        [Display(Name = "Direction")]
        public StatWidgetDirectionType Direction { get; set; }
        [Display(Name = "Time interval")]
        public StatWidgetTimeIntervalType TimeInterval { get; set; }

        //public TextStyle TextStyle { get; set; }


    }
}
