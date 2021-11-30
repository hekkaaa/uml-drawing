using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            // тут сделать загрузку проекта.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadProject_Load(object sender, EventArgs e)
        {
            // тут сделать парсин папки на наличие проектов по имени.
            // вывести список в выпадающем списке ListProject
        }
    }
}
