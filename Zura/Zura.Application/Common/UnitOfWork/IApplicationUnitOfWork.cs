using Microsoft.EntityFrameworkCore;
using Zura.Domain.Model.Todo.Entity;

namespace Zura.Application.Common.UnitOfWork;

public interface IApplicationUnitOfWork : IUnitOfWork
{
    public DbSet<Todo> Todos { get; }
}