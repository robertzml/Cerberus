using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cerberus.API.Utility
{
    /// <summary>
    /// 响应数据
    /// </summary>
    public class ResponseData
    {
        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }
    }
}
