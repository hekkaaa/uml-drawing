using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using UML_drawing.SubLogical;
using UML_Logic_Library;

namespace UML_drawing.ViewForm
{
    public partial class CreateForm : Form
    {
        public CreateForm()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Handler btncreate = new Handler();
            string res = CheckValidName.Check(textBoxCreate.Text);
            if (res != null)
            {
                infoLabel1.ForeColor = Color.Red;
                infoLabel1.Text = res;
            }
            else
            {
                try
                {
                    btncreate.CreateProj(textBoxCreate.Text);
                    btncreate.SaveProject(textBoxCreate.Text);
                    Close();
                }
                catch (DuplicateNameException)
                {
                    InfoLabel.ForeColor = Color.Red;
                    InfoLabel.Text = "Проект с таким именем уже существует";
                }
                catch (Exception ex)
                {
                    InfoLabel.ForeColor = Color.Red;
                    InfoLabel.Text = "Неизвестная ошибка при создании проекта";
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
