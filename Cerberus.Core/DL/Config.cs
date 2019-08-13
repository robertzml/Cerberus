using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Cerberus.Core.DL
{
    [SugarTable("config")]
    public class Config
    {
        [SugarColumn(ColumnName = "show_total_users")]
        public bool ShowTotalUsers { get; set; }

        [SugarColumn(ColumnName = "show_already_found")]
        public bool ShowAlreadyFound { get; set; }

        [SugarColumn(ColumnName = "show_fortune_buddy")]
        public bool ShowFortuneBuddy { get; set; }

        [SugarColumn(ColumnName = "if_weixin_need")]
        public bool IfWeixinNeed { get; set; }
    }
}
