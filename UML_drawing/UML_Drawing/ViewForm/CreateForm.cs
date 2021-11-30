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
    public partial class CreateForm : Form
    {
        public CreateForm()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            UML_Database_Library.API.ApiData btmcreate = new UML_Database_Library.API.ApiData();
            btmcreate.CreateProj(textBoxCreate.Text);
            // Прикрутить логику по созданию в местной папке проекта.
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
