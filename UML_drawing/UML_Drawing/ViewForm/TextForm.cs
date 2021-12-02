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
    public partial class TextForm : Form
    {
        public TextForm()
        {
            InitializeComponent();
            textBox.Text = textToObj;
            textBox.TextChanged += textBox_TextChanged;
        }

        public TextForm(string objectField) : base()
        {
            InitializeComponent();
            textBox.Text = objectField;
            textBox.TextChanged += textBox_TextChanged;
        }

        private void OkTextButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string textToObj;

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            textToObj = textBox.Text;
        }

    }
}
