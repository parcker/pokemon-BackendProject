using System;
namespace Pokemon.Model.CacheingModels
{
    public class CacheRequest
    {
        public string key { get; set; }
        public object Value { get; set; }
        public TimeSpan TimeToLive { get; set; }
    }
}
