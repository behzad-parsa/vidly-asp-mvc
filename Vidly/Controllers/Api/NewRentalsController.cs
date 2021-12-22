using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;
namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRentalDto)
        {

            //finding Customer
            var customer = _context.Customers.Single  (c => c.Id == newRentalDto.CustomerId); 

 
            //finding list of movies
            var movies =  _context.Movies
                .Where(m => newRentalDto.MovieIds.Contains(m.Id))
                .ToList();


            List<Rental> rentalList = new List<Rental>();
            //foreach movie exist in the movieList  , the rentalList was added with given customer and current DateTimer
            movies.ForEach(m => rentalList.Add(new Rental()
            {
                Customer = customer,
                Movie = m,
                DateRented = DateTime.Now

            })
            ) ;
            

            //sampleCode of Multiple Condition

            //movies.ForEach(m => {
            //    rentalList.Add(new Rental()
            //    {
            //        Customer = customer,
            //        Movie = m,
            //        DateRented = DateTime.Now

            //    });
            //    m.NumberAvailable--;
            //}) ;


            
            //sample code - another form of assign

            //rentalList
            //    .Select(r => {
            //        r.DateRented = DateTime.Now;
            //        r.Customer = customer;
            //        return r;
            //    }).ToList();



            _context.Renatls.AddRange(rentalList);
            _context.SaveChanges();

            //if Process of Adding to Db Successfully performed , Decrease number of available movie
            movies.ForEach(m => m.NumberAvailable--);

            // return Created(new Uri(Request.RequestUri + "/" + newRentalDto.CustomerId) , newRentalDto);
            return Ok(); //cause we have multiple resources
        }
    }
}