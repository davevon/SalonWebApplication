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
    public class OrderController : Controller
    {
        private readonly IOrdersDetailsRepository _ordersDetailsRepo;
        private readonly IOrderRepository _OrderRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IPaymentTypeRepository _paymentRepo;
        private readonly IServiceRepository _serviceRepo;
        private readonly IProductRepository _prodRepo;
        private readonly IMapper _mapper;

        public OrderController(IOrdersDetailsRepository OrdersDetailsRepo, IServiceRepository serviceRepo, IOrderRepository orderrepo, IProductRepository prodRepo, ICustomerRepository customerRepo, IPaymentTypeRepository paymentRepo, IMapper mapper)
        {
            _ordersDetailsRepo = OrdersDetailsRepo;
            _OrderRepo = orderrepo;
            _customerRepo = customerRepo;
            _paymentRepo = paymentRepo;
            _prodRepo = prodRepo;
            _mapper = mapper;
            _serviceRepo = serviceRepo;

        }




        // GET: OrderController
        public ActionResult Index()
        {
            var typesoforder = _OrderRepo.FindAll().ToList();

            var maptoOrder = _mapper.Map<List<Order>, List<OrderViewModel>>(typesoforder);

            return View(maptoOrder);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {

            if (!_OrderRepo.isExist(id))
            {
                return NotFound();
            }
            var typesoforder = _OrderRepo.FindById(id);
            var maptoOrder = _mapper.Map<OrderViewModel>(typesoforder);
            var details = (_ordersDetailsRepo.FindAll()).Where(q => q.OrderId == id).ToList();
            maptoOrder.OrdersDetails = _mapper.Map<List<OrdersDetailsViewModel>>(details);
            return View(maptoOrder);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {

            var clients = _customerRepo.FindAll();
            var customername = clients.Select(q => new SelectListItem
            {
                Text = $"{ q.CustomerFirstName } { q.CustomerLastName}",
                Value = q.CustomerId.ToString()
            }
            );

            var Produce = _prodRepo.FindAll();
            var Productsname = Produce.Select(q => new SelectListItem
            {
                Text = $"{ q.ProductName } - { q.ProductCost}",
                Value = q.ProductId.ToString()
            }
            );

            var funds = _paymentRepo.FindAll();
            var Paymentname = funds.Select(q => new SelectListItem
            {
                Text = q.PaymentName,
                Value = q.PaymentTypeId.ToString()
            }
            );
            var model = new OrderViewModel
            {
                Customers = customername,
                Products = Productsname,
                PaymentTypes = Paymentname,
            };
            model.OrderDate = DateTime.Now;
            return View(model);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderViewModel model, OrdersDetailsViewModel ordersDetailsViewModel, int id)
        {
            try
            {
                
                var clients = _customerRepo.FindAll();
                var customername = clients.Select(q => new SelectListItem
                {
                    Text = $"{ q.CustomerFirstName } { q.CustomerLastName}",
                    Value = q.CustomerId.ToString()
                }
                );

                var Produce = _prodRepo.FindAll();
                var Productsname = Produce.Select(q => new SelectListItem
                {
                    Text = $"{ q.ProductName } - ${ q.ProductCost}",
                    Value = q.ProductId.ToString()
                }
                );

                var funds = _paymentRepo.FindAll();
                var Paymentname = funds.Select(q => new SelectListItem
                {
                    Text = q.PaymentName,
                    Value = q.PaymentTypeId.ToString()
                }
                );

                model.Customers = customername;
                model.Products = Productsname;
                model.PaymentTypes = Paymentname;

                var product = _prodRepo.FindById(model.ProductId);
                var totalcost = model.Total;
               /* if (product.ProductQty > model.ProductQuantities)
                {*/
                    totalcost = product.ProductCost * model.ProductQuantities;
               /* }*/
              if (model.ProductQuantities <= 0)
                {
                    ModelState.AddModelError("", "Please enter a value for the quantity");
                    return View(model);
                }

                model.Total = totalcost;
                /* var salevalue = new OrderViewModel
                 {
                     // objects to pass into the model
                     CustomerId = model.CustomerId,
                   *//*   CustomerName = model.CustomerName,*//*
                     Customer = model.Customer,
                     ProductId = model.ProductId,
                   *//*  ProductName = model.ProductName,*//*
                   PaymentTypeId=model.PaymentTypeId,
                     ProductPrices = model.ProductPrices,
                     Product = model.Product
                     ProductQuantities = model.ProductQuantities,
                     OrderId = model.OrderId,
                     Total = model.Total,
                     OrderDate = model.OrderDate

             };
 */


                var orderproduct = _mapper.Map<Order>(model);


                var isuccessful = _OrderRepo.Create(orderproduct);

                if (!isuccessful)
                {
                    ModelState.AddModelError("", "Something went wrong while submitting your record...");
                    return View(model);

                }
                model.OrdersDetails = new List<OrdersDetailsViewModel>();
                model.OrdersDetails.Add(new OrdersDetailsViewModel
                {
                    ProductId = model.ProductId,
                    Quantity = model.ProductQuantities,
                    OrderId = orderproduct.OrderId
                });
                var orderDetails = _mapper.Map<List<OrdersDetails>>(model.OrdersDetails);
                foreach (var item in orderDetails)
                {
                    _ordersDetailsRepo.Create(item);
                }


                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong submitting your record...");
                return View(model);
            }

        }


        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_OrderRepo.isExist(id))
            {
                return NotFound();
            }
            var appservice = _OrderRepo.FindById(id);
            var model = _mapper.Map<OrderViewModel>(appservice);
            var clients = _customerRepo.FindAll();
            var customername = clients.Select(q => new SelectListItem
            {
                Text = $"{ q.CustomerFirstName } { q.CustomerLastName}",
                Value = q.CustomerId.ToString()
            }
            );

            var Produce = _prodRepo.FindAll();
            var Productsname = Produce.Select(q => new SelectListItem
            {
                Text = $"{ q.ProductName } - { q.ProductCost}",
                Value = q.ProductId.ToString()
            }
            );

            var funds = _paymentRepo.FindAll();
            var Paymentname = funds.Select(q => new SelectListItem
            {
                Text = q.PaymentName,
                Value = q.PaymentTypeId.ToString()
            }
            );
            model.Customers = customername;
            model.Products = Productsname;
            model.PaymentTypes = Paymentname;            
            return View(model);
        }

        // POST: ServiceAppointmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrderViewModel model)
        {
            try
            {                
                var clients = _customerRepo.FindAll();
                var customername = clients.Select(q => new SelectListItem
                {
                    Text = $"{ q.CustomerFirstName } { q.CustomerLastName}",
                    Value = q.CustomerId.ToString()
                }
                );

                var Produce = _prodRepo.FindAll();
                var Productsname = Produce.Select(q => new SelectListItem
                {
                    Text = $"{ q.ProductName } - { q.ProductCost}",
                    Value = q.ProductId.ToString()
                }
                );

                var funds = _paymentRepo.FindAll();
                var Paymentname = funds.Select(q => new SelectListItem
                {
                    Text = q.PaymentName,
                    Value = q.PaymentTypeId.ToString()
                }
                );
                model.Customers = customername;
                model.Products = Productsname;
                model.PaymentTypes = Paymentname;
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();
                    return View(model);
                }
                var appservice = _mapper.Map<Order>(model);
                var isSucess = _OrderRepo.Update(appservice);
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

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            var appservice = _OrderRepo.FindById(id);
            var isSucess = _OrderRepo.Delete(appservice);
            if (!isSucess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: ServiceAppointmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, OrderViewModel model)
        {
            try
            {
                var appservice = _OrderRepo.FindById(id);
                var isSucess = _OrderRepo.Delete(appservice);
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
