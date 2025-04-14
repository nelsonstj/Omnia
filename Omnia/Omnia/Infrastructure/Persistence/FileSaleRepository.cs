using Newtonsoft.Json;
using Omnia.Domain.Entities;
using Omnia.Domain.Interfaces;

namespace Omnia.Infrastructure.Persistence
{
	public class FileSaleRepository : ISaleRepository
	{
		private const string FilePath = "Infrastructure/Persistence/sales.json";

		private static List<Sale> LoadSales()
		{
			if (!File.Exists(FilePath))
				return [];

			var json = File.ReadAllText(FilePath);
			return JsonConvert.DeserializeObject<List<Sale>>(json) ?? [];
		}

		public void Add(Sale sale)
		{
			var sales = LoadSales();
			sale.Id = sales.Count > 0 ? sales.Max(s => s.Id) + 1 : 1;
			sale.SaleNumber = $"S{sale.Id:D4}";
			sales.Add(sale);
			SaveSales(sales);
		}

		public void Update(Sale sale)
		{
			var sales = LoadSales();
			var existingSale = sales.FirstOrDefault(s => s.Id == sale.Id);
			if (existingSale != null)
			{
				sales.Remove(existingSale);
				sales.Add(sale);
				SaveSales(sales);
			}
		}

		public Sale GetById(int id)
		{
			return LoadSales().FirstOrDefault(s => s.Id == id);
		}

		public IEnumerable<Sale> GetAll()
		{
			return LoadSales();
		}

		private static void SaveSales(List<Sale> sales)
		{
			var json = JsonConvert.SerializeObject(sales, Formatting.Indented);
			File.WriteAllText(FilePath, json);
		}
	}
}