using System.ComponentModel.DataAnnotations;

namespace HalterExercise.Models
{
	public class Collar
	{
		[Key]
		public int Id { get; set; }
		public CollarStatus CollarStatus { get; set; }
	}
}