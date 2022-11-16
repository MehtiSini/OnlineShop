using System.Globalization;

namespace Blog.Domain.Tools
{
    public static class ShamsiToMiladi
    {
        public static string GetShamsi(this DateTime dateTime)
        {
            PersianCalendar pc = new PersianCalendar();
            return string.Format("{0}/{1}/{2}",
                pc.GetYear(dateTime),
                pc.GetMonth(dateTime),
                pc.GetDayOfMonth(dateTime));
        }
     }
}
