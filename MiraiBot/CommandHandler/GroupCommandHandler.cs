using Mirai_CSharp.Models;
using MiraiBot.Extensions;
using MiraiBot.Templates;
using System.Threading.Tasks;

namespace MiraiBot.CommandHandler
{
    public class GroupCommandHandler : BaseCommandHandler<IGroupMessageEventArgs>
    {
        public override Task<PlainMessage> PersonalizedOperation(IGroupMessageEventArgs e)
        {
            if (e.Chain.HasAtMe())
                return Task.FromResult(new PlainMessage(Template.RenderBaseReply()));

            return Task.FromResult(new PlainMessage(Template.RenderEmpty()));
        }
    }
}
