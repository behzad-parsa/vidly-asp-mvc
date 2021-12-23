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
            //When having No Movies id
            if (newRentalDto.MovieIds.Count == 0)
            {
                return BadRequest("No Movie Id have been Given");
            }


            //finding Customer
            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRentalDto.CustomerId);

            if (customer == null)
                return BadRequest("CutsomerId is not Valid . ");
            
            //finding list of movies
            var movies =  _context.Movies
                .Where(m => newRentalDto.MovieIds.Contains(m.Id))
                .ToList();

            if (movies.Count != newRentalDto.MovieIds.Count)
                return BadRequest("One Or More MovieIds are Invalid");

            
            List<Rental> rentalList = new List<Rental>();

            //foreach movie exist in the movieList  , the rentalList was added with given customer and current DateTimer 
            // at end of the process ,  the Avaiablitiy Will Be Decreas
            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie Is not Available .");
                //if Process of Adding to Db Successfully performed , Decrease number of available movie
                movie.NumberAvailable--;
                
                rentalList.Add(new Rental()
                {
                    Customer = customer ,
                    Movie = movie ,
                    DateRented = DateTime.Now 
                });
            }


            _context.Renatls.AddRange(rentalList);
            _context.SaveChanges();


            //sample code 1 - another form of assign

            //rentalList
            //    .Select(r => {
            //        r.DateRented = DateTime.Now;
            //        r.Customer = customer;
            //        return r;
            //    }).ToList();




            //Sample Code 2
            //movies.ForEach(m =>
            //{
            //    rentalList.Add(new Rental()
            //    {
            //        Customer = customer,
            //        Movie = m,
            //        DateRented = DateTime.Now

            //    });
            //    if (m.NumberAvailable != 0)
            //        m.NumberAvailable--;
            //    else
            //        return BadRequest("Movie Is Not Available");
            //});


            // return Created(new Uri(Request.RequestUri + "/" + newRentalDto.CustomerId) , newRentalDto);
            return Ok(); //cause we have multiple resources
        }
    }
}