using MiraiBot.Model;
using System.Linq;

namespace MiraiBot.Templates
{
    public class Template
    {
        public static string RenderSearchResponse(string key, SearchResponseModel model)
        {
            if (model.Datas.Any())
            {
                var infos = model.Datas.Select(x =>x.Name + "\n" + x.Url).ToArray();
                var data_info = string.Join("\n", infos);
                return $"为保证观看效果,请用手机浏览器打开以下链接。\n" +
                $"您好，您搜索的 {key} 共有 {model.Count} 条数据，本次展示 {model.Datas.Count} 条:\n{data_info}";
            }

            return $"您好，您搜索的 {key} 不存在，我们已经进行记录，会尽快添加此资源！";
        }

        public static string RenderBaseReply()
        {
            return "你好,请输入看+关键字(看功夫)进行影视资源搜索！" +
                "\n 源网站为:\n http://www.qianping.cc" +
                "\n 请使用本地浏览器打开网页。";
        }
    }
}
