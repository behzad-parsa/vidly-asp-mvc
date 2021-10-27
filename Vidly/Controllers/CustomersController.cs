using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {

            var customers = GetCutomer();

            return View(customers);

        }


        public ActionResult Detail(int id)
        {
            var customer = GetCutomer().SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            //return Content(customer.Name);
            return View(customer);

        }


        private IEnumerable<Customer> GetCutomer()
        {
            return new List<Customer>
            {
                new Customer{Id = 1 , Name="John Smith"},
                new Customer{Id = 2 , Name="Mary Wiliams"}

            };
        }
    }
}