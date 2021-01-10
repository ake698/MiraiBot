using Mirai_CSharp.Extensions;
using Mirai_CSharp.Models;
using MiraiBot.Const;
using MiraiBot.Templates;
using System;
using System.Threading.Tasks;

namespace MiraiBot.CommandHandler
{
    public class FriendCommandHandler : BaseCommandHandler<IFriendMessageEventArgs>
    {
        public override Task<PlainMessage> PersonalizedOperation(IFriendMessageEventArgs e)
        {
            // 添加直接更新操作 为管理员或者指定用户可操作
            var command = e.Chain.GetPlain();
            if (command.StartsWith("更新") && Setting.UpdateActionPermission.Contains(e.Sender.Id.ToString()))
                return UpdateCommandHandler(command);

            return Task.FromResult(new PlainMessage(Template.RenderBaseReply()));
        }
    }
}
