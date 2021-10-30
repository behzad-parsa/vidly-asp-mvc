using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }

        // GET: Customers
        public ActionResult Index()
        {

            var customers = _context.Customers.Include(c=>c.MembershipType).ToList();

            return View(customers);

        }


        public ActionResult Detail(int id)
        {
            var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            //return Content(customer.Name);
            return View(customer);

        }


        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel()
            {
                MembershipTypes = membershipTypes , 
                
            };

            return View(viewModel);

        }







        //private IEnumerable<Customer> GetCutomer()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer{Id = 1 , Name="John Smith"},
        //        new Customer{Id = 2 , Name="Mary Wiliams"}

        //    };
        //}
    }
}