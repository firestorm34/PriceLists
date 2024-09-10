using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PriceLists.Data;
using PriceLists.Extentions;
using PriceLists.Models;
using PriceLists.Models.ViewModels;
using PriceLists.Services;
using PriceLists.Extentions;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;

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
            productModel.Columns = unit.ColumnRepository.GetForPriceList(productModel.PriceListId);

            if (productModel.Values.Where(value=>value!=null).Count() < 1)
            {
                ModelState.AddModelError("", "You must fill at least one field");

                return View(productModel);

            }
            Product product = new Product { PriceListId = productModel.PriceListId };
            Product productEntity = unit.ProductRepository.Add(product);
            await unit.SaveAsync();
           
            foreach (var (column, columnValue) in productModel.Columns.Zip(productModel.Values))
            {
                Func<string, ConversionResult> conversionMethod = ColumnTypeConvert.ColumnTypeConversions[column.Type];
                ConversionResult result = conversionMethod(columnValue);
                if (result.HasSucceeded)
                {
                    columnServices.TryAddColumnValue(column, result.Value, product.Id);
                   

                }
                else
                {
                    ModelState.AddModelError("", result.FailReason.ToString() + " error has been thrown");
                    return View(productModel);
                }

            }
            return RedirectToAction(nameof(PriceListController.Get), "PriceList", new { priceListId = productModel.PriceListId });
        }



}
}
