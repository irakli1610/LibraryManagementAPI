using LibraryManagement.Application;
using LibraryManagement.Persistance.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure
{
    public class ContextWrapper : IContextWrapper
    {
        protected readonly LibraryManagementContext _context;

        public ContextWrapper(LibraryManagementContext context)
        {
            _context = context;
        }

        public async Task<IDbContextTransaction> BeginTransaction()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public LibraryManagementContext GetContext()
        {
            return _context;
        }

        public async Task SaveChanges(CancellationToken token)
        {
            try
            {
                await _context.SaveChangesAsync(token);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
