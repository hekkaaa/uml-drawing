using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_drawing.SubLogical
{
    internal static class CheckValidName
    {   
        public static string Check(string name)
        {
            if (CheckNotNull(name)) return "Введите имя проекта";
            else
            {
                if (CheckSymb(name)) return "Имя содержит символы:\n '*', '\\', '/', ':', '?', '<', '>', '|'";
                else return null;
            }
        }
        private static bool CheckNotNull(string name)
        {
            if (String.IsNullOrWhiteSpace(name)) return true; // это плохо. значит пустая
            return false;
        }
        private static bool CheckSymb(string name)
        {
            char[] symb = { '*', '\\', '/', ':', '?', '<', '>', '|' };

            for (int i = 0; i < symb.Length; i++)
            {
                if (name.Contains(symb[i])) return true;
            }
            return false;
        }
    }
}
