using System;

namespace StudentManagementApp.Library.Helpers
{
    public class SystemDateTime
    {
        private static DateTime _custom = DateTime.MinValue;

        public static void Set(DateTime custom)
        {
            _custom = custom;
        }

        public static void Reset()
        {
            _custom = DateTime.MinValue;
        }

        public static DateTime UtcNow()
        {
            if(_custom != DateTime.MinValue)
            {
                return _custom;
            }
            return DateTime.UtcNow;
        }
    }
}
