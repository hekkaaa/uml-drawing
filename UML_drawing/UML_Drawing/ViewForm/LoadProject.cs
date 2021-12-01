using System;
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

namespace UML_drawing.ViewForm
{
    public partial class LoadProject : Form
    {
        public LoadProject()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Заменить потом на методы Алии.
            //UML_Database_Library.API.ApiData test = new UML_Database_Library.API.ApiData();
            //btnclick.LoadProject(ListProject.SelectedItem.ToString());
            // ==== ТУТ НУЖНО ДОРАБОТАТЬ МЕТОД АЛИИ == 

            Handler btnclick = new Handler();
            btnclick.LoadProject();
            Close();
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
