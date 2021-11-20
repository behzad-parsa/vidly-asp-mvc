using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

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
       public IEnumerable<Customer> GetCustomers()
       {
            return _context.Customers.ToList();
       }

        // Get /api/customers/1
        public Customer GetCustomer(int id)
        {
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDB == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            return customerInDB;

        }

        //Post /api /customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer; 
        }

        // put /api/customer/1

        [HttpPut]
        public void UpdateCusotmer(int id , Customer customer)
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

            customerInDB.Name = customer.Name;
            customerInDB.Birthday = customer.Birthday;
            customerInDB.MembershipTypeId = customer.MembershipTypeId;
            customerInDB.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

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

