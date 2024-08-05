

const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7027/pricelisthub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

var currentPageNumber = 1;
var totalNumberOfPages = 0;
var pageSize = 4;

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
    finally {
        connection.invoke("GetProductPage", pageSize, currentPageNumber);
    }
};

async function onPrevPageClick() {

    connection.invoke("GetProductPage", pageSize, currentPageNumber - 1);


}


function onNextPageClick() {
    connection.invoke("GetProductPage", pageSize, currentPageNumber + 1);
}


function checkBtnAppearance() {
    if (currentPageNumber < 1) {
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

connection.on("ReceiveProductPage", (ProductsPage) => {

    currentPageNumber = ProductsPage.pageNumber;
    totalNumberOfPages = ProductsPage.totalNumberOfPages;
    checkBtnAppearance();
    var products = ProductsPage.values;
    if (products != null && products != undefined) {
        let tableBody = document.getElementById("table-body");
        tableBody.innerHTML = "";
        products.forEach((product) => {
            let row = document.createElement("tr");

            let idCell = document.createElement("td");
            idCell.textContent = product.id;
            row.appendChild(idCell);

            product.values.forEach(value => {
                let nameCell = document.createElement("td");
                if (value == null) {
                    nameCell.textContent = "null";
                }
                else { 
                    nameCell.textContent = value;
                }
                row.appendChild(nameCell);
            })

            tableBody.appendChild(row);
        })
    }
});

connection.onclose(async () => {
    await start();
});


start();
