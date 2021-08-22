using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalonWebApplication.Contracts;
using SalonWebApplication.Data;
using SalonWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SalonWebApplication.Controllers
{
    [Authorize]
    public class PaymentTypeController : Controller
    {
        private readonly IPaymentTypeRepository _paymentTypeRepo;
        private readonly IMapper _mapper;

        public PaymentTypeController(IPaymentTypeRepository paymentTyperepo, IMapper mapper)
        {
            _paymentTypeRepo = paymentTyperepo;
            _mapper = mapper;
        }


        // GET: PaymentTypeController
        public ActionResult Index()
        {
            var typesofPaymentType = _paymentTypeRepo.FindAll().ToList();

            var maptoPaymentType = _mapper.Map<List<PaymentType>, List<PaymentTypeViewModel>>(typesofPaymentType);

            return View(maptoPaymentType);
        }

        // GET: PaymentTypeController/Details/5
        public ActionResult Details(int id)
        {
            if (!_paymentTypeRepo.isExist(id))
            {
                return NotFound();
            }
            var typesofPaymentType = _paymentTypeRepo.FindById(id);
            var maptoPaymentType = _mapper.Map<PaymentTypeViewModel>(typesofPaymentType);
            return View(maptoPaymentType);
        }

        // GET: PaymentTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PaymentTypeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var paymentType = _mapper.Map<PaymentType>(model);
                var issuccessful = _paymentTypeRepo.Create(paymentType);
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

        // GET: PaymentTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_paymentTypeRepo.isExist(id))
            {
                return NotFound();
            }
            var PaymentType = _paymentTypeRepo.FindById(id);
            var model = _mapper.Map<PaymentTypeViewModel>(PaymentType);
            return View(model);
        }

        // POST: PaymentTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PaymentTypeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var paymentType = _mapper.Map<PaymentType>(model);
                var isSucess = _paymentTypeRepo.Update(paymentType);
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

        // GET: PaymentTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            var paymentType = _paymentTypeRepo.FindById(id);
            var isSucess = _paymentTypeRepo.Delete(paymentType);
            if (!isSucess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: PaymentTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, PaymentTypeViewModel model)
        {
            try
            {
                var paymentType = _paymentTypeRepo.FindById(id);
                var isSucess = _paymentTypeRepo.Delete(paymentType);
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
