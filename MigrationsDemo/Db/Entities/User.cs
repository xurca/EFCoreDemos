namespace MigrationsDemo.Db.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Role { get; set; }
    }
}