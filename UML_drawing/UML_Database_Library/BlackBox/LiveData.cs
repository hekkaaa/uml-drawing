using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Database_Library.BlackBox
{
    public class LiveData
    {
        public string nameproject { get; set; }
        List<LiveDataElem> _liveDataProjects = new List<LiveDataElem> { };

        public LiveData() { }
        public LiveData(string name, object obj)
        {
            this.nameproject = name;
            LiveDataProjects.Add((LiveDataElem)obj);
        }

        public List<LiveDataElem> LiveDataProjects
        {
            get { return this._liveDataProjects; }
            set { this._liveDataProjects = value; }
        }

        internal bool RemoveEl(int id)
        {

            for (int i = 0; i < LiveDataProjects.Count; i++)
            {
                if (_liveDataProjects[i].id == id)
                {
                    try
                    {
                        _liveDataProjects.RemoveAt(i);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception();
                    }
                }
            }
            return false;
        }

    }
}
