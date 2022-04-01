using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIPLOMA.Models
{
    public class StatWidgetDirectionType : TypeModel
    {
        public string Value { get; set; }
        public virtual ICollection<StatisticWidget> StatisticWidgets { get; set; }
    }
    public static class SWDirectionValueConstants
    {
        public const string RightLeft = "left";

        public const string LeftRight = "right";

        public const string TopBottom = "down";

        public const string BottomTop = "up";
    }
    public static class SWDirectionConstants
    {
        public const string RightLeft = "RL";

        public const string LeftRight = "LR";

        public const string TopBottom = "TB";

        public const string BottomTop = "BT";
    }
    public static class SWDirectionDsrcConstants
    {
        public const string RightLeftDscr = "Right -> Left";

        public const string LeftRightDscr = "Left -> Right";

        public const string TopBottomDscr = "Top -> Bottom";

        public const string BottomTopDscr = "Bottom -> Top";
    }
    
}
