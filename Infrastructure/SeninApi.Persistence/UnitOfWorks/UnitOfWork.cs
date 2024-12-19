using SeninApi.Application.Interfaces.Repositories;
using SeninApi.Application.Interfaces.UnitOfWorks;
using SeninApi.Persistence.Context;
using SeninApi.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeninApi.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;

        public UnitOfWork(AppDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public async ValueTask DisposeAsync() => await dbContext.DisposeAsync();

        public int Save() => dbContext.SaveChanges();

        public async Task<int> SaveAsync() => await dbContext.SaveChangesAsync();
        

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(dbContext);
        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(dbContext);
        
    }
}
