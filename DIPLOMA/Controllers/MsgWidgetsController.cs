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
    [Authorize]
    public class MsgWidgetsController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MsgWidgetsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            IWebHostEnvironment webHost, IHttpContextAccessor httpContextAccessor)
            : base(context, userManager, httpContextAccessor)
        {
            _webHostEnvironment = webHost;

        }

        // GET: MsgWidgets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MsgWidget.
                Include(m => m.User).
                Where(r => r.UserID == _currentUserId);
            return View(await applicationDbContext.ToListAsync());
        }

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
               .Include(m => m.TextStyle)

                .FirstOrDefaultAsync(m => m.ID == id);

            DisplayMsgViewModel displayMsgViewModel = new DisplayMsgViewModel();
            displayMsgViewModel.MWidget = msgWidget;
            displayMsgViewModel.Content = new List<MsgWidgetContentViewModel>();
            if (msgWidget.TextStyle == null)
            {
                msgWidget.TextStyle = new TextStyle();
            }
            displayMsgViewModel.TextStyle = msgWidget.TextStyle;
            
            var contentUrls = ContanteToUrls(msgWidget.MsgWidgetContent.ToList());
            foreach (var item in contentUrls)
            {
                MsgWidgetContentViewModel msgVM = new MsgWidgetContentViewModel();
                msgVM.AnimSrc = item.Item1;
                msgVM.SoundSrc = item.Item2;

                displayMsgViewModel.Content.Add(msgVM);
            }

            if (msgWidget == null)
            {
                return NotFound();
            }
            return View(displayMsgViewModel);
        }
        public ActionResult LoadAudio(MsgWidgetContent msgWidgetContent)
        {
            byte[] audioBytes = msgWidgetContent.Sound.Data;
            string format = "audio/mp3";
            if (msgWidgetContent.Sound.Extension.Contains("mp3"))
            {
                format = "audio/mp3";
            }
            else
            if (msgWidgetContent.Sound.Extension.Contains("wav"))
            {
                format = "audio/wav";
            }
            return base.File(audioBytes, format);
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
                .ThenInclude(m => m.Sound)
                .Include(m => m.MsgWidgetContent)
                .ThenInclude(m => m.Animation)
               .Include(m => m.TextStyle)

                .Where(r => r.UserID == _currentUserId)
                .FirstOrDefaultAsync(m => m.ID == id);

            msgWidget.DisplayUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}" +
                    $"{msgWidget.Url.Replace("Controller", "")}";


            if (msgWidget == null)
            {
                return NotFound();
            }

            MsgWidgetViewModel viewModel = new MsgWidgetViewModel();
            viewModel.MWidget = msgWidget;
            viewModel.VMMsgWidgetContent = msgWidget.MsgWidgetContent.ToList();


            foreach (var item in viewModel.VMMsgWidgetContent)
            {
                var contentsUrls = ContanteToUrls(item);

                item.AnimSrc = contentsUrls.Item1;
                item.SoundSrc = contentsUrls.Item2;

            }

            return View(viewModel);
        }

        #region Create
        // GET: /MsgWidgets/Create
        public async Task<IActionResult> CreateAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(HttpContext.User)}'.");
            }

            var vm = new MsgWidgetViewModel();
            vm.MWidget = new MsgWidget();
            //vm.MWidget.TextStyle = new TextStyle();
            vm.TextStyle = new TextStyle();

            vm.MWidget.UserID = user.Id;
            vm.MWidget.MaxSymbols = 100;
            vm.MWidget.DisplayTimeSec = 5;

            var contentList = new List<MsgWidgetContent>();

            var msgContent = new MsgWidgetContent();

            contentList.Add(msgContent);

            vm.VMMsgWidgetContent = contentList;


            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MsgWidgetViewModel msgWidgetVM)
        {
            var msgWidget = msgWidgetVM.MWidget;
            var msgWidgetContent = msgWidgetVM.VMMsgWidgetContent;
            //msgWidget.UserID = (string)ViewData["UserID"];

            if (ModelState.IsValid)
            {
                try
                {
                    msgWidget.ID = Guid.NewGuid();
                    msgWidget.Url = $"/{nameof(MsgWidgetsController).Replace("Controller", "")}/{nameof(this.Display)}/{msgWidget.ID}";
                    msgWidget.DisplayUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}" +
                    $"{msgWidget.Url}";
                    msgWidget.TextStyle = msgWidgetVM.TextStyle;
                    //_context.Add(msgWidget.TextStyle);
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

        #endregion
        #region Edit
        public async Task<IActionResult> Edit(Guid? id)
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
               .Include(m => m.TextStyle)
               .Where(r => r.UserID == _currentUserId)
               .FirstOrDefaultAsync(m => m.ID == id);
            msgWidget.DisplayUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}" +
                    $"{msgWidget.Url.Replace("Controller", "")}";

            if (msgWidget == null)
            {
                return NotFound();
            }
            if (msgWidget.TextStyle == null)
            {
                msgWidget.TextStyle = new TextStyle();
            }

            MsgWidgetViewModel viewModel = new MsgWidgetViewModel();
            viewModel.MWidget = msgWidget;
            viewModel.TextStyle = msgWidget.TextStyle;
            //viewModel.VMMsgWidgetContent = new List<MsgWidgetContent>() { new MsgWidgetContent() };
            viewModel.VMMsgWidgetContent = msgWidget.MsgWidgetContent.ToList();


            foreach (var item in viewModel.VMMsgWidgetContent)
            {
                var contentsUrls = ContanteToUrls(item);

                item.AnimSrc = contentsUrls.Item1;
                item.SoundSrc = contentsUrls.Item2;
                item.AnimFormFile = GetFormFile(item.Animation);
                item.SoundFormFile = GetFormFile(item.Sound);
            }
            viewModel.VMMsgWidgetContent.Add(new MsgWidgetContent());

            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", msgWidget.UserID);
            return View(viewModel);
        }
        public async Task<IActionResult> EditBASE(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var msgWidget = await _context.MsgWidget.FirstOrDefaultAsync(m => m.ID == id);
            msgWidget.DisplayUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}" +
                    $"{msgWidget.Url.Replace("Controller", "")}";

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
        public async Task<IActionResult> Edit(Guid id, MsgWidgetViewModel msgWidgetViewModel)
        {
            MsgWidget msgWidget = msgWidgetViewModel.MWidget;
            msgWidget.TextStyle = msgWidgetViewModel.TextStyle;
            List<MsgWidgetContent> contentList = msgWidgetViewModel.VMMsgWidgetContent;

            if (id != msgWidget.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //return View(msgWidgetViewModel.MWidget);

                try
                {
                    //var origContent = await _context.MsgWidgetContent.
                    //    Where(r => r.MsgWidgetID == msgWidget.ID).
                    //    ToListAsync();

                    msgWidget.MsgWidgetContent = new List<MsgWidgetContent>();
                    List<Guid?> deleatedFileID = new List<Guid?>();
                    foreach (var content in contentList)
                    {

                        IFormFile animFromFile = content.AnimFormFile;
                        IFormFile soundFromFile = content.SoundFormFile;

                        if (animFromFile == null
                            && soundFromFile == null)
                        {
                            continue;
                        }

                        if ((animFromFile?.Length + soundFromFile?.Length ?? 0) < 2097152 * 20)
                        {
                            if (animFromFile != null)
                            {
                                Guid? oldId = content.AnimationFileId;
                                if (oldId != null)
                                {
                                    deleatedFileID.Add(oldId);
                                }

                                UploadFile animUploadFile = await GetUploadFileAsync(animFromFile);
                                content.AnimationFileId = animUploadFile.ID;
                           
                                _context.Add(animUploadFile);
                            }
                            if (soundFromFile != null)
                            {
                                var oldId = content.SoundFileId;
                                if (oldId != null)
                                {
                                    deleatedFileID.Add(oldId);
                                }

                                UploadFile soundUploadFile = await GetUploadFileAsync(soundFromFile);
                                content.SoundFileId = soundUploadFile.ID;

                                _context.Add(soundUploadFile);

                            }
                            if (content.ID != null
                                && content.MsgWidgetID != null)
                            {
                                msgWidget.MsgWidgetContent.Add(content);
                            }
                            else
                            {
                                content.MsgWidgetID = msgWidgetViewModel.MWidget.ID;
                                _context.Add(content);
                            }


                        }
                        else
                        {
                            ModelState.AddModelError("File", "The files is too large.");
                        }


                    }

                    _context.Update(msgWidget);
                    await _context.SaveChangesAsync();

                    foreach (var item in deleatedFileID)
                    {
                        _context.Remove(_context.UploadFile.
                                        FirstOrDefault(f => f.ID == item));
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MsgWidgetExists(msgWidgetViewModel.MWidget.ID))
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
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", msgWidgetViewModel.MWidget.UserID);
            return View(msgWidgetViewModel);
        }

        // POST: MsgWidgets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBASE(Guid id, 
            //[Bind("MinAmt,MaxAmt,HeaderText,MaxSymbols,DisplayTimeSec,RandomContent,ReadHeader,ReadMessage,ID,UserID,Name,Url")] 
        MsgWidget msgWidget)
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

        #endregion
        #region Delete
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
        #endregion
        #region Helpers
        private IFormFile GetFormFile(UploadFile uploadFile)
        {
            if (uploadFile != null
                && uploadFile.Data != null)
            {
                using (var stream = new MemoryStream(uploadFile.Data))
                {
                    IFormFile file = new FormFile(stream, 0, uploadFile.Data.Length,
                        uploadFile.Name, uploadFile.Name);
                    return file;
                }
            }
            else
            {
                return null;
            }
        }
        private bool MsgWidgetExists(Guid id)
        {
            return _context.MsgWidget.Any(e => e.ID == id);
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
        private IEnumerable<(string, string)> ContanteToUrls(IEnumerable<MsgWidgetContent> contentList)
        {
            foreach (var item in contentList)
            {
                yield return ContanteToUrls(item);
            }
        }
        private (string, string) ContanteToUrls(MsgWidgetContent content)
        {
            string animScr = "";
            string soundScr = "";

            if (content.Animation != null)
            {
                if (content.Animation.Extension.Contains("gif"))
                {
                    animScr = String.Format("data:image/gif;base64,{0}",
                     Convert.ToBase64String(content.Animation.Data));
                }
                else
                {
                    animScr = String.Format("data:image/{0};base64,{1}",
                     content.Animation.Extension.Replace(".", ""), Convert.ToBase64String(content.Animation.Data));
                }

            }
            if (content.Sound != null)
            {
                if (content.Sound.Extension.Contains("wav"))
                {
                    soundScr = String.Format("data:audio/wav;base64,{0}",
                        Convert.ToBase64String(content.Sound.Data));
                }
                else
                if (content.Sound.Extension.Contains("mp3"))
                {
                    soundScr = String.Format("data:audio/mp3;base64,{0}",
                        Convert.ToBase64String(content.Sound.Data));
                }
                else
                {
                    soundScr = String.Format("data:audio/{0};base64,{1}",
                        content.Sound.Extension.Replace(".", ""), Convert.ToBase64String(content.Sound.Data));
                }

            }

            return (animScr, soundScr);
        }
        #endregion

    }
}
