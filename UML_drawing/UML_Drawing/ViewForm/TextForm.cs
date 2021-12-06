using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UML_Logic_Library;
using UML_Logic_Library.StructuralEntities;
using Component = UML_Logic_Library.StructuralEntities.Component;

namespace UML_drawing.ViewForm
{
    public partial class TextForm : Form
    {
        private readonly SimpleRectangle objectInForm;

        public TextForm(Component objectFromForm) : base()
        {
            InitializeComponent();
            objectInForm = (objectFromForm as SimpleRectangle);
            textBox.Text = objectInForm.Text.TextFields;
            textBox.Font = objectInForm.Text.Font;
            textBox.TextChanged += textBox_TextChanged;
        }

        private void OkTextButton_Click(object sender, EventArgs e)
        {
            objectInForm.Text.Font = textBox.Font;
            this.Close();
        }


        private void textBox_TextChanged(object sender, EventArgs e)
        {
            objectInForm.Text.TextFields = textBox.Text;
        }

        private void fontEditor_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            textBox.Font = fontDialog1.Font;
        }

    }
}
