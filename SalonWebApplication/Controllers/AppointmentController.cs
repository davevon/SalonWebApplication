using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository _AppointmentRepo;
        private readonly IEmployeeRepository _employeeRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentRepository AppointmentRepo, IEmployeeRepository employeeRepo,
            ICustomerRepository customerRepo, IMapper mapper)
        {
            _AppointmentRepo = AppointmentRepo;
            _customerRepo = customerRepo;
            _employeeRepo = employeeRepo;

            _mapper = mapper;
        }


        // GET: AppointmentController
        public ActionResult Index()
        {
            try
            {
                var typesofappointment = _AppointmentRepo.FindAll().ToList();

                var maptoAppointment = _mapper.Map<List<Appointment>, List<AppointmentViewModel>>(typesofappointment);
                return View(maptoAppointment);
            }
            catch (Exception e)
            {

                throw;
            }

        }

        // GET: AppointmentController/Details/5
        public ActionResult Details(int id)
        {
            if (!_AppointmentRepo.isExist(id))
            {
                return NotFound();
            }
            var typesofappointment = _AppointmentRepo.FindById(id);
            var maptoAppointment = _mapper.Map<AppointmentViewModel>(typesofappointment);
            return View(maptoAppointment);
        }

        // GET: AppointmentController/Create
        public ActionResult Create()
        {
            var employee = _employeeRepo.FindAll();
            var employeeClients = employee.Select(q => new SelectListItem
            {
                Text = q.FirstName,
                Value = q.EmployeeId.ToString()


            });

            var customer = _customerRepo.FindAll();
            var employeeCustomer = customer.Select(q => new SelectListItem
            {
                Text = q.CustomerFirstName + q.CustomerLastName,
                Value = q.CustomerId.ToString()
            }
            ); ;
            var model = new AppointmentViewModel
            {
                Employees = employeeClients,
                Customers = employeeCustomer
            };

            return View(model);
        }

        // POST: AppointmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppointmentViewModel model)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var appointment = _mapper.Map<Appointment>(model);
                var issuccessful = _AppointmentRepo.Create(appointment);
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

        // GET: AppointmentController/Edit/5
        public ActionResult Edit(int id)
        {            

            if (!_AppointmentRepo.isExist(id))
            {
                return NotFound();
            }
            var appointment = _AppointmentRepo.FindById(id);
            var model = _mapper.Map<AppointmentViewModel>(appointment);
            var employee = _employeeRepo.FindAll();
            var employeeClients = employee.Select(q => new SelectListItem
            {
                Text = q.FirstName,
                Value = q.EmployeeId.ToString()


            });

            var customer = _customerRepo.FindAll();
            var employeeCustomer = customer.Select(q => new SelectListItem
            {
                Text = q.CustomerFirstName + q.CustomerLastName,
                Value = q.CustomerId.ToString()
            }
            ); ;


            model.Employees = employeeClients;
            model.Customers = employeeCustomer;
            return View(model);


        }

        // POST: AppointmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AppointmentViewModel model)
        {
            var employee = _employeeRepo.FindAll();
            var employeeClients = employee.Select(q => new SelectListItem
            {
                Text = q.FirstName,
                Value = q.EmployeeId.ToString()


            });

            var customer = _customerRepo.FindAll();
            var employeeCustomer = customer.Select(q => new SelectListItem
            {
                Text = q.CustomerFirstName + q.CustomerLastName,
                Value = q.CustomerId.ToString()
            }
            ); ;


            model.Employees = employeeClients;
            model.Customers = employeeCustomer;
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var appointment = _mapper.Map<Appointment>(model);
                var isSucess = _AppointmentRepo.Update(appointment);
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

        // GET: AppointmentController/Delete/5
        public ActionResult Delete(int id)
        {

            var appointment = _AppointmentRepo.FindById(id);
            var isSucess = _AppointmentRepo.Delete(appointment);
            if (!isSucess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: AppointmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AppointmentViewModel model)
        {
            try
            {
                var appointment = _AppointmentRepo.FindById(id);
                var isSucess = _AppointmentRepo.Delete(appointment);
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
