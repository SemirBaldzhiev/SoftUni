using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarDealer.DTO.Input;
using CarDealer.DTO.Output;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SupplierInputDto, Supplier>();
            CreateMap<PartInputDto, Part>();
            CreateMap<CustomerInputDto, Customer>();
            CreateMap<SalesInputDto, Sale>();

            CreateMap<Customer, OrderdCustomerDto>();
            CreateMap<Car, CarsWithMakeDto>();


        }
    }
}
