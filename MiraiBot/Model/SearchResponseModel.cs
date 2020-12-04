using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MiraiBot.Model
{
    public class SearchResponseModel
    {
        [JsonPropertyName("datas")]
        public List<ResponseDataModel> Datas { get; set; }
        [JsonPropertyName("count")]
        public int Count { get; set; }
    }

    public class ResponseDataModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
