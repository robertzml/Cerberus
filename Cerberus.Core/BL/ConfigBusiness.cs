﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SqlSugar;
using Cerberus.Core.DL;
using Cerberus.Core.Utility;

namespace Cerberus.Core.BL
{
    /// <summary>
    /// 配置业务类
    /// </summary>
    public class ConfigBusiness
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
                ConnectionString = "Server=localhost;Database=tmr;User=cerberus;Password=Cerberus2019;CharSet=utf8mb4;Allow Zero Datetime=True;",
                DbType = DbType.MySql,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
            return db;
        }
        #endregion //Function

        #region Method
        public ConfigData GetData(string wechatId)
        {
            ConfigData data = new ConfigData();
            var db = GetInstance();
            data.TotalUsers = db.Queryable<Person>().Count() + 85000;

            var person = db.Queryable<Person>().Where(r => r.WechatId == wechatId).First();
            if (person == null)
            {
                data.AlreadyFound = 0;
            }
            else
            {
                data.AlreadyFound = db.Queryable<Person>().Where(r => r.Horoscope == person.Horoscope && r.WechatId != wechatId).Count();
            }

            var fortune = db.Queryable<Person>()
                .GroupBy(r => new { r.Horoscope })
                .Having(t => SqlFunc.AggregateCount(t.Id) > 1)
                .Select(s => new { s.Horoscope, Count = SqlFunc.AggregateCount(s.Id) }).ToList();

            data.FortuneBuddy = fortune.Sum(r => r.Count) + 2300;

            var config = db.Queryable<Config>().First();
            data.ShowTotalUsers = config.ShowTotalUsers;
            data.ShowAlreadyFound = config.ShowAlreadyFound;
            data.ShowFortuneBuddy = config.ShowFortuneBuddy;
            data.IfWeixinNeed = config.IfWeixinNeed;
            data.ModifyCount = config.ModifyCount;

            return data;
        }
        #endregion //Method
    }
}
