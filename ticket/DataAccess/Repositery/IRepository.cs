﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ticket.DataAccess.Repositery
{
    public interface IRepository<T>
    {
        T GetData(int id);
        ObservableCollection<T> GetDataByScheduleId(int id);
        ObservableCollection<T> GetAll();
        void AddData(T data);
        void UpdateData(T data);
        void DeleteData(T id);
    }
}
