using System;
using System.Text.Json.Serialization;

namespace HalterExercise.Models
{
	public class CollarStatus
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("serialNumber")]
		public string SerialNumber { get; set; }

		[JsonPropertyName("lat")]
		public string Lat { get; set; }

		[JsonPropertyName("healthy")]
		public bool Healthy { get; set; }

		[JsonPropertyName("lng")]
		public string Lng { get; set; }

		[JsonPropertyName("timestamp")]
		public DateTime Timestamp { get; set; }
	}
}