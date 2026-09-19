using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace LegacyMvcApp.Controllers
{
    public class LegacyController : Controller
    {
        [Obsolete("This method is deprecated and will be removed in future versions.")]
        public IActionResult OldMethod()
        {
            // Using WebClient which is obsolete in newer .NET versions
#pragma warning disable SYSLIB0014 // Type or member is obsolete
            using (WebClient client = new WebClient())
            {
                var data = client.DownloadString("https://example.com");
                ViewBag.Data = data;
            }
#pragma warning restore SYSLIB0014 // Type or member is obsolete
            return View();
        }

        public IActionResult UseMd5()
        {
            // MD5 is considered insecure and often flagged during migrations
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                var hash = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes("test"));
                ViewBag.Hash = BitConverter.ToString(hash);
            }
            return View("OldMethod");
        }
    }
}
