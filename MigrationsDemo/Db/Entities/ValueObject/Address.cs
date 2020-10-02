using System;
using System.Collections.Generic;
using System.Text;

namespace MigrationsDemo.Db.Entities.ValueObject
{
    public class Address //: BaseEntity
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
    }
}
