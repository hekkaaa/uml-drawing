using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UML_Database_Library.API;
using UML_Logic_Library.Interfaces;

namespace UML_Logic_Library
{
    public class Components
    {
        private List<IComponent> _components;
        private IComponent _ribbonRect;
        private readonly ApiData _apiData = new ApiData();
        
        public void CreateProj(string nameProj)
        {
            //_apiData.SaveProject(nameProj, _components.Select(x => x.ToLiveDataElem()));
        }

        public void LoadProject(string nameProj)
        {
            
        }
        
    }
}