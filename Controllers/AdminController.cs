using BRTS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;

namespace BRTS.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminDashBoard()
        {
            ApplicationDBContext _dbContext = new ApplicationDBContext();
            var AccList = (from s in _dbContext.Accounts select s).ToList();            
            var BusList = (from s in _dbContext.Buses select s).ToList();
            var tripList = (from s in _dbContext.Trips select s).ToList();
            return View("AdminDashBoard", new BRTS.Web.Models.DashBoardViewModel(AccList, BusList, tripList));
        }    
        public IActionResult CreateTrip()
        {
            ApplicationDBContext _dbContext = new ApplicationDBContext();
            var BusList = (from s in _dbContext.Buses select s).ToList();
            return View(BusList);
        }
        public IActionResult AddNewBus()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewBusRequest(Bus bus)
        {
            ApplicationDBContext _dbContext = new ApplicationDBContext();
            _dbContext.Buses.Add(bus);
            _dbContext.SaveChanges();
            return View( "AddNewBus");
        } 
        [HttpPost]
        public IActionResult AddNewTripRequest(Trip trip , int BusId)
        {
            ApplicationDBContext _dbContext = new ApplicationDBContext();

            var BusList = (from s in _dbContext.Buses select s).ToList();

            _dbContext.Trips.Add(trip);
            _dbContext.SaveChanges();
            return View( "CreateTrip", BusList);    
                
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        [HttpPost]
        public IActionResult EditTrip( int tripId)
        {
            ApplicationDBContext _dbContext = new ApplicationDBContext();

            var BusList = (from s in _dbContext.Trips where s.TripId == tripId select s).ToList();

            return View("EditTrip", BusList[0]);

        } 
        [HttpPost]
        public IActionResult EditTripRequest( Trip tr )
        {
            ApplicationDBContext _dbContext = new ApplicationDBContext();
            var productToUpdate = (from s in _dbContext.Trips
                                where s.TripId == tr.TripId
                                select s).SingleOrDefault();
            productToUpdate.TripName = tr.TripName;
            productToUpdate.TripDestination = tr.TripDestination;
            productToUpdate.StartDateAndTime = tr.StartDateAndTime; 
            productToUpdate.EndDateAndTime = tr.EndDateAndTime;
            productToUpdate.TripGoingFrom = tr.TripGoingFrom;   


            _dbContext.SaveChanges();
            return AdminDashBoard();

        }
        [HttpPost]
        public IActionResult DropTrip(int tripId)
        {
            ApplicationDBContext _dbContext = new ApplicationDBContext();
            var productsToRemove = _dbContext.Trips
                                      .Where(product => product.TripId == tripId);

            _dbContext.Trips.RemoveRange(productsToRemove);
            _dbContext.SaveChanges();

            return AdminDashBoard();

        }

        ////////////////////////////////////////////////////////////

        [HttpPost]
        public IActionResult EditBusRequest(Bus tr)
        {
            ApplicationDBContext _dbContext = new ApplicationDBContext();
            var productToUpdate = (from s in _dbContext.Buses
                                   where s.BusId == tr.BusId
                                   select s).SingleOrDefault();
            productToUpdate.TotalSeats= tr.TotalSeats;
            productToUpdate.AvailabelSeats= tr.AvailabelSeats;
            productToUpdate.TripId = tr.TripId;
            productToUpdate.Captin_Id = tr.Captin_Id;

            _dbContext.SaveChanges();
            return AdminDashBoard();

        }

        [HttpPost]
        public IActionResult EditBus(int BusId)
        {
            ApplicationDBContext _dbContext = new ApplicationDBContext();

            var BusList = (from s in _dbContext.Buses where s.BusId == BusId select s).ToList();

            return View("EditBus", BusList[0]);

        }
        [HttpPost]
        public IActionResult DropBus(int tripId)
        {
            ApplicationDBContext _dbContext = new ApplicationDBContext();
            var productsToRemove = _dbContext.Buses.Where(product => product.BusId == tripId);

            _dbContext.Buses.RemoveRange(productsToRemove);
            _dbContext.SaveChanges();

            return AdminDashBoard();

        }



    }
}
