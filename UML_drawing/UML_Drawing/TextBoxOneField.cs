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

namespace UML_drawing
{
    public partial class TextBoxOneField : Form
    {
        private RectangleOneField _objectInForm;

        public TextBoxOneField(Component objectFromForm)
        {
            InitializeComponent();
            _objectInForm = objectFromForm as RectangleOneField;
            textBox2.Text = _objectInForm.Head.Text.TextFields;
            textBox2.Font = _objectInForm.Head.Text.Font;
            textBox3.Text = _objectInForm.FieldRectangle.Text.TextFieldsProp;
            textBox3.Font = _objectInForm.FieldRectangle.Text.Font;
            textBox2.TextChanged += textBox2_TextChanged;
            textBox3.TextChanged += textBox3_TextChanged;
        }

        public string textToObjTitle;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            _objectInForm.Head.Text.TextFields = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            _objectInForm.FieldRectangle.Text.TextFieldsProp = textBox3.Text;
        }

        private void OkTextButton_Click(object sender, EventArgs e)
        {
            _objectInForm.Head.Text.Font = textBox2.Font;
            _objectInForm.FieldRectangle.Text.Font = textBox3.Font;
            this.Close();
        }

        private void fontEditor_Click(object sender, EventArgs e)
        {
            fontDialog3.ShowDialog();
            textBox2.Font = fontDialog3.Font;
        }

        private void textEditor2_Click(object sender, EventArgs e)
        {
            fontDialog4.ShowDialog();
            textBox3.Font = fontDialog4.Font;
        }

        
    }
}
