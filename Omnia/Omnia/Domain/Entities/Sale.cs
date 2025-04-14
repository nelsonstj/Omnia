using Omnia.Domain.Events;

namespace Omnia.Domain.Entities
{
	public class Sale
	{
		public int Id { get; set; }
		public string SaleNumber { get; set; }
		public DateTime SaleDate { get; set; }
		public string Customer { get; set; }
		public decimal TotalAmount => Items.Sum(x => x.Total);
		public string Branch { get; set; }
		public List<SaleItem> Items { get; set; } = [];
		public bool IsCancelled { get; private set; }

		public void AddItem(SaleItem item)
		{
			// * It's not possible to sell above 20 identical items
			if (item.Quantity > 20)
				throw new Exception("Cannot sell more than 20 identical items.");

			Items.Add(item);
			//RecalculateTotal();
		}

		public void Cancel()
		{
			IsCancelled = true;
			DomainEvents.Raise(new SaleCancelledEvent(this));
		}

		private void RecalculateTotal()
		{
			//TotalAmount = Items.Sum(i => i.Total);
		}
	}
}
