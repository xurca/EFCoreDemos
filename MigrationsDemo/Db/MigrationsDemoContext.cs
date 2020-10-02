using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Logging;
using MigrationsDemo.Db.Common;
using MigrationsDemo.Db.Entities;
using MigrationsDemo.Db.Entities.ValueObject;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;

namespace MigrationsDemo.Db
{
    public class MigrationsDemoContext : DbContext
    {
        ILoggerFactory logger = LoggerFactory.Create(x =>
        {
            x.AddDebug();
            x.AddConsole();
        });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(logger)
                .UseSqlServer("server=.;database=MigrationsDemo;integrated security=true;");
            //.UseSqlServer("server=.;database=MigrationsDemo;Trusted_Connection=true;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contractor>()
                .OwnsOne(x => x.Finance);

            modelBuilder.Entity<Contractor>()
                .OwnsOne(x => x.Legal, b => b.ToTable("LegalAddresses"))
                .OwnsOne(x => x.Physical, b => b.ToTable("PhysicalAddresses"));

            modelBuilder.Entity<Warehouse>()
                .OwnsMany(x => x.Addresses)
                .ToTable("WarehouseAddresses");

            modelBuilder.Entity<Product>()
                .HasDiscriminator(x => x.Type)
                .HasValue<Service>(ProductType.Service)
                .HasValue<Material>(ProductType.Material);

            modelBuilder.Entity<Product>().Property(x => x.Type)
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);

            modelBuilder.Entity<Employee>()
                .HasOne(x => x.User).WithOne().HasForeignKey<User>(x => x.Id);

            modelBuilder.Entity<Employee>()
                .Ignore(x => x.ContactInfo);

            modelBuilder.Entity<Employee>()
                .Property<string>("ContactInfoJson");

            modelBuilder.Entity<Employee>()
                .Property(x => x.Phone)
                .HasField("_phone")
                .UsePropertyAccessMode(PropertyAccessMode.Field);

            modelBuilder.Entity<Employee>()
                .Property(x => x.Address)
                .HasMaxLength(800)
                .HasConversion(
                    obj => JsonConvert.SerializeObject(obj),
                    val => JsonConvert.DeserializeObject<Address>(val));

            modelBuilder.Entity<Employee>()
                .Property<DateTime>("CreatedOn")
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Employee>()
                .Property(x => x.FullName)
                .HasComputedColumnSql("[FirstName] + N' ' + [LastName]");

            modelBuilder.Entity<Employee>()
                .ToTable("Employees");

            modelBuilder.Entity<User>()
                .ToTable("Employees");

            ConfigureDeletedQueryFilterTypes(modelBuilder);

            modelBuilder.HasDbFunction(() => GetAverage(default(int))).HasSchema("dbo");

            base.OnModelCreating(modelBuilder);
        }

        public void ConfigureDeletedQueryFilterTypes(ModelBuilder builder)
        {
            var types = builder.Model.GetEntityTypes().Select(x => x.ClrType)
                .Where(x => typeof(IDeletedQueryFilter).IsAssignableFrom(x))
                .Where(x => x.BaseType == null || x.BaseType.Name == nameof(BaseEntity));

            foreach (var type in types)
            {
                var property = type.GetProperties().Where(x => x.Name == "Deleted").FirstOrDefault();

                var param = Expression.Parameter(type, "x");

                var constant = Expression.Constant(false, typeof(bool));

                var filter = Expression.Lambda(Expression.Equal(Expression.Property(param, property), constant), param);

                builder.Entity(type).HasQueryFilter(filter);
            }
        }

        public static decimal? GetAverage(int id)
        {
            throw new NotImplementedException("Must be db function!");
        }
    }
}
