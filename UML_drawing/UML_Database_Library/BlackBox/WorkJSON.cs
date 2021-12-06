using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using UML_Database_Library.BlackBox;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace UML_Database_Library.BlackBox
{
    internal static class WorkJson
    {
        internal static LiveData LoadJson(string namefile)
        {
            try
            {

                // тут проблема с путями сохранения и чтения.
                // нужно решить потом.

                string userDirectory = Directory.GetCurrentDirectory();

                string json = File.ReadAllText($@"{userDirectory}\project\{namefile}.json");
                JsonDocument parse = JsonDocument.Parse(json);
                LiveData liveDataProject = new LiveData();

                try
                {
                    for (int i = 0; i < parse.RootElement.GetArrayLength(); i++)
                    {
                        LiveDataElem tmpelem = JsonSerializer.Deserialize<LiveDataElem>(parse.RootElement[i].ToString());
                        liveDataProject.ListObjectFigure.Add(tmpelem);
                    };
                    liveDataProject.nameproject = namefile;
                    return liveDataProject;
                }
                catch (InvalidOperationException)
                {
                    throw new InvalidOperationException();
                }

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

        internal static bool SaveJson(string namefile, List<LiveDataElem> obj)
        {   
            // Проверяем есть ли папка project вообще.
            SystemFiles.CreateDirectoryProject(SystemFiles.CheckDirectory());
            string json = JsonSerializer.Serialize(obj);

            try
            {
                using (StreamWriter sw = new StreamWriter($@"{Directory.GetCurrentDirectory()}\project\{namefile}.json"))
                {
                    sw.WriteLine(json);
                }
                return true;
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
