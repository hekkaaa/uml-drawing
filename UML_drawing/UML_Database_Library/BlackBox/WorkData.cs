using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using UML_Database_Library.BlackBox;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;


namespace UML_Database_Library.BlackBox
{
    internal static class WorkData
    {
        internal static LiveData Load(string namefile)
        {
            try
            {
                var dataProject = new LiveData();
                string userDirectory1 = Directory.GetCurrentDirectory();
                using (FileStream fs = new FileStream($@"{userDirectory1}\project\{namefile}.uml", FileMode.Open))
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
            catch(DirectoryNotFoundException ex)
            {
                throw new DirectoryNotFoundException($"Не найдена папка по указанному пути | " + ex.Message);
            }
        }

        internal static bool Save(string namefile, List<LiveDataElem> components)
        {   
            using (FileStream fs = new FileStream($@"{Directory.GetCurrentDirectory()}\project\{namefile}.uml", FileMode.Create))
                new BinaryFormatter().Serialize(fs, components);

            return true;
        }
    }
}
