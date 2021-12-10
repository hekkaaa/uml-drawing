using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using UML_Logic_Library.AdditionalClasses;
using Component = UML_Logic_Library.StructuralEntities.Component;

namespace UML_drawing.ViewForm
{
    public partial class SavesInfoFrom : Form
    {
        private Handler _handler;
        private Form1 _form;

        public SavesInfoFrom(string nameProj, List<Component> components, Form1 form)
        {
            InitializeComponent();
            _handler = new Handler(nameProj, components);
            _form = form;
        }

        private void SavesInfoFrom_Load(object sender, EventArgs e)
        {
            _handler.SaveProject(_handler.NameProj, _handler.ComponentsInProj);
            progressBar1.Value = 0;
            for (int i = 0; i <= 100; i += 10)
            {
                progressBar1.Value = i;
                Thread.Sleep(150);
                ResetText();
                Update();
            }
            _form.Text = "UML Creater" + $" - {_handler.NameProj}";
            _form._boolName = false;
            Close();
        }
    }
}
