using System;
using System.Collections.Generic;
using System.IO;
using UML_Database_Library.API;
using UML_Database_Library.BlackBox;
using UML_Logic_Library.Interfaces;
using UML_Logic_Library.StructuralEntities;

namespace UML_Logic_Library.AdditionalClasses
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

        //private string _nameProj = "DefaultProject";
        public string NameProj { get { return _liveData.nameproject; } set { _liveData.nameproject = value; } }
        public Handler() { _liveData.nameproject = "DefaultProject"; } // назначаем имя по умолчанию при создании нового проекта.
        public Handler(string nameProj, List<Component> components)
        {
            NameProj = nameProj;
            ComponentsInProj = new List<Component>(components);
        }
        public void CreateProj(string nameProj)
        {
            NameProj = nameProj;
            _liveData = _apiData.CreateProj(nameProj);
        }
        
        public LiveData LoadProject(string nameProj)
        {
            var load = _apiData.LoadProject(nameProj);
            foreach (var component in load.ListObjectFigure)
            {
                //ComponentsInProj.Add(new Component(component));

                //ComponentsInProj.Add(new Component
                //{
                //    ItemId = component._id,
                //});
                //_liveData.ListObjectFigure.Add(new LiveDataElem
                //{
                //    _id = component.ItemId,
                //    //_pen = component.Pen.,
                //    _penColor = component.PenColor,
                //    _penWidth = component.PenWidth,
                //    Path = component.Path
                //}); ;
            }
            return _apiData.LoadProject(nameProj);
        }
        
        
        public bool SaveProject(string nameProj, List<Component> components)
        {
            try
            {
                foreach (var component in components)
                {
                    _liveData.ListObjectFigure.Add(new LiveDataElem
                    {
                        _id = component.ItemId,
                        //_pen = component.Pen.,
                        _penColor = component.PenColor,
                        _penWidth = component.PenWidth,
                        Path = component.Path
                    }); ;
                }
                return _apiData.SaveProject(nameProj, _liveData.ListObjectFigure);
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


        // public bool Refresh(BlockRequest blockRequest, int id)
        // {
        //     var singleBlock = ComponentFactory.CreateSingleBlock(blockRequest);
        //     if (singleBlock == null) 
        //         throw new Exception("Несуществующий компонент");
        //     
        //     for (var i = 0; i < _liveData.ListObjectFigure.Count; i++)
        //     {
        //         if (_liveData.ListObjectFigure[i]._id == id)
        //         {
        //             //_liveData.ListObjectFigure[i] = block.ToLiveDataElem();
        //             _apiData.SaveProject(_liveData.nameproject, _liveData);
        //             return true;
        //         }
        //     }
        //     return false;
        // }
        
    }
}