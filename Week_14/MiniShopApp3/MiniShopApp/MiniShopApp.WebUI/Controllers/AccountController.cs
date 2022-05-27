using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiniShopApp.WebUI.EmailServices;
using MiniShopApp.WebUI.Identity;
using MiniShopApp.WebUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShopApp.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private IEmailSender _emailSender;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Login(string ReturnUrl=null)
        {
            return View(
                new LoginModel()
                {
                   ReturnUrl = ReturnUrl
                }
                );

        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            //Burada login işlemlerini gerçekleştireceğiz.
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model) //Async metod yapmak için IActionResult'u async Task<IActionResult> şeklinde değiştirdik.
        {
            if (!ModelState.IsValid) //modelimde validationlara uygun olmayan hergangi bir şey varsa
            {
                return View(model);
            }
            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName= model.UserName,
                Email = model.Email,
            };
            var resul = await _userManager.CreateAsync(user, model.Password); //Async metod=birden fazla işi aynı anda yapmak için 
            if (resul.Succeeded) //Create işlemi başarılıysa
            {
                //Burada mail onay işlemlerini yapacağız.
                //Token işlemleri
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var url = Url.Action("ConfirmEmail","Account",new
                { 
                    userId = user.Id,
                    token = code
                });
                //Mail gönderme işemleri
                await _emailSender.SendEmailAsync(model.Email, "MiniShopApp Hesap Onaylama", $"Lütfen email hesabınızı oynaylamak için <a href='https://localhost:5001{url}'>Tıklayınız</a>");
                return RedirectToAction("Login", "Account");
            }
            CreateMessage("hata", "danger");
            return View(model);
        }
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId==null || token == null)
            {
                return View();
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user!=null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    CreateMessage("Hesabınız onaylanmıştır", "success");
                    return View();
                }
            }
            CreateMessage("hesabınız onaylanamadı", "warning");
            return View();
        }
        private void CreateMessage(string message, string alertType)
        {
            var msg = new AlertMessage()
            {
                Message = message,
                AlertType = alertType
            };
            TempData["Message"] = JsonConvert.SerializeObject(msg);
        }
    }
}
