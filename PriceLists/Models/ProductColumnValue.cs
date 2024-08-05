using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

namespace PriceLists.Models
{
    public abstract class ProductColumnValue 
    {
        public abstract object GetValue();
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]

        public int ColumnId { get; set; }
        public Column Column { get; set; }
        public Product Product { get; set; }
    }

    public class StringProductColumnValue : ProductColumnValue
    {
        public override object GetValue()
        {
            return StringValue;
        }
        public string StringValue { get; set; }

    }

    public class DateProductColumnValue : ProductColumnValue
    {
        public override object GetValue()
        {
            return DateValue;
        }
        public DateTime DateValue { get; set; }

    }
    public class NumberProductColumnValue : ProductColumnValue
    {
        public override object GetValue()
        {
            return NumberValue;
        }
        public int NumberValue { get; set; }

    }
    public class FloatProductColumnValue : ProductColumnValue
    {
        public override object GetValue()
        {
            return FloatValue;
        }
        public double FloatValue { get; set; }

    }
}
