using Mirai_CSharp;
using Mirai_CSharp.Extensions;
using Mirai_CSharp.Models;
using MiraiBot.CommandHandler;
using MiraiBot.Resources;
using MiraiBot.Templates;
using MiraiBot.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiraiBot.Plugins
{
    public partial class NormalPlugin
    {
        private FriendCommandHandler _friendHandler = new FriendCommandHandler();

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

            return await _friendHandler.CommandHandler(e);
        }

    }
}
