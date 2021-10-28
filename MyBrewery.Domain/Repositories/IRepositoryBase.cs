using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyBrewery.Domain.Repositories
{
    public interface IRepositoryBase
    {
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
