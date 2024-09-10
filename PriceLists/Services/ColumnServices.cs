using PriceLists.Data;
using PriceLists.Extentions;
using PriceLists.Models.ViewModels;
using PriceLists.Models;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;


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


        public Column? Add(Column column)
        {
             Column columnEntity = unitOfWork.ColumnRepository.Add(column);
            unitOfWork.Save();
            return columnEntity;

        }

        public ProductColumnValue? TryAddColumnValue(Column column, object? inputValue, int productId)
        {

            switch (column.Type)
            {
                case ColumnDataType.Number: 
                    return  AddNumberColumn(column.Id, productId, Convert.ToInt32(inputValue));
                case ColumnDataType.Date:
                    return  AddDateColumn(column.Id, productId, Convert.ToDateTime( inputValue));
                case ColumnDataType.Float:
                    return AddFloatColumn(column.Id, productId, Convert.ToDouble(inputValue));
                case ColumnDataType.String:
                    return  AddStringColumn(column.Id, productId, (string)inputValue);
                default: return null;
            }
        }

       

        public  ProductColumnValue? AddStringColumn (int columnId, int productId, string value) {
            return  unitOfWork.ProductColumnValueRepository.Add(
                new StringProductColumnValue { ColumnId = columnId, ProductId = productId, StringValue = value });
        }


        public  ProductColumnValue? AddDateColumn(int columnId, int productId, DateTime value)
        {
            return  unitOfWork.ProductColumnValueRepository.Add(
                new DateProductColumnValue { ColumnId = columnId, ProductId = productId, DateValue = value });
        }


        public ProductColumnValue? AddNumberColumn(int columnId, int productId, int value)
        {
            return  unitOfWork.ProductColumnValueRepository.Add(
                new NumberProductColumnValue { ColumnId = columnId, ProductId = productId, NumberValue = value });
        }


        public ProductColumnValue? AddFloatColumn(int columnId, int productId, double value)
        {
            return  unitOfWork.ProductColumnValueRepository.Add(
                new FloatProductColumnValue { ColumnId = columnId, ProductId = productId, FloatValue = value });
        }
    }
}
