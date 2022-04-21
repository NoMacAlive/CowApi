using System.Text.Json.Serialization;

namespace HalterExercise.Models.RequestModels
{
	public class UpdateCowRequest
	{
		[JsonPropertyName("collarId")]
		public int CollarId { get; set; }
		[JsonPropertyName("cowNumber")]
		public int CowNumber { get; set; }
	}
}