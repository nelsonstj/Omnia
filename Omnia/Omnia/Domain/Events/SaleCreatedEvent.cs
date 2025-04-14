using Omnia.Domain.Entities;

namespace Omnia.Domain.Events
{
	public class SaleCreatedEvent(Sale sale) : IDomainEvent
	{
		public Sale Sale { get; } = sale;
	}
}
