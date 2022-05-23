using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DIPLOMA.Models
{
    public class DashboardStatistic
    {
        public string ChartDivID { get; set; }

        public string Caption { get; set; }
        public decimal TotalAmt { get; set; }
        public List<DateTime> Dates { get; set; }
        public List<decimal> Amounts { get; set; }
        public List<DonateMsg> TopDonators { get; set; }
        public List<DonateMsg> AllDonateMsgs { get; set; }

    }
    public class DashboardViewModel
    {
        public DashboardStatistic AllDonatesChart { get; set; }
        public DashboardStatistic InBordersChart { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
    }
}
