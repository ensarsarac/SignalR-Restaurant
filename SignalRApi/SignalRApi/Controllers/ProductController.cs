using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.ProductDto;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(values);
        }
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var values = _mapper.Map<List<ResultProductWithCategory>>(_productService.TGetProductListWithCategory());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto model)
        {
            var value = _mapper.Map<Product>(model);
            _productService.TAdd(value);
            return Ok("Başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Kayıt başarılı bir şekilde silindi");
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto model)
        {
            var value = _mapper.Map<Product>(model);
            _productService.TUpdate(value);
            return Ok("Kayıt başarılı bir şekilde güncellendi.");
        }
        [HttpGet("GetProductWithId")]
        public IActionResult GetProductWithId(int id)
        {
            var value = _mapper.Map<GetProductDto>(_productService.TGetById(id));
            return Ok(value);
        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_productService.TProductCount());
        }
		[HttpGet("ProductByHamburgerCount")]
		public IActionResult ProductByHamburgerCount()
		{
			return Ok(_productService.TProductCountByCategoryNameHamburger());
		}
		[HttpGet("ProductByIcecekCount")]
		public IActionResult ProductByIcecekCount()
		{
			return Ok(_productService.TProductCountByCategoryNameIcecek());
		}
		[HttpGet("MaxPriceProduct")]
		public IActionResult MaxPriceProduct()
		{
			return Ok(_productService.TProductByMaxPrice());
		}
		[HttpGet("MinPriceProduct")]
		public IActionResult MinPriceProduct()
		{
			return Ok(_productService.TProductByMinPrice());
		}
		[HttpGet("AverageHamburgerPrice")]
		public IActionResult AverageHamburgerPrice()
		{
			return Ok(_productService.TAvearageHamburgerPrice());
		}

		[HttpGet("ProductPriceAvg")]
		public IActionResult ProductPriceAvg()
		{
			return Ok(_productService.TProductPriceAvg());
		}


	}
}
