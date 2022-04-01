using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIPLOMA.Models.ViewModels
{
    public class DisplayStatisticViewModel
    {
        public StatisticWidget SWidget { get; set; }
        public string WidgetTypeCD { get; set; }
        public string DisplayTypeCD { get; set; }
        public string DirectionTypeCD { get; set; }
        public List<DonateMsg> DonateMsgs { get; set; }
    }
}
