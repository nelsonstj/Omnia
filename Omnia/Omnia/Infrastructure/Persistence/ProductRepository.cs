using Omnia.Domain.Entities;

namespace Omnia.Infrastructure.Persistence
{
	public class ProductRepository : BaseFileRepository<Product>
	{
		public ProductRepository() : base("Infrastructure/Persistence/products.json") { }

		public Product GetById(int id) => LoadData().FirstOrDefault(p => p.Id == id);
		public IEnumerable<Product> GetAll() => LoadData();
	}
}