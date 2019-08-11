﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace Cerberus.Core.BL
{
    using SqlSugar;
    using Cerberus.Core.DL;
    using Cerberus.Core.Utility;

    /// <summary>
    /// 用户业务类
    /// </summary>
    public class PersonBusiness
    {
        #region Function
        /// <summary>
        /// Create SqlSugarClient
        /// </summary>
        /// <returns></returns>
        private SqlSugarClient GetInstance()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                //ConnectionString = "Server=localhost;Database=tmr;User=root;Password=123456;CharSet=utf8mb4;Allow Zero Datetime=True;",
                ConnectionString = "Server=localhost;Database=tmr;User=cerberus;Password=Cerberus2019;CharSet=utf8mb4;Allow Zero Datetime=True;",
                DbType = DbType.MySql,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
            //Print sql
            //db.Aop.OnLogExecuting = (sql, pars) =>
            //{
            //    Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
            //    Console.WriteLine();
            //};
            return db;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        public List<Person> FindAll()
        {
            var db = GetInstance();
            return db.Queryable<Person>().ToList();
        }

        /// <summary>
        /// 根据微信ID查询用户
        /// </summary>
        /// <param name="wechatId">微信ID</param>
        /// <returns></returns>
        public Person FindByWechatId(string wechatId)
        {
            var db = GetInstance();
            var data = db.Queryable<Person>().Where(r => r.WechatId == wechatId).First();
            return data;
        }

        /// <summary>
        /// 根据八字查找用户
        /// </summary>
        /// <param name="horoscope">八字</param>
        /// <returns></returns>
        //public List<Person> FindByHoroscope(string horoscope)
        //{
        //    using (IDbConnection connecton = new MySqlConnection(CerberusConstant.ConnectionString))
        //    {
        //        return connecton.Query<Person>(
        //            "SELECT id, wechat_id WechatId, name, gender, birthday, horoscope FROM person WHERE horoscope = @horoscope",
        //            new { Horoscope = horoscope }).ToList();
        //    }
        //}
        #endregion //Method

        #region CRUD
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="person">用户信息</param>
        /// <returns></returns>
        public bool Create(Person person)
        {
            ChineseDateTime cdt = new ChineseDateTime(person.Birthday);
            person.Horoscope = cdt.ToChineseEraString();

            var db = GetInstance();
            var result = db.Insertable(person).ExecuteCommand();
            return result == 1;
        }
        #endregion //CRUD
    }
}
