using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DIPLOMA.Data;
using DIPLOMA.Models;
using Microsoft.AspNetCore.SignalR;
using DIPLOMA.Services;

namespace DIPLOMA.Controllers
{
    public class DonateMsgsController : Controller
    {
        private IHubContext<DonateHub> _donateHub;
        private readonly ApplicationDbContext _context;

        public DonateMsgsController(ApplicationDbContext context, IHubContext<DonateHub> hubContext)
        {
            _context = context;
            _donateHub = hubContext;
        }

        //// GET: DonateMsgs
        //public async Task<IActionResult> Index()
        //{
        //    var applicationDbContext = _context.DonateMsg.Include(d => d.User);
        //    return View(await applicationDbContext.ToListAsync());
        //}

        // GET: DonateMsgs/Donate/5
        [HttpGet("Donate/{username}")]
        public async Task<IActionResult> Create(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.NickName == username);

            if (user == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", user.Id);

            return View(new DonateMsg() { UserID = user.Id });
        }

       

        // POST: DonateMsgs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,Amount,DonatorName,Message,Date")] DonateMsg donateMsg)
        {
            if (ModelState.IsValid)
            {
                //donateMsg.Date = DateTime.Now;
                _context.Add(donateMsg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", donateMsg.UserID);
            
            await _donateHub.Clients.All.SendAsync("ReceiveMessage", donateMsg);

            return View(donateMsg);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donate = await _context.DonateMsg
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (donate == null)
            {
                return NotFound();
            }

            return View(donate);
        }
        [HttpGet("Donates/{userid}")]
        public async Task<IActionResult> Show(string userid)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == userid);

            if (user == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", userid);

            return View(new DonateMsg() { UserID = userid });
        }
        // GET: DonateMsgs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donateMsg = await _context.DonateMsg.FindAsync(id);
            if (donateMsg == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", donateMsg.UserID);
            return View(donateMsg);
        }

        // POST: DonateMsgs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserID,Amount,DonatorName,Message,Date")] DonateMsg donateMsg)
        {
            if (id != donateMsg.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donateMsg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonateMsgExists(donateMsg.ID.GetValueOrDefault()))
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
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", donateMsg.UserID);
            return View(donateMsg);
        }

        // GET: DonateMsgs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donateMsg = await _context.DonateMsg
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (donateMsg == null)
            {
                return NotFound();
            }

            return View(donateMsg);
        }

        // POST: DonateMsgs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donateMsg = await _context.DonateMsg.FindAsync(id);
            _context.DonateMsg.Remove(donateMsg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonateMsgExists(int id)
        {
            return _context.DonateMsg.Any(e => e.ID == id);
        }
    }
}
