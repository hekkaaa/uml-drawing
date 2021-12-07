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
            load.nameproject = NameProj;
            //foreach (var component in load.ListObjectFigure)
            //{
                    
            //}
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
                        // Алия мне нужно Bounds свойсво как то достать. Оно есть в элементе но достать не могу.
                        //_x = component.Bounds
                        //_pen = component.Pen
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
    }
}