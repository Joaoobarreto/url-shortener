using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace url_shortener.Application.UseCases.CreateShortUrl;
public sealed class CreateShortUrlHandler : IRequestHandler<CreateShortUrlCommand, string>
{
    public Task<string> Handle(CreateShortUrlCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult($"https://short.url/{Guid.NewGuid().ToString().Substring(0, 8)}");
    }
}
