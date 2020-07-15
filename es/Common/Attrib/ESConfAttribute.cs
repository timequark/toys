using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Common.Attrib
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class ESConfAttribute : Attribute
    {
        public string esTag { get; set; }
        public string indexName { get; set; }
        public string typeName { get; set; }
    }
}
