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
    public class CityRepository : ICityRepository
    {
        public TravelDBEntities1 _context { get; set; }

        public CityRepository()
        {
            _context = new TravelDBEntities1();
        }
        public void AddData(City data)
        {
            throw new NotImplementedException();
        }

        public void DeleteData(City data)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<City> GetAll()
        {
            var result = from c in _context.Cities
                         orderby c.Name
                         select c;
            return new ObservableCollection<City>(result);
        }

        public City GetData(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(City data)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<City> GetDataByScheduleId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
