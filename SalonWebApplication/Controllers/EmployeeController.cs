using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalonWebApplication.Contracts;
using SalonWebApplication.Data;
using SalonWebApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _EmployeeRepo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;

        public EmployeeController(IEmployeeRepository employeerepo, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _EmployeeRepo = employeerepo;
            _mapper = mapper;
            this._hostEnvironment = hostEnvironment;
        }



        // GET: EmployeeController
        public ActionResult Index()
        {
            var typesofEmployee = _EmployeeRepo.FindAll().ToList();

            var maptoemployee = _mapper.Map<List<Employee>, List<EmployeeViewModel>>(typesofEmployee);

            return View(maptoemployee);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            if (!_EmployeeRepo.isExist(id))
            {
                return NotFound();
            }
            var typesofemployee = _EmployeeRepo.FindById(id);
            var maptoEmployee = _mapper.Map<EmployeeViewModel>(typesofemployee);
            return View(maptoEmployee);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                if (model.Image != null)
                {
                    model.EmployeeImg = UploadImage(model.Image);
                }
                var employee = _mapper.Map<Employee>(model);
                var issuccessful = _EmployeeRepo.Create(employee);
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

        private string UploadImage(IFormFile file)
        {
            ////Generate Image upload path
            string uploads = Path.Combine(_hostEnvironment.WebRootPath, "uploads", "employee_images");
            if (file.Length > 0)
            {
                ////Get Extension for image and create new filename from random GUID and extension
                var extension = Path.GetExtension(file.FileName);
                var imageName = $"{Guid.NewGuid().ToString().Replace("-", "")}{extension}";
                var imagePath = Path.Combine(uploads, imageName);


                ////Use Filestream to copy file from memory to the path 
                using Stream filestream = new FileStream(imagePath, FileMode.Create);
                file.CopyTo(filestream);


                ///Return image name to be stored in database
                return imageName;
            }

            return string.Empty;
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_EmployeeRepo.isExist(id))
            {
                return NotFound();
            }
            var employee = _EmployeeRepo.FindById(id);
            var model = _mapper.Map<EmployeeViewModel>(employee);

            return View(model);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeViewModel model)
        {
            try
            {
                
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var employee = _mapper.Map<Employee>(model);
                var isSucess = _EmployeeRepo.Update(employee);
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

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = _EmployeeRepo.FindById(id);
            var isSucess = _EmployeeRepo.Delete(employee);
            if (!isSucess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EmployeeViewModel model)
        {
            try
            {
                var Employee = _EmployeeRepo.FindById(id);
                var isSucess = _EmployeeRepo.Delete(Employee);
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
