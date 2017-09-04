using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoMap.Interfaces
{
    interface ICrud<T>
    {
        bool Create(T obj);
        List<T> Read(T obj);
        T Login(T obj);
        bool Update(T obj);
        bool Delete(T obj);
    }
}
