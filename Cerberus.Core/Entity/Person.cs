using System;
using System.Collections.Generic;
using System.Text;

namespace Cerberus.Core.Entity
{
    public class Person
    {
        public string WechatId { get; set; }

        public string Name { get; set; }

        public short Gender { get; set; }

        public DateTime Birthday { get; set; }
    }
}
