using CowApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CowApi
{
	public class CowContext : DbContext
	{
		public DbSet<Cow> Cows { get; set; }

		public CowContext (DbContextOptions<CowContext> options)
			: base(options)
		{
		}
		
		#region Required
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		}
		#endregion
	}
}