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
    public abstract class BaseCommandHandler<T>  where T : ICommonMessageEventArgs 
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
    }
}
