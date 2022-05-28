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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.IO;

namespace DIPLOMA.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected readonly ApplicationDbContext _context;
        protected readonly UserManager<ApplicationUser> _userManager;
        protected string _currentUserId;
        public BaseController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _currentUserId = httpContextAccessor?.HttpContext?.User.
                FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public async Task<UploadFile> GetUploadFileAsync(IFormFile formFile)
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

        public IEnumerable<(string, string)> ContanteToUrls(IEnumerable<MsgWidgetContent> contentList)
        {
            foreach (var item in contentList)
            {
                yield return ContanteToUrls(item);
            }
        }
        /// <summary>
        /// Return Url for image file
        /// If issound == true, it process sound
        /// </summary>
        /// <param name="content"></param>
        /// <param name="issound"></param>
        /// <returns></returns>
        public string ContanteToUrls(UploadFile content, bool issound = false)
        {
            string scr = "";
            if(content != null)
            {
                if (issound)
                {
                    if (content.Extension.Contains("wav"))
                    {
                        scr = String.Format("data:audio/wav;base64,{0}",
                            Convert.ToBase64String(content.Data));
                    }
                    else
                    if (content.Extension.Contains("mp3"))
                    {
                        scr = String.Format("data:audio/mp3;base64,{0}",
                            Convert.ToBase64String(content.Data));
                    }
                    else
                    {
                        scr = String.Format("data:audio/{0};base64,{1}",
                        content.Extension.Replace(".", ""), Convert.ToBase64String(content.Data));
                    }

                }
                else
                {
                    if (content.Extension.Contains("gif"))
                    {
                        scr = String.Format("data:image/gif;base64,{0}",
                         Convert.ToBase64String(content.Data));
                    }
                    else
                    {
                        scr = String.Format("data:image/{0};base64,{1}",
                        content.Extension.Replace(".", ""), Convert.ToBase64String(content.Data));
                    }
                }
                
            }
            return scr;
        }
        public (string, string) ContanteToUrls(MsgWidgetContent content)
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
        public IFormFile GetFormFile(UploadFile uploadFile)
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
    }
}
