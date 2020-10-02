using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MigrationsDemo.Db.Entities.ValueObject
{
    public class Financial
    {
        public decimal Balance
        {
            get
            {
                return Credit > 0 ? Credit : Debit;
            }
        }

        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
    }
}
