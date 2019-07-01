using Cerberus.Core.BL;
using Cerberus.Core.DL;
using Dapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System.Data;

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

            person.Id = System.Guid.NewGuid().ToString();
            person.WechatId = "123";
            person.Name = "test";
            person.Gender = 1;
            person.Birthday = new System.DateTime(2011, 10, 5, 8, 0, 0);

            PersonBusiness personBusiness = new PersonBusiness();

            var result =  personBusiness.Create(person);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestFind()
        {
            PersonBusiness personBusiness = new PersonBusiness();
            var data = personBusiness.FindAll();

            Assert.AreEqual(1, data.Count);
        }
    }
}
