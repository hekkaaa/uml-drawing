using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UML_drawing.ViewForm;
using UML_Logic_Library;
using UML_Logic_Library.Arrows;
using Component = System.ComponentModel.Component;

namespace UML_drawing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form1_Load(null,null);
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
            myBoxControl.Handler = new Handler();
            myBoxControl.Handler = myBoxControl.Handler;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           InfoForms.About about = new InfoForms.About();
            about.ShowDialog();
        }

        // КНОПКИ В FILE 
        private void createProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var createform = new CreateForm();
            createform.ShowDialog();
            myBoxControl.Handler = createform.Handler;
            myBoxControl.Handler = myBoxControl.Handler;
        }

        private void loadProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var createform = new LoadProject();
            createform.ShowDialog();
        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var createform = new SavesInfoFrom(myBoxControl.Handler.NameProj, myBoxControl.Handler.ComponentsInProj);
            createform.ShowDialog(this);
        }

        //***********************************************


        
        Point startDragPoint = new Point(90,50);

        private void ObjectButton_Click(object sender, EventArgs e)
        {
            myBoxControl.AddFigure<RectangleComponent>(startDragPoint);
        }

        private void myBoxControl_DoubleClick(object sender, EventArgs e)
        {
            if (myBoxControl.SelectedFigure is Line) return;
            if (myBoxControl.SelectedFigure is RectangleOneField)
            {
                var objectField1 = (myBoxControl.SelectedFigure as RectangleOneField).TextFieldTitle.TextFields;
                var objectField2 = (myBoxControl.SelectedFigure as RectangleOneField).TextFieldProperty.TextFieldsProp;
                var createfromtwofields = new TextBoxOneField(objectField1, objectField2);
                createfromtwofields.ShowDialog();
                myBoxControl.SelectedBeginEditText(createfromtwofields.textToObjTitle, createfromtwofields.textToObjProp);
                return;
            }
            if (myBoxControl.SelectedFigure is RectangleTwoFields)
            {
                var objectField1 = (myBoxControl.SelectedFigure as RectangleTwoFields).TextFieldTitle.TextFields;
                var objectField2 = (myBoxControl.SelectedFigure as RectangleTwoFields).TextFieldProperty.TextFieldsProp;
                var objectField3 = (myBoxControl.SelectedFigure as RectangleTwoFields).TextFieldMethods.TextFieldsMethod;
                var createfromtwofields = new TextBoxTwoFields(objectField1, objectField2, objectField3);
                createfromtwofields.ShowDialog();
                myBoxControl.SelectedBeginEditText(createfromtwofields.textToObjTitle, createfromtwofields.textToObjProp, createfromtwofields.textToObjMethods);
                return;
            }
            var objectField = (myBoxControl.SelectedFigure as SimpleRectangle).Text.TextFields;
            var createfrom = new TextForm(objectField);
            createfrom.ShowDialog();
            myBoxControl.SelectedBeginEditText(createfrom.textToObj);
            
        }

        private void associationLineButton_Click(object sender, EventArgs e)
        {
            myBoxControl.SelectedAddLedgeLine();
            //myBoxControl.AddFigure<Line>(startDragPoint);
        }

        private void inheritanceLineButton_Click(object sender, EventArgs e)
        {
            myBoxControl.SelectedAddDashLedgeLine();
        }

        private void objectOneFieldButton_Click(object sender, EventArgs e)
        {
            myBoxControl.AddFigure<RectangleOneField>(startDragPoint);
        }

        private void objectTwoFieldsButton_Click(object sender, EventArgs e)
        {
            myBoxControl.AddFigure<RectangleTwoFields>(startDragPoint);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            var obj = myBoxControl.SelectedFigure;
            if (obj is SimpleRectangle)
            {
                (obj as SimpleRectangle).Color = colorDialog1.Color;
            }
        }
        // ******************************************************************


        // Анимации PictureBoxHover при наведении
        private void ObjectButton_MouseHover(object sender, EventArgs e)
        {
            // Кнопка 1
            pictureBoxHover.Size = new Size(220, 122);
            pictureBoxHover.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxHover.BackgroundImage = Image.FromFile(@"..\..\BaseImages\object0.png");
            pictureBoxHover.Location = new Point(13, 71);
            pictureBoxHover.Visible = true;

        }
        private void ObjectButton_MouseLeave(object sender, EventArgs e)
        {      // Кнопка 1
             pictureBoxHover.Visible = false;
        }

        private void objectOneFieldButton_MouseHover(object sender, EventArgs e)
        {
            // Кнопка 2
            pictureBoxHover.Size = new Size(215, 217);
            pictureBoxHover.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxHover.BackgroundImage = Image.FromFile(@"..\..\BaseImages\object1.png");
            pictureBoxHover.Location = new Point(43, 71);
            pictureBoxHover.Visible = true;
        }

        private void objectOneFieldButton_MouseLeave(object sender, EventArgs e)
        {   
            // Кнопка 2
            pictureBoxHover.Visible = false;
        }

        private void objectTwoFieldsButton_MouseHover(object sender, EventArgs e)
        {
            // Кнопка 3
            pictureBoxHover.Size = new Size(210, 310);
            pictureBoxHover.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxHover.BackgroundImage = Image.FromFile(@"..\..\BaseImages\object2.png");
            pictureBoxHover.Location = new Point(68, 71);
            pictureBoxHover.Visible = true;
        }

        private void objectTwoFieldsButton_MouseLeave(object sender, EventArgs e)
        {
            // Кнопка 3
            pictureBoxHover.Visible = false;
        }

        private void associationLineButton_MouseHover(object sender, EventArgs e)
        {
            // Кнопка 4
            pictureBoxHover.Size = new Size(295, 47);
            pictureBoxHover.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxHover.BackgroundImage = Image.FromFile(@"..\..\BaseImages\line0.png");
            pictureBoxHover.Location = new Point(88, 71);
            pictureBoxHover.Visible = true;
        }

        private void associationLineButton_MouseLeave(object sender, EventArgs e)
        {
            // Кнопка 4
            pictureBoxHover.Visible = false;
        }

        private void inheritanceLineButton_MouseHover(object sender, EventArgs e)
        {
            // Кнопка 4
            pictureBoxHover.Size = new Size(295, 47);
            pictureBoxHover.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxHover.BackgroundImage = Image.FromFile(@"..\..\BaseImages\line1.png");
            pictureBoxHover.Location = new Point(108, 71);
            pictureBoxHover.Visible = true;
        }

        private void inheritanceLineButton_MouseLeave(object sender, EventArgs e)
        {
            // Кнопка 4
            pictureBoxHover.Visible = false;
        }

        // ******************************************************************
    }
}