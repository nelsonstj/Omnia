using Omnia.Domain.Entities;
using Omnia.Infrastructure.Persistence;

namespace Omnia.Tests.Repositories
{
	public class SaleRepositoryTests
	{
		[Fact]
		public void Should_Add_Sale_With_Sequential_Id_And_SaleNumber()
		{
			var repo = new SaleRepository();

			var sale = new Sale { SaleNumber = "S0005", SaleDate = DateTime.Now, Customer = "Nicolas", Branch = "Branch A" };
			sale.AddItem(new SaleItem("Product A", 5, 10)); // 5 items at $10 each, 10% discount
			sale.AddItem(new SaleItem("Product B", 2, 20)); // No discount

			repo.Add(sale);

			Assert.Equal(1, sale.Id);
			Assert.Equal("S0001", sale.SaleNumber);
			Assert.Single(repo.GetAll());
		}

		[Fact]
		public void CreateSale_ShouldCalculateTotalAmount()
		{
			// Arrange
			var sale = new Sale { SaleNumber = "S0005", SaleDate = DateTime.Now, Customer = "Nicolas", Branch = "Branch A" };
			sale.AddItem(new SaleItem("Product A", 5, 10)); // 5 items at $10 each, 10% discount
			sale.AddItem(new SaleItem("Product B", 2, 20)); // No discount

			// Act
			var total = sale.TotalAmount;

			// Assert
			Assert.Equal(5 * 10 * 0.9m + 2 * 20, total);
		}

		[Fact]
		public void AddItem_ShouldApplyCorrectDiscounts()
		{
			// Arrange
			var item1 = new SaleItem("Product A", 5, 10); // 10% discount
			var item2 = new SaleItem("Product B", 10, 20); // 20% discount
			var item3 = new SaleItem("Product C", 3, 30); // No discount

			// Act & Assert
			Assert.Equal(5 * 10 * 0.10m, item1.Discount);
			Assert.Equal(10 * 20 * 0.20m, item2.Discount);
			Assert.Equal(0, item3.Discount);
		}

		[Fact]
		public void AddItem_ShouldThrowException_WhenQuantityExceedsLimit()
		{
			// Arrange & Act
			var exception = Assert.Throws<Exception>(() => new SaleItem("Product A", 25, 10));

			// Assert
			Assert.Equal("Cannot sell more than 20 identical items.", exception.Message);
		}

		[Fact]
		public void CancelSale_ShouldSetIsCancelledToTrue()
		{
			// Arrange
			var sale = new Sale { SaleNumber = "S0005", SaleDate = DateTime.Now, Customer = "Nicolas", Branch = "Branch A" };

			// Act
			sale.Cancel();

			// Assert
			Assert.True(sale.IsCancelled);
		}
	}
}