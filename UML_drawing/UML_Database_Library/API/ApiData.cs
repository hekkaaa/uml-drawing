using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UML_Database_Library.BlackBox;

namespace UML_Database_Library.API
{
    public class ApiData
    {
        //public LiveData CreateProj()
        //{
        //    LiveData project = new LiveData();
        //    return project;
        //}

        public LiveData CreateProj(string nameprodject)
        {   
            SystemFiles.CreateDirectoryProject(SystemFiles.CheckDirectory()); // Проверка наличия папки project
            bool res = SystemFiles.CheckDublicateName(nameprodject);
            if (res)
            {   // ошибка летит на фронт как дубликат имени.
                throw new DuplicateNameException();
            }
            else
            {
                LiveData project = new LiveData(nameprodject);
                return project;
            } 
        }

        public LiveDataElem CreateElem(LiveData obj)
        {
            LiveDataElem elem = new LiveDataElem();
            int newid = CreateId.CreaterId(obj);
            elem._id = newid;  // Узнаем свободный ID у присваиваем

            obj.ListObjectFigure.Add(elem);
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
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Такого элемента не существует! " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // нужно указать "<filename>.json" вернет обьект с экзепляром Livedata и всеми елементами что сохранились.
        public LiveData LoadProject(string nameproject)
        {
            try
            {
                return WorkJson.LoadJson(nameproject);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                throw new FileNotFoundException(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                throw new InvalidOperationException(ex.Message);
            }
            catch(DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                throw new DirectoryNotFoundException(ex.Message);
            }
            return null;
        }

        // сохраненение текущей Livedate в файловой системе.
        public bool SaveProject(string nameproject, List<LiveDataElem> obj/*LiveData obj*/)
        {
            try
            {
                return WorkJson.SaveJson(nameproject, obj);
            }
            catch (DirectoryNotFoundException ex)
            {   
                throw new DirectoryNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Добавляем элемент в проект. ПОКА ОСТАВЛЕН.
        public bool AddElement(LiveData obj, LiveDataElem obj2)
        {   
            if(obj2._id == default)
            {
                int tmpint = CreateId.CreaterId(obj);
                obj2._id = tmpint;
            }
            try 
            { 
                obj.AddEl(obj, obj2);
                return true; 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
