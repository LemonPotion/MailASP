using Kurstest.Services;
using MailASP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MailASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IEmailSender emailSender;
        public HomeController(IEmailSender service, ILogger<HomeController> logger)
        {
            emailSender = service;
            _logger = logger;
        }
        [HttpPost]
        public IActionResult SendEmail()
        {
            string? recipientEmail = Request.Form["Email"];
            string? subject = Request.Form["Subject"];
            string? message = Request.Form["message"];
            Console.WriteLine("Recipient mail:"+recipientEmail);
            Console.WriteLine("Subject:"+subject);
            Console.WriteLine("Message:"+message);
            emailSender.SendEmailAsync(recipientEmail, subject, message);
            return RedirectToAction("Privacy");
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
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