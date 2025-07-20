
using System.Data.Common;

namespace CleanArchitecture.Application
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<DbTransaction> BeginTransactionAsync(CancellationToken  cancellationToken = default);
        ValueTask DisposeAsync();
    }
}
