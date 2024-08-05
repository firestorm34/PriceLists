using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace PriceLists.Models
{
    public class Column
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]

        public int PriceListId { get; set; }
        public ColumnDataType Type { get; set; }

        public PriceList PriceList { get; set; }



    }
    
   

    public enum ColumnDataType
    {
        Number,
        Float,
        String,
        Date
        

    }




  
}