using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace Cerberus.Core.BL
{
    using Dapper;
    using MySql.Data.MySqlClient;
    using Cerberus.Core.DL;

    /// <summary>
    /// 用户业务类
    /// </summary>
    public class PersonBusiness
    {
        #region Method
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        public List<Person> FindAll()
        {
            using (IDbConnection connecton = new MySqlConnection(CerberusConstant.ConnectionString))
            {
                return connecton.Query<Person>("SELECT id, wechat_id WechatId, name, gender, birthday FROM person").ToList();
            }
        }

        /// <summary>
        /// 根据ID查询用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public Person FindById(string id)
        {
            using (IDbConnection connecton = new MySqlConnection(CerberusConstant.ConnectionString))
            {
                return connecton.Query<Person>("SELECT id, wechat_id WechatId, name, gender, birthday FROM person WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }
        #endregion //Method

        #region CRUD
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="person">用户信息</param>
        /// <returns></returns>
        public bool Create(Person person)
        {
            using (IDbConnection connection = new MySqlConnection(CerberusConstant.ConnectionString))
            {
                int result = connection.Execute("INSERT INTO person(id, wechat_id,name,gender,birthday) VALUES(@Id, @WechatId, @Name, @Gender, @Birthday)", person);
                return result == 1;
            }            
        }
        #endregion //CRUD
    }
}
