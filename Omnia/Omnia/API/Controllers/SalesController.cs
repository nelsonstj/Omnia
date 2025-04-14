using Microsoft.AspNetCore.Mvc;
using Omnia.Application.Services;
using Omnia.Domain.Entities;

namespace Omnia.API.Controllers
{
	[ApiController]
	[Route("api/sales")]
	public class SalesController(SaleService saleService) : ControllerBase
	{
		private readonly SaleService _saleService = saleService;

		[HttpPost]
		public IActionResult Create(Sale sale)
		{
			if (sale == null || sale.Items == null || !sale.Items.Any())
				return BadRequest("Invalid sale data."); 
			
			var newSale = _saleService.CreateSale(sale);
			return CreatedAtAction(nameof(GetById), new { id = newSale.Id }, newSale);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var sale = _saleService._repository.GetById(id);
			return sale == null ? NotFound() : Ok(sale);
		}

		[HttpPost("{id}/cancel")]
		public IActionResult Cancel(int id)
		{
			_saleService.CancelSale(id);
			return NoContent();
		}
	}
}
