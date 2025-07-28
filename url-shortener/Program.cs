using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using url_shortener.Data.Extensions;
using url_shortener.Projection.Queries;
using url_shortener.Requests;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureEfContexts(builder.Configuration)
    .AddRepositories();

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(Assembly.Load("url-shortener.Application"))
    .RegisterServicesFromAssembly(Assembly.Load("url-shortener.Projection"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/shorten", async (CreateShortUrlRequest request, IMediator mediator) => await mediator.Send(request.GetCommand()));

app.MapGet(":shortUrl", async ([FromQuery] string shortUrl, IMediator mediator) =>
await mediator.Send(new GetOriginalUrlQuery(shortUrl)));

app.Run();