using System;
using System.Text.Json.Serialization;

namespace HalterExercise.Models.RequestModels
{
	public class GetCowsResponse
	{
		[JsonPropertyName("id")]
		public Guid Id { get; set; }
		[JsonPropertyName("collarId")]
		public int CollarId { get; set; }
		[JsonPropertyName("cowNumber")]
		public int CowNumber { get; set; }
		[JsonPropertyName("collarStatus")]
		public Enums.CollarStatus CollarStatus { get; set; }
		[JsonPropertyName("lastLocation")]
		public Location LastLocation { get; set; }
	}
}