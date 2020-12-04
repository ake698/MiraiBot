using Mirai_CSharp;
using Mirai_CSharp.Extensions;
using Mirai_CSharp.Models;
using MiraiBot.Const;
using MiraiBot.Extensions;
using MiraiBot.Resources;
using MiraiBot.Templates;
using MiraiBot.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiBot.Plugins
{
    public partial class NormalPlugin
    {
        public async Task<bool> GroupMessage(MiraiHttpSession session, IGroupMessageEventArgs e) // 法2: 使用 params IMessageBase[]
        {
            var replyMsg = await GroupMessageHandler(e);
            if (replyMsg == null)
                return true;
            await session.SendGroupMessageAsync(e.Sender.Group.Id, new AtMessage(e.Sender.Id), replyMsg/*, plain2, /* etc... */); // 向消息来源群异步发送由以上chain表示的消息
            return false; // 不阻断消息传递。如需阻断请返回true
        }


        private async Task<PlainMessage> GroupMessageHandler(IGroupMessageEventArgs e)
        {
            if (e.Sender.Group.Id != Setting.GroupId)
                return null;

            $"收到了来自{e.Sender.Name}[{e.Sender.Id}]{{{e.Sender.Permission}}}的群消息:{string.Join(null, (IEnumerable<IMessageBase>)e.Chain)}".LogInfo();
            //     / 发送者群名片 /  / 发送者QQ号 /   /   发送者在群内权限

            if (e.Chain.HasAtMe())
                return new PlainMessage("你好呀！");

            var msg = e.Chain.GetPlain();
            if (!msg.StartsWith("看"))
                return new PlainMessage(Template.RenderPersonReply());
            var key = msg.Substring(1);
            var model = await ResourceAcquisition.SearchResourceFromQP(key);
            msg = Template.RenderSearchResponse(key, model);
            return new PlainMessage(msg);
        }

        private void RecordNullKey(Model.SearchResponseModel model)
        {
            if (model.Datas.Any())
                return;

            // 记录
        }
    }
}
