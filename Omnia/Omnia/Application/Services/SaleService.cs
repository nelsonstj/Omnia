using Omnia.Domain.Entities;
using Omnia.Domain.Events;
using Omnia.Domain.Interfaces;

namespace Omnia.Application.Services
{
	public class SaleService(ISaleRepository repository)
	{
		public readonly ISaleRepository _repository = repository;

		public Sale CreateSale(Sale sale)
		{
			ArgumentNullException.ThrowIfNull(sale);

			_repository.Add(sale);
			DomainEvents.Raise(new SaleCreatedEvent(sale));
			return sale;
		}

		public void CancelSale(int id)
		{
			var sale = _repository.GetById(id) ?? throw new Exception("Sale not found");
			sale.Cancel();
			_repository.Update(sale);
		}
	}
}
