using Mirai_CSharp;
using Mirai_CSharp.Extensions;
using Mirai_CSharp.Models;
using MiraiBot.Resources;
using MiraiBot.Templates;
using MiraiBot.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiraiBot.Plugins
{
    public partial class NormalPlugin
    {
        public async Task<bool> FriendMessage(MiraiHttpSession session, IFriendMessageEventArgs e) // 法1: 使用 IMessageBase[]
        {
            var replyMsg = await MessageHandler(e);
            if (replyMsg == null)
                return true;
            await session.SendFriendMessageAsync(e.Sender.Id, replyMsg/*, plain2, /* etc... */);
            return false; // 不阻断消息传递。如需阻断请返回true
        }


        private async Task<PlainMessage> MessageHandler(IFriendMessageEventArgs e)
        {
            $"收到了来自{e.Sender.Name}({e.Sender.Remark})[{e.Sender.Id}]的私聊消息:{string.Join(null, (IEnumerable<IMessageBase>)e.Chain)}".LogInfo();
            // 好友昵称 /  / 好友备注 /  / 好友QQ号 /
            var msg = e.Chain.GetPlain();
            if (!msg.StartsWith("看"))
                return new PlainMessage(Template.RenderPersonReply());
            var key = msg.Substring(1);
            var model = await ResourceAcquisition.SearchResourceFromQP(key);
            msg = Template.RenderSearchResponse(key, model);
            return new PlainMessage(msg);
        }

    }
}
