using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using AngularAsyncValidator.Api.Models;
using AngularAsyncValidator.Api.Core;
using AngularAsyncValidator.Api.Interfaces;

namespace AngularAsyncValidator.Api.Features
{
    public class RemoveProfile
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
                var profile = await _context.Profiles.SingleAsync(x => x.ProfileId == request.ProfileId);
                
                _context.Profiles.Remove(profile);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Profile = profile.ToDto()
                };
            }
            
        }
    }
}
