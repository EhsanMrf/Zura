namespace Zura.Application.Common.UnitOfWork;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    public Task<Result> SaveChangesAsync(CancellationToken cancellationToken = default);
}