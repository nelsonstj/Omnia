using Microsoft.AspNetCore.Mvc;
using Omnia.Infrastructure.Persistence;

namespace Omnia.API.Controllers
{
	[ApiController]
	[Route("api/products")]
	public class ProductsController(ProductRepository productRepository) : ControllerBase
	{
		private readonly ProductRepository _productRepository = productRepository;

		[HttpGet]
		public IActionResult GetAll()
		{
			return Ok(_productRepository.GetAll());
		}
	}
}
