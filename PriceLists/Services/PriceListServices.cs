using NuGet.Protocol.Core.Types;
using System.Drawing.Printing;
using PriceLists.Models;
using PriceLists.Extentions;
using PriceLists.Data;
using PriceLists.Models.ViewModels;

namespace PriceLists.Services
{
    public class PriceListServices
    {
        private UnitOfWork unitOfWork;
        public PriceListServices(UnitOfWork UnitOfWork)
        {
            this.unitOfWork = UnitOfWork;
        }
        public PageResult<PriceList> GetBatch(int pageSize, int pageNumber) {

            IQueryable<PriceList> priceLists= unitOfWork.PriceListRepository.GetBatch(pageSize * (pageNumber - 1), pageSize);
            int priceListAmount = unitOfWork.PriceListRepository.Count;
            return PageResultExtention.
            CreatePageResult<PriceList>(priceLists, pageNumber, pageSize, priceListAmount);

        }


        public async Task<PriceList?> Create(PriceList priceList)
        {

           
                 PriceList createPricelist = await unitOfWork.PriceListRepository.AddAsync(priceList);
                 await unitOfWork.SaveAsync();
                  return createPricelist;
                
          
        }

        public async Task<PriceListViewModel> GetWithColumns(int priceListId)
        {

            PriceList priceList = await unitOfWork.PriceListRepository.GetAsync(priceListId);
            if(priceList != null) { 
                IQueryable<Column> priceListColumns =  unitOfWork.ColumnRepository.GetForPriceList(priceListId);
                PriceListViewModel viewModel = new() { Id = priceList.Id, Name = priceList.Name, Columns = priceListColumns };
                return viewModel;

            }
            else
            {
                return null;
            }
        }
    }
}
