using AngularAsyncValidator.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace AngularAsyncValidator.Api.Interfaces
{
    public interface IAngularAsyncValidatorDbContext
    {
        DbSet<Profile> Profiles { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
