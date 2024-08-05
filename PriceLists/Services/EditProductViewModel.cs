using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PriceLists.Models {


    public class CreateProductViewModel
    {
        public int Id { get; set; }
        public int PriceListId { get; set; }
        public IEnumerable<Column> Columns { get; set; } = new List<Column>();
        [Required]
        public List<string> Values { get; set; } = new List<string>();
    }
    public class ProductViewModel
    {
        public int Id { get; set; }
        public List<dynamic> Values { get; set; }
    }
}