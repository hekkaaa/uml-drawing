using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UML_Database_Library.BlackBox;

namespace UML_Database_Library.API
{
    public class ApiData
    {
        public LiveData CreateProj()
        {
            LiveData project = new LiveData();
            return project;
        }

        public LiveData CreateProj(string nameprodject, object obj)
        {
            LiveData project = new LiveData(nameprodject, obj); // доработать возможность передачи LIST<obj>, а не по одному.
            return project;
        }

        public LiveDataElem CreateElem(LiveData obj)
        {
            LiveDataElem elem = new LiveDataElem();
            obj.LiveDataProjects.Add(elem);
            return elem;
        }

        public LiveDataElem CreateElem()
        {
            LiveDataElem elem = new LiveDataElem();
            return elem;
        }

        // Удаления по ID. Нужно передать экземпляр класса проекта и нужный ID.
        public bool RemoveElem(LiveData obj, int id)
        {
            var rem = obj;
            try
            {
                bool res = rem.RemoveEl(id);
                if (res) { return true; }
                else { throw new Exception("Обьект с указанным ID не найден"); }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
