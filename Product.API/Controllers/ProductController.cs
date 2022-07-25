using Microsoft.AspNetCore.Mvc;
using Product.API.Dtos;
using Product.API.Services;

namespace Product.API.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
           
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var responce = new APIResponceDto
            {
                IsSucess = true,
                Message = "you got All Products",
                Data = _productService.GetAll()
            };
            return Ok(responce);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var data = _productService.Get(id);
            var isSucess = data != null;
            var responce = new APIResponceDto
            {
                IsSucess = isSucess,
                Message = isSucess ? $"you got the Product with Id {id}" : $"not found product with id {id}",
                Data = data
            };
            return Ok(responce);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var responce = new APIResponceDto
            {
                IsSucess = true,
                Message = $"you deleted the Product with Id {id}",
                Data = _productService.Get(id)
            };
            return Ok(responce);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateProductDto dto)
        {
            var responce = new APIResponceDto
            {
                IsSucess = true,
                Message = "you added Product ",
                Data = _productService.Create(dto.Name, dto.Cost, dto.Price)
            };
            return Ok(responce);
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateProductDto dto)
        {

            var responce = new APIResponceDto
            {
                IsSucess = true,
                Message = $"you Update Product with id {dto.Id}",
                Data = _productService.Update(dto.Id, dto.Name, dto.Cost, dto.Price)
            };
            return Ok(responce);
        }
    }
}
