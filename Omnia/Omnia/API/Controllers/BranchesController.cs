using Microsoft.AspNetCore.Mvc;
using Omnia.Infrastructure.Persistence;

namespace Omnia.API.Controllers
{
	[ApiController]
	[Route("api/branches")]
	public class BranchesController(BranchRepository branchRepository) : ControllerBase
	{
		private readonly BranchRepository _branchRepository = branchRepository;

		[HttpGet]
		public IActionResult GetAll()
		{
			return Ok(_branchRepository.GetAll());
		}
	}
}
