using SalvaLucroClient.Extensions.jsonConverters;
using Newtonsoft.Json;

namespace SalvaLucroClient.Domain.Model
{
    internal class Token
    {
        public bool sucess { get; set; }
        public string message { get; set; }
        public string acess_token { get; set; }
        [JsonConverter(typeof(jsonInt32JsonConverter))]
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        [JsonConverter(typeof(jsonDateOnlyConverter), "yyyy-MM-dd")]
        public DateTime refresh_expires_in { get; set; }
        public string token_type { get; set; }
        public string scope { get; set; }
    }
}
