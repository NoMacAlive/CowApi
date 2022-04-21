using HalterExercise.Models;
using Microsoft.EntityFrameworkCore;

namespace HalterExercise
{
	public class HalterContext : DbContext
	{
		public DbSet<Cow> Cows { get; set; }

		public HalterContext (DbContextOptions<HalterContext> options)
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