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
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //Get /api /Customers
       public IEnumerable<CustomerDto> GetCustomers()
       {
            return _context.Customers
                .Include(c=>c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer,CustomerDto>);
       }

        // Get /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDB == null)
                return NotFound();
                //throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(Mapper.Map<Customer , CustomerDto>(customerInDB));

        }

        //Post /api /customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri +"/" + customer.Id) , customerDto); 
        }

        // put /api/customer/1

        [HttpPut]
        public void UpdateCusotmer(int id , CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDB == null )
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            //          Source      Dest
            Mapper.Map<CustomerDto, Customer>(customerDto, customerInDB); //CustomerinDb is in Context so This Line Enough to Transfer

            //customerInDB.Name = customerDto.Name;
            //customerInDB.Birthday = customerDto.Birthday;
            //customerInDB.MembershipTypeId = customerDto.MembershipTypeId;
            //customerInDB.IsSubscribedToNewsLetter = customerDto.IsSubscribedToNewsLetter;

            _context.SaveChanges();
        }


        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();


        }



    }
}

