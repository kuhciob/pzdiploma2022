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
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using DIPLOMA.Services;

namespace DIPLOMA.Controllers
{
    [Authorize]
    public class MsgWidgetsController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        IHubContext<DonateHub> _hubContext;
        public MsgWidgetsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            IWebHostEnvironment webHost, IHubContext<DonateHub> hubContext)
        {
            _context = context;
            _userManager = userManager;
            _webHostEnvironment = webHost;
            _hubContext = hubContext;
        }

        // GET: MsgWidgets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MsgWidget.Include(m => m.User);
            return View(await applicationDbContext.ToListAsync());
        }
        // GET: MsgWidgets/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Display(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var msgWidget = await _context.MsgWidget
                .Include(m => m.User)
                .Include(m => m.MsgWidgetContent)
                .ThenInclude(m => m.Animation)
                .Include(m => m.MsgWidgetContent)
                .ThenInclude(m => m.Sound)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (msgWidget == null)
            {
                return NotFound();
            }

            return View(msgWidget);
        }
        public ActionResult LoadAudio(byte[] audioBytes)
        {
            return base.File(audioBytes, "audio/wav");
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
                .Include(m => m.MsgWidgetContent)
                .ThenInclude(m => m.Animation)
                .Include(m => m.MsgWidgetContent)
                .ThenInclude(m => m.Sound)
                .FirstOrDefaultAsync(m => m.ID == id);
            msgWidget.DisplayUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}" +
                    $"{msgWidget.Url}";


            if (msgWidget == null)
            {
                return NotFound();
            }

            MsgWidgetViewModel viewModel = new MsgWidgetViewModel();
            viewModel.MWidget = msgWidget;
            viewModel.MsgWidgetContent = msgWidget.MsgWidgetContent.ToList();

            foreach (var item in viewModel.MsgWidgetContent)
            {
                if(item.Animation?.Data != null
                    && item.Animation.Data.Length > 0)
                item.AnimSrc = String.Format("data:image/gif;base64,{0}", Convert.ToBase64String(item.Animation.Data));

            }

            return View(viewModel);
        }

        // GET: /MsgWidgets/Create
        public async Task<IActionResult> CreateAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if(user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(HttpContext.User)}'.");
            }

            var vm = new MsgWidgetViewModel();
            vm.MWidget = new MsgWidget();
            vm.MWidget.UserID = user.Id;
            vm.MWidget.MaxSymbols = 100;
            vm.MWidget.DisplayTimeSec = 5;

            var contentList = new List<MsgWidgetContent>();
            
            var msgContent = new MsgWidgetContent();

            contentList.Add(msgContent);

            vm.MsgWidgetContent = contentList;


            return View(vm);
        }
       
        private async Task<UploadFile> GetUploadFileAsync(IFormFile formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);
                UploadFile uploadFile = new UploadFile();
                uploadFile.ID = Guid.NewGuid();
                uploadFile.Name = formFile.FileName;
                if (uploadFile.Name.LastIndexOf(".") > 0)
                {
                    uploadFile.Extension = uploadFile.Name.
                        Trim().
                        Substring(uploadFile.Name.LastIndexOf("."));
                }
                uploadFile.Data = memoryStream.ToArray();

                return uploadFile;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MsgWidgetViewModel msgWidgetVM)
        {
            var msgWidget = msgWidgetVM.MWidget;
            var msgWidgetContent = msgWidgetVM.MsgWidgetContent;
            msgWidget.UserID = (string)ViewData["UserID"];

            if (ModelState.IsValid)
            {
                try
                {
                    msgWidget.ID = Guid.NewGuid();
                    msgWidget.Url = $"/{nameof(MsgWidgetsController)}/{nameof(this.Display)}/{msgWidget.ID}";
                    msgWidget.DisplayUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}"+
                    $"{msgWidget.Url}";
                    _context.Add(msgWidget);
                    foreach (var content in msgWidgetContent)
                    {
                        IFormFile animFromFile = content.AnimFormFile;
                        IFormFile soundFromFile = content.SoundFormFile;


                        if ((animFromFile.Length + soundFromFile.Length) < 2097152 * 20)
                        {
                            UploadFile animUploadFile = await GetUploadFileAsync(animFromFile);
                            UploadFile soundUploadFile = await GetUploadFileAsync(soundFromFile);

                            content.AnimationFileId = animUploadFile.ID;
                            content.SoundFileId = soundUploadFile.ID;

                            content.MsgWidgetID = msgWidget.ID;

                            _context.Add(animUploadFile);
                            _context.Add(soundUploadFile);

                            _context.Add(content);
                        }
                        else
                        {
                            ModelState.AddModelError("File", "The files is too large.");
                        }     
                    } 
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", msgWidget.UserID);
            return View(msgWidget);
        }

        private string GetUploadedFileName(IFormFile file)
        {
            string uniqueFileName = null;

            if (file != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
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
