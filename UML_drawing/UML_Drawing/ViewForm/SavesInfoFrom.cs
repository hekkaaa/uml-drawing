using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UML_Logic_Library;
using UML_Logic_Library.AdditionalClasses;
using Component = UML_Logic_Library.StructuralEntities.Component;

namespace UML_drawing.ViewForm
{
    public partial class SavesInfoFrom : Form
    {
        private Handler _handler;
        public SavesInfoFrom(string nameProj, List<Component> components)
        {
            InitializeComponent();
            _handler = new Handler(nameProj, components);
        }

        private void SavesInfoFrom_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            for (int i = 0; i <= 100; i += 10)
            {
                progressBar1.Value = i;
                Thread.Sleep(150);
                ResetText();
                Update();
                // тут нужно прикрутить метод save от Алии.
            }
            // ну чтобы он постоянно в цикле не вызывался)
            _handler.SaveProject(_handler.NameProj, _handler.ComponentsInProj);
            Close();
        }
    }
}
