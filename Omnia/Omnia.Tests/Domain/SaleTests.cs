using Omnia.Domain.Entities;

namespace Omnia.Tests.Domain
{

	public class SaleTests
	{
		[Theory]
		[InlineData(3, 10, 0)]     // Sem desconto
		[InlineData(4, 10, 4)]     // 10% de desconto
		[InlineData(10, 10, 20)]   // 20% de desconto
		[InlineData(20, 10, 40)]   // 20% de desconto
		public void Should_Apply_Correct_Discount(int quantity, decimal unitPrice, decimal expectedDiscount)
		{
			var item = new SaleItem("Produto Teste", quantity, unitPrice);

			Assert.Equal(expectedDiscount, item.Discount);
		}

		[Fact]
		public void Should_Throw_When_Quantity_Exceeds_Limit()
		{
			var sale = new Sale
			{
				Customer = "Cliente Teste",
				Branch = "Filial X",
				SaleDate = DateTime.Now
			};

			sale.AddItem(new SaleItem("Produto A", 21, 100 ));

			var ex = Assert.Throws<InvalidOperationException>(() => sale.TotalAmount);

			Assert.Equal("Quantity for product 'Produto A' cannot exceed 20.", ex.Message);
		}

		[Fact]
		public void Should_Calculate_Total_Sale_Amount()
		{
			var sale = new Sale
			{
				Customer = "Cliente Teste",
				Branch = "Filial Y",
				SaleDate = DateTime.Now
			};

			sale.AddItem(new SaleItem("Produto A", 4, 100)); // 10% = 40 desconto => 360 total

			sale.AddItem(new SaleItem("Produto B", 2, 50)); // sem desconto => 100 total

			Assert.Equal(460, sale.TotalAmount);
		}
	}
}