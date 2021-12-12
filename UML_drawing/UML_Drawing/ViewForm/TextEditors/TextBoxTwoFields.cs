using System;
using System.Windows.Forms;
using UML_Logic_Library.StructuralEntities;
using Component = UML_Logic_Library.StructuralEntities.Component;

namespace UML_drawing.ViewForm.TextEditors
{
    public partial class TextBoxTwoFields : Form
    {
        private RectangleTwoFields _objectInForm;

        public TextBoxTwoFields(Component objectFromForm)
        {
            InitializeComponent();
            _objectInForm = objectFromForm as RectangleTwoFields;
            textBox.Text = _objectInForm.Head.Text.TextFields;
            textBox.Font = _objectInForm.Head.Text.Font;
            textBox1.Text = _objectInForm.FieldProp.Text.TextFieldsProp;
            textBox1.Font = _objectInForm.FieldProp.Text.Font;
            textBox2.Text = _objectInForm.FieldMethods.Text.TextFieldsMethod;
            textBox2.Font = _objectInForm.FieldMethods.Text.Font;
            textBox.TextChanged += textBox_TextChanged;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox2.TextChanged += textBox2_TextChanged;
        }

        public string textToObjTitle;
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            _objectInForm.Head.Text.TextFields = textBox.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _objectInForm.FieldProp.Text.TextFieldsProp = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            _objectInForm.FieldMethods.Text.TextFieldsMethod = textBox2.Text;
        }

        private void OkTextButton_Click(object sender, EventArgs e)
        {
            _objectInForm.Head.Text.Font = textBox.Font;
            _objectInForm.FieldProp.Text.Font = textBox1.Font;
            _objectInForm.FieldMethods.Text.Font = textBox2.Font;
            this.Close();
        }

        private void fontEditor_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            textBox.Font = fontDialog1.Font;
        }

        private void fontEditor2_Click(object sender, EventArgs e)
        {
            fontDialog2.ShowDialog();
            textBox1.Font = fontDialog2.Font;
        }

        private void fontEditor3_Click(object sender, EventArgs e)
        {
            fontDialog3.ShowDialog();
            textBox2.Font = fontDialog3.Font;
        }

        private void TextBoxTwoFields_Load(object sender, EventArgs e)
        {

        }
    }
}
