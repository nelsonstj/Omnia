using Omnia.Domain.Entities;
using Omnia.Domain.Interfaces;

namespace Omnia.Infrastructure.Persistence
{
	public class SaleRepository : ISaleRepository
	{
		private readonly List<Sale> _sales = [];
		private int _lastId = 0; // Último ID utilizado

		public void Add(Sale sale)
		{
			sale.Id = ++_lastId; // Gera o próximo Id de forma sequencial
			sale.SaleNumber = $"S{sale.Id:D4}"; // Formato de número da venda
			_sales.Add(sale);
		}

		public void Update(Sale sale) 
		{
			var existingSale = GetById(sale.Id);
			if (existingSale != null)
			{
				_sales.Remove(existingSale);
				_sales.Add(sale);
			}
		}
		public Sale GetById(int id) => _sales.FirstOrDefault(s => s.Id == id);
		public IEnumerable<Sale> GetAll() => _sales;
	}
}
