using MigrationsDemo.Db;
using MigrationsDemo.Db.Entities;
using System;
using System.Linq;

namespace MigrationsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MigrationsDemoContext())
            {
                db.Set<Product>()
                    .Select(x => MigrationsDemoContext.GetAverage(x.Id))
                    .ToList();
            }

            Console.WriteLine("Hello World!");
        }
    }
}
