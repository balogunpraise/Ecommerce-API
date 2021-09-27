using AutoMapper;
using ECommerceAPI.Entities;
using ECommerceAPI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Dtos
{
    public class HelperMethod : Profile
    {
        public HelperMethod()
        {
            CreateMap<Product, ProductDto>()
            .ForMember(member => member.ProductBrand, option => option.MapFrom(x => x.ProductBrand.Name))
            .ForMember(member => member.ProductType, option => option.MapFrom(x => x.ProductType.Name))
            .ForMember(member => member.PictureUrl, option => option.MapFrom<ProductUrlResolver>());

        }
    }
}
