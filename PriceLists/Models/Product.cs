using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace PriceLists.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public int PriceListId { get; set; }
        public PriceList PriceList { get;set; }
    }
}
