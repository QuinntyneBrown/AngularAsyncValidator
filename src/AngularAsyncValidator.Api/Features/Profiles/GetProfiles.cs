using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using AngularAsyncValidator.Api.Core;
using AngularAsyncValidator.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AngularAsyncValidator.Api.Features
{
    public class GetProfiles
    {
        public class Request : IRequest<Response> { }

        public class Response : ResponseBase
        {
            public List<ProfileDto> Profiles { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IAngularAsyncValidatorDbContext _context;

            public Handler(IAngularAsyncValidatorDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new()
                {
                    Profiles = await _context.Profiles.Select(x => x.ToDto()).ToListAsync()
                };
            }

        }
    }
}
