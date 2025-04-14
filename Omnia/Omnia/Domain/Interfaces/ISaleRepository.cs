using Omnia.Domain.Entities;

namespace Omnia.Domain.Interfaces
{
	public interface ISaleRepository
	{
		void Add(Sale sale);
		void Update(Sale sale);
		Sale GetById(int id);
		IEnumerable<Sale> GetAll();
	}
}
