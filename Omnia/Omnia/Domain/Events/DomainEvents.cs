namespace Omnia.Domain.Events
{
	public static class DomainEvents
	{
		private static readonly List<Action<IDomainEvent>> Handlers = [];

		public static void Raise(IDomainEvent domainEvent)
		{
			foreach (var handler in Handlers)
			{
				handler(domainEvent);
			}
		}

		public static void Register(Action<IDomainEvent> eventHandler)
		{
			Handlers.Add(eventHandler);
		}
	}
}
