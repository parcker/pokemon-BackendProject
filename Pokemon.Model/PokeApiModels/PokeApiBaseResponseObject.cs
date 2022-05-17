using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Pokemon.Model
{

    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);


    public class PokeApiBaseResponseObject
    {


        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("species")]
        public Species Species { get; set; }


    }


    public class Species
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

}