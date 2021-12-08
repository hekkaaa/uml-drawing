﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UML_Database_Library.API;
using UML_Database_Library.BlackBox;
using UML_Logic_Library.Interfaces;
using UML_Logic_Library.StructuralEntities;

namespace UML_Logic_Library.AdditionalClasses
{
    [Serializable]
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
        
        public Handler LoadProject(string nameProj)
        {
            var load = _apiData.LoadProject(nameProj);
            try
            {
                var listComp = load
                .ListObjectFigure
                .Select(component => ComponentMapper.FromLiveData(component))
                .ToList();
                return new Handler(nameProj, listComp);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(ex.Message);
            }
            
        }
        
        
        public bool SaveProject(string nameProj, List<Component> components)
        {
            try
            {
                foreach (var component in components)
                {
                    _liveData.ListObjectFigure.Add(ComponentMapper.ToLiveData(component));
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