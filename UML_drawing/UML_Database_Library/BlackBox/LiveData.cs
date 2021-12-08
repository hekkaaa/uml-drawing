using System.Collections.Generic;

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
    }
}
