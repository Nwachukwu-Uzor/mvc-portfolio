using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portfolio.MVC.Contracts;
using Portfolio.MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _emailService;

        public HomeController(ILogger<HomeController> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(EmailViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) { 
                    TempData["Error"] = "Invalid Model Property";
                }

                await _emailService.SendMail(model);
                return RedirectToAction(nameof(Sent), new SentViewModel { Name = model.Name } );
            } catch(Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
           
        }

        public IActionResult Sent(SentViewModel sendView)
        {
            return View(sendView);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
