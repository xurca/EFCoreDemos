using MigrationsDemo.Db.Entities.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace MigrationsDemo.Db.Entities
{
    public class Warehouse : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
