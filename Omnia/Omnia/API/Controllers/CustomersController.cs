using Microsoft.AspNetCore.Mvc;
using Omnia.Infrastructure.Persistence;

namespace Omnia.API.Controllers
{
	[ApiController]
	[Route("api/customers")]
	public class CustomersController(CustomerRepository customerRepository) : ControllerBase
	{
		private readonly CustomerRepository _customerRepository = customerRepository;

		[HttpGet]
		public IActionResult GetAll()
		{
			return Ok(_customerRepository.GetAll());
		}
	}
}
