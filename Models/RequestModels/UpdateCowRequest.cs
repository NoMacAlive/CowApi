using System.Text.Json.Serialization;

namespace CowApi.Models.RequestModels
{
	public class UpdateCowRequest
	{
		[JsonPropertyName("collarId")]
		public int CollarId { get; set; }
		[JsonPropertyName("cowNumber")]
		public int CowNumber { get; set; }
	}
}