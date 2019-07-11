﻿using System;
using System.Collections.Generic;
using System.Text;
using Dapper;

namespace Cerberus.Core.DL
{
    /// <summary>
    /// 用户类
    /// </summary>
    public class Person
    {
        public string Id { get; set; }
        
        public string WechatId { get; set; }

        public string Name { get; set; }

        public short Gender { get; set; }

        public DateTime Birthday { get; set; }

        /// <summary>
        /// 八字
        /// </summary>
        public string Horoscope { get; set; }
    }
}
