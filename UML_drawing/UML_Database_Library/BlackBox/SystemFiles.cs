using System;
using System.IO;
using System.Linq;

namespace UML_Database_Library.BlackBox
{
    internal static class SystemFiles
    {
        // Проверяем есть ли вокруг запущегого прилодения папка project
        public static bool CheckDirectory()
        {
            string userDirectory = Directory.GetCurrentDirectory();
            var res = Directory.GetDirectories(userDirectory, "project");
            if (res.Length > 0) return true;
            else return false;
        }

        internal static bool CreateDirectoryProject(bool obj)
        {
            if (!obj)
            {
                try
                {
                    Directory.CreateDirectory($@"{Directory.GetCurrentDirectory()}\project");
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Папка не может быть создана");
                }
            }
            return false;
        }

        internal static string[] GetNameFileProject()
        {
            // получаем имена файлов в папке без расширения.
            string userDirectory = Directory.GetCurrentDirectory();
            string[] files = Directory.GetFiles($@"{userDirectory}\project\").Select(fn => Path.GetFileNameWithoutExtension(fn)).ToArray();
            return files;
        }

        internal static bool CheckDublicateName(string namepj)
        {
            // проверка совпадения принятого имени с файлами в проектах. Нужен для того чтобы не дублировать.
            string[] poolname = GetNameFileProject();
            foreach (string i in poolname)
            {
                if (i == namepj) return true;
            }
            return false;
        }
    }
}
