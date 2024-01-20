using BRTS.Web.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Net;
using System.Security.Claims;

namespace BRTS.Web.Controllers
{
    public class CustomerController : Controller
    { 
        public IActionResult CustomerDashBoard(int id)
        {
            ApplicationDBContext _dbContext = new ApplicationDBContext();
            var tripList = (from s in _dbContext.Trips select s).ToList();
            var BookedTripsList = ( (    from a in _dbContext.BookedRequests
                                         where a.accountId == id
                                         join c in _dbContext.Trips on a.TripId equals c.TripId
                                         select c ).ToList());
            return View("CustomerDashBoard", new DashBoardViewModel(tripList, id, BookedTripsList));
        }
       

        [HttpPost]
        public IActionResult BookAtrip(int id, int TripId)
        {
            ApplicationDBContext _dbContext = new ApplicationDBContext();
            BookedRequests c = new BookedRequests();
            c.accountId = id;
            c.TripId = TripId;
            _dbContext.BookedRequests.Add(c);
            _dbContext.SaveChanges();
            return CustomerDashBoard(id);
        }
        [HttpPost]
        public IActionResult DeleteAtrip(int id, int TripId)
        {
            ApplicationDBContext _dbContext = new ApplicationDBContext();
            var productsToRemove = _dbContext.BookedRequests
                                   .Where(product => product.TripId == TripId && product.accountId == id);

            _dbContext.BookedRequests.RemoveRange(productsToRemove);
            _dbContext.SaveChanges();
            return CustomerDashBoard(id);
        }

       
    }
}
