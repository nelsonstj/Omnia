using Omnia.Domain.Entities;

namespace Omnia.Domain.Events
{
	public class SaleCancelledEvent(Sale sale) : IDomainEvent
	{
		public Sale Sale { get; } = sale;
	}
}
