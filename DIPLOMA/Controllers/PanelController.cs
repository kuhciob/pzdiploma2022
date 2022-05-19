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
            if(StartDate == null)
            {
                StartDate = DateTime.Now;
            }
            if (EndDate == null)
            {
                EndDate = DateTime.Now;
            }

            List<DonateMsg> donateMsgs = await _context.DonateMsg.
                Include(d => d.User).
                Where(r => r.UserID == _currentUserId).
                OrderBy(r => r.CreatedDate).
                ToListAsync();

            ChartDateAmtData allTimeChart = new ChartDateAmtData()
            {
                Amounts = donateMsgs.Select(r => r.Amount.GetValueOrDefault()).
                ToList(),
                Dates = donateMsgs.
                    Select(r => new DateTime(r.CreatedDate.Year, r.CreatedDate.Month, r.CreatedDate.Day)).
                    ToList()
            };
            
            List<DonateMsg> donateMsgsInBounds = donateMsgs.Where(r => r.CreatedDate <= EndDate
                && r.CreatedDate >= StartDate).
                OrderBy(r => r.CreatedDate).
                ToList();
            ChartDateAmtData inBordersTimeChart = new ChartDateAmtData()
            {
                Amounts = donateMsgsInBounds.Select(r => r.Amount.GetValueOrDefault()).
                ToList(),
                Dates = donateMsgsInBounds.
                    Select(r => new DateTime(r.CreatedDate.Year, r.CreatedDate.Month, r.CreatedDate.Day)).
                    ToList()
            };

            var allTimeAmt = donateMsgs.Sum(r => r.Amount.GetValueOrDefault());
            var inBordersAmt = donateMsgsInBounds.Sum(r => r.Amount.GetValueOrDefault());

            var topGroupsAttTime = donateMsgs.GroupBy(d => d.DonatorName,
            (dname, donates) => new
            {
                Key = dname,
                Count = donates.Count(),
                Sum = donates.Sum(d => d.Amount.GetValueOrDefault()),
                Min = donates.Min(d => d.Amount.GetValueOrDefault()),
                Max = donates.Max(d => d.Amount.GetValueOrDefault()),

            }).
            ToList();

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

            var topDonateList = topGroupsAttTime.Select(r =>
                new DonateMsg()
                {
                    DonatorName = r.Key,
                    Amount = r.Sum
                }).
            OrderByDescending(r => r.Amount).
            ToList();

            var topDonateListInBorders = topGroupsInBorders.Select(r =>
                new DonateMsg()
                {
                    DonatorName = r.Key,
                    Amount = r.Sum
                }).
            OrderByDescending(r => r.Amount).
            ToList();




            DashboardViewModel dashboard = new DashboardViewModel();


            dashboard.AllDonateMsgs = donateMsgs;
            dashboard.InBordersDonateMsgs = donateMsgsInBounds;
            dashboard.TopDonators = topDonateList;
            dashboard.InBordersTopDonators = topDonateListInBorders;

            dashboard.AllTimeAmt = allTimeAmt;
            dashboard.InBordersAmt = inBordersAmt;

            dashboard.InBordersChart = inBordersTimeChart;

            dashboard.AllDonatesChart = allTimeChart;
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
