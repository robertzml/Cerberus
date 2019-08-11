using System;
using System.Collections.Generic;
using System.Text;

namespace Cerberus.Core.Utility
{
    /// <summary>
    /// 配置类
    /// </summary>
    public class ConfigData
    {
        public int TotalUsers { get; set; }

        public int AlreadyFound { get; set; }

        public int FortuneBuddy { get; set; }

        public bool ShowTotalUsers { get; set; }

        public bool ShowAlreadyFound { get; set; }

        public bool ShowFortuneBuddy { get; set; }
    }
}
