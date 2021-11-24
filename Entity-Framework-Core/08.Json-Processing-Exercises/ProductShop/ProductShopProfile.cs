using AutoMapper;
using ProductShop.Dtos;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<InputUserDto, User>();
            CreateMap<InputProductDto, Product>();
            CreateMap<InputCategoryDto, Category>();
            CreateMap<InputCategoryProductDto, CategoryProduct>();
        }
    }
}
