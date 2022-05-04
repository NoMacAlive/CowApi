
using System.Text.Json.Serialization;

namespace CowApi.Models.RequestModels
{
	public class CreateNewCowRequest
	{
		[JsonPropertyName("collarId")]
		public string CollarId { get; set; }

		[JsonPropertyName("cowNumber")]
		public string CowNumber { get; set; }
	}
}