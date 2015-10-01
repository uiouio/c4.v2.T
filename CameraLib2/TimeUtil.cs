using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CameraLib2
{
    public class TimeUtil
    {
        public static long ToTimestamp(DateTime dateTime)
        {
            var gtm = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            return Convert.ToInt64((dateTime - gtm).TotalSeconds);
        }

        public static DateTime FromTimestamp(long timestamp)
        {
            var gtm = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return gtm.AddSeconds(timestamp).ToLocalTime();
        }
    }
}
