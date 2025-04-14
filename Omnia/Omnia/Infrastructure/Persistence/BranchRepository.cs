using Omnia.Domain.Entities;

namespace Omnia.Infrastructure.Persistence
{
	public class BranchRepository : BaseFileRepository<Branch>
	{
		public BranchRepository() : base("Infrastructure/Persistence/branches.json") { }

		public Branch GetById(int id) => LoadData().FirstOrDefault(b => b.Id == id);
		public IEnumerable<Branch> GetAll() => LoadData();
	}
}
