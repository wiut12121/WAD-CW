using MagnumStore.Data;
using MagnumStore.Models;
using MagnumStore.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace MagnumStore.Controllers
{
    public class CustomersController : Controller
    {
        private readonly MagnumStoreDbContext magnumStoreDbContext;

        public CustomersController(MagnumStoreDbContext magnumStoreDbContext)
        {
            this.magnumStoreDbContext = magnumStoreDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var customers = await magnumStoreDbContext.Customers.ToListAsync();
            return View(customers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCustomerViewModel addCustomerRequest)
        {
            var customer = new Customer()
            {
                Id = Guid.NewGuid(),
                Name = addCustomerRequest.Name,
                Surname = addCustomerRequest.Surname,
                Email = addCustomerRequest.Email,
                PhoneNumber = addCustomerRequest.PhoneNumber,
                Gender = addCustomerRequest.Gender,
                DateOfBrith = addCustomerRequest.DateOfBrith

            };

            await magnumStoreDbContext.Customers.AddAsync(customer);
            await magnumStoreDbContext.SaveChangesAsync();
            return RedirectToAction("Add");


        }

        [HttpGet]

        public async Task<IActionResult> View(Guid id)
        {
            var customer = await magnumStoreDbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);

            if (customer != null)
            {
                var viewModel = new UpdateCustomerViewModel()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Surname = customer.Surname,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                    Gender = customer.Gender,
                    DateOfBrith = customer.DateOfBrith
                };
                return await Task.Run(() => View("View", viewModel));
            };

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateCustomerViewModel model)
        {
            var customer= await magnumStoreDbContext.Customers.FindAsync(model.Id);

            if (customer != null)
            {
                customer.Name = model.Name;
                customer.Surname = model.Surname;
                customer.Email = model.Email;
                customer.PhoneNumber = model.PhoneNumber;
                customer.Gender = model.Gender;
                customer.DateOfBrith = model.DateOfBrith;

                await magnumStoreDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]

        public async Task<IActionResult> Delete(UpdateCustomerViewModel model)
        {
            var customer = magnumStoreDbContext.Customers.Find(model.Id);

            if (customer != null)
            {
                magnumStoreDbContext.Customers.Remove(customer);
                await magnumStoreDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
