using Amexport.Models;
using AutoMapper;
using ENTITI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amexport.AutoMapperConfig
{
    public class MappingProfile : Profile
    {


        public MappingProfile()
        {
            CreateMap<EmployeesModel, Employees>();
            CreateMap<Employees, EmployeesModel>();

            CreateMap<CategoriesModel, Categories>();
            CreateMap<Categories, CategoriesModel>();

            CreateMap<CustomersModel, Customers>();
            CreateMap<Customers, CustomersModel>();

            CreateMap<OrdersModel, Orders>();
            CreateMap<Orders, OrdersModel>();

            CreateMap<ProductsModel, Products>();
            CreateMap<Products, ProductsModel>();

            CreateMap<ShippersModel, Shippers>();
            CreateMap<Shippers, ShippersModel>();

            CreateMap<SuppliersModel, Suppliers>();
            CreateMap<Suppliers, SuppliersModel>();

        }


    }
}