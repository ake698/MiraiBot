using Mirai_CSharp.Extensions;
using Mirai_CSharp.Models;
using MiraiBot.Resources;
using MiraiBot.Templates;
using MiraiBot.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MiraiBot.CommandHandler
{
    public abstract class BaseCommandHandler<T> where T : ICommonMessageEventArgs
    {
        public virtual async Task<PlainMessage> CommandHandler(T e)
        {
            var command = e.Chain.GetPlain();
            if (command.StartsWith("看"))
                return await ResouceCommandHandler(command);
            try
            {
                return await PersonalizedOperation(e);
            }catch(Exception ex)
            {
                ex.Message.LogError();
                return BaseReply();
            }


        }

        public abstract Task<PlainMessage> PersonalizedOperation(T e);

        public virtual PlainMessage BaseReply()
        {
            return new PlainMessage(Template.RenderBaseReply());
        }

        /// <summary>
        /// 查找资源，无资源则推送搜索命令
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<PlainMessage> ResouceCommandHandler(string command)
        {
            var key = command.Substring(1);
            var model = await ResourceAcquisition.SearchResourceFromQP(key);
            var reply = Template.RenderSearchResponse(key, model);
            reply.LogInfo();
            if (!model.Datas.Any())
            {
                MQUtil.PublishMQ(key);
            }
            return new PlainMessage(reply);
        }

        /// <summary>
        /// 更新操作，直接推送资源名称至MQ
        /// </summary>
        /// <param name="command">原命令</param>
        /// <returns>更新操作成功魔板</returns>
        public Task<PlainMessage> UpdateCommandHandler(string command)
        {
            var key = command.Substring(2);
            var reply = Template.RenderUpdateActionResponse(key);
            MQUtil.PublishMQ(key);
            return Task.FromResult(new PlainMessage(reply));
        }
    }
}
