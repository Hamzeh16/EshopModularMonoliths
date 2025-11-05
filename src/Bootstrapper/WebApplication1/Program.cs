


var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, config) => 
    config.ReadFrom.Configuration(context.Configuration));

// Add Services to the container.

// comman services : carter , mdiatr , fluntvalidation
var catalogAssembly = typeof(CatalogModule).Assembly;
var basketAssembly = typeof(BasketModule).Assembly;

builder.Services
    .AddCarterWithAssemblies(
   catalogAssembly, basketAssembly);

builder.Services
    .AddMediatRWithAssemblies(basketAssembly, catalogAssembly);

// Appliction Use Case services
//builder.Services.AddMediatR(config =>
//{
//    config.RegisterServicesFromAssemblies(catalogAssembly, basketAssembly);
//    config.AddOpenBehavior(typeof(ValidtionBehavires<,>));
//    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
//});

//builder.Services.AddValidatorsFromAssemblies([catalogAssembly, basketAssembly]);


builder.Services
    .AddCatalogModule(builder.Configuration)
    .AddBasketModule(builder.Configuration)
    .AddOrderingModule(builder.Configuration);

builder.Services
    .AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

// Congigure the HTTP request pipline.

app.MapCarter();
app.UseSerilogRequestLogging();
app.UseExceptionHandler(options => { });

app
    .UseCatalogModule()
    .UseBasketModule()
    .UseOrderingModule();

app.Run();
