using PriceLists.Data;
using PriceLists.Extentions;
using PriceLists.Models.ViewModels;
using PriceLists.Models;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PriceLists.Services
{
    public class ColumnServices
    {

        private UnitOfWork unitOfWork;
        public ColumnServices(UnitOfWork UnitOfWork)
        {
            unitOfWork = UnitOfWork;
        }
        public async Task DeleteAsync(int ColumnId)
        {
            await unitOfWork.ColumnRepository.DeleteAsync(ColumnId);

        }


        public async Task<CreationResult> TryAddColumnValueAsync(Column column, string inputValue, int productId)
        {
            Func<string, ConversionResult> conversionMethod = ColumnTypeConvert.ColumnTypeConversions[column.Type];
            conversionMethod(inputValue);
        }

       

        public  async Task<ProductColumnValue?> AddStringColumnAsync (int columnId, int productId, string value) {
            return await unitOfWork.ProductColumnValueRepository.AddAsync(
                new StringProductColumnValue { ColumnId = columnId, ProductId = productId, StringValue = value });
        }


        public async Task<ProductColumnValue?> AddDateColumnAsync(int columnId, int productId, DateTime value)
        {
            return await unitOfWork.ProductColumnValueRepository.AddAsync(
                new DateProductColumnValue { ColumnId = columnId, ProductId = productId, DateValue = value });
        }


        public async Task<ProductColumnValue?> AddNumberColumnAsync(int columnId, int productId, int value)
        {
            return await unitOfWork.ProductColumnValueRepository.AddAsync(
                new NumberProductColumnValue { ColumnId = columnId, ProductId = productId, NumberValue = value });
        }


        public async Task<ProductColumnValue?> AddFloatAsync(int columnId, int productId, double value)
        {
            return await unitOfWork.ProductColumnValueRepository.AddAsync(
                new FloatProductColumnValue { ColumnId = columnId, ProductId = productId, FloatValue = value });
        }
    }
}
