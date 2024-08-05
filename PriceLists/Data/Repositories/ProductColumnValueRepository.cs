
using Microsoft.EntityFrameworkCore;
using PriceLists.Models;
namespace PriceLists.Data.Repositories
{
    public class ProductColumnValueRepository: GenericRepository<ProductColumnValue>
    {
        ApplicationContext context;
        public ProductColumnValueRepository(ApplicationContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<ProductColumnValue>? GetForProductColumn (int productId, Column column)
        {
           return await context.ProductColumnValues.FirstAsync((value) => 
                (value.ColumnId == column.Id) && (value.ProductId == productId) 
            ) ;

            
        }

    }
}
