using assignment_Dataaccess.Models;
using assignment_Dataaccess.Models.Enities;
using Microsoft.EntityFrameworkCore;

namespace assignment_Dataaccess.Models
{
    public class SqlContext :DbContext
    {

        public SqlContext()
        {

        }
        public SqlContext(DbContextOptions<SqlContext> _options) : base (_options)
        {

        }


        //Entitys = to become table in Sql server
        public virtual DbSet<AddressEntity> Addresses { get; set; } = null!;
        public virtual DbSet<CategorysEntity> Categorys { get; set; } = null!;
        public virtual DbSet<CustomerEntity> Customers { get; set; } = null!;
        public virtual DbSet<OrderEntity> Orders { get; set; } = null!;
        public virtual DbSet<OrderItemsEntity> OrderItems { get; set; } = null!;
        public virtual DbSet<PriceListEntity> PriceLists { get; set; } = null!;
        public virtual DbSet<ProductsEntity> Products { get; set; } = null!;
        public virtual DbSet<VendorsEntity> Vendors { get; set; } = null!;
        public DbSet<assignment_Dataaccess.Models.Products> Product { get; set; }







    }
}
