using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DIPLOMA.Data;
using DIPLOMA.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace DIPLOMA.Controllers
{
    public class UserProfilesController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public UserProfilesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
             IHttpContextAccessor httpContextAccessor)
            : base(context, userManager, httpContextAccessor)
        {
            _context = context;
        }

        //// GET: UserProfiles
        public async Task<IActionResult> UserProfile()
        {
            var userprofile = await _context.UserProfile.
                Include(u => u.BackgroundImg).
                Include(u => u.ProfilePic).
                Include(u => u.User).
                FirstOrDefaultAsync(u => u.UserID == _currentUserId);

            if(userprofile == null)
            {
                userprofile = new UserProfile();
                userprofile.UserID = _currentUserId;

                var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == _currentUserId);
                userprofile.User = user;
            }
            else
            {
                userprofile.BackgroundImgSrc = base.ContanteToUrls(userprofile.BackgroundImg);
                userprofile.ProfilePicImgSrc = base.ContanteToUrls(userprofile.ProfilePic);

                userprofile.BackgroundImgFormFile = GetFormFile(userprofile.BackgroundImg);
                userprofile.ProfilePicFormFile = GetFormFile(userprofile.ProfilePic);
            }


            userprofile.ProfileUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}" +
                "/Donate/"+
                   $"{userprofile.User.NickName}";
            return View(userprofile);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserProfile(UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                if (userProfile == null)
                {
                    return NotFound();
                }

                if (userProfile.ID == null
                    || userProfile.ID == default(Guid))
                {
                    userProfile.ID = Guid.NewGuid();

                    IFormFile backFormFile = userProfile.BackgroundImgFormFile;
                    IFormFile profPicFornmFile = userProfile.ProfilePicFormFile;

                    if ((backFormFile?.Length + profPicFornmFile?.Length) < 2097152 * 20)
                    {
                        UploadFile backUploadFile = await GetUploadFileAsync(backFormFile);
                        UploadFile profPicUploadFile = await GetUploadFileAsync(profPicFornmFile);

                        userProfile.BackgroundImgId = backUploadFile.ID;
                        userProfile.ProfilePicId = profPicUploadFile.ID;

                        _context.Add(backUploadFile);
                        _context.Add(profPicUploadFile);
                    }


                    _context.Add(userProfile);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(UserProfile));
                }
                else
                {
                    try
                    {
                        List<Guid?> deleatedFileID = new List<Guid?>();

                        IFormFile backFormFile = userProfile.BackgroundImgFormFile;
                        IFormFile profPicFornmFile = userProfile.ProfilePicFormFile;

                        if ((backFormFile?.Length + profPicFornmFile?.Length ?? 0) < 2097152 * 20)
                        {
                            if (backFormFile != null)
                            {
                                if (backFormFile != null)
                                {
                                    Guid? oldId = userProfile.BackgroundImgId;

                                    if (oldId != null)
                                    {
                                        deleatedFileID.Add(oldId);
                                    }

                                    UploadFile animUploadFile = await GetUploadFileAsync(backFormFile);
                                    userProfile.BackgroundImgId = animUploadFile.ID;
                                    _context.Add(animUploadFile);

                                                                  
                                }

                            }
                            if (profPicFornmFile != null)
                            {
                                if (profPicFornmFile != null)
                                {
                                    var oldId = userProfile.ProfilePicId;
                                    if (oldId != null)
                                    {
                                        deleatedFileID.Add(oldId);
                                    }

                                    UploadFile soundUploadFile = await GetUploadFileAsync(profPicFornmFile);
                                    userProfile.ProfilePicId = soundUploadFile.ID;

                                    _context.Add(soundUploadFile);

                                }

                            }

                        }
                        else
                        {
                            ModelState.AddModelError("File", "The files is too large.");
                        }

                        _context.Update(userProfile);
                        await _context.SaveChangesAsync();

                        foreach (var item in deleatedFileID)
                        {
                            _context.Remove(_context.UploadFile.
                                            FirstOrDefault(f => f.ID == item));
                        }
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!UserProfileExists(userProfile.ID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(UserProfile));
                }

                
            }
            
            ViewData["BackgroundImgId"] = new SelectList(_context.UploadFile, "ID", "ID", userProfile.BackgroundImgId);
            ViewData["ProfilePicId"] = new SelectList(_context.UploadFile, "ID", "ID", userProfile.ProfilePicId);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", userProfile.UserID);
            return View(userProfile);
        }
        //GET: UserProfiles/Details/5
        [HttpGet("User/{username}")]
        [AllowAnonymous]

        public async Task<IActionResult> Details(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return NotFound();
            }

            var userProfile = await _context.UserProfile
                .Include(u => u.BackgroundImg)
                .Include(u => u.ProfilePic)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.User.NickName == username);
            if (userProfile == null)
            {
                return NotFound();
            }
            //else
            //{
            //    userProfile = new UserProfile();
            //}

            userProfile.BackgroundImgSrc = base.ContanteToUrls(userProfile.BackgroundImg);
            userProfile.ProfilePicImgSrc = base.ContanteToUrls(userProfile.ProfilePic);

            return View(userProfile);
        }

        // GET: UserProfiles/Create
        //public IActionResult Create()
        //{
        //    ViewData["BackgroundImgId"] = new SelectList(_context.UploadFile, "ID", "ID");
        //    ViewData["ProfilePicId"] = new SelectList(_context.UploadFile, "ID", "ID");
        //    ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id");
        //    return View();
        //}

        // POST: UserProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                userProfile.ID = Guid.NewGuid();
                _context.Add(userProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BackgroundImgId"] = new SelectList(_context.UploadFile, "ID", "ID", userProfile.BackgroundImgId);
            ViewData["ProfilePicId"] = new SelectList(_context.UploadFile, "ID", "ID", userProfile.ProfilePicId);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", userProfile.UserID);
            return View(userProfile);
        }

        // GET: UserProfiles/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProfile = await _context.UserProfile.FindAsync(id);
            if (userProfile == null)
            {
                return NotFound();
            }
            ViewData["BackgroundImgId"] = new SelectList(_context.UploadFile, "ID", "ID", userProfile.BackgroundImgId);
            ViewData["ProfilePicId"] = new SelectList(_context.UploadFile, "ID", "ID", userProfile.ProfilePicId);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", userProfile.UserID);
            return View(userProfile);
        }

        // POST: UserProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Instagram,Discord,Twitter,Facebook,Youtube,Twitch,Telegram,Bio,BackgroundImgId,ProfilePicId,UserID")] UserProfile userProfile)
        {
            if (id != userProfile.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserProfileExists(userProfile.ID))
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
            ViewData["BackgroundImgId"] = new SelectList(_context.UploadFile, "ID", "ID", userProfile.BackgroundImgId);
            ViewData["ProfilePicId"] = new SelectList(_context.UploadFile, "ID", "ID", userProfile.ProfilePicId);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", userProfile.UserID);
            return View(userProfile);
        }

        // GET: UserProfiles/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProfile = await _context.UserProfile
                .Include(u => u.BackgroundImg)
                .Include(u => u.ProfilePic)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (userProfile == null)
            {
                return NotFound();
            }

            return View(userProfile);
        }

        // POST: UserProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var userProfile = await _context.UserProfile.FindAsync(id);
            _context.UserProfile.Remove(userProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public bool UserProfileExists(Guid id)
        {
            return _context.UserProfile.Any(e => e.ID == id);
        }
    }
}
