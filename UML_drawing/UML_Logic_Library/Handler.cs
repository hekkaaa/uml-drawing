using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UML_Database_Library.API;
using UML_Database_Library.BlackBox;
using UML_Logic_Library.Interfaces;
using UML_Logic_Library.Requests;
using UML_Logic_Library.Requests.Abstract;

namespace UML_Logic_Library
{
    /// <summary>
    /// Это у же не актуальный класс, но пусть пока что будет тут
    /// </summary>
    public class Handler : IHandler
    {
        private ApiData _apiData = new ApiData();
        private LiveData _liveData = new LiveData();
        // После всех свистоплясок сделать маппинг объектов _liveData в норм компоненты, наверное хз
        public List<Component> ComponentsInProj = new List<Component>();
        private string _nameProj = "Project1";

        public string NameProj
        {
            get => _nameProj;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Назовите проект!");
                }

                _nameProj = value;
            }
        }
        
        public Handler(){}

        public Handler(string nameProj, List<Component> components)
        {
            NameProj = nameProj;
            ComponentsInProj = new List<Component>(components);
        }
        
        public void CreateProj(string nameProj)
        {
            _liveData = _apiData.CreateProj(nameProj);
        }
        
        // Наверн это уже не нужно
        
        
        // public IComponent Create(BlockRequest blockRequest)
        // {
        //     var component = ComponentFactory.CreateSingleBlock(blockRequest);
        //     // Тут все-таки надо передавать тебе в метод параметр (объект для записи)
        //     // мб я чет совсем путаю, но в момент написания я очень уверена была и все вроде логично
        //     var componentCreated = _apiData.CreateElem(_liveData);
        //     component.ItemId = componentCreated._id;
        //     return component;
        // }

        // public IComponent GetItem(int id)
        // {
        //     var liveDataElement = _liveData.ListObjectFigure.Find(x => x._id == id);
        //     //var component = ComponentFactory.CreateSingleBlock(liveDataElement);
        //     //if (component == null)
        //     //    throw new ArgumentNullException("Выберите подходящий объект!");
        //     return new SimpleRectangle();
        // }
        //
        // public bool DeleteItem(int id)
        // {
        //     return _apiData.RemoveElem(_liveData, id);
        // }

        // Надо подумать над методом, потому что мне или визуалу смысл от LiveData
        // скорее всего может нужно вернуть ListObjectFigure и отрисовывать компоненты по очереди
        public LiveData LoadProject(string nameProj)
        {
            return _apiData.LoadProject(nameProj);
        }
        
        
        public bool SaveProject(string nameProj, List<Component> components)
        {
            try
            {
                return _apiData.SaveProject(nameProj, _liveData);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new DirectoryNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public bool Refresh(BlockRequest blockRequest, int id)
        {
            var singleBlock = ComponentFactory.CreateSingleBlock(blockRequest);
            if (singleBlock == null) 
                throw new Exception("Несуществующий компонент");
            
            for (var i = 0; i < _liveData.ListObjectFigure.Count; i++)
            {
                if (_liveData.ListObjectFigure[i]._id == id)
                {
                    //_liveData.ListObjectFigure[i] = block.ToLiveDataElem();
                    _apiData.SaveProject(_liveData.nameproject, _liveData);
                    return true;
                }
            }
            return false;
        }
        
    }
}