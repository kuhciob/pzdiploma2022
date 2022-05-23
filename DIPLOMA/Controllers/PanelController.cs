using DIPLOMA.Data;
using DIPLOMA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DIPLOMA.Controllers
{
    public class PanelController : BaseController
    {
        public PanelController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, 
            IHttpContextAccessor httpContextAccessor)
            : base(context, userManager, httpContextAccessor)
        {
        }
        
        public async Task<IActionResult> Index(DateTime? StartDate, DateTime? EndDate)
        {
            
            List<DonateMsg> donateMsgs = await _context.DonateMsg.
                Include(d => d.User).
                Where(r => r.UserID == _currentUserId).
                OrderBy(r => r.CreatedDate).
                ToListAsync();

            if (StartDate == null)
            {
                StartDate = donateMsgs.Min(r => r.CreatedDate.Date);
            }
            if (EndDate == null)
            {
                EndDate = donateMsgs.Max(r => r.CreatedDate.Date);
            }
            //#region AllTime


            //DashboardStatistic allTimeChart = new DashboardStatistic()
            //{
            //    Amounts = donateMsgs.Select(r => r.Amount.GetValueOrDefault()).
            //    ToList(),
            //    Dates = donateMsgs.
            //        Select(r => r.CreatedDate.Date).
            //        ToList()
            //};
            //var allTimeAmt = donateMsgs.Sum(r => r.Amount.GetValueOrDefault());

            //allTimeChart.Caption = "Statistics for all time";
            //allTimeChart.TotalAmt = allTimeAmt;

            //var topGroupsAllTime = donateMsgs.GroupBy(d => d.DonatorName,
            //(dname, donates) => new
            //{
            //    Key = dname,
            //    Count = donates.Count(),
            //    Sum = donates.Sum(d => d.Amount.GetValueOrDefault()),
            //    Min = donates.Min(d => d.Amount.GetValueOrDefault()),
            //    Max = donates.Max(d => d.Amount.GetValueOrDefault()),

            //}).
            //ToList();
            //var topDonateList = topGroupsAllTime.Select(r =>
            //    new DonateMsg()
            //    {
            //        DonatorName = r.Key,
            //        Amount = r.Sum
            //    }).
            //OrderByDescending(r => r.Amount).
            //ToList();
            //allTimeChart.TopDonators = topDonateList;

            //allTimeChart.ChartDivID = "AllTimeChartID";
            //#endregion
            #region InBorder
            List<DonateMsg> donateMsgsInBounds = donateMsgs.
                Where(r => (r.CreatedDate <= EndDate || EndDate == null)
               && (r.CreatedDate >= StartDate || StartDate == null)).
               OrderBy(r => r.CreatedDate).
               ToList();
            DashboardStatistic inBordersTimeChart = new DashboardStatistic()
            {
                Amounts = donateMsgsInBounds.Select(r => r.Amount.GetValueOrDefault()).
                ToList(),
                Dates = donateMsgsInBounds.
                    Select(r => r.CreatedDate.Date).
                    ToList()
            };
            inBordersTimeChart.AllDonateMsgs = donateMsgsInBounds;
            inBordersTimeChart.Caption = "Statistics";
            var inBordersAmt = donateMsgsInBounds.Sum(r => r.Amount.GetValueOrDefault());

            inBordersTimeChart.TotalAmt = inBordersAmt;

            var topGroupsInBorders = donateMsgsInBounds.
                GroupBy(d => d.DonatorName,
            (dname, donates) => new
            {
                Key = dname,
                Count = donates.Count(),
                Sum = donates.Sum(d => d.Amount.GetValueOrDefault()),
                Min = donates.Min(d => d.Amount.GetValueOrDefault()),
                Max = donates.Max(d => d.Amount.GetValueOrDefault()),

            }).
            ToList();


            var topDonateListInBorders = topGroupsInBorders.Select(r =>
                new DonateMsg()
                {
                    DonatorName = r.Key,
                    Amount = r.Sum
                }).
            OrderByDescending(r => r.Amount).
            ToList();


            inBordersTimeChart.TopDonators = topDonateListInBorders;
            inBordersTimeChart.ChartDivID = "InBordersChartID";

            #endregion

            DashboardViewModel dashboard = new DashboardViewModel();

            //dashboard.AllDonateMsgs = donateMsgs;
            //dashboard.InBordersDonateMsgs = donateMsgsInBounds;
           
            dashboard.InBordersChart = inBordersTimeChart;
            //dashboard.AllDonatesChart = allTimeChart;

            ViewBag.StartDate = StartDate;
            ViewBag.EndDate = EndDate;

            return View(dashboard);
        }
        public IActionResult Messages()
        {
            return View();
        }
        public IActionResult Fundraising()
        {
            return View();
        }
        public IActionResult Notification()
        {
            return View();
        }
        public IActionResult Statistic()
        {
            return View();
        }
    }
}
