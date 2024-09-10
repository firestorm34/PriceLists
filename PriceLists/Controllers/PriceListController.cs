using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PriceLists.Data;
using PriceLists.Extentions;
using PriceLists.Models;
using PriceLists.Models.ViewModels;
using PriceLists.Services;
using System.Diagnostics;


namespace PriceLists.Controllers
{
    [Controller]
    public class PriceListController : Controller
    {
        private UnitOfWork unit;
        PriceListServices priceListServices;
        ProductServices productServices;
        ColumnServices columnServices;
        public PriceListController(UnitOfWork unitOfWork, PriceListServices priceListServices,
            ProductServices productServices,ColumnServices columnServices)
        {
            this.unit = unitOfWork;
            this.columnServices = columnServices;
            this.priceListServices = priceListServices;
            this.productServices = productServices;
        }

        public IActionResult Index(int pageSize = 10, int pageNumber = 1)
        {
            PageResult<PriceList> priceLists = priceListServices.GetBatch(pageSize, pageNumber);
            return View(priceLists);
        }


        [HttpGet("get/{priceListId}")]
        public async Task<IActionResult> Get (int priceListId)
        {
            PriceListViewModel viewModel = await priceListServices.GetWithColumns(priceListId);

            return View(viewModel);
        }

        [HttpGet("add")]

        public async Task<IActionResult> Add()
        {
            CreatePriceListViewModel viewModel = new();

            return View(viewModel);
        }

        [HttpPost("add")]

        public async Task<IActionResult> Add(CreatePriceListViewModel viewModel)
        {


            if (!ModelState.IsValid) {

                return View(viewModel);
            }

    

            PriceList? createdPriceList = await priceListServices.Create(new PriceList { Id = viewModel.Id, Name = viewModel.Name });
            if(createdPriceList != null) { 
                foreach ((ColumnDataType type, string name) in viewModel.ColumnTypes.Zip(viewModel.ColumnNames))
                {

                    Column column = new Column { Name = name, Type = type, PriceListId = createdPriceList.Id };
                    columnServices.Add(column);
                }
                await unit.SaveAsync();

            }
            return View("Index");
        }


        
    }
}