namespace Website.Domain.Repositories.EntityFramework
{
	public class EFPhoneRepository
	{
		AppDbContext db;

		public EFPhoneRepository(AppDbContext context) 
		{ 
			db = context;
		}


	}
}
