using Mirai_CSharp.Extensions;
using Mirai_CSharp.Models;
using MiraiBot.Const;
using MiraiBot.Extensions;
using MiraiBot.Templates;
using MiraiBot.Utils;
using System.Threading.Tasks;

namespace MiraiBot.CommandHandler
{
    public class GroupCommandHandler : BaseCommandHandler<IGroupMessageEventArgs>
    {
        // 其他类型的操作
        public override Task<PlainMessage> PersonalizedOperation(IGroupMessageEventArgs e)
        {
            // 添加直接更新操作 为管理员或者指定用户可操作
            var command = e.Chain.GetPlain();
            if (command.StartsWith("更新") &&
                (e.Sender.Permission != GroupPermission.Member || Setting.UpdateActionPermission.Contains(e.Sender.Id.ToString())))
                return UpdateCommandHandler(command);
            if (e.Chain.HasAtMe())
                return Task.FromResult(new PlainMessage(Template.RenderBaseReply()));

            return Task.FromResult(new PlainMessage(Template.RenderEmpty()));
        }
    }
}
