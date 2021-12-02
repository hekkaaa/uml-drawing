using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Database_Library.BlackBox
{
    internal static class CreateId
    {
         public static int CreaterId(LiveData obj)
        {
            List<LiveDataElem> tmplist = obj.ListObjectFigure;
            if(tmplist.Count == 0) return 1;
            else
            {
                int inttmp = obj.ListObjectFigure[tmplist.Count - 1]._id;
                return inttmp + 1;
            } 
        }
    }
}
