using PriceLists.Models;

namespace PriceLists.Data.Repositories
{
    public class ColumnRepository: GenericRepository<Column>
    {
        ApplicationContext context;
        public ColumnRepository(ApplicationContext context) : base(context)
        {
            this.context = context;
        }

        public  List<Column> GetForPriceList (int priceListId)
        {
            return  context.Columns.
                Where(column => column.PriceListId == priceListId).ToList();

        }


    }
}
