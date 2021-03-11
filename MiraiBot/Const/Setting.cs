using System.Collections.Generic;

namespace MiraiBot.Const
{
    public class Setting
    {
        public const string Host = "119.3.230.152";
        public const int Port = 9999;
        public const string AuthKey = "redhat5431";

        public const long QQ = 1471259552;
        //public const long GroupId = 424101920;
        public static List<long> GroupIds = new List<long>
        {
            424101920,
            518603906
        };

        public const string MQUserName = "qp";
        public const string MQPassword = "redhat5431";
        public const string MQChannel = "search";

        public static List<string> UpdateActionPermission = new List<string>{
            "1137230948","376494614",
            "1321812866","1950193476"
        };
    }
}
