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
    public partial class TextBoxTwoFields : Form
    {
        public TextBoxTwoFields()
        {
            InitializeComponent();
        }

        public TextBoxTwoFields(string title, string prop, string methods)
        {
            InitializeComponent();

            textBox.Text = title;
            textBox.TextChanged += textBox_TextChanged;
            textBox1.Text = prop;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox2.Text = methods;
            textBox2.TextChanged += textBox2_TextChanged;
        }

        public string textToObjTitle;
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            textToObjTitle = textBox.Text;
        }

        public string textToObjProp;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textToObjProp = textBox1.Text;
        }
        public string textToObjMethods;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textToObjMethods = textBox2.Text;
        }

        

        private void OkTextButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
