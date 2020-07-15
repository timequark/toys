using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Common.Entity
{
    public class Pantent
    {
        public string id { get; set; }
        public string patentType { get; set; }
        public string applicationNumber { get; set; }
        public DateTime applicationDate { get; set; }
        public string documentNumber { get; set; }
        public string title { get; set; }
        public string patentStatusId { get; set; }
        public DateTime paymentDeadline { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime expiredDate { get; set; }
        public string summary { get; set; }
        public float price { get; set; }

    }
}
