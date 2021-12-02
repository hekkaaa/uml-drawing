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
        List<LiveDataElem> _listObjectFigure = new List<LiveDataElem> { };

        public LiveData() { }

        public LiveData(string name) { this.nameproject = name; }
      
        public LiveData(string name, object obj)
        {
            this.nameproject = name;
            ListObjectFigure.Add((LiveDataElem)obj);
        }

        public List<LiveDataElem> ListObjectFigure
        {
            get { return this._listObjectFigure; }
            set { this._listObjectFigure = value; }
        }

        internal bool RemoveEl(int id)
        {

            for (int i = 0; i < ListObjectFigure.Count; i++)
            {
                if (_listObjectFigure[i]._id == id)
                {
                    try
                    {
                        _listObjectFigure.RemoveAt(i);
                        return true;
                    }
                    catch(ArgumentException ex)
                    {
                        throw new ArgumentException("Такого элемента не существует! " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
            return false;
        }

        internal bool AddEl(LiveData obj, LiveDataElem obj2)
        {   
        
            try
            {
                obj._listObjectFigure.Add(obj2);
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
