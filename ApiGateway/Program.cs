using ApiGateway.Policies;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Polly;
using Polly;
using Polly.Extensions.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

builder.Services.AddOcelot(builder.Configuration).
    AddPolly().
    AddDelegatingHandler<PollyHandler>(true);





var app = builder.Build();

await app.UseOcelot();


app.Run();
