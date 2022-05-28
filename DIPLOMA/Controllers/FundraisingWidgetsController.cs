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
    public class FundraisingWidgetsController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FundraisingWidgetsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            IWebHostEnvironment webHost, IHttpContextAccessor httpContextAccessor )
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

            var widget = await _context.FundraisingWidget
                .Include(m => m.User)
               .Include(m => m.TextStyle)

                .FirstOrDefaultAsync(m => m.ID == id);

            if (widget == null)
            {
                return NotFound();
            }
            var percebt = (100 * (widget.InitialAmt.GetValueOrDefault(0) + widget.CollectedAmt.GetValueOrDefault(0))) /
                (widget.TargetAmt.GetValueOrDefault(0) == 0 ? 1 : widget.TargetAmt.GetValueOrDefault());
            widget.ProgressPercent = Convert.ToInt32(percebt);

            widget.IndicatorPercent = widget.ProgressPercent > 100 ? 100 : widget.ProgressPercent;

            widget.IndicatorStyle = $"border-radius: {widget.Radius}px;" +
                $" border: {widget.BorderSize}px solid {widget.BorderColorHex};" +
                $"height: {widget.Height}px;" ;

            widget.IndicatorLeftStyle = $"background: {widget.IndicatorBackgroundColorHex};" +
                $"width: {100 - widget.IndicatorPercent}%;" +
                $"height: {widget.Height}px;";
            widget.IndicatorGotStyle = $"background: {widget.IndicatorColorHex}; " +
                $"width: { widget.IndicatorPercent}%;" +
                $"height: {widget.Height}px;";

            if(widget.TextStyle == null)
            {
                widget.TextStyle = new TextStyle();
            }
            widget.DigitsStyle = $"color: {widget.DigitsColorHex};";
            return View(widget);
        }

        // GET: FundraisingWidgets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FundraisingWidget.
                Include(f => f.User).
                Where(r => r.UserID == _currentUserId);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FundraisingWidgets/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fundraisingWidget = await _context.FundraisingWidget
                .Include(f => f.User)
               .Include(m => m.TextStyle)

                .Where(r => r.UserID == _currentUserId)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fundraisingWidget == null)
            {
                return NotFound();
            }

            return View(fundraisingWidget);
        }

        // GET: FundraisingWidgets/Create
        public IActionResult Create()
        {
            FundraisingWidget fundraisingWidgets = new FundraisingWidget();
            fundraisingWidgets.UserID = _currentUserId;
            fundraisingWidgets.Active = true;
            fundraisingWidgets.Height = 0;
            fundraisingWidgets.BorderSize = 0;
            fundraisingWidgets.Radius = 0;
            fundraisingWidgets.CollectedAmt = 0;
            fundraisingWidgets.InitialAmt = 0;
            fundraisingWidgets.TargetAmt = 0;
            fundraisingWidgets.TextStyle = new TextStyle();

            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id");
            return View(fundraisingWidgets);
        }

        // POST: FundraisingWidgets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            //[Bind("HeaderText,InitialAmt,TargetAmt,CollectedAmt,HideInitAndTargetAmounts,Active,IndicatorColorHex,IndicatorBackgroundColorHex,BorderColorHex,DigitsColorHex,BorderSize,Height,Radius,ID,UserID,Name,Url,CreatedDate,UpdatedDate")] 
        FundraisingWidget fundraisingWidget)
        {
            if (ModelState.IsValid)
            {
                fundraisingWidget.ID = Guid.NewGuid();
                fundraisingWidget.Url = $"/{nameof(MsgWidgetsController).Replace("Controller", "")}/{nameof(this.Display)}/{fundraisingWidget.ID}";
                fundraisingWidget.DisplayUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}" +
                $"{fundraisingWidget.Url}";
                //_context.Add(fundraisingWidget.TextStyle);
                _context.Add(fundraisingWidget);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", fundraisingWidget.UserID);
            return View(fundraisingWidget);
        }

        // GET: FundraisingWidgets/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fundraisingWidget = await _context.FundraisingWidget
               .Include(m => m.TextStyle)

                .Where(r => r.UserID == _currentUserId
                    && r.ID == id).
                FirstOrDefaultAsync();

            if (fundraisingWidget == null)
            {
                return NotFound();
            }
            if (fundraisingWidget.TextStyle == null)
            {
                fundraisingWidget.TextStyle = new TextStyle();
            }

            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", fundraisingWidget.UserID);
            return View(fundraisingWidget);
        }

        // POST: FundraisingWidgets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, 
            //[Bind("HeaderText,InitialAmt,TargetAmt,CollectedAmt,HideInitAndTargetAmounts,Active,IndicatorColorHex,IndicatorBackgroundColorHex,BorderColorHex,DigitsColorHex,BorderSize,Height,Radius,ID,UserID,Name,Url,CreatedDate,UpdatedDate")] 
        FundraisingWidget fundraisingWidget)
        {
            if (id != fundraisingWidget.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fundraisingWidget);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FundraisingWidgetExists(fundraisingWidget.ID))
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
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", fundraisingWidget.UserID);
            return View(fundraisingWidget);
        }

        // GET: FundraisingWidgets/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fundraisingWidget = await _context.FundraisingWidget
                .Include(f => f.User)
                .Where(r => r.UserID == _currentUserId)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fundraisingWidget == null)
            {
                return NotFound();
            }

            return View(fundraisingWidget);
        }

        // POST: FundraisingWidgets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var fundraisingWidget = await _context.FundraisingWidget.FindAsync(id);
            _context.FundraisingWidget.Remove(fundraisingWidget);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public bool FundraisingWidgetExists(Guid id)
        {
            return _context.FundraisingWidget.
                Where(r => r.UserID == _currentUserId).
                Any(e => e.ID == id);
        }
    }
}
