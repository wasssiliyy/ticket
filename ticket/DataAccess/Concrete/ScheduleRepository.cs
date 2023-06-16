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
    public class ScheduleRepository : ISchedulesRepository
    {
        public TravelDBEntities1 _context { get; set; }

        public ScheduleRepository()
        {
            _context = new TravelDBEntities1();
        }
        public void AddData(Schedule data)
        {
            throw new NotImplementedException();
        }

        public void DeleteData(Schedule data)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Schedule> GetAll()
        {
            var result = from s in _context.Schedules
                         select s;
            return new ObservableCollection<Schedule>(result);
        }

        public ObservableCollection<Schedule> CityGetAll(int id)
        {
            var schedule = GetAll();
            var data = schedule.Where(c => c.CityId == id);

            return new ObservableCollection<Schedule>(data);
           
        }

        public Schedule GetData(int id)
        {
            var data = GetAll()
                .FirstOrDefault(s => s.Id == id);
            return data;
        }

        public void UpdateData(Schedule data)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Schedule> GetDataByScheduleId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
