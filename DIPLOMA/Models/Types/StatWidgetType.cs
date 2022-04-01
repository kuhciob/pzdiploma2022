using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIPLOMA.Models
{  
    public class StatWidgetType : TypeModel
    {
        public virtual ICollection<StatisticWidget> StatisticWidgets { get; set; }

    }
    
    public static class SWTypeConstants
    {
        public const string Top = "TP";

        public const string LastDonater = "LD";

        public const string CollectedAmt = "CA";
    }
    public static class SWTypeDscrConstants
    {
        public const string TopDscr = "Top";

        public const string LastDonaterDscr = "Last Donater";

        public const string CollectedAmtDscr = "Collected  amount";
    }
}
