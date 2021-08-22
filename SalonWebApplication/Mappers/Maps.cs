using AutoMapper;
using SalonWebApplication.Data;
using SalonWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SalonWebApplication.Mappers
{
    public class Maps : Profile
    { 
        public Maps()
        {
            CreateMap<Appointment, AppointmentViewModel>().ReverseMap();
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            ////  CreateMap<Supplier, CalcationViewModel>().ReverseMap();
            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<Order, OrderViewModel>().ForMember(dest => dest.CustomerName, opts => opts.MapFrom(src =>string.Format("{0} {1}", src.Customers.CustomerFirstName, src.Customers.CustomerLastName)))
                .ForMember(dest => dest.PaymentType, opts => opts.MapFrom(src => src.PaymentTypes)).ReverseMap();
            CreateMap<OrdersDetails, OrdersDetailsViewModel>().ReverseMap();
            CreateMap<PaymentType, PaymentTypeViewModel>().ReverseMap();

            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<ServiceAppointment,ServiceAppointmentViewModel>().ReverseMap();
            CreateMap<Service, ServiceViewModel>()
                .ForMember(dest => dest.Duration, opts => opts.MapFrom(src => src.Duration))
                .ReverseMap();
       



        }

    }
}
