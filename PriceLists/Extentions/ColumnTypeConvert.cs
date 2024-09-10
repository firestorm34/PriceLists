using PriceLists.Data;
using PriceLists.Models;

namespace PriceLists.Extentions
{
    public class ColumnTypeConvert
    {


        static public ConversionResult TryConvertFromStringToInt(string value)
        {
            try
            {
                int result = Convert.ToInt32(value);

                if (result != 0)
                {

                    return new ConversionResult(value);

                }
                return new ConversionResult(false);
            }

            catch (Exception e)
            {

               return MapExceptionConversionResult(e);
            }
        }

        static public ConversionResult TryConvertFromStringToDateTime(string value)
        {
            try
            {
                DateTime result = Convert.ToDateTime(value);

                if (result != DateTime.MinValue)
                {

                    return new ConversionResult(value);

                }
                return new ConversionResult(false);
            }

            catch (Exception e)
            {

                return MapExceptionConversionResult(e);
            }
        }

        public static ConversionResult TryConvertFromStringToFloat(string value)
        {
            try
            {
                double result = Convert.ToDouble(value);

                if (result != 0.0)
                {

                    return new ConversionResult(value);

                }
                return new ConversionResult(false);
            }

            catch (Exception e)
            {

                return MapExceptionConversionResult(e);
            }



        }




        public delegate (bool, object?) ConversionDelegate(string value, out object? colValue);

        


        public static Dictionary<ColumnDataType, Func<string, ConversionResult>> ColumnTypeConversions = new()
        {
            [ColumnDataType.Float] = TryConvertFromStringToFloat,
            [ColumnDataType.Number] = TryConvertFromStringToInt,
            [ColumnDataType.Date] = TryConvertFromStringToDateTime,
            [ColumnDataType.String] = (string value) => new ConversionResult (value)
        };

        static ConversionResult MapExceptionConversionResult(Exception exception)
        {
            switch (exception)
            {
                case OverflowException:
                    return new ConversionResult(false, ConversionFailReason.Overflow);
                case FormatException:
                    return new ConversionResult(false, ConversionFailReason.IncorrectFormat);
                default:
                    return new ConversionResult(false);
            }
        }

    }
}
