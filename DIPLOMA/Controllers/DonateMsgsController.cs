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
using Stripe;
using Stripe.BillingPortal;
using Stripe.Checkout;
using Newtonsoft.Json;
using System.Net;
using System.Globalization;

namespace DIPLOMA.Controllers
{
    [Authorize]
    public class DonateMsgsController : BaseController
    {
        private IHubContext<DonateHub> _donateHub;
        //private readonly ApplicationDbContext _context;
        //private readonly UserManager<ApplicationUser> _userManager;
        //private string _currentUserId;
        public DonateMsgsController(ApplicationDbContext context, IHubContext<DonateHub> hubContext,
            UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
            : base(context, userManager, httpContextAccessor)
        {
            _donateHub = hubContext;
        }

        //// GET: DonateMsgs
        public async Task<IActionResult> Test()
        {
            List<string> Donators = new List<string> { "Ivan", "Petro Kegla", "Mazeppa", "Ruslannndsa", "BAZA" };
            Random random = new Random();

            double minDonateAmt = 300;
            double maxDonateAmt = 500000;

            var donates = await _context.DonateMsg.
                Include(m => m.User).
                Where(r => r.UserID == _currentUserId).
                ToListAsync();

            DateTime startDate = donates.Min(r => r.CreatedDate).Date;

            DateTime dateTime = DateTime.Now.Date;

            while(startDate <= dateTime)
            {
                DonateMsg donateMsg = new DonateMsg()
                {
                    CreatedDate = startDate,
                    DonatorName = Donators.ElementAt(random.Next(Donators.Count)),
                    Message = $"Test Donate {startDate.ToShortDateString()}",
                    Amount = Convert.ToDecimal(random.NextDouble() * (maxDonateAmt - minDonateAmt) + minDonateAmt),
                    Read = true,
                    UserID = _currentUserId,
                    UpdatedDate = startDate,
                    CheckoutSessionSucceed = true
                };

                _context.Add(donateMsg);
                startDate = startDate.AddDays(1);
            }
            await _context.SaveChangesAsync();
            return new JsonResult("Done");
        }
        public async Task<IActionResult> Index(DateTime? StartDate, DateTime? EndDate, string DonatorName)
        {
            var donateMsgs = _context.DonateMsg.
                Include(m => m.User).
                Where(r => r.UserID == _currentUserId);

            donateMsgs = donateMsgs.
                Where(r => (r.CreatedDate >= StartDate || StartDate == null)
                && (r.CreatedDate <= EndDate || EndDate == null)
                && (string.IsNullOrEmpty(DonatorName) || r.DonatorName == DonatorName));

            ViewBag.StartDate = StartDate;
            ViewBag.EndDate= EndDate;
            ViewBag.DonatorName = DonatorName;

            return View(await donateMsgs.ToListAsync());
        }
        // GET: Donate/lvasuk
        [AllowAnonymous]
        [HttpGet("TestDonate/{username}")]
        public async Task<IActionResult> TestDonate(string username)
        {
            return await Create(username);
        }
        [HttpPost("TestDonate/{username}")]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> TestDonate(DonateMsg donateMsg)
        {
            if (ModelState.IsValid)
            {
                var session = CreateCheckoutSession(donateMsg);

                donateMsg.CheckoutSessionID = session.Id;
                donateMsg.CreatedDate = DateTime.Now;
                _context.Add(donateMsg);
                await _context.SaveChangesAsync();               
                await _donateHub.Clients.Group(donateMsg.UserID).SendAsync("ReceiveMessage", donateMsg);
                ////await _donateHub.Clients.All.SendAsync("ReceiveMessage", donateMsg);
                List<FundraisingWidget> fundrasingWidgets = await _context.FundraisingWidget.
                    Where(r => r.UserID == donateMsg.UserID
                    && r.Active == true).
                    ToListAsync();

                try
                {
                    foreach (var item in fundrasingWidgets)
                    {
                        item.CollectedAmt = item.CollectedAmt.GetValueOrDefault() + donateMsg.Amount;
                        _context.Update(item);
                    }
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                }


                return RedirectToAction(nameof(Create));
            }
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", donateMsg.UserID);


            return View(donateMsg);
        }
        [AllowAnonymous]
        [HttpGet("Donate/{username}")]
        //[HttpGet()]
        public async Task<IActionResult> Create(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(r => r.UserProfile)
                .ThenInclude(u => u.BackgroundImg)
                .Include(r => r.UserProfile)
                .ThenInclude(u => u.ProfilePic)
                .FirstOrDefaultAsync(m => m.NickName == username);

            if (user == null)
            {
                return NotFound();
            }

            if(user.UserProfile != null)
            {
                user.UserProfile.BackgroundImgSrc = base.ContanteToUrls(user.UserProfile.BackgroundImg);
                user.UserProfile.ProfilePicImgSrc = base.ContanteToUrls(user.UserProfile.ProfilePic);
            }
            else
            {
                user.UserProfile = new UserProfile();
            }
            

            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", user.Id);

            var donMsg = new DonateMsg();
            donMsg.UserID = user.Id;
            donMsg.User = user;
            return View(donMsg);
        }

        [HttpPost("create-checkout-session")]
        public ActionResult CreateCheckoutSession()
        {
            var session = CreateCheckoutSession();
            return new StatusCodeResult(303);
        }
        public Stripe.Checkout.Session CreateCheckoutSession(DonateMsg donateMsg)
        {
            string domainName = $"{this.Request.Scheme}://{this.Request.Host}";
            StripeConfiguration.ApiKey = "sk_test_4eC39HqLyjWDarjtT1zdp7dc";

            var options = new Stripe.Checkout.SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            //UnitAmount = Convert.ToInt64( donateMsg.Amount.GetValueOrDefault() * 100),
                            UnitAmountDecimal = donateMsg.Amount * 100,
                            Currency = "usd",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "Donate",
                                //Images = 
                            },

                        },
                        Quantity = 1,
                    },
                },
                Mode = "payment",
                SuccessUrl = domainName + "/Donate/success?session_id={CHECKOUT_SESSION_ID}",
                
                CancelUrl = domainName + "/Donate/cancel?session_id={CHECKOUT_SESSION_ID}",
            };
            

            var service = new Stripe.Checkout.SessionService();
            Stripe.Checkout.Session session = service.Create(options);
            Response.Headers.Add("Location", session.Url);

            session.Metadata.Add("TESTMETA", "HELLO!");
            return session;
        }

        [HttpPost()]
        [AllowAnonymous]
        public async Task<IActionResult> SendToHub(DonateMsg donateMsg)
        {
            await _donateHub.Clients.Group(donateMsg.UserID).SendAsync("ReceiveMessage", donateMsg);
            return Ok();
        }
        
        // POST: DonateMsgs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Donate/{username}")]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Create(DonateMsg donateMsg)
        {
            if (ModelState.IsValid)
            {
                var session = CreateCheckoutSession(donateMsg);

                donateMsg.CheckoutSessionID = session.Id;
                donateMsg.CreatedDate = DateTime.Now;
                var clientIpAddress = Request.HttpContext.Connection.RemoteIpAddress;
  

                _context.Add(donateMsg);
                await _context.SaveChangesAsync();

                //session.Metadata.Add("DonateMsgID", donateMsg.ID.GetValueOrDefault().ToString());
                return new StatusCodeResult(303);

                //await _donateHub.Clients.Group(donateMsg.UserID).SendAsync("ReceiveMessage", donateMsg);
                ////await _donateHub.Clients.All.SendAsync("ReceiveMessage", donateMsg);
                //List<FundraisingWidget> fundrasingWidgets = await _context.FundraisingWidget.
                //    Where(r => r.UserID == donateMsg.UserID
                //    && r.Active == true).
                //    ToListAsync();

                try
                {
                    //foreach (var item in fundrasingWidgets)
                    //{
                    //    item.CollectedAmt = item.CollectedAmt.GetValueOrDefault() + donateMsg.Amount;
                    //    _context.Update(item);
                    //}
                    //await _context.SaveChangesAsync();
                }
                catch(Exception ex)
                {

                }
                

                return RedirectToAction(nameof(Create));
            }
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", donateMsg.UserID);


            return View(donateMsg);
        }
        [HttpGet("Donate/success")]
        [AllowAnonymous]
        public async Task<IActionResult> DonateSuccess([FromQuery] string session_id)
        {
            var sessionService = new Stripe.Checkout.SessionService();
            Stripe.Checkout.Session session = sessionService.Get(session_id);

            var customerService = new CustomerService();
            Customer customer = customerService.Get(session.CustomerId);

            DonateMsg donateMsg = await _context.DonateMsg
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.CheckoutSessionID == session_id);

            if (donateMsg == null)
            {
                return Content($"<html><body><h1>Ups... Something Go wrong :(</h1></body></html>");

            }
            else
            {
                donateMsg.CheckoutSessionSucceed = true;
               

                if(donateMsg.Read == false)
                {
                    await _donateHub.Clients.Group(donateMsg.UserID).SendAsync("ReceiveMessage", donateMsg);
                    donateMsg.Read = true;
                }
                _context.Update(donateMsg);
                await _context.SaveChangesAsync();

                List<FundraisingWidget> fundrasingWidgets = await _context.FundraisingWidget.
                    Where(r => r.UserID == donateMsg.UserID
                    && r.Active == true).
                    ToListAsync();

                try
                {
                    foreach (var item in fundrasingWidgets)
                    {
                        item.CollectedAmt = item.CollectedAmt.GetValueOrDefault() + donateMsg.Amount;
                        _context.Update(item);
                    }
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                }
                
                return View();

            }
        }
        [HttpGet("Donate/cancel")]
        [AllowAnonymous]
        public async Task<ActionResult> DonateCancelAsync([FromQuery] string session_id)
        {
            var donateMsg = await _context.DonateMsg
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.CheckoutSessionID == session_id);

            if (donateMsg == null)
            {
                return NotFound();
            }
            else
            {
                donateMsg.CheckoutSessionSucceed = false;
                _context.DonateMsg.Remove(donateMsg);
                await _context.SaveChangesAsync();
                return Content($"<html><body><h1>Donate waw cance!</h1></body></html>");

            }
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

        // GET: DonateMsgs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
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
        public async Task<IActionResult> Edit(int? id,  DonateMsg donateMsg)
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
        public class IpInfo
        {
            [JsonProperty("ip")]
            public string Ip { get; set; }

            [JsonProperty("hostname")]
            public string Hostname { get; set; }

            [JsonProperty("city")]
            public string City { get; set; }

            [JsonProperty("region")]
            public string Region { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("loc")]
            public string Loc { get; set; }

            [JsonProperty("org")]
            public string Org { get; set; }

            [JsonProperty("postal")]
            public string Postal { get; set; }
        }
        public static string GetUserCountryByIp(string ip)
        {
            IpInfo ipInfo = new IpInfo();
            try
            {
                string info = new WebClient().DownloadString("http://ipinfo.io/" + ip);
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
                RegionInfo myRI1 = new RegionInfo(ipInfo.Country);
                ipInfo.Country = myRI1.EnglishName;
            }
            catch (Exception)
            {
                ipInfo.Country = null;
            }

            return ipInfo.Country;
        }
        protected bool DonateMsgExists(int? id)
        {
            return _context.DonateMsg.Any(e => e.ID == id);
        }
    }
}
