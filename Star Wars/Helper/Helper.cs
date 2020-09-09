namespace Star_Wars.Helper
{
    public static class Helper
    {
        public const int DAY_HOUR = 24;
        public const int WEEK_DAY = 7;
        public const int MONTH_DAY = 30;
        public const int YEAR_DAY = 365;
        public static int ConvertToInt(string mGLT)
        {
            return int.TryParse(mGLT, out int result) ? result : -1;
        }
        public static int ConvertHours(string consumables)
        {
            var a = consumables.Split(' ');
            if (a == null || a.Length < 2) return -1;
            if (!int.TryParse(a[0], out int time)) return -1;
            return time * ConvertToHours(a[1]);
        }

        private static int ConvertToHours(string v)
        {
            if (v == "day" || v == "days") return DAY_HOUR;
            if (v == "week" || v == "weeks") return DAY_HOUR * WEEK_DAY;
            if (v == "month" || v == "months") return DAY_HOUR * MONTH_DAY;
            if (v == "year" || v == "years") return DAY_HOUR * YEAR_DAY;
            return -1;
        }

        public static long FindFreq(int mGLT, int consumables, long distance)
        {
            if (mGLT == -1) return -1;
            if (consumables == -1) return -1;
            return distance / (mGLT * consumables);
        }
        public static long ValidInput(string s)
        {
            return long.TryParse(s, out long result) ? result : -1;
        }
    }
}
