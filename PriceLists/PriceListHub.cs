using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PriceLists.Data;
using PriceLists.Extentions;
using PriceLists.Models;
using PriceLists.Services;
using System.Drawing.Printing;

public class PriceListHub : Hub
{
    private UnitOfWork unit;
    PriceListServices priceListServices;
    ProductServices productServices;
    public PriceListHub(UnitOfWork unitOfWork, PriceListServices priceListServices,
            ProductServices productServices)
    {
        this.unit = unitOfWork;
        this.priceListServices = priceListServices;
        this.productServices = productServices;
    }


    public async Task GetPriceListPage(int pageSize = 10, int pageNumber=1)
    {
        PageResult<PriceList> priceLists = priceListServices.GetBatch(pageSize, pageNumber);
        await Clients.Client(Context.ConnectionId).SendAsync("ReceivePriceListPage", priceLists);
    }

    public async Task GetProductPage(int pageSize = 10, int pageNumber = 1)
    {
        PageResult<ProductViewModel> productViewModels = await productServices.GetViewModelBatch(pageSize, pageNumber);
        await Clients.Client(Context.ConnectionId).SendAsync("ReceiveProductPage",productViewModels );
    }

    public async Task DeleteProduct(int productId, int pageSize = 10, int pageNumber=1)
    {
        await productServices.Delete(productId);
        await unit.SaveAsync();
        PageResult<Product> products = productServices.GetBatch(pageSize, pageNumber);
        await Clients.Client(Context.ConnectionId).SendAsync("ReceiveProductPage", products);
    }

}