using PriceLists.Models;

namespace PriceLists.Data.Repositories
{
    public class PriceListRepository : GenericRepository<PriceList>
    {
        ApplicationContext context;

        public int Count { get=>context.PriceLists.Count(); }
        public PriceListRepository(ApplicationContext context): base(context)
        {
            this.context = context;
        }

        public IQueryable<PriceList> GetBatch (int priceListsToSkip, int priceListsToTake)
        {
            return  context.PriceLists.Skip(priceListsToSkip).Take(priceListsToTake);
        }


    }
}
