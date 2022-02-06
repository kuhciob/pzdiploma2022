using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DIPLOMA.Data;
using DIPLOMA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using DIPLOMA.Models.ViewModels;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;


namespace DIPLOMA.Controllers
{
    [Authorize]
    public class MsgWidgetsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public MsgWidgetsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: MsgWidgets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MsgWidget.Include(m => m.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MsgWidgets/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var msgWidget = await _context.MsgWidget
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (msgWidget == null)
            {
                return NotFound();
            }

            return View(msgWidget);
        }

        // GET: /MsgWidgets/Create
        public async Task<IActionResult> CreateAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if(user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(HttpContext.User)}'.");
            }

            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", user.Id);

            var vm = new MsgWidgetViewModel();
            vm.MWidget = new MsgWidget();
            vm.MWidget.UserID = user.Id;
            vm.MWidget.HeaderText = "Hello";
            vm.MWidget.Name = "Hello 2";

            vm.MsgWidgetContent = new List<MsgWidgetContent>();
            vm.Foo = "World";
            return View(vm);
        }

        //// POST: MsgWidgets/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("MinAmt,MaxAmt,HeaderText,MaxSymbols,DisplayTimeSec,RandomContent,ReadHeader,ReadMessage,ID,UserID,Name,Url")] MsgWidget msgWidget)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        msgWidget.ID = Guid.NewGuid();
        //        _context.Add(msgWidget);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", msgWidget.UserID);
        //    return View(msgWidget);
        //}
        // POST: MsgWidgets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MsgWidgetViewModel msgWidgetVM)
        {
            var msgWidget = msgWidgetVM.MWidget;
            var msgWidgetContent = msgWidgetVM.MsgWidgetContent;

            if (ModelState.IsValid)
            {
                msgWidget.ID = Guid.NewGuid();
                _context.Add(msgWidget);
                foreach (var item in msgWidgetContent)
                {
                    item.MsgWidgetID = msgWidget.ID;
                    _context.Add(item);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", msgWidget.UserID);
            return View(msgWidget);
        }

        // GET: MsgWidgets/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var msgWidget = await _context.MsgWidget.FindAsync(id);
            if (msgWidget == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", msgWidget.UserID);
            return View(msgWidget);
        }

        // POST: MsgWidgets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("MinAmt,MaxAmt,HeaderText,MaxSymbols,DisplayTimeSec,RandomContent,ReadHeader,ReadMessage,ID,UserID,Name,Url")] MsgWidget msgWidget)
        {
            if (id != msgWidget.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(msgWidget);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MsgWidgetExists(msgWidget.ID))
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
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", msgWidget.UserID);
            return View(msgWidget);
        }

        // GET: MsgWidgets/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var msgWidget = await _context.MsgWidget
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (msgWidget == null)
            {
                return NotFound();
            }

            return View(msgWidget);
        }

        // POST: MsgWidgets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var msgWidget = await _context.MsgWidget.FindAsync(id);
            _context.MsgWidget.Remove(msgWidget);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MsgWidgetExists(Guid id)
        {
            return _context.MsgWidget.Any(e => e.ID == id);
        }
    }
}
