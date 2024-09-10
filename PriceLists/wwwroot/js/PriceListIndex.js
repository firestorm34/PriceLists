

const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7027/pricelisthub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

var currentPageNumber = 1;
var totalNumberOfPages = 0;
var pageSize = 10;

async function start() {
    try {
        await connection.start();
        connection.invoke("GetPriceListPage", pageSize, currentPageNumber);
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
    finally {
    }
};

async function onPrevPageClick() {

    connection.invoke("GetPriceListPage", pageSize, currentPageNumber-1);
    
    //FETCH
    // var response = await fetch('/page', {
    //    method: 'Post',
    //    headers: {
    //        'Content-Type': 'application/json;charset=utf-8'
    //    },
    //    body: JSON.stringify({
    //        "connectionId": connectionId,
    //         "pageSize": pageSize,
    //        "pageNumber": currentPageNumber,
           
            
    //        })
    //});
}


function onNextPageClick ()  {
    connection.invoke("GetPriceListPage", pageSize, currentPageNumber+1);
}


function checkBtnAppearance() {
    if (currentPageNumber < 1 ) {
        document.getElementById("pageBtnBlock").style["display"] = "none";
    }
    else {
        document.getElementById("pageBtnBlock").style["display"] = "block";


        if (currentPageNumber > 1) {
            document.getElementById("prevPageBtn").style["display"] = "block";
        }
        else {
            document.getElementById("prevPageBtn").style["display"] = "none";

        }

        if (currentPageNumber < totalNumberOfPages) {
            document.getElementById("nextPageBtn").style["display"] = "block";
        }
        else {
            document.getElementById("nextPageBtn").style["display"] = "none";

        }
    }
}


function onDeleteBtnClick(priceListId) {
    connection.invoke("DeletePriceList", priceListId, pageSize, currentPageNumber);
    removeRowById(productId);
}

connection.on("ReceivePriceListPage", (priceListsPage) => {
   
    currentPageNumber = priceListsPage.pageNumber;
    totalNumberOfPages = priceListsPage.totalNumberOfPages;
    checkBtnAppearance();
    priceLists = priceListsPage.values;
    if (priceLists != null && priceLists != undefined) {
       
        let tableBody = document.getElementById("table-body");
        tableBody.innerHTML = "";
        priceLists.forEach((priceList) => {
            let row = document.createElement("tr");

            let idCell = document.createElement("td");
            idCell.textContent = priceList.id;
            row.appendChild(idCell);

            let nameCell = document.createElement("td");
            nameCell.textContent = priceList.name;
            row.appendChild(nameCell);


            //let deleteBtn = document.createElement("a");
            //deleteBtn.classList = "btn btn-danger";
            //deleteBtn.addEventListener()
            //deleteBtn.textContent = "Delete";


            let viewBtn = document.createElement("a");
            viewBtn.classList = "btn btn-primary";
            viewBtn.textContent = "View";
            viewBtn.style["marginRight"] = "10px ";
            viewBtn.href = "https://localhost:7027/get/" + priceList.id;


            let actionCell = document.createElement("td");
            actionCell.style["width"] = "150px";

            let deleteBtn = document.createElement("span");
            deleteBtn.innerHTML = "<a  class='btn btn-danger'  onclick=onDeleteBtnClick(" + priceList.id + ")> Delete</a>";
            actionCell.appendChild(viewBtn);
            actionCell.appendChild(deleteBtn);
            row.appendChild(actionCell);
            tableBody.appendChild(row);
        })
    }
});

connection.onclose(async () => {
    await start();
});


start();
