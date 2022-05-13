
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Pokemon.Model.CachingModels
{
    
    public  class CachedResponseObject
    {
        
        [JsonPropertyName("Value")]
        public Value Value { get; set; }

        [JsonPropertyName("Formatters")]
        public IEnumerable<object> Formatters { get; set; }

        [JsonPropertyName("ContentTypes")]
        public IEnumerable<object> ContentTypes { get; set; }

        [JsonPropertyName("DeclaredType")]
        public object DeclaredType { get; set; }

        [JsonPropertyName("StatusCode")]
        public int StatusCode { get; set; }
    }

    public class Value
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }
    }
}