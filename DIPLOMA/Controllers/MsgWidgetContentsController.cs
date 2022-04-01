using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DIPLOMA.Data;
using DIPLOMA.Models;

namespace DIPLOMA.Controllers
{
    public class MsgWidgetContentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MsgWidgetContentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MsgWidgetContents
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MsgWidgetContent.Include(m => m.Animation).Include(m => m.MsgWidget).Include(m => m.Sound);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MsgWidgetContents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var msgWidgetContent = await _context.MsgWidgetContent
                .Include(m => m.Animation)
                .Include(m => m.MsgWidget)
                .Include(m => m.Sound)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (msgWidgetContent == null)
            {
                return NotFound();
            }

            return View(msgWidgetContent);
        }

        // GET: MsgWidgetContents/Create
        public IActionResult Create()
        {
            ViewData["AnimationFileId"] = new SelectList(_context.Set<UploadFile>(), "ID", "ID");
            ViewData["MsgWidgetID"] = new SelectList(_context.MsgWidget, "ID", "Name");
            ViewData["SoundFileId"] = new SelectList(_context.Set<UploadFile>(), "ID", "ID");
            return View();
        }

        // POST: MsgWidgetContents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MsgWidgetID,AnimationFileId,SoundFileId")] MsgWidgetContent msgWidgetContent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(msgWidgetContent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimationFileId"] = new SelectList(_context.Set<UploadFile>(), "ID", "ID", msgWidgetContent.AnimationFileId);
            ViewData["MsgWidgetID"] = new SelectList(_context.MsgWidget, "ID", "Name", msgWidgetContent.MsgWidgetID);
            ViewData["SoundFileId"] = new SelectList(_context.Set<UploadFile>(), "ID", "ID", msgWidgetContent.SoundFileId);
            return View(msgWidgetContent);
        }

        // GET: MsgWidgetContents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var msgWidgetContent = await _context.MsgWidgetContent.FindAsync(id);
            if (msgWidgetContent == null)
            {
                return NotFound();
            }
            ViewData["AnimationFileId"] = new SelectList(_context.Set<UploadFile>(), "ID", "ID", msgWidgetContent.AnimationFileId);
            ViewData["MsgWidgetID"] = new SelectList(_context.MsgWidget, "ID", "Name", msgWidgetContent.MsgWidgetID);
            ViewData["SoundFileId"] = new SelectList(_context.Set<UploadFile>(), "ID", "ID", msgWidgetContent.SoundFileId);
            return View(msgWidgetContent);
        }

        // POST: MsgWidgetContents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("ID,MsgWidgetID,AnimationFileId,SoundFileId")] MsgWidgetContent msgWidgetContent)
        {
            if (id != msgWidgetContent.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(msgWidgetContent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MsgWidgetContentExists(msgWidgetContent.ID))
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
            ViewData["AnimationFileId"] = new SelectList(_context.Set<UploadFile>(), "ID", "ID", msgWidgetContent.AnimationFileId);
            ViewData["MsgWidgetID"] = new SelectList(_context.MsgWidget, "ID", "Name", msgWidgetContent.MsgWidgetID);
            ViewData["SoundFileId"] = new SelectList(_context.Set<UploadFile>(), "ID", "ID", msgWidgetContent.SoundFileId);
            return View(msgWidgetContent);
        }

        // GET: MsgWidgetContents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var msgWidgetContent = await _context.MsgWidgetContent
                .Include(m => m.Animation)
                .Include(m => m.MsgWidget)
                .Include(m => m.Sound)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (msgWidgetContent == null)
            {
                return NotFound();
            }

            return View(msgWidgetContent);
        }

        // POST: MsgWidgetContents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var msgWidgetContent = await _context.MsgWidgetContent.FindAsync(id);
            _context.MsgWidgetContent.Remove(msgWidgetContent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MsgWidgetContentExists(int? id)
        {
            return _context.MsgWidgetContent.Any(e => e.ID == id);
        }
    }
}
