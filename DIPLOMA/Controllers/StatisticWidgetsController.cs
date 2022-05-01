using DIPLOMA.Data;
using DIPLOMA.Models;
using DIPLOMA.Models.ViewModels;
using DIPLOMA.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DIPLOMA.Controllers
{
    public class StatisticWidgetsController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StatisticWidgetsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            IWebHostEnvironment webHost, IHttpContextAccessor httpContextAccessor)
            : base(context, userManager, httpContextAccessor)
        {
            _webHostEnvironment = webHost;

        }

        [AllowAnonymous]
        public async Task<IActionResult> Display(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stawidget = await _context.StatisticWidget
                .Include(m => m.User)
                .Include(m => m.WidgetType)
                .Include(m => m.Direction)
                .Include(m => m.TimeInterval)
                .Include(m => m.DisplayMode)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (stawidget == null)
            {
                return NotFound();
            }

            DateTime borderDate = new DateTime();
            switch (stawidget.TimeInterval.CD)
            {
                case SWTimeIntervalCDConstants.AllTime:
                    borderDate = new DateTime();
                    break;
                case SWTimeIntervalCDConstants.Last24:
                    borderDate = DateTime.Now.AddHours(-24);
                    break;
                case SWTimeIntervalCDConstants.Last7Days:
                    borderDate = DateTime.Now.AddDays(-7);
                    break;
                case SWTimeIntervalCDConstants.Last30Days:
                    borderDate = DateTime.Now.AddDays(-30);
                    break;               
                case SWTimeIntervalCDConstants.LastYear:
                    borderDate = DateTime.Now.AddYears(-1);
                    break;
                case SWTimeIntervalCDConstants.Today:
                    borderDate = DateTime.Today;
                    break;
                case SWTimeIntervalCDConstants.ThisWeek:
                    int diff = (7 + (DateTime.Today.DayOfWeek - DayOfWeek.Monday)) % 7;
                    borderDate = DateTime.Today.AddDays(-1 * diff);
                    break;
                case SWTimeIntervalCDConstants.ThisMonth:
                    borderDate = new DateTime(DateTime.Today.Year, 
                        DateTime.Today.Month, 1);
                    break;               
                case SWTimeIntervalCDConstants.ThisYear:
                    borderDate = new DateTime(DateTime.Today.Year,
                       1, 1);
                    break;
                
                default:
                    borderDate = new DateTime();
                    break;
            }

            List<DonateMsg> donateMsgList  = await _context.DonateMsg.
                Where(u => u.UserID == stawidget.UserID
                    && u.CreatedDate >= borderDate).
                ToListAsync();

            int elCount = stawidget.ElementsCount;
            List<DonateMsg> resultList = new List<DonateMsg>();

            switch (stawidget.WidgetType.CD)
            {
                case SWTypeConstants.Top:
                    var groups = donateMsgList.GroupBy(d => d.DonatorName,
                        //d => d.DonatorName,
                        (dname, donates) => new
                        {
                            Key = dname,
                            Count = donates.Count(),
                            Sum = donates.Sum(d => d.Amount),
                            Min = donates.Min(d => d.Amount),
                            Max = donates.Max(d => d.Amount),

                        }).
                        ToList();

                    resultList = groups.Select(r =>
                    new DonateMsg()
                    {
                        DonatorName = r.Key,
                        Amount = r.Sum
                    }).
                    OrderByDescending(r => r.Amount).
                    Take(elCount).
                    ToList();

                    break;
                case SWTypeConstants.LastDonater:
                    resultList = donateMsgList.
                        GroupBy(d => d.DonatorName, (dname, donates) =>
                        new 
                        { 
                            DonatorName = dname,
                            LastDonateDate = donates.Max(d => d.CreatedDate)
                        }).
                        Select(r =>
                        new DonateMsg()
                        {
                            DonatorName = r.DonatorName,
                            Amount = null,
                            CreatedDate = r.LastDonateDate
                        }).
                        OrderByDescending(r => r.CreatedDate).
                        Take(elCount).
                        ToList();
                        

                    break;
                case SWTypeConstants.CollectedAmt:
                    resultList.Add(
                        new DonateMsg()
                        {
                            DonatorName = "",
                            Amount = donateMsgList.Sum(r => r.Amount)
                        });
                    break;
                default:
                    break;
            }

            DisplayStatisticViewModel viewModel = new DisplayStatisticViewModel();
            viewModel.SWidget = stawidget;
            viewModel.DirectionTypeCD = stawidget.Direction.CD;
            viewModel.DisplayTypeCD = stawidget.DisplayMode.CD;
            viewModel.DirectionTypeCD = stawidget.Direction.CD;
            viewModel.DonateMsgs = resultList;

            return View(viewModel);
        }

        // GET: StatisticWidgets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StatisticWidget.
                Include(s => s.Direction).
                Include(s => s.DisplayMode).
                Include(s => s.TimeInterval).
                Include(s => s.User).
                Include(s => s.WidgetType).
                Where(r => r.UserID == _currentUserId);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StatisticWidgets/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statisticWidget = await _context.StatisticWidget
                .Include(s => s.Direction)
                .Include(s => s.DisplayMode)
                .Include(s => s.TimeInterval)
                .Include(s => s.User)
                .Include(s => s.WidgetType)
                .Where(r => r.UserID == _currentUserId)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (statisticWidget == null)
            {
                return NotFound();
            }
            if(string.IsNullOrEmpty(statisticWidget.Url)
                || string.IsNullOrEmpty(statisticWidget.DisplayUrl))
            {
                statisticWidget.Url = $"/{nameof(MsgWidgetsController).Replace("Controller", "")}/{nameof(this.Display)}/{statisticWidget.ID}";
                statisticWidget.DisplayUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}" +
                $"{statisticWidget.Url}";
            }
           
            return View(statisticWidget);
        }

        // GET: StatisticWidgets/Create
        public IActionResult Create()
        {
            StatisticWidget statisticWidget = new StatisticWidget();

            statisticWidget.UserID = _currentUserId;
            statisticWidget.ElementsCount = 5;
            statisticWidget.ScrollingSpeed = 5;

            ViewData["DirectionID"] = new SelectList(_context.StatWidgetDirectionType, nameof(TypeModel.ID), nameof(TypeModel.Description));
            ViewData["DisplayModeID"] = new SelectList(_context.StatWidgetDisplayModeType, nameof(TypeModel.ID), nameof(TypeModel.Description));
            ViewData["TimeIntervalID"] = new SelectList(_context.StatWidgetTimeIntervalType, nameof(TypeModel.ID), nameof(TypeModel.Description));
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", _currentUserId);
            ViewData["WidgetTypeID"] = new SelectList(_context.StatWidgetType, nameof(TypeModel.ID), nameof(TypeModel.Description));
            return View(statisticWidget);
        }

        // POST: StatisticWidgets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StatisticWidget statisticWidget)
        {
            if (ModelState.IsValid)
            {
                statisticWidget.ID = Guid.NewGuid();
                statisticWidget.Url = $"/{nameof(MsgWidgetsController).Replace("Controller", "")}/{nameof(this.Display)}/{statisticWidget.ID}";
                statisticWidget.DisplayUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}" +
                $"{statisticWidget.Url}";
                _context.Add(statisticWidget);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DirectionID"] = new SelectList(_context.StatWidgetDirectionType, nameof(TypeModel.ID), nameof(TypeModel.Description), statisticWidget.DirectionID);
            ViewData["DisplayModeID"] = new SelectList(_context.StatWidgetDisplayModeType, nameof(TypeModel.ID), nameof(TypeModel.Description), statisticWidget.DisplayModeID);
            ViewData["TimeIntervalID"] = new SelectList(_context.StatWidgetTimeIntervalType, nameof(TypeModel.ID), nameof(TypeModel.Description), statisticWidget.TimeIntervalID);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", statisticWidget.UserID);
            ViewData["WidgetTypeID"] = new SelectList(_context.StatWidgetType, nameof(TypeModel.ID), nameof(TypeModel.Description), statisticWidget.WidgetTypeID);
            return View(statisticWidget);
        }

        // GET: StatisticWidgets/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statisticWidget = await _context.StatisticWidget.
                FindAsync(id);

            if (statisticWidget == null
                || statisticWidget.UserID != _currentUserId)
            {
                return NotFound();
            }
            ViewData["DirectionID"] = new SelectList(_context.StatWidgetDirectionType, nameof(TypeModel.ID), nameof(TypeModel.Description), statisticWidget.DirectionID);
            ViewData["DisplayModeID"] = new SelectList(_context.StatWidgetDisplayModeType, nameof(TypeModel.ID), nameof(TypeModel.Description), statisticWidget.DisplayModeID);
            ViewData["TimeIntervalID"] = new SelectList(_context.StatWidgetTimeIntervalType, nameof(TypeModel.ID), nameof(TypeModel.Description), statisticWidget.TimeIntervalID);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", statisticWidget.UserID);
            ViewData["WidgetTypeID"] = new SelectList(_context.StatWidgetType, nameof(TypeModel.ID), nameof(TypeModel.Description), statisticWidget.WidgetTypeID);
            return View(statisticWidget);
        }

        // POST: StatisticWidgets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("HeaderText,ElementsCount,ScrollingSpeed,DisplayModeID,WidgetTypeID,DirectionID,TimeIntervalID,ID,UserID,Name,Url,CreatedDate,UpdatedDate")] StatisticWidget statisticWidget)
        {
            if (id != statisticWidget.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statisticWidget);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatisticWidgetExists(statisticWidget.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DirectionID"] = new SelectList(_context.StatWidgetDirectionType, nameof(TypeModel.ID), nameof(TypeModel.Description), statisticWidget.DirectionID);
            ViewData["DisplayModeID"] = new SelectList(_context.StatWidgetDisplayModeType, nameof(TypeModel.ID), nameof(TypeModel.Description), statisticWidget.DisplayModeID);
            ViewData["TimeIntervalID"] = new SelectList(_context.StatWidgetTimeIntervalType, nameof(TypeModel.ID), nameof(TypeModel.Description), statisticWidget.TimeIntervalID);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", statisticWidget.UserID);
            ViewData["WidgetTypeID"] = new SelectList(_context.StatWidgetType, nameof(TypeModel.ID), nameof(TypeModel.Description), statisticWidget.WidgetTypeID);
            return View(statisticWidget);
        }

        // GET: StatisticWidgets/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statisticWidget = await _context.StatisticWidget
                .Include(s => s.Direction)
                .Include(s => s.DisplayMode)
                .Include(s => s.TimeInterval)
                .Include(s => s.User)
                .Include(s => s.WidgetType)
                .Where(r => r.UserID == _currentUserId)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (statisticWidget == null)
            {
                return NotFound();
            }

            return View(statisticWidget);
        }

        // POST: StatisticWidgets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var statisticWidget = await _context.StatisticWidget.FindAsync(id);
            _context.StatisticWidget.Remove(statisticWidget);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatisticWidgetExists(Guid id)
        {
            return _context.StatisticWidget.Any(e => e.ID == id);
        }
    }
}
