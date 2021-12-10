using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace UML_Database_Library.BlackBox
{
    internal static class WorkData
    {
        internal static LiveData Load(string namefile)
        {
            try
            {
                var dataProject = new LiveData();
                using (FileStream fs = new FileStream($@"{Directory.GetCurrentDirectory()}\project\{namefile}.uml", FileMode.Open))
                    dataProject.ListObjectFigure = (List<LiveDataElem>)new BinaryFormatter().Deserialize(fs);

                return dataProject;
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException($"Файл с именем проекта {namefile} не найден || " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Файл с именем проекта {namefile} не может быть обработан, либо поврежден || " + ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new DirectoryNotFoundException($"Не найдена папка по указанному пути | " + ex.Message);
            }
        }

        internal static bool Save(string namefile, List<LiveDataElem> components)
        {
            try
            {
                using (FileStream fs = new FileStream($@"{Directory.GetCurrentDirectory()}\project\{namefile}.uml", FileMode.Create))
                    new BinaryFormatter().Serialize(fs, components);

                return true;
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException($"Файл с именем проекта {namefile} не найден || " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Файл с именем проекта {namefile} не может быть обработан, либо поврежден || " + ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new DirectoryNotFoundException($"Не найдена папка по указанному пути | " + ex.Message);
            }

        }
    }
}
