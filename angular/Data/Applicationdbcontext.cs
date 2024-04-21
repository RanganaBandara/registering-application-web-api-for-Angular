using Microsoft.EntityFrameworkCore;

namespace angular.Data


{
	public class Applicationdbcontext:DbContext
	{
		public Applicationdbcontext(DbContextOptions<Applicationdbcontext> options) : base(options) { }

		public DbSet<Employee> Employees { get; set; }

	}
}
