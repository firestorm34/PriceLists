using System.ComponentModel.DataAnnotations;

namespace PriceLists.Models.ViewModels
{
    public class PriceListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IQueryable<Column> Columns { get; set; }

    }

    public class CreatePriceListViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<string> ColumnNames { get; set; } = new();
        [Required]
        public List<ColumnDataType> ColumnTypes { get; set; } = new();

    }
}
