using System.Text.Json; 
namespace Pokemon.Common.ErrorModel
{
    public class Error
    {
        public string Code { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}