using Omnia.Application.Services;
using Omnia.Domain.Entities;
using Omnia.Domain.Interfaces;
using Omnia.Infrastructure.Persistence;
using Xunit;

namespace Omnia.Tests
{
	public class SaleServiceTests
	{
		private readonly ISaleRepository _repository = new SaleRepository();
		private readonly SaleService _service;

		public SaleServiceTests()
		{
			_service = new SaleService(_repository);
		}

		[Fact]
		public void CreateSale_ShouldStoreSaleAndRaiseEvent()
		{
			// Arrange
			var sale = new Sale { SaleNumber = "S456", SaleDate = DateTime.Now, Customer = "Nelson", Branch = "Branch 2" };

			// Act
			var createdSale = _service.CreateSale(sale);

			// Assert
			Assert.NotNull(_repository.GetById(createdSale.Id));
		}

		[Fact]
		public void CancelSale_ShouldSetSaleAsCancelled()
		{
			// Arrange
			var sale = new Sale { SaleNumber = "S789", SaleDate = DateTime.Now, Customer = "Katia", Branch = "Branch 1" };
			_repository.Add(sale);

			// Act
			_service.CancelSale(sale.Id);

			// Assert
			Assert.True(sale.IsCancelled);
		}
	}
}
