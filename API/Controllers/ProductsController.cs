using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productsRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandsRepository;
        private readonly IGenericRepository<ProductType> _productTypesRepository;
        private readonly IMapper _mapper;

        public ProductsController(
            IGenericRepository<Product> productsRepository,
            IGenericRepository<ProductBrand> productBrandsRepository,
            IGenericRepository<ProductType> productTypesRepository,
            IMapper mapper)
        {
            _productsRepository = productsRepository;
            _productBrandsRepository = productBrandsRepository;
            _productTypesRepository = productTypesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductToReturnDto>>> GetProductsAsync(string sort)
        {
            var spec = new ProductsWithTypesAndBrandsSpecifications(sort);
            var products = await _productsRepository.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
           var spec = new ProductsWithTypesAndBrandsSpecifications(id);
           var product = await _productsRepository.GetEntityWithSpec(spec);
           if(product == null) return NotFound(new ApiResponse(404));
           return _mapper.Map<Product, ProductToReturnDto>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productsRepository.ListAllASync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypesRepository.ListAllASync());
        }
    }
}