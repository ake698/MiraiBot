using Mirai_CSharp.Models;
using MiraiBot.Extensions;
using System;
using System.Threading.Tasks;

namespace MiraiBot.CommandHandler
{
    public class GroupCommandHandler : BaseCommandHandler<IGroupMessageEventArgs>
    {
        public override Task<PlainMessage> PersonalizedOperation(IGroupMessageEventArgs e)
        {
            if (e.Chain.HasAtMe())
                return Task.FromResult(new PlainMessage("你好呀！"));

            return null;
        }
    }
}
