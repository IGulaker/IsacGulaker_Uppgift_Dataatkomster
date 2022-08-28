using IsacGulaker_Uppgift_Dataatkomster.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace IsacGulaker_Uppgift_Dataatkomster.Data
{
    public class DataContext : DbContext
    {
        public virtual DbSet<UserEntity> Users { get; set; } = null!;
        public virtual DbSet<AddressEntity> Addresses { get; set; } = null!;
        public virtual DbSet<ProductEntity> Products { get; set; } = null!;
        public virtual DbSet<CategoryEntity> Categories { get; set; } = null!;
        public virtual DbSet<SubcategoryEntity> Subcategories { get; set; } = null!;
        public virtual DbSet<ManufacturerEntity> Manufacturers { get; set; } = null!;
        public virtual DbSet<OrderEntity> Orders { get; set; } = null!;

        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
