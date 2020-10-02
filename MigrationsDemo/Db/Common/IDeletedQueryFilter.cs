using System;
using System.Collections.Generic;
using System.Text;

namespace MigrationsDemo.Db.Common
{
    public interface IDeletedQueryFilter
    {
        public bool Deleted { get; set; }
    }
}
