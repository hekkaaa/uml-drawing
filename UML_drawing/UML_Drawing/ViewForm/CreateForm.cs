using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using UML_drawing.SubLogical;
using UML_Logic_Library;
using UML_Logic_Library.AdditionalClasses;

namespace UML_drawing.ViewForm
{
    public partial class CreateForm : Form
    {
        //private Form1 _form;
        public Handler Handler;
        private MyBoxControl _boxControl;
        public CreateForm(MyBoxControl boxControl)
        {
            InitializeComponent();
           
                _boxControl = boxControl;
                textBoxCreate.TextChanged += textBoxCreate_TextChanged;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            // Сбрасываю на значения по умолчанию при повторном клике.
            InfoLabel.Text = default;
            infoLabel1.Text = default;

            Handler = new Handler();
            _boxControl.Handler.SaveProject(this.Handler.NameProj, this.Handler.ComponentsInProj);
            
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
                    Handler.CreateProj(textBoxCreate.Text);
                    Handler.SaveProject(textBoxCreate.Text, Handler.ComponentsInProj);
                    _boxControl.Handler = Handler;
                    _boxControl.Handler.NameProj = textBoxCreate.Text;
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
            this.Close();
        }

        private void textBoxCreate_TextChanged(object sender, EventArgs e)
        {
            textBoxCreate.Text = textBoxCreate.Text;
        }

        private void CreateForm_Load(object sender, EventArgs e)
        {

        }
    }
}
