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
            Handler btnclick = new Handler();
            var load = btnclick.LoadProject(ListProject.SelectedItem.ToString());
            //load.ListObjectFigure[0]._id = 0;
            //myBoxControl.AddFigure<RectangleComponent>(startDragPoint);
            //this.Close();
            //MyBoxControl myBoxControl = new MyBoxControl();
            //Point startDragPoint = new Point(140, 50);
            //myBoxControl.BackColor = load.ListObjectFigure[0]._penColor;
            //myBoxControl.AddFigure<RectangleComponent>(startDragPoint);
            //myBoxControl.ResetText();

            Form1 frm = new Form1();


            frm.ShowDialog();
            frm.AddTestELEM();


            //frm.AddTestELEM();
            Close();
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
