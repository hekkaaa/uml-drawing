using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UML_drawing.ViewForm;

namespace UML_drawing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ЗАКРЫТИЕ ЧЕРЕЗ FILE
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
                 "Вы действительно хотите выйти из программы?",
                 "Завершение программы",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Warning
                );
        }

        // ЗАКРЫТИЕ ЧЕРЕЗ КРЕСТИК
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
            "Вы действительно хотите выйти из программы?",
            "Завершение программы",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
           );
            if (dialog == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }


        // тут при загрузке формы можно вешкать фоновые методы.
        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

      

        // Логика при клике.
        private void MyEventHandler1(object sender, MouseEventArgs e)
        {
            //var Form2 = new Form();
            //Form2.ShowDialog();
            //Form2.Show(this);
            //var forms = new ViewForm.LineForm();
            //forms.ShowDialog();
            //Color test = new Color();
        
        }


        // ******************************************************************
        // при действие наведении.

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           InfoForms.About about = new InfoForms.About();
            about.ShowDialog();

        }

        private void createProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var createform = new CreateForm();
            createform.ShowDialog();

        }

        private void loadProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var createform = new LoadProject();
            createform.ShowDialog();
        }

        
        // Взаимодействие с листом стрелок
        private void ListLine_SelectedIndexChanged(object sender, EventArgs e)
        {   
              var createform = new LineForm();
            createform.ShowDialog();
             //string selectedState = ListLine.SelectedItem.ToString();
             //label3.Text = selectedState;
           
        }

        private void ListLine_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // тут сделать логику вызова окна.
            ListLine_SelectedIndexChanged(sender, e);
        
        }

        private void ListLine_Leave(object sender, EventArgs e)
        {
            ListLine.ClearSelected();
        }

        // ******************************************************************

        // Взаимодействие с листом стрелок
            
        private void ObjectList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var createfrom = new ObjectForm();
            createfrom.ShowDialog();
        }

        private void ObjectList_Leave(object sender, EventArgs e)
        {
            ObjectList.ClearSelected();
        }

        private void ObjectList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // ******************************************************************
    }
}