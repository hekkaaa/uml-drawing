using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UML_drawing
{
    public partial class TextBoxOneField : Form
    {
        public TextBoxOneField()
        {
            InitializeComponent();
        }

        public TextBoxOneField(string title, string prop)
        {
            InitializeComponent();
            textBox.Text = title;
            textBox.TextChanged += textBox_TextChanged;
            textBox1.Text = prop;
            textBox1.TextChanged += textBox1_TextChanged;
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

        private void OkTextButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
