using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SupportService.Entities;
using SupportService.Models;
using SupportService.Util;

namespace SupportService.Controllers
{
    public class AccountController : Controller
    {
        private const string Obj = "Manager";
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;
        private readonly RoleManager<IdentityRole> _roleManager;
        
        public AccountController(UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signInManager,
                                 AppDbContext context,
                                 IEmailService emailService,
                                 RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _emailService = emailService;
            _roleManager = roleManager;
        }

        

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction( "Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Ticket");
            }

            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel registerUserViewModel)
        {
            //var dummy = await _userManager.FindByNameAsync(registerUserViewModel.Company.Replace(" ", ""));
            //if (dummy != null)
            //{
            //    return RedirectToAction("Register", "Account");
            //}

            if (ModelState.IsValid)
            {
                
                AppUser user = new AppUser { UserName = registerUserViewModel.Company.Replace(" ","") };
                user.Customers.Add(new Customer { Name = registerUserViewModel.Name,
                    PhoneNumber = registerUserViewModel.PhoneNumber,
                    Email = registerUserViewModel.Email,
                    UserName = registerUserViewModel.Company.Replace(" ", ""),
                    Company = registerUserViewModel.Company 

                });
                var createUser = await _userManager.CreateAsync(user, registerUserViewModel.Password);
                if (createUser.Succeeded)
                {
                    string subject = "Customer Added";
                    string message = "Welcome to Tech Height Support Service. You have been successfully registered to our portal.";
                    await _emailService.SendEmailAsync(registerUserViewModel.Email, subject, message);
                    //var jtitle = registerUserViewModel.Jobtitle.ToString();

                    //if (string.Equals(registerUserViewModel.Jobtitle.ToString(), Obj))
                    //{
                    //    if (!await _roleManager.RoleExistsAsync("Admin"))
                    //    {
                    //        var user_role = new IdentityRole("Admin");
                    //        var result = await _roleManager.CreateAsync(user_role);
                    //        if (result.Succeeded)
                    //        {
                    //            await _userManager.AddToRoleAsync(user, "Admin");
                    //        }
                    //    }

                    //}

                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Create", "Ticket");
                }
                else
                {
                    foreach (var error in createUser.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

                return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Create", "Ticket");
            }
            
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await _signInManager.PasswordSignInAsync(
                                                       model.Username, model.Password,
                                                       model.RememberMe, false);
                if (loginResult.Succeeded)
                {
                    if (Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Create", "Ticket");
                    }
                }

            }
            ModelState.AddModelError("", "Could not login");
            return View(model);

        }

    }
}