using HalterExercise.Models;
using Microsoft.EntityFrameworkCore;

namespace HalterExercise
{
	public class HalterContext : DbContext
	{
		public DbSet<Cow> Cows { get; set; }

		public DbSet<Collar> Collars { get; set; }

		// public HalterContext( string connection ) : base( new DbContextOptionsBuilder( ).UseNpgsql( connection ).Options )
		// {
		// }
		protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
			=> optionsBuilder.UseNpgsql( "Host=localhost:5432;Database=my_db;Username=postgres;Password=changeme" );
		public HalterContext (DbContextOptions<HalterContext> options)
			: base(options)
		{
		}
	}
}