using System;
using System.Globalization;

namespace Pruebas.Servicios
{
    /// <summary>
    /// Extensor para agregar los métodos GetWeekOfYear y GetWeekOfMonth a la clase DateTime
    /// </summary>
    static class ExtensorDateTime
    {
        static readonly GregorianCalendar Gc = new GregorianCalendar();
        public static int GetSemanaDelMes(this DateTime time)
        {
            var first = new DateTime(time.Year, time.Month, 1);
            return time.GetSemanaDelAño() - first.GetSemanaDelAño() + 1;
        }

        static int GetSemanaDelAño(this DateTime time)
        {
            return Gc.GetWeekOfYear(time, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }
    }
}
