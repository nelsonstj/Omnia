namespace Omnia.Domain.Entities
{
	public class SaleItem
	{
		public int Id { get; set; }
		public string Product { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal Discount { get; private set; }
		public decimal Total => (UnitPrice * Quantity) - Discount;

		public SaleItem(string product, int quantity, decimal unitPrice)
		{
			Product = product;
			Quantity = quantity;
			UnitPrice = unitPrice;
			ApplyDiscount();
		}

		private void ApplyDiscount()
		{
			// * Purchases below 4 items cannot have a discount
			// * Purchases above 4 identical items have a 10% discount
			if (Quantity >= 4 && Quantity < 10)
				Discount = (UnitPrice * Quantity) * 0.10m;
			// * Purchases between 10 and 20 identical items have a 20 % discount
			else if (Quantity >= 10 && Quantity <= 20)
				Discount = (UnitPrice * Quantity) * 0.20m;
		}
	}
}
