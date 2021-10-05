using AngularAsyncValidator.Api.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AngularAsyncValidator.Api.Features
{
    public class EmailExists
    {
        public class Request : IRequest<Response> {
            public string Email { get; set; }
        }

        public class Response
        {
            public bool Exists { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IAngularAsyncValidatorDbContext _context;

            public Handler(IAngularAsyncValidatorDbContext context){
                _context = context;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {

                var exists = await _context.Profiles.SingleOrDefaultAsync(x => x.Email == request.Email);

                return new () { 
                    Exists = (await _context.Profiles.SingleOrDefaultAsync(x => x.Email == request.Email)) != null
                };
            }
        }
    }
}
