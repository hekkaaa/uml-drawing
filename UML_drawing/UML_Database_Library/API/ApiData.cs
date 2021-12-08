using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UML_Database_Library.BlackBox;

namespace UML_Database_Library.API
{
    public class ApiData
    {
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

        //public LiveDataElem CreateElem(LiveData obj)
        //{
        //    LiveDataElem elem = new LiveDataElem();
        //    int newid = CreateId.CreaterId(obj);
        //    elem._id = newid;  // Узнаем свободный ID у присваиваем

        //    obj.ListObjectFigure.Add(elem);
        //    return elem;
        //}

        public LiveDataElem CreateElem()
        {
            LiveDataElem elem = new LiveDataElem();
            return elem;
        }

        public LiveData LoadProject(string nameproject)
        {
            try
            {
                return WorkData.Load(nameproject);
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
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                throw new DirectoryNotFoundException(ex.Message);
            }
            return null;
        }

        // сохраненение текущей Livedate в файловой системе.
        public bool SaveProject(string nameproject, List<LiveDataElem> components)
        {
            try
            {
                return WorkData.Save(nameproject, components);
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
    }
}
