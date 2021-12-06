using System.Collections.Generic;
using UML_Database_Library.BlackBox;

namespace UML_Logic_Library.Interfaces
{
    public interface IHandler
    {
        //public IComponent Create (BlockRequest blockRequest);
        
        // public IComponent GetItem(int id);
        //
        // public bool DeleteItem(int id);
        
        public LiveData LoadProject(string nameProject);
        
        //public bool Refresh(BlockRequest blockRequest, int id);
        
    }
}