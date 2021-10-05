using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using AngularAsyncValidator.Api.Core;
using AngularAsyncValidator.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AngularAsyncValidator.Api.Features
{
    public class GetProfileById
    {
        public class Request: IRequest<Response>
        {
            public Guid ProfileId { get; set; }
        }

        public class Response: ResponseBase
        {
            public ProfileDto Profile { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IAngularAsyncValidatorDbContext _context;
        
            public Handler(IAngularAsyncValidatorDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    Profile = (await _context.Profiles.SingleOrDefaultAsync(x => x.ProfileId == request.ProfileId)).ToDto()
                };
            }
            
        }
    }
}
