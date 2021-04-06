using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
	public class Context: DbContext
	{
		public Context(DbContextOptions<Context> options) : base(options)
		{

		}
	}
}
