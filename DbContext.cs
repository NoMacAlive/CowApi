using HalterExercise.Models;
using Microsoft.EntityFrameworkCore;

namespace HalterExercise
{
	public class HalterContext : DbContext
	{
		public DbSet<Cow> Cows { get; set; }

		// public DbSet<Collar> Collars { get; set; }
		
		public HalterContext (DbContextOptions<HalterContext> options)
			: base(options)
		{
		}
		
		#region Required
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// modelBuilder.Entity<Cow>( )
			// 	.OwnsOne( p => p.LastLocation );
		}
		#endregion
	}
}