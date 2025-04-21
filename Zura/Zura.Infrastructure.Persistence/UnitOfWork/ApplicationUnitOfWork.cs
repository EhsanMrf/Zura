using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zura.Application.Common.UnitOfWork;
using Zura.Application.Common;
using Zura.Domain.Model.Todos.Entity;

namespace Zura.Infrastructure.Persistence.UnitOfWork
{
    public  class ApplicationUnitOfWork(ApplicationDbContext applicationDbContext) : IApplicationUnitOfWork
    {
        public async Task<Result> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await applicationDbContext.SaveChangesAsync(cancellationToken);
                return Result.Success();
            }
            catch (DbUpdateConcurrencyException e)
            {
                //If you want to do something
                return Result.Failure(e.Message);
            }
            catch (DbUpdateException e)
            {
                return Result.Failure(e.Message);
            }
        }

        public void Dispose()
        {
            applicationDbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            await applicationDbContext.DisposeAsync();
            GC.SuppressFinalize(this);
        }

        public DbSet<Todo> Todos => applicationDbContext.Set<Todo>();
    }
}
