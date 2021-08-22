using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalonWebApplication.Contracts;
using SalonWebApplication.Data;
using SalonWebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Controllers
{
    [Authorize]
    public class ServiceController : Controller
    {
        private readonly IServiceRepository _serviceRepo;
        private readonly IMapper _map;

        public ServiceController(IServiceRepository serviceRepo, IMapper mapper)
        {
            _map = mapper;
            _serviceRepo = serviceRepo;
        }
        // GET: ServiceController
        public ActionResult Index()
        {
            var typesofservice = _serviceRepo.FindAll().ToList();

            var maptoService = _map.Map<List<Service>, List<ServiceViewModel>>(typesofservice);

            return View(maptoService);
        }

        // GET: ServiceController/Details/5
        public ActionResult Details(int id)
        {
            if (!_serviceRepo.isExist(id))
            {
                return NotFound();
            }
            var typesofservice = _serviceRepo.FindById(id);
            var maptoService = _map.Map<ServiceViewModel>(typesofservice);
            return View(maptoService);
        }

        // GET: ServiceController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: ServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var service = _map.Map<Service>(model);
                var issuccessful = _serviceRepo.Create(service);
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

        // GET: ServiceController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_serviceRepo.isExist(id))
            {
                return NotFound();
            }
            var work = _serviceRepo.FindById(id);
            var model = _map.Map<ServiceViewModel>(work);
            DateTime time = DateTime.Today.Add(model.Duration);
            model.TimeDuration = time.ToString("hh:mm:ss");            
            return View(model);
        }

        // POST: ServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ServiceViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var work = _map.Map<Service>(model);
                var isSucess = _serviceRepo.Update(work);
                if (! isSucess)
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

        // GET: ServiceController/Delete/5
        public ActionResult Delete(int id)
        {
            var service = _serviceRepo.FindById(id);
            var isSucess = _serviceRepo.Delete(service);
            if (!isSucess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: ServiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ServiceViewModel model)
        {
            try
            {
                var service = _serviceRepo.FindById(id);
                var isSucess = _serviceRepo.Delete(service);
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
