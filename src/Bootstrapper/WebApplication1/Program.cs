
var builder = WebApplication.CreateBuilder(args);

// Add Services to the container.

builder.Services.AddCarterWithAssemblies
    (typeof(CatalogModule).Assembly);

builder.Services
    .AddCatalogModule(builder.Configuration)
    .AddBasketModule(builder.Configuration)
    .AddOrderingModule(builder.Configuration);



var app = builder.Build();

// Congigure the HTTP request pipline.

app.MapCarter();

app
    .UseCatalogModule()
    .UseBasketModule()
    .UseOrderingModule();


app.Run();
