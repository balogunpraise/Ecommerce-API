using AutoMapper;
using Core.Interfaces;
using Core.Specifications;
using ECommerceAPI.Data;
using ECommerceAPI.Dtos;
using ECommerceAPI.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _repo;
       
        private readonly IGenericRepository<ProductBrand> _brand;

        private readonly IGenericRepository<ProductType> _type;

        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> repo,
                                  IGenericRepository<ProductBrand> brand,
                                  IGenericRepository<ProductType> type, IMapper mapper)
        {
            _repo = repo;
            _brand = brand;
            _type = type;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();

            var products = await _repo.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products));
        }


        [HttpGet("brand")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()
        {
            return Ok(await _brand.GetAllAsync());
        }



        [HttpGet("Type")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetTypes()
        {
            return Ok(await _type.GetAllAsync());
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _repo.GetEntityWithSpec(spec);

            return _mapper.Map<Product, ProductDto>(product);
        }
    }
}
