using MigrationsDemo.Db.Entities.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace MigrationsDemo.Db.Entities
{
    public class Contractor : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string IdNumber { get; set; }
        public Financial Finance { get; set; }
        public Address Legal { get; set; }
        public Address Physical { get; set; }
    }
}
