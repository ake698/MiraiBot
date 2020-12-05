using Mirai_CSharp.Models;
using MiraiBot.Templates;
using System;
using System.Threading.Tasks;

namespace MiraiBot.CommandHandler
{
    public class FriendCommandHandler : BaseCommandHandler<IFriendMessageEventArgs>
    {
        public override Task<PlainMessage> PersonalizedOperation(IFriendMessageEventArgs e)
        {
            return Task.FromResult(new PlainMessage(Template.RenderBaseReply()));
        }
    }
}
