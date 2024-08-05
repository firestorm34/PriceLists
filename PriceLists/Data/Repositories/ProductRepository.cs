using PriceLists.Models;


namespace PriceLists.Data.Repositories
{
    public class ProductRepository: GenericRepository<Product>
    {
        ApplicationContext context;

        public ProductRepository(ApplicationContext context) : base(context)
        {
            this.context = context;
        }

        public int Count() { 
            return context.Products.Count(); 
        }

        public IQueryable<Product> GetBatch(int productsToSkip, int productsToTake)
        {
            return context.Products.Skip(productsToSkip).Take(productsToTake);
        }
    }
}
