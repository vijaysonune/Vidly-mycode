using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Vidly.Models;
using Vidly.DAL;


namespace Vidly.Controllers.Api
{
    
    public class CustomersController : ApiController
    {
        private VidlyDb _context;
        public CustomersController()
        {
            _context = new VidlyDb();
        }

        // Get api/Customers
        [HttpGet]        
        public IEnumerable<Customer> Get()
        {
            return _context.Customers.ToList();
        }

        // Get api/Customers/1
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var customer= _context.Customers.Where(x => x.Id == id).SingleOrDefault();
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        // Post api/Customers
        [HttpPost]
        public IHttpActionResult Create(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDB = _context.Customers.Where(x => x.Id == customer.Id).SingleOrDefault();
                customerInDB.Name = customer.Name;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
                customerInDB.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

            }
            _context.SaveChanges();
            return Ok();
        }

        // Put api/Customers
        [HttpPut]
        public IHttpActionResult UpdateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (customer.Id == 0)
            {
                return NotFound();
            }
            else
            {
                var customerInDB = _context.Customers.Where(x => x.Id == customer.Id).SingleOrDefault();
                customerInDB.Name = customer.Name;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
                customerInDB.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

            }
            _context.SaveChanges();
            return Ok();
        }

        // Delete api/Customers/1
        //http://localhost:58585/api/Department/3
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var customer = _context.Customers.Where(x => x.Id == id).SingleOrDefault();
            if (customer.Id == 0)
            {
                return NotFound();
            }
            else
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}
