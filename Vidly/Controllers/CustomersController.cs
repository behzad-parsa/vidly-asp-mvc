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
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes , 
                
            };

            return View("CustomerForm",viewModel);

        }

        
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)  //It's New Customer So It must added To DB 
            {
                _context.Customers.Add(customer);
            }
            else                   // It's a Existing Customer And Must Update
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
            
        }


        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();

            }

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm" , viewModel);
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