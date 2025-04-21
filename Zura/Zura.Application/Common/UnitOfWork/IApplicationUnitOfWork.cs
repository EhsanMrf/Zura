using Microsoft.EntityFrameworkCore;

namespace Zura.Application.Common.UnitOfWork;

public interface IApplicationUnitOfWork : IUnitOfWork
{
    public DbSet<Domain.Model.Todos.Entity.Todo> Todos { get; }
}