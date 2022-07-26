using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Contexts
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions options) : base(options)
        {}
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
           var datas= ChangeTracker
                .Entries<BaseEntity>();
            foreach (var data in datas)
            {
                 _ = data.State switch
                {
                    EntityState.Added=>data.Entity.CreatedDate=DateTime.Now,
                    EntityState.Modified=>data.Entity.UpdatedDate=DateTime.Now,
                    _=>DateTime.UtcNow
                };
            }
                

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
