using Angular_Shop.API.Filters;
using Angular_Shop.Domain.ApiModels;
using Angular_Shop.Domain.Supervisor;
using FluentValidation;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Angular_Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    [ApiVersion("1.0")]
    public class ProductsController : ControllerBase
    {
        private readonly IAngularShopSupervisor _angularShopSupervisor;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IAngularShopSupervisor angularShopSupervisor,
            ILogger<ProductsController> logger)
        {
            _angularShopSupervisor = angularShopSupervisor;
            _logger = logger;
        }

        [HttpGet]
        [Produces(typeof(List<ProductApiModel>))]
        public async Task<ActionResult<List<ProductApiModel>>> GetAll()
        {
            _logger.LogInformation("Getting All Products");

            var products = await _angularShopSupervisor.GetAllProduct();
            if (!products.Any())
            {
                throw new KeyNotFoundException("Products Not Nound.");
            }

            return Ok(products);

        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<ProductApiModel>> GetById(int id)
        {
            _logger.LogInformation("Getting The Product");

            var product = await _angularShopSupervisor.GetProductById(id);
            if (product == null)
            {
                throw new KeyNotFoundException("Product Not Found.");
            }

            return Ok(product);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<ActionResult<ProductApiModel>> AddProduct([FromBody] ProductApiModel productApiModel)
        {
            _logger.LogInformation("Adding New Product.");

            if (productApiModel == null)
            {
                throw new KeyNotFoundException("Given Product Is Null");
            }

            return Ok(await _angularShopSupervisor.AddProduct(productApiModel));
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<ActionResult<ProductApiModel>> UpdateProduct(int id, [FromBody] ProductApiModel productApiModel)
        {
            _logger.LogInformation("Updating given product.");

            if (productApiModel == null)
            {
                throw new ApplicationException("Given Product Is Null");
            }

            await _angularShopSupervisor.UpdateProduct(productApiModel);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            _logger.LogInformation("Deleting given product");

            await _angularShopSupervisor.DeleteProduct(id);
            return NoContent();
        }
    }
}
