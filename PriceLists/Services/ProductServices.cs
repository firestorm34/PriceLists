﻿using PriceLists.Data;
using PriceLists.Extentions;
using PriceLists.Models.ViewModels;
using PriceLists.Models;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace PriceLists.Services
{
    public class ProductServices
    {

        private UnitOfWork unitOfWork;
        public ProductServices(UnitOfWork UnitOfWork)
        {
            this.unitOfWork = UnitOfWork;
        }
        public PageResult<Product> GetBatch(int pageSize, int pageNumber)
        {

            IQueryable<Product> products = unitOfWork.ProductRepository.GetBatch(pageSize * (pageNumber - 1), pageSize);
            int productAmount = unitOfWork.ProductRepository.Count();
            return PageResultExtention.
            CreatePageResult<Product>(products, pageNumber, pageSize, productAmount);

        }
        public async Task Delete(int productId)
        {
            await unitOfWork.ProductRepository.DeleteAsync(productId);

        }

        public async Task<PageResult<ProductViewModel>> GetViewModelBatch(int pageSize, int pageNumber)
        {

            List<Product> products = await unitOfWork.ProductRepository.GetBatch(pageSize * (pageNumber - 1), pageSize).ToListAsync();
            int productAmount = unitOfWork.ProductRepository.Count();
            List<ProductViewModel> productViewModelList = new ();
            foreach(Product product in products)
            {
                ProductViewModel viewModel = await GetViewModel(product.Id);
                productViewModelList.Add(viewModel);
            }
            return PageResultExtention.CreatePageResult<ProductViewModel>(productViewModelList, pageNumber, pageSize, productAmount);
        }

        public async Task<ProductViewModel> GetViewModel(int productId)
        {

            Product? product = await unitOfWork.ProductRepository.GetAsync(productId);
            if (product != null)
            {


                //List<Column> productColumns = unitOfWork.ColumnRepository.GetForPriceList(product.PriceListId).ToList();
                Column productColumn = await unitOfWork.ColumnRepository.GetAsync(1);
                List<dynamic> productColumnValues = new();

                
                    var value = await unitOfWork.ProductColumnValueRepository.GetForProductColumn(1, productColumn);
                    
                    productColumnValues.Add(value.GetValue());
                
                ProductViewModel viewModel = new()
                {
                    Id = product.Id,
                    Values = productColumnValues
                };
                return viewModel;

            }
            else
            {
                return null;
            }
        }



    }
}