using System;
using System.Text.Json.Serialization;

namespace Pokemon.Model
{
  
   
    public class Contents
    {
        [JsonPropertyName("translated")]
        public string Translated { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("translation")]
        public string Translation { get; set; }
    }

    public class ShakespeareTranslateResponseObject
    {
        [JsonPropertyName("success")]
        public Success Success { get; set; }

        [JsonPropertyName("contents")]
        public Contents Contents { get; set; }
    }

    public class Success
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }
    }


}
