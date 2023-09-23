using Website.Domain.Repositories.Abstract;

namespace Website.Domain.Repositories.EntityFramework
{
	public class EFPhoneRepository : IPhoneRepository
	{
		AppDbContext db;

		public EFPhoneRepository(AppDbContext context)
		{ 
			db = context;
		}


	}
}
