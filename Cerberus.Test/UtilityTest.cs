using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace Cerberus.Test
{
    using Cerberus.Core.Utility;

    [TestClass]
    public class UtilityTest
    {
        [TestMethod]
        public void TestHoroscope()
        {
            Horoscope horoscope = new Horoscope();
            //var z = horoscope.YearChar(1987);
            //Assert.AreEqual("丁卯", z);

            //var m = horoscope.MonthChar(1987, 6);
            //Assert.AreEqual("丙午", m);

            //var d = horoscope.DayChar(1985, 25);
            //Assert.AreEqual("庚子", d);
        }

        [TestMethod]
        public void TestCalendar()
        {
            ChineseLunisolarCalendar chineseDate = new ChineseLunisolarCalendar();

            for (int i = chineseDate.MinSupportedDateTime.Year; i < chineseDate.MaxSupportedDateTime.Year; i++)
            {
                Console.WriteLine("年份：{0}，月份总数：{1}，总天数：{2}，干支序号：{3}", i, chineseDate.GetMonthsInYear(i), chineseDate.GetDaysInYear(i)
                                  , chineseDate.GetSexagenaryYear(new DateTime(i, 3, 1)));
            }
        }

        [TestMethod]
        public void TestChinese()
        {
            DateTime dt = new DateTime(1987, 6, 17, 5, 0, 0);
            ChineseDateTime cdt = new ChineseDateTime(dt);
            //Console.WriteLine(cdt.ToShortDateString());

            //Console.WriteLine(cdt.ToChineseString());

            Console.WriteLine(cdt.ToChineseEraString());
        }
    }
}
