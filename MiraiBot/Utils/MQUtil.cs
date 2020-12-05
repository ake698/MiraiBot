using MiraiBot.Const;
using RabbitMQ.Client;
using System.Text;

namespace MiraiBot.Utils
{
    public class MQUtil
    {
        public static IModel Channel;
        public static void InitMQ()
        {
            ConnectionFactory factory = new ConnectionFactory
            {
                UserName = Setting.MQUserName,//用户名
                Password = Setting.MQPassword,//密码
                HostName = Setting.Host//rabbitmq ip
            };
            //创建连接
            var connection = factory.CreateConnection();
            //创建通道
            var channel = connection.CreateModel();
            channel.QueueDeclare(Setting.MQChannel, false, false, false, null);
            Channel = channel;
        }

        public static void PublishMQ(string key)
        {
            var sendKey = Encoding.UTF8.GetBytes(key);
            Channel.BasicPublish("", Setting.MQChannel, null, sendKey);
        }
    }
}
