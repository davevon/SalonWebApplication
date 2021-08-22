using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
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
    public class ServiceAppointmentController : Controller
    {
        private readonly IServiceAppointmentRepository _serviceAppointmentRepo;
        private readonly IAppointmentRepository _appointmentRepo;
        private readonly IServiceRepository _serviceRepo;
        private readonly IMapper _mapper;

        public ServiceAppointmentController(IServiceAppointmentRepository serviceAppointmentrepo, IServiceRepository serviceRepo, IAppointmentRepository appointmentRepo, IMapper mapper)
        {
            _serviceAppointmentRepo = serviceAppointmentrepo;
            _serviceRepo = serviceRepo;
            _appointmentRepo = appointmentRepo;
            _mapper = mapper;

        }

        // GET: ServiceAppointmentController
        public ActionResult Index()
        {
            var typesofserviceappointment = _serviceAppointmentRepo.FindAll().ToList();

            var maptoserviceAppointment = _mapper.Map<List<ServiceAppointment>, List<ServiceAppointmentViewModel>>(typesofserviceappointment);

            return View(maptoserviceAppointment);
        }

        // GET: ServiceAppointmentController/Details/5
        public ActionResult Details(int id)
        {

            if (!_serviceAppointmentRepo.isExist(id))
            {
                return NotFound();
            }
            var typesofserviceappointment = _serviceAppointmentRepo.FindById(id);
            var maptoserviceAppointment = _mapper.Map<ServiceAppointmentViewModel>(typesofserviceappointment);
            return View(maptoserviceAppointment);
        }

        // GET: ServiceAppointmentController/Create
        public ActionResult Create()
        {
            var serviceo = _serviceRepo.FindAll();
            var serviceClients = serviceo.Select(q => new 
            {
                Text = q.ServiceName,
                Value = q.ServiceId.ToString()
            });

            var custo = _appointmentRepo.FindAll();
            var employeeCustomer = custo.Select(q => new 
            {
                Text = $"{ q.Customer.CustomerFirstName } {q.Customer.CustomerLastName}",
                Value = q.AppointmentId.ToString(),

            });

            ViewBag.Services = serviceClients;
            ViewBag.Appointments = employeeCustomer;
            var model = new ServiceAppointmentViewModel
            {
            };

            return View(model);  
            
                }
        // POST: ServiceAppointmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceAppointmentViewModel model)
        {
            

                try
                
            {
                var serviceo = _serviceRepo.FindAll();
                var serviceClients = serviceo.Select(q => new SelectListItem
                {
                    Text = q.ServiceName,
                    Value = q.ServiceId.ToString()
                });

                var custo = _appointmentRepo.FindAll();
                var employeeCustomer = custo.Select(q => new SelectListItem
                {
                    Text = $"{ q.Customer.CustomerFirstName } {q.Customer.CustomerLastName}",
                    Value = q.CustomerId.ToString(),

                });

                ViewBag.Services = serviceClients;
                ViewBag.Appointments = employeeCustomer;


                if (!ModelState.IsValid)
                    {
                        return View(model);
                    }
                    var servoappointment = _mapper.Map<ServiceAppointment>(model);
                    var issuccessful = _serviceAppointmentRepo.Create(servoappointment);
                    if (!issuccessful)
                    {
                        ModelState.AddModelError("", "Something Went wrong......");
                        return View(model);
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(model);
                }
            
        }

            // GET: ServiceAppointmentController/Edit/5
            public ActionResult Edit(int id)
        {
            if (!_serviceAppointmentRepo.isExist(id))
            {
                return NotFound();
            }
            var appservice = _serviceAppointmentRepo.FindById(id);
            var model = _mapper.Map<ServiceAppointmentViewModel>(appservice);
            return View(model);
        }

        // POST: ServiceAppointmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ServiceAppointmentViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var appservice = _mapper.Map<ServiceAppointment>(model);
                var isSucess = _serviceAppointmentRepo.Update(appservice);
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

        // GET: ServiceAppointmentController/Delete/5
        public ActionResult Delete(int id)
        {
            var appservice = _serviceAppointmentRepo.FindById(id);
            var isSucess = _serviceAppointmentRepo.Delete(appservice);
            if (!isSucess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: ServiceAppointmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ServiceAppointmentViewModel model)
        {
            try
            {
                var appservice = _serviceAppointmentRepo.FindById(id);
                var isSucess = _serviceAppointmentRepo.Delete(appservice);
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
