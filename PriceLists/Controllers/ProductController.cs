using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PriceLists.Data;
using PriceLists.Extentions;
using PriceLists.Models;
using PriceLists.Models.ViewModels;
using PriceLists.Services;
using PriceLists.Extentions;
using Newtonsoft.Json.Linq;

namespace PriceLists.Controllers
{
    public class ProductController : Controller
    {

        private UnitOfWork unit;
        ProductServices productServices;
        ColumnServices columnServices;

        public ProductController(UnitOfWork unitOfWork, PriceListServices priceListServices,
            ProductServices productServices, ColumnServices columnServices)
        {
            this.unit = unitOfWork;
            this.productServices = productServices;
            this.columnServices = columnServices;
        }


        [HttpGet("product/add")]
        public IActionResult Add(int priceListId)
        {
            var columns = unit.ColumnRepository.GetForPriceList(priceListId).ToList();

            CreateProductViewModel model = new CreateProductViewModel() { PriceListId = priceListId, Columns = columns };
            return View(model);
        }

        [HttpPost("product/add")]
        public async Task<IActionResult> Add(CreateProductViewModel productModel)
        {
            if (!ModelState.IsValid)
            {
                return View(productModel);
            }
            var c = typeof(int);
            Product product = new Product { PriceListId = productModel.PriceListId };
            Product productEntity = await unit.ProductRepository.AddAsync(product);
            await unit.SaveAsync();
            foreach (var (column, columnValue) in productModel.Columns.Zip(productModel.Values))
            {
              
                if (result.HasSucceeded)
                {
                    switch (column.Type)
                    {
                        case ColumnDataType.Number: await columnServices.AddNumberColumnAsync(result.va),
                    }
                }

            }
            return RedirectToAction("Index", "PriceList");
        }



}
}
