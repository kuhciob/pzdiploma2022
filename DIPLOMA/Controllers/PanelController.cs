﻿using DIPLOMA.Data;
using DIPLOMA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIPLOMA.Controllers
{
    public class PanelController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PanelController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DonateMsg.Include(d => d.User);
            return View(await applicationDbContext.ToListAsync());
        }
        public IActionResult Messages()
        {
            return View();
        }
        public IActionResult Fundraising()
        {
            return View();
        }
        public IActionResult Notification()
        {
            return View();
        }
        public IActionResult Statistic()
        {
            return View();
        }
    }
}
