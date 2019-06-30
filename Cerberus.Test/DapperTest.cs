using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using Dapper;
using Cerberus.Core.Entity;

namespace Cerberus.Test
{
    [TestClass]
    public class DapperTest
    {
        private string connectionString = "Server=localhost;Database=tmr;User=root;Password=123456;CharSet=utf8mb4;Allow Zero Datetime=True;";


        [TestMethod]
        public void TestInsert()
        {
            Person person = new Person();
            person.WechatId = "123";
            person.Name = "test";
            person.Gender = 1;
            person.Birthday = new System.DateTime(2011, 10, 5, 8, 0, 0);
                        
            //using (IDbConnection connection = new SqlConnection(connectionString))
            //{
            //    int result = connection.Execute("insert into Person(Name,Remark) values(@Name,@Remark)", person);
            //    Assert.Equals(result, 1);
            //}
        }
    }
}
