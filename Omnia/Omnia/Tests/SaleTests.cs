using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Omnia.Domain.Entities;

namespace Omnia.Tests
{
	public class SaleTests
	{
		[Fact]
		public void CreateSale_ShouldCalculateTotalAmount()
		{
			// Arrange
			var sale = new Sale { SaleNumber = "S123", SaleDate = DateTime.Now, Customer = "John Doe", Branch = "Branch1" };
			sale.AddItem(new SaleItem("Product1", 5, 10)); // 5 items at $10 each, 10% discount
			sale.AddItem(new SaleItem("Product2", 2, 15)); // No discount

			// Act
			var total = sale.TotalAmount;

			// Assert
			Assert.Equal(5 * 10 * 0.9m + 2 * 15, total);
		}

		[Fact]
		public void AddItem_ShouldApplyCorrectDiscounts()
		{
			// Arrange
			var item1 = new SaleItem("Product1", 5, 10); // 10% discount
			var item2 = new SaleItem("Product2", 10, 20); // 20% discount
			var item3 = new SaleItem("Product3", 3, 50); // No discount

			// Act & Assert
			Assert.Equal(5 * 10 * 0.10m, item1.Discount);
			Assert.Equal(10 * 20 * 0.20m, item2.Discount);
			Assert.Equal(0, item3.Discount);
		}

		[Fact]
		public void AddItem_ShouldThrowException_WhenQuantityExceedsLimit()
		{
			// Arrange & Act
			var exception = Assert.Throws<Exception>(() => new SaleItem("Product1", 25, 10));

			// Assert
			Assert.Equal("Cannot sell more than 20 identical items.", exception.Message);
		}

		[Fact]
		public void CancelSale_ShouldSetIsCancelledToTrue()
		{
			// Arrange
			var sale = new Sale { SaleNumber = "S123", SaleDate = DateTime.Now, Customer = "John Doe", Branch = "Branch1" };

			// Act
			sale.Cancel();

			// Assert
			Assert.True(sale.IsCancelled);
		}
	}
}
