

using PriceLists.Data.Repositories;
using PriceLists.Models;

namespace PriceLists.Data
{
    public class UnitOfWork
    {

        private readonly ApplicationContext context;
        private readonly ProductRepository productRepository;
        private readonly ColumnRepository columnRepository;
        private readonly PriceListRepository priceListRepository;
        private readonly ProductColumnValueRepository productColumnValueRepository;

        
       public  ProductRepository ProductRepository { get => productRepository==null? new(context): productRepository ; }
       public ColumnRepository ColumnRepository { get => columnRepository == null ? new(context) : columnRepository;  }
       public PriceListRepository PriceListRepository { get => priceListRepository == null ? new(context) : priceListRepository;  }
       public ProductColumnValueRepository ProductColumnValueRepository { get => productColumnValueRepository == null 
                                                                            ? new(context) : productColumnValueRepository; }
        public UnitOfWork(ApplicationContext context)
        {
            this.context = context;
        }



        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
