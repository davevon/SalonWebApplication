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

namespace SalonWebApplication.Controllers
{
    public class OrdersDetailsController : Controller
    {
        private readonly IOrdersDetailsRepository _ordersDetailsRepo;
        private readonly IOrderRepository _orderRepo;
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public OrdersDetailsController(IOrdersDetailsRepository ordersDetailsrepo, IOrderRepository orderRepo, IProductRepository productRepo, IMapper mapper)
        {
            _ordersDetailsRepo = ordersDetailsrepo;
            _orderRepo = orderRepo;
            _productRepo = productRepo;
            _mapper = mapper;

        }


        // GET: OrdersDetailsController
        public ActionResult Index()
        {
            var typesofordersDetails = _ordersDetailsRepo.FindAll().ToList();

            var maptoOrdersDetails = _mapper.Map<List<OrdersDetails>, List<OrdersDetailsViewModel>>(typesofordersDetails);

            return View(maptoOrdersDetails);
        }

        // GET: OrdersDetailsController/Details/5
        public ActionResult Details(int id)
        {
            if (!_ordersDetailsRepo.isExist(id))
            {
                return NotFound();
            }
            var typesofordersDetails = _ordersDetailsRepo.FindById(id);
            var maptoOrdersDetails = _mapper.Map<OrdersDetailsViewModel>(typesofordersDetails);
            return View(maptoOrdersDetails);
        }

        // GET: OrdersDetailsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdersDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrdersDetails model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var appservice = _mapper.Map<OrdersDetails>(model);
                var issuccessful = _ordersDetailsRepo.Create(appservice);
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

        // GET: OrdersDetailsController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_ordersDetailsRepo.isExist(id))
            {
                return NotFound();
            }
            var appservice = _ordersDetailsRepo.FindById(id);
            var model = _mapper.Map<OrdersDetailsViewModel>(appservice);
            return View(model);
        }

        // POST: ServiceAppointmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrdersDetailsViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var appservice = _mapper.Map<OrdersDetails>(model);
                var isSucess = _ordersDetailsRepo.Update(appservice);
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

        // GET: OrdersDetailsController/Delete/5
        public ActionResult Delete(int id)
        {
            var appservice = _ordersDetailsRepo.FindById(id);
            var isSucess = _ordersDetailsRepo.Delete(appservice);
            if (!isSucess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: ServiceAppointmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, OrdersDetailsViewModel model)
        {
            try
            {
                var appservice = _ordersDetailsRepo.FindById(id);
                var isSucess = _ordersDetailsRepo.Delete(appservice);
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
