using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UML_drawing.ViewForm
{
    public partial class LineForm : Form
    {
        List<string> _tmplist = new List<string>();
        public LineForm()
        {
            InitializeComponent();
        }

        private void LineForm_Load(object sender, EventArgs e)
        {
           
            Type colorType = typeof(System.Drawing.Color);
            PropertyInfo[] propInfos = colorType.GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (PropertyInfo propInfo in propInfos)
            {
                _tmplist.Add(propInfo.Name);
            }

            // тут дальше нужно в ColorBOx список поместить.


        }
    }
}
