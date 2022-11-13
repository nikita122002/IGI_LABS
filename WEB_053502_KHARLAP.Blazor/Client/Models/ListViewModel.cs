using System.Text.Json.Serialization;

namespace WEB_053502_KHARLAP.Blazor.Client.Models
{
    public class ListViewModel
    {
        [JsonPropertyName("id")]
        public int CarId { get; set; }

        [JsonPropertyName("name")]
        public string CarName { get; set; }
    }
}