var builder = WebApplication.CreateBuilder(args);

// Add Services to the container.
builder.Services
    .AddCatalogModule(builder.Configuration)
    .AddBasketModule(builder.Configuration)
    .AddOrderingModule(builder.Configuration);



var app = builder.Build();

// Congigure the HTTP request pipline.
app
    .UseCatalogModule()
    .UseBasketModule()
    .UseOrderingModule();


app.Run();
