using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ticket.DataAccess.Abstractions;
using ticket.Domain.SqlServer;

namespace ticket.DataAccess.Concrete
{
    public class FlightTypesRepository : IFlightTypesRepository
    {
        public TravelDBEntities1 _context { get; set; }

        public FlightTypesRepository()
        {
            _context = new TravelDBEntities1();
        }
        public void AddData(FlightType data)
        {
            throw new NotImplementedException();
        }

        public void DeleteData(FlightType data)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<FlightType> GetAll()
        {
            var result = from ft in _context.FlightTypes
                         select ft;
            return new ObservableCollection<FlightType>(result);
        }

        public FlightType GetData(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(FlightType data)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<FlightType> GetDataByScheduleId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
