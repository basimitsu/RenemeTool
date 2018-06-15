using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Converters
{
    public class Date
    {
        public static uint ToUnixTimeStamp(DateTime dt)
        {
             // 文字列のローカル日付をUnix Timestampに変換 
            var timespan = dt.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (uint)timespan.TotalSeconds;
        }

        public static DateTime ToDateTime(double unixTimeStamp)
        {
            // Unix Timestampをローカル日付に変換 
            var dt = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTimeStamp).ToLocalTime();
            return dt;
        }
    }
}
