using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ticket.DataAccess.Repositery;
using ticket.Domain.SqlServer;

namespace ticket.DataAccess.Abstractions
{
    public interface ITicketsRepository : IRepository<Ticket>
    {
    }
}
