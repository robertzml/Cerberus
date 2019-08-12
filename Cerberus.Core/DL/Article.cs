using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Cerberus.Core.DL
{
    [SugarTable("article")]
    public class Article
    {
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [SugarColumn(ColumnName = "title")]
        public string Title { get; set; }

        [SugarColumn(ColumnName = "sub_title")]
        public string SubTitle { get; set; }

        [SugarColumn(ColumnName = "url")]
        public string Url { get; set; }

        [SugarColumn(ColumnName = "img")]
        public string Img { get; set; }
    }
}
