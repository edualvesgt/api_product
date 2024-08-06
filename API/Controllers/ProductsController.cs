using API_Product.Domains;
using API_Product.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productRepository;

        // Construtor que recebe a instância de IProductsRepository
        public ProductsController(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_productRepository.List());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id) 
        {
            try
            {
                Products SearchProducts = _productRepository.GetById(id);

                return Ok(SearchProducts);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Create(Products products)
        {
            try
            {
                _productRepository.Create(products);
                return StatusCode(201, products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(Products products,Guid id)
        {
            try
            {
                _productRepository.Update(products, id);

                return Ok("Produto Alterado com Sucesso ");

            }
            catch (Exception e )
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete ("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _productRepository.Delete(id);
                return NoContent();
            }
            catch (Exception e )
            {
                return BadRequest(e.Message);
            }
        }
    }
}
