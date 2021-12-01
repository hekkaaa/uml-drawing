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

namespace UML_drawing.ViewForm
{
    public partial class SavesInfoFrom : Form
    {
        public SavesInfoFrom()
        {
            InitializeComponent();
        }

        private void SavesInfoFrom_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            for (int i = 0; i <= 100; i += 10)
            {
                progressBar1.Value = i;
                Thread.Sleep(400);
                ResetText();
                Update();
                // тут нужно прикрутить метод save от Алии.
            }
            Close();
        }
    }
}
