using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using url_shortener.Data.Extensions;
using url_shortener.Requests;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureEfContexts(builder.Configuration);

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(Assembly.Load("url-shortener.Application"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/shorten", async (CreateShortUrlRequest request, IMediator mediator) => await mediator.Send(request.GetCommand()));

app.Run();