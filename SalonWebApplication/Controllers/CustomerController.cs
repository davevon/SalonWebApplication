using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalonWebApplication.Contracts;
using SalonWebApplication.Data;
using SalonWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _CustomerRepo;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerrepo, IMapper mapper)
        {
            _CustomerRepo = customerrepo;
            _mapper = mapper;
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            var typesofcustomer = _CustomerRepo.FindAll().ToList();

            var maptoCustomer = _mapper.Map<List<Customer>, List<CustomerViewModel>>(typesofcustomer);

            return View(maptoCustomer);
        }

        // GET: CustomerController/Details/5 
        public ActionResult Details(int id)
        {

            if (!_CustomerRepo.isExist(id))
            {
                return NotFound();
            }
            var typesofcustomer = _CustomerRepo.FindById(id);
            var maptoCustomer = _mapper.Map<CustomerViewModel>(typesofcustomer);
            return View(maptoCustomer);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var customer = _mapper.Map<Customer>(model);
                var issuccessful = _CustomerRepo.Create(customer);
                if (!issuccessful)
                {
                    ModelState.AddModelError("", "Something Went wrong......");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went wrong......");
                return View(model);
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_CustomerRepo.isExist(id))
            {
                return NotFound();
            }
            var customer = _CustomerRepo.FindById(id);
            var model = _mapper.Map<CustomerViewModel>(customer);
            return View(model);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var customer = _mapper.Map<Customer>(model);
                var isSucess = _CustomerRepo.Update(customer);
                if (!isSucess)
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong");
                return View(model);
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = _CustomerRepo.FindById(id);
            var isSucess = _CustomerRepo.Delete(customer);
            if (!isSucess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CustomerViewModel model)
        {
            try
            {
                var customer = _CustomerRepo.FindById(id);
                var isSucess = _CustomerRepo.Delete(customer);
                if (!isSucess)
                {
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
