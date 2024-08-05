namespace PriceLists.Models
{


        public class ConversionResult
        {
            public ConversionResult(object? value)
            {
                this.Value = value;
                this.HasSucceeded = true;
            }

            public ConversionResult(bool hasSucceded, ConversionFailReason reason = ConversionFailReason.Unknown)
            {

            }
            public bool HasSucceeded { get; }
            public object? Value { get; }
            public ConversionFailReason FailReason { get; }
        }


        public enum ConversionFailReason
        {
            Overflow,
            IncorrectFormat,
            Unknown
        }
    
}
