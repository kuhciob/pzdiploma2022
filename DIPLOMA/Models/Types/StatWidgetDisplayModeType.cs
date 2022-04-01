using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DIPLOMA.Models
{
    public class StatWidgetDisplayModeType : TypeModel
    {
        public virtual ICollection<StatisticWidget> StatisticWidgets { get; set; }

    }
    public static class SWDisplayModeConstants
    {
        public const string List = "LL";

        public const string СreepingLine = "CL";

        public const string Slider = "SL";
    }
    public static class SWDisplayModeDscrConstants
    {
        public const string ListDscr = "List";

        public const string СreepingLineDscr = "Сreeping line";

        public const string SliderDscr = "Slider";
    }
}
