using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DIPLOMA.Models
{
    public class ChartDateAmtData
    {
        public List<DateTime> Dates { get; set; }
        public List<decimal> Amounts { get; set; }

    }
    public class DashboardViewModel
    {
        public ChartDateAmtData AllDonatesChart { get; set; }
        public ChartDateAmtData InBordersChart { get; set; }

        public List<DonateMsg> AllDonateMsgs { get; set; }
        public List<DonateMsg> InBordersDonateMsgs { get; set; }
        public List<DonateMsg> TopDonators { get; set; }
        public List<DonateMsg> InBordersTopDonators { get; set; }
        public decimal AllTimeAmt { get; set; }
        public decimal InBordersAmt { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
    }
}
