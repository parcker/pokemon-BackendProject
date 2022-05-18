using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Pokemon.Model.PokemonSpecies
{
    public class FlavorTextEntry
    {
        [JsonPropertyName("flavor_text")]
        public string FlavorText { get; set; }

        [JsonPropertyName("language")]
        public Language Language { get; set; }

        [JsonPropertyName("version")]
        public Version Version { get; set; }
    }
    public class Language
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
    public class PokemonSpeciesBaseResponseObject
    {
       

        [JsonPropertyName("flavor_text_entries")]
        public IEnumerable<FlavorTextEntry> FlavorTextEntries { get; set; }

       
    }
    public class Version
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }


}
