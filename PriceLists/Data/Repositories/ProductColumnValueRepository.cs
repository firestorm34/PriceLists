
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

        public ProductColumnValue? GetForProductColumn (int productId, Column column)
        {
            var res = context.ProductColumnValues;
                
                var res2= res.FirstOrDefault((value) => 
                (value.ColumnId == column.Id) && (value.ProductId == productId) 
            ) ;

            return res2;

            
        }

    }
}
