using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Cerberus.Core.BL
{
    public class BaseBusiness
    {
        #region Function
        /// <summary>
        /// Create SqlSugarClient
        /// </summary>
        /// <returns></returns>
        protected SqlSugarClient GetInstance()
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
    }
}
