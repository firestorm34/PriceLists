using Microsoft.EntityFrameworkCore;
using PriceLists.Models;
using System.Collections.Generic;
using System.Drawing;

namespace PriceLists.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public  DbSet<PriceList> PriceLists { get; set; }
        public  DbSet<Column> Columns { get; set; }
        public  DbSet<ProductColumnValue> ProductColumnValues {get;set;}
        public  DbSet<StringProductColumnValue> StringProductColumnValues {get;set;}

        public  DbSet<DateProductColumnValue> DateProductColumnValues {get;set;}
        public  DbSet<NumberProductColumnValue> NumberProductColumnValues {get;set;} 
    DbSet<FloatProductColumnValue> FloatProductColumnValues { get; set; }  

     public ApplicationContext(DbContextOptions options): base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductColumnValue>()
           .HasDiscriminator<int>("Type")
           .HasValue<DateProductColumnValue>((int)ColumnDataType.Date)
           .HasValue<NumberProductColumnValue>((int)ColumnDataType.Number)
           .HasValue<FloatProductColumnValue>((int)ColumnDataType.Float)
           .HasValue<StringProductColumnValue>((int)ColumnDataType.String);
        }
    }
}
