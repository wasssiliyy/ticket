using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ticket.DataAccess.Abstractions;
using ticket.Domain.SqlServer;

namespace ticket.DataAccess.Concrete
{
    public class TicketRepository : ITicketsRepository
    {
        public TravelDBEntities1 _context { get; set; }

        public TicketRepository()
        {
            _context = new TravelDBEntities1();
        }
        public void AddData(Ticket data)
        {
            _context.Entry(data).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void DeleteData(Ticket data)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Ticket> GetAll()
        {
            var result = from c in _context.Tickets
                         select c;
            return new ObservableCollection<Ticket>(result);
        }

        public Ticket GetData(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(Ticket data)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Ticket> GetDataByScheduleId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
