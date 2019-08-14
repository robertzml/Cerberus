using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Cerberus.Core.DL
{
    /// <summary>
    /// 用户类
    /// </summary>
    [SugarTable("person")]
    public class Person
    {
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true)]
        public string Id { get; set; }

        /// <summary>
        /// 微信openid
        /// </summary>
        [SugarColumn(ColumnName = "wechat_id")]
        public string WechatId { get; set; }

        /// <summary>
        /// 微信号
        /// </summary>
        [SugarColumn(ColumnName = "wechat_number")]
        public string WechatNumber { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [SugarColumn(ColumnName = "name")]
        public string Name { get; set; }               

        /// <summary>
        /// 昵称
        /// </summary>
        [SugarColumn(ColumnName = "nick_name")]
        public string NickName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [SugarColumn(ColumnName = "gender")]
        public short Gender { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        [SugarColumn(ColumnName = "birthday")]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 八字
        /// </summary>
        [SugarColumn(ColumnName = "horoscope")]
        public string Horoscope { get; set; }

        /// <summary>
        /// 修改次数
        /// </summary>
        [SugarColumn(ColumnName = "modify_count")]
        public int ModifyCount { get; set; }
    }
}
