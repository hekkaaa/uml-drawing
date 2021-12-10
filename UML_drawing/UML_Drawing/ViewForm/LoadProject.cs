using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace UML_drawing.ViewForm
{
    public partial class LoadProject : Form
    {
        private MyBoxControl _boxControl;
        private Form1 _form;
        public LoadProject(MyBoxControl boxControl, Form1 form)
        {
            InitializeComponent();
            _boxControl = boxControl;
            _form = form;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var hand = _boxControl.Handler.LoadProject(ListProject.SelectedItem.ToString());
                _boxControl.Handler = hand;
                //_boxControl.Handler.NameProj.ToString()
                _form.Text = "UML Creater" + $" - {_boxControl.Handler.NameProj}";
                _form._boolName = false;
                Close();
            }
            catch (NullReferenceException)
            {
                label2.Text = "НЕТ СОЗДАННЫХ ПРОЕКТОВ";
                throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadProject_Load(object sender, EventArgs e)
        {
            string userDirectory = Directory.GetCurrentDirectory();
            var res = Directory.GetDirectories(userDirectory, "project");
            if (res.Length > 0)
            {
                string[] files = Directory.GetFiles($@"{userDirectory}\project\").Select(fn => Path.GetFileNameWithoutExtension(fn)).ToArray();
                for (int i = 0; i < files.Length; i++)
                {
                    ListProject.Items.Add(files[i]);
                }
            }
            else label2.Text = "НЕТ СОЗДАННЫХ ПРОЕКТОВ";
            // тут сделать парсин папки на наличие проектов по имени.
            // вывести список в выпадающем списке ListProject
        }
    }
}
