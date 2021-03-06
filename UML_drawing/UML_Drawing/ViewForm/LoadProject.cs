using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using UML_drawing.Canvas;
using UML_Logic_Library;
using UML_Logic_Library.Arrows;

namespace UML_drawing.ViewForm
{
    public partial class LoadProject : Form
    {
        private readonly MyBoxControl _boxControl;
        private readonly Form1 _form;
        public LoadProject(MyBoxControl boxControl, Form1 form)
        {
            InitializeComponent();
            _boxControl = boxControl;
            _form = form;
        }

       
        private void button1_Click(object sender, EventArgs e)
        {   
            // Форма если есть несохраненные изменения.
            if(_form.BoolName){
                DialogResult dialog = MessageBox.Show(
               "Сохранить изменения в текущем проекте?",
               "Изменения не сохранены",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning
           );
                if (dialog == DialogResult.Yes)
                {
                    _boxControl.Handler.SaveProject(_boxControl.Handler.NameProj, _boxControl.Handler.ComponentsInProj);
                }
            }

            try
            {
                var hand = _boxControl.Handler.LoadProject(ListProject.SelectedItem.ToString());
                foreach (var arrow in hand.ComponentsInProj.OfType<Arrows>())
                {
                    foreach (var comp in hand.ComponentsInProj)
                    {
                        if (arrow.From.EqualComponents(comp))
                            arrow.From = comp;
                        if (arrow.To.EqualComponents(comp))
                            arrow.To = comp;
                    }
                }
                _boxControl.Handler = hand;
                _form.Text = "UML Creater" + $" - {_boxControl.Handler.NameProj}";
                _form.BoolName = false;
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
            ListProject.Visible = true;
            button1.Enabled = false;
            var res = Directory.GetDirectories(Directory.GetCurrentDirectory(), "project");
            if (res.Length > 0)
            {
                string[] files = Directory.GetFiles($@"{Directory.GetCurrentDirectory()}\project\").Select(fn => Path.GetFileNameWithoutExtension(fn)).ToArray();
                if (files.Length > 0)
                {
                    label2.Text = "";
                    for (int i = 0; i < files.Length; i++)
                    {
                        ListProject.Items.Add(files[i]);
                    }
                }
                else
                {
                    button1.Enabled = false;
                    label2.Text = "НЕТ СОЗДАННЫХ ПРОЕКТОВ";
                    ListProject.Visible = false;
                }
            }
            else
            {
                button1.Enabled = false;
                label2.Text = "НЕТ СОЗДАННЫХ ПРОЕКТОВ";
                ListProject.Visible = false;
            }
            // тут сделать парсин папки на наличие проектов по имени.
            // вывести список в выпадающем списке ListProject
        }

        private void ListProject_SelectionChangeCommitted(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
    }
}
