using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ticket.DataAccess.Abstractions;
using ticket.DataAccess.Repositery;
using ticket.Domain.SqlServer;

namespace ticket.DataAccess.Concrete
{
    public class AirplaneRepository : IAirplanesRepository
    {
        public TravelDBEntities1 _context { get; set; }
        public AirplaneRepository()
        {
            _context = new TravelDBEntities1();
        }
        public void AddData(Airplane data)
        {
            throw new NotImplementedException();
        }

        public void DeleteData(Airplane data)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Airplane> GetAll()
        {
            var result = from a in _context.Airplanes
                         select a;
            return new ObservableCollection<Airplane>(result);
        }

        public Airplane GetData(int id)
        {
            var data = GetAll()
            .FirstOrDefault(c=>c.Id==id);
            return data;
        }

        public void UpdateData(Airplane data)
        {
            throw new NotImplementedException();
        }

       
        public ObservableCollection<Airplane> GetDataByScheduleId(int id)
        {
            var data = GetAll()
            .Where(c => c.Id == id);
            return new ObservableCollection<Airplane>(data);
        }
    }
}
