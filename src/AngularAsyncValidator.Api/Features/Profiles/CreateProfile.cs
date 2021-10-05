using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AngularAsyncValidator.Api.Models;
using AngularAsyncValidator.Api.Core;
using AngularAsyncValidator.Api.Interfaces;

namespace AngularAsyncValidator.Api.Features
{
    public class CreateProfile
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Profile).NotNull();
                RuleFor(request => request.Profile).SetValidator(new ProfileValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public ProfileDto Profile { get; set; }
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
                var profile = new Profile();
                
                _context.Profiles.Add(profile);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Profile = profile.ToDto()
                };
            }
            
        }
    }
}
