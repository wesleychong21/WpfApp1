using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiteDB;

namespace WpfApp1
{
    public class UnsafeRecord
    {
        [BsonId]
        public int Id { get; set; }
        public string Observer { get; set; }
        public string Observee { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public DateTime ReportDate { get; set; }
    }
}
