using Mirai_CSharp;
using Mirai_CSharp.Models;
using MiraiBot.Const;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiraiBot.Plugins
{
    public partial class NormalPlugin
    {
        public async Task<bool> Disconnected(MiraiHttpSession session, IDisconnectedEventArgs e)
        {
            // e.Exception: 引发掉线的响应异常, 按需处理
            MiraiHttpSessionOptions options = new MiraiHttpSessionOptions(Setting.Host, Setting.Port, Setting.AuthKey);
            while (true)
            {
                try
                {
                    await session.ConnectAsync(options, 0); // 连到成功为止, QQ号自填, 你也可以另行处理重连的 behaviour
                    return true;
                }
                catch (Exception)
                {
                    await Task.Delay(1000);
                }
            }
        }
    }
}
