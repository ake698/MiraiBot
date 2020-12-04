using Mirai_CSharp;
using Mirai_CSharp.Models;
using System.Threading.Tasks;

namespace MiraiBot.Plugins
{
    public partial class NormalPlugin 
    {
        public async Task<bool> GroupApply(MiraiHttpSession session, IGroupApplyEventArgs e)
        {
            await session.HandleGroupApplyAsync(e, GroupApplyActions.Allow, "欢迎");
            return false;
        }
    }
}
