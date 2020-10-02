using MigrationsDemo.Db.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MigrationsDemo.Db.Entities
{
    public abstract class Product : BaseEntity, IDeletedQueryFilter
    {
        public string Name { get; set; }
        public ProductType Type { get; set; }
        public decimal Price { get; set; }
        public bool Deleted { get; set; }
    }
}
