using Mirai_CSharp.Extensions;
using Mirai_CSharp.Utility;
using MiraiBot.Model;
using System.Net.Http;
using System.Threading.Tasks;

namespace MiraiBot.Resources
{
    public class ResourceAcquisition
    {
        public const string QPSearchUri = "http://www.qianping.cc/botsearch";

        public static async Task<SearchResponseModel> SearchResourceFromQP(string key)
        {
            var response = await BuildHttpClient().PostAsJsonAsync($"{QPSearchUri}?key={key}", new {key}).GetJsonAsync();
            return response.RootElement.Deserialize<SearchResponseModel>();
        }



        private static HttpClient BuildHttpClient()
        {
            return new HttpClient();
        }
    }
}
