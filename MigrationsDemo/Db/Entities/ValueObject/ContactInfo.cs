using System;
using System.Collections.Generic;
using System.Text;

namespace MigrationsDemo.Db.Entities.ValueObject
{
    public class ContactInfo
    {
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }

        public ICollection<string> AdditionalContacts { get; set; }
    }
}
