using MigrationsDemo.Db.Entities.ValueObject;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MigrationsDemo.Db.Entities
{
    public class Employee : BaseEntity
    {
        private string _phone;

        private string ContactInfoJson;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Code { get; set; }
        public string IdNumber { get; set; }

        public string FullName { get; private set; }

        public User User { get; set; }

        public string Phone
        {
            get
            {
                return _phone.StartsWith("+995") ? _phone : $"+995{_phone}";
            }
            set
            {
                _phone = value;
            }
        }

        public Address Address { get; set; }

        public ContactInfo ContactInfo
        {
            get
            {
                return JsonConvert.DeserializeObject<ContactInfo>(ContactInfoJson);
            }
            set
            {
                ContactInfoJson = JsonConvert.SerializeObject(value);
            }
        }
    }
}
