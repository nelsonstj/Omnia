using Omnia.Domain.Entities;

namespace Omnia.Infrastructure.Persistence
{
	public class CustomerRepository : BaseFileRepository<Customer>
	{
		public CustomerRepository() : base("Infrastructure/Persistence/customers.json") { }

		public Customer GetById(int id) => LoadData().FirstOrDefault(c => c.Id == id);
		public IEnumerable<Customer> GetAll() => LoadData();
	}
}
