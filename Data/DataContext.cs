using Examination_WebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Examination_WebApi.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public virtual DbSet<UserEntity> Users { get; set; } = null!;
        public virtual DbSet<AddressEntity> Addresses { get; set; } = null!;
        public virtual DbSet<ProductEntity> Products { get; set; } = null!;
        public virtual DbSet<CategoryEntity> Categories { get; set; } = null!;
        public virtual DbSet<InventoryEntity> Inventories { get; set; } = null!;
        //public virtual DbSet<OrderEntity> Orders { get; set; } = null!;
        //public virtual DbSet<OrderedProductEntity> OrderedProducts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("LocalSql"));
            }
        }
    }
}
