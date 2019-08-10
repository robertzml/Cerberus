using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlSugar;
using Cerberus.Core.DL;

namespace Cerberus.Test
{
    [TestClass]
    public class SugarTest
    {
        /// <summary>
        /// Create SqlSugarClient
        /// </summary>
        /// <returns></returns>
        private SqlSugarClient GetInstance()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "Server=localhost;Database=tmr;User=root;Password=123456;CharSet=utf8mb4;Allow Zero Datetime=True;",
                DbType = DbType.MySql,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
            //Print sql
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };
            return db;
        }

        [TestMethod]
        public void TestInsert()
        {
            var db = GetInstance();

            var p = new Person();
            p.Id = Guid.NewGuid().ToString();
            p.WechatId = "abcde";
            p.Name = "张三";
            p.NickName = "李四";
            p.Gender = 1;
            p.Birthday = new DateTime(2010, 4, 2, 10, 0, 0);

            var result = db.Insertable(p).ExecuteCommand();

            Assert.AreEqual(1, result);
        }
    }
}
