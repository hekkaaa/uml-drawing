using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using UML_drawing.SubLogical;

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
            // ВРЕМЕННОЕ РЕШЕНИЕ В ОБХОД ЛОГИКЕ АЛИИ.
            UML_Database_Library.API.ApiData btncreate = new UML_Database_Library.API.ApiData();

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
                    var test = btncreate.CreateProj(textBoxCreate.Text);
                    btncreate.SaveProject(textBoxCreate.Text, test);
                    Close();
                }
                catch (DuplicateNameException)
                {
                    InfoLabel.ForeColor = Color.Red;
                    InfoLabel.Text = "Проект с таким именем уже существует";
                }
            }




            // InfoLabel label для ошибок.
            // Прикрутить логику по созданию в местной папке проекта.
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
