using System.ComponentModel.DataAnnotations;

namespace MigrationsDemo.Db.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
