using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Data;
using SharedTrip.Dtos.Trips;
using SharedTrip.Models;
using SharedTrip.Services;
using System;
using System.Linq;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext data;
        public TripsController(IValidator validator, ApplicationDbContext data)
        {
            this.validator = validator;
            this.data = data;
        }

        [Authorize]
        public HttpResponse All()
        {
            var allTrips = this.data
                .Trips
                .Select(trip => new AllTripsViewModel
                {
                    Id = trip.Id,
                    StartPoint = trip.StartPoint,
                    EndPoint = trip.EndPoint,
                    Description = trip.Description,
                    Seats = trip.Seats,
                    DepartureTime = trip.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    ImagePath = trip.ImagePath
                })
                .ToList();

            return View(allTrips);
        }

        [Authorize]
        public HttpResponse Add() => View();

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddTripFormModel model)
        {
            var modelErrors = this.validator.ValidateTrip(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                Seats = model.Seats,
                Description = model.Description,
                DepartureTime = model.DepartureTime,
                ImagePath = model.ImagePath
            };


            this.data.Trips.Add(trip);

            this.data.SaveChanges();

            return Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            var tripDetails = this.data
                .Trips
                .Where(t => t.Id == tripId)
                .Select(t => new TripDetailsViewModel
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    Description = t.Description,
                    DepartureTime = t.DepartureTime.ToString("yyyy-MM-ddTHH:mm"),
                    Seats = t.Seats,
                    ImagePath = t.ImagePath
                })
                .FirstOrDefault();

            if (tripDetails == null)
            {
                return NotFound();
            }

            return View(tripDetails);
        }

        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            var trip = this.data.Trips.Find(tripId);

            if (trip == null)
            {
                return NotFound();
            }

            var userTrip = new UserTrip
            {
                TripId = trip.Id,
                UserId = this.User.Id
            };

            this.data.UserTrips.Add(userTrip);

            this.data.SaveChanges();

            return Redirect("/Trips/All");
        }
    }
}
