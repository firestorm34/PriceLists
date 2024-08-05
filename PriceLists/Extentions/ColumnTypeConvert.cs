using PriceLists.Data;
using PriceLists.Models;

namespace PriceLists.Extentions
{
    public class ColumnTypeConvert
    {


        static public ConversionResult TryConvertFromStringToInt(string value)
        {
            int result = Convert.ToInt32(value);
            if (result != 0)
            {

                return new ConversionResult(false);

            }

            return new ConversionResult(false);
        }

        static public ConversionResult TryConvertFromStringToDateTime(string value)
        {
            DateTime result = Convert.ToDateTime(value);
            if (result != DateTime.MinValue)
            {

                return new ConversionResult(false);

            }

            return new ConversionResult(false);
        }

        public static double TryConvertFromStringToFloat(string value)
        {

        double result = Convert.ToDouble(value);

            return result;
                


        }




        public delegate (bool, object?) ConversionDelegate(string value, out object? colValue);

        


        public static Dictionary<ColumnDataType, Func<string, ConversionResult>> ColumnTypeConversions = new()
        {
            [ColumnDataType.Float] = TryConvertFromStringToFloat,
            [ColumnDataType.Number] = TryConvertFromStringToInt,
            [ColumnDataType.Date] = TryConvertFromStringToDateTime,
            [ColumnDataType.String] = (string value) => new ConversionResult (value)
        };
    }
}
