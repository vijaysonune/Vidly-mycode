using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.DAL;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using Vidly.ViewModels;
using Vidly.Models;

namespace Vidly.Controllers
{
    
    public class CustomerController : Controller
    {
        private VidlyDb _Context;

        public CustomerController()
        {
            _Context = new VidlyDb();
        }

        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }
        // GET: Customer
        [Route("LoggedInCustomer/Index")]
        public ViewResult Index()
        {
            var customers = _Context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        // GET: Customer/Details/5
        [Route("LoggedInCustomer/Details/{id}")]
        public ActionResult Details(int id)
        {
            var cust = _Context.Customers.Include(c => c.MembershipType).SingleOrDefault(x => x.Id == id);
            return View(cust);
        }

        public ActionResult NewCustomer()
        {
            var memershiptypes = _Context.MembershipTypes.ToList();
            NewCustomerViewModel viewModel = new NewCustomerViewModel
            {
                MembershipTypes = memershiptypes
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(NewCustomerViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                var Model = new NewCustomerViewModel
                {
                    Customer = viewModel.Customer,
                    MembershipTypes = _Context.MembershipTypes.ToList()
                };

                return View("NewCustomer", Model);
            }
            if (viewModel.Customer.Id == 0)
            {
                _Context.Customers.Add(viewModel.Customer);
            }
            else 
            {
                var CustomerInDb = _Context.Customers.Single(x => x.Id == viewModel.Customer.Id);
                CustomerInDb.Name = viewModel.Customer.Name;
                CustomerInDb.IsSubscribedToNewsLetter = viewModel.Customer.IsSubscribedToNewsLetter;
                CustomerInDb.MembershipTypeId = viewModel.Customer.MembershipTypeId;
                
            }
            _Context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }


        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _Context.Customers.SingleOrDefault(x => x.Id == id);

            var viewModel = new NewCustomerViewModel
            {
                Customer = model,
                MembershipTypes = _Context.MembershipTypes.ToList()
            };

            return View("NewCustomer", viewModel);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public PartialViewResult ListCustomer()
        {
            var customers = _Context.Customers.ToList();
            return PartialView("_customer", customers);
        }

        public PartialViewResult Top3()
        {
            var customers = _Context.Customers.OrderByDescending(x=>x.Id).Take(3).ToList();
            return PartialView("_customer", customers);
        }

    }
}
