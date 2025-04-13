using LibraryManagement.Persistance.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application
{
    public interface  IContextWrapper
    {
        Task SaveChanges(CancellationToken token);
        LibraryManagementContext GetContext();

        Task<IDbContextTransaction> BeginTransaction();
    }
}
