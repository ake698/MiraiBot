using Mirai_CSharp.Models;
using MiraiBot.Const;
using System.Linq;

namespace MiraiBot.Extensions
{
    public static class MessageChainExtensions
    {
        public static bool HasAtMe(this IMessageBase[] chain)
        {
            return chain.OfType<AtMessage>().Select(p => p.Target).Any(p => p == Setting.QQ);
        }
    }
}
