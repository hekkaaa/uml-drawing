using System;
using System.Collections.Generic;
using System.Linq;
using UML_Database_Library.API;
using UML_Database_Library.BlackBox;
using UML_Logic_Library.Interfaces;
using UML_Logic_Library.Requests;
using UML_Logic_Library.Requests.Abstract;

namespace UML_Logic_Library
{
    public class Handler : IHandler
    {
        private ApiData _apiData = new ApiData();
        private LiveData _liveData;
        
        public void CreateProj(string nameProj)
        {
            _liveData = _apiData.CreateProj(nameProj);
        }
        
        // Когда добавятся еще компоненты, то добавлю еще перегрузку 
        public IComponent Create(SingleBlockRequest singleBlockRequest)
        {
            var component = ComponentFactory.CreateSingleBlock(singleBlockRequest);
            // Тут все-таки надо передавать тебе в метод параметр (объект для записи)
            // мб я чет совсем путаю, но в момент написания я очень уверена была и все вроде логично
            var componentCreated = _apiData.CreateElem(_liveData, component);
            component.SetId(componentCreated._id);
            return component;
        }

        public IComponent GetItem(int id)
        {
            if (id < 0)
                throw new ArgumentException("Такого элемента не существует!");
            var liveDataElement = _liveData.ListObjectFigure.Find(x => x._id == id);
            var component = ComponentFactory.CreateSingleBlock(liveDataElement);
            if (component == null)
                throw new ArgumentNullException("Выберите подходящий объект!");
            return component;
        }

        public bool DeleteItem(int id)
        {
            if (id < 0)
                throw new ArgumentException("Такого элемента не существует!");
            return _apiData.RemoveElem(_liveData, id);
        }

        // Надо подумать над методом, потому что мне или визуалу смысл от LiveData
        // скорее всего может нужно вернуть ListObjectFigure и отрисовывать компоненты по очереди
        public LiveData LoadProject()
        {
            return _apiData.LoadProject(_liveData.nameproject);
        }
        
        public bool Refresh(SingleBlockRequest singleBlockRequest, int id)
        {
            if (id < 0)
                throw new ArgumentException("Такого элемента не существует!");
            var singleBlock = ComponentFactory.CreateSingleBlock(singleBlockRequest);
            if (singleBlock == null) 
                throw new Exception("Несуществующий компонент");

            // Помнишь, мы обсуждали обновление всей коллекции после изменения обЪекта,
            // я тут подумала, что тебе тогда нужно будет перезаписать существующую,
            // пока что вызываю метод CreateProj, но он будет создавать новую
            for (var i = 0; i < _liveData.ListObjectFigure.Count; i++)
            {
                if (_liveData.ListObjectFigure[i]._id == id)
                {
                    _liveData.ListObjectFigure[i] = singleBlock.ToLiveDataElem();
                    _apiData.CreateProj(_liveData.nameproject);
                    return true;
                }
            }
            return false;
        }
        
    }
}