using System;
using System.Collections.Generic;
using System.Text;
using Cerberus.Core.DL;
using SqlSugar;

namespace Cerberus.Core.BL
{
    public class ArticleBusiness :BaseBusiness
    {
        /// <summary>
        /// 根据微信ID查询用户
        /// </summary>
        /// <param name="wechatId">微信ID</param>
        /// <returns></returns>
        public List<Article> FindByPage(int page)
        {
            var db = GetInstance();

            int pageIndex = page;
            int pageSize = 3;
            int totalCount = 0;
            var data = db.Queryable<Article>().ToPageList(pageIndex, pageSize, ref totalCount);            
            return data;
        }
    }
}
