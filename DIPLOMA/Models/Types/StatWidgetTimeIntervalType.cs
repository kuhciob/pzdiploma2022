using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIPLOMA.Models
{
    public class StatWidgetTimeIntervalType : TypeModel
    {
        public virtual ICollection<StatisticWidget> StatisticWidgets { get; set; }
    }
    public static class SWTimeIntervalCDConstants
    {
        public const string Today = "TD";

        public const string AllTime = "AT";

        public const string Last24 = "24";

        public const string ThisWeek = "TW";

        public const string Last7Days = "7D";

        public const string ThisMonth = "TM";

        public const string Last30Days = "30";

        public const string ThisYear = "TY";

        public const string LastYear = "LY";
    }
    public static class SWTimeIntervalDscrConstants
    {
        public const string TodayDscr = "Today";

        public const string AllTimeDscr = "All time";

        public const string Last24Dscr = "Last 24 hours";

        public const string ThisWeekDscr = "This week";

        public const string Last7DaysDscr = "Last 7 days";

        public const string ThisMonthDscr = "This month";

        public const string Last30DaysDscr = "Last 30 Days";

        public const string ThisYearDscr = "This Year";

        public const string LastYearDscr = "Last Year";
    }
}
