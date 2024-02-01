using VendingMachine_Approval_Kata;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

string selectedProduct = null;
var stock = new Dictionary<string, int> { { "Chips", 10 }, { "Candy", 10 }, { "Cola", 10 } };

var machine = new VendingMachine(selectedProduct, stock);

app.MapGet("/stock", () => machine.Stock)
    .WithName("GetStock")
    .WithOpenApi();

app.MapPut("/stock/{name}", (string name, int quantity) => machine.UpdateStock(name, quantity))
    .WithName("UpdateStock")
    .WithOpenApi();

app.MapGet("/bank", () => machine.Bank)
    .WithName("GetBankedCoins")
    .WithOpenApi();

app.MapGet("/coins", () => machine.Coins)
    .WithName("GetInsertedCoins")
    .WithOpenApi();

app.MapPost("/coins", (int coin) =>
    {
        machine.InsertCoin(coin);
        machine.Tick();
    })
    .WithName("InsertCoin")
    .WithOpenApi();

app.MapGet("/returns", () => machine.Returns)
    .WithName("GetReturnedCoins")
    .WithOpenApi();

app.MapGet("/display", () => machine.Display)
    .WithName("GetDisplay")
    .WithOpenApi();

app.MapGet("/dispenser", () => machine.DispensedProduct)
    .WithName("GetDispenserContents")
    .WithOpenApi();

app.MapPost("/selectProduct", (string product) =>
    {
        machine.SelectProduct(product);
        machine.Tick();
    })
    .WithName("SelectProduct")
    .WithOpenApi();

app.MapPost("/tick", (string product) => machine.Tick())
    .WithName("Tick")
    .WithOpenApi();

app.Run();