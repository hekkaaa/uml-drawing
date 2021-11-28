using System.Collections.Generic;
using UML_Database_Library.BlackBox;
using UML_Logic_Library.Requests;
using UML_Logic_Library.Requests.Abstract;

namespace UML_Logic_Library.Interfaces
{
    public interface IHandler
    {
        public IComponent Create (SingleBlockRequest singleBlockRequest);
        
        public IComponent GetItem(int id);
        
        public bool DeleteItem(int id);
        
        public LiveData LoadProject();
        
        public bool Refresh(SingleBlockRequest singleBlockRequest, int id);
        
    }
}