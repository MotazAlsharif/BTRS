using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Claims;
using BRTS.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.CodeAnalysis.Scripting;
namespace BRTS.Web.Controllers
{
    public class UserController : Controller
    {   
        
        [Route("")]
        [Route("/User/Index")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Trips()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult EventDetails()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Elements()
        {
            return View();
        }public IActionResult SignIn()
        {
            return View("SignIn");
        }public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult CheckingStatus()
        {
            


            return View();
        }
        
        [HttpPost]
        public IActionResult CheckingStatusRequest(Account account)
        {
            ApplicationDBContext _dbContext = new ApplicationDBContext();
      
            var user = (from s in _dbContext.Accounts
                        where s.userName.Equals( account.emailAddress) && s.password.Equals(account.password)
                        select s ).FirstOrDefault();





            if (user != null)
            {
                return View("CheckingStatus" , user);   
            }
            else
            {
                return View("Index" );
            }

        }
       
        [HttpPost]
        public IActionResult SignUpRequest( Account Account)
        {
            ApplicationDBContext _dbContext = new ApplicationDBContext();
_dbContext.Accounts.Add(Account);
_dbContext.SaveChanges();
            return SignIn();
        }
       
        [HttpPost]
        public IActionResult SignInRequest( Account Account)
        {
            ApplicationDBContext _dbContext = new ApplicationDBContext();

            var user = ( from s in _dbContext.Accounts
                        where s.userName.Equals(Account.emailAddress) && s.password.Equals(Account.password )
                        select s).FirstOrDefault() ;



            if (user.role == "Admin")
            {
                return RedirectToAction( "AdminDashBoard", "Admin");
            }
            else if (user.role == "Captin")
            {
                return RedirectToAction( "CaptinDashBoard", "Captin");
            }
            else if(user.role == "User")
            {
                return RedirectToAction("CustomerDashBoard", "Customer", new { id = user.accountId});
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
        }
        
    }
}
