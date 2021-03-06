﻿using System;

namespace Prudena.Web.Models
{
    public class Utilities
    {
        public static long DateTimeToUnixTimestamp(DateTime _DateTime)
        {
            TimeSpan _UnixTimeSpan = (_DateTime - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)_UnixTimeSpan.TotalSeconds;
        }

        public static DateTime UnixTimestampToDateTime(long _UnixTimeStamp)
        {
            return (new DateTime(1970, 1, 1, 0, 0, 0)).AddSeconds(_UnixTimeStamp);
        }

        
    }
}