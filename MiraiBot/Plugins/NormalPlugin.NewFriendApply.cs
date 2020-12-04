using Mirai_CSharp;
using Mirai_CSharp.Models;
using System.Threading.Tasks;

namespace MiraiBot.Plugins
{
    public partial class NormalPlugin
    {
        public async Task<bool> NewFriendApply(MiraiHttpSession session, INewFriendApplyEventArgs e)
        {
            await session.HandleNewFriendApplyAsync(e, FriendApplyAction.Allow, "你好！");
            return false;
        }
    }
}
