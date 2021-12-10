﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UML_Logic_Library;
using UML_Logic_Library.AdditionalClasses;
using UML_Logic_Library.StructuralEntities;
using Component = UML_Logic_Library.StructuralEntities.Component;

namespace UML_drawing.ViewForm
{
    public partial class LoadProject : Form
    {
        private MyBoxControl _boxControl;
        private Form1 _form;
        public LoadProject(MyBoxControl boxControl, Form1 form)
        {
            InitializeComponent();
            _boxControl = boxControl;
            _form = form;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Handler btnclick = new Handler();
            // var elem = btnclick.LoadProject(ListProject.SelectedItem.ToString());
            try
            { 
                var hand = _boxControl.Handler.LoadProject(ListProject.SelectedItem.ToString());
                _boxControl.Handler = hand;
                Close();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
                //label2.Text = "НЕТ СОЗДАННЫХ ПРОЕКТОВ";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
          

            // foreach (var comp in elem.ListObjectFigure)
            // {
            //     switch (comp.CompName)
            //     {
            //         case "RectangleComponent" :
            //             var component = ComponentMapper.FromLiveData(comp) as RectangleComponent;
            //             _boxControl.AddFigure<RectangleComponent>(component.Location);
            //             break;
            //         case "RectangleOneField" :
            //             var component1 = ComponentMapper.FromLiveData(comp) as RectangleOneField;
            //             _boxControl.AddFigure<RectangleOneField>(component1.Location);
            //             break;
            //     }
            // }

            // Осталось понять как делать рисовку обратно.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadProject_Load(object sender, EventArgs e)
        {
            string userDirectory = Directory.GetCurrentDirectory();
            var res = Directory.GetDirectories(userDirectory, "project");
            if (res.Length > 0)
            {
                string[] files = Directory.GetFiles($@"{userDirectory}\project\").Select(fn => Path.GetFileNameWithoutExtension(fn)).ToArray();
                for(int i = 0; i < files.Length; i++)
                {
                    ListProject.Items.Add(files[i]);
                }   
            }
            else label2.Text = "НЕТ СОЗДАННЫХ ПРОЕКТОВ";
            // тут сделать парсин папки на наличие проектов по имени.
            // вывести список в выпадающем списке ListProject
        }
    }
}
