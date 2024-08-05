using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace PriceLists.Models
{
    public class PriceList
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        DbSet<Column> Columns;
        DbSet<Product> Products;

    }
}
