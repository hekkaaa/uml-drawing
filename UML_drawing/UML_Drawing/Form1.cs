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
using UML_Logic_Library.AdditionalClasses;
using UML_Logic_Library.Arrows;
using UML_Logic_Library.StructuralEntities;
using Component = System.ComponentModel.Component;

namespace UML_drawing
{
    public partial class Form1 : Form
    {
        private ToolStripButton[] _arrowButtons;

        public Form1()
        {
            InitializeComponent();
            Form1_Load(null,null);
            myBoxControl.SelectedChanged += delegate
                {
                    foreach (var button in _arrowButtons)
                    {
                        button.Enabled = myBoxControl.SelectedFigure is SimpleRectangle;
                    }
                    textEditor.Enabled = myBoxControl.SelectedFigure is SimpleRectangle;
                    colorEdit.Enabled = !(myBoxControl.SelectedFigure is null);
                };
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
            _arrowButtons = new ToolStripButton[]
            {
                associationLineButton, 
                inheritanceLineButton, 
                addictionLineButton, 
                realizationLineButton,
                compositionLineButton,
                aggregationLineButton
            };
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

        // Пхехп, короче, он сохраняет картиночку все ок, но рофл в том, что сохраняет с рамочкой
        // если джипег сохрянять то вообще со скроллом)))))))))) воть
        private void saveAsImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveImage.ShowDialog();
                myBoxControl.GetImage().Save(saveImage.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception)
            {
                return;
            }
            
            
        }

        //***********************************************



        Point startDragPoint = new Point(90,50);

        private void ObjectButton_Click(object sender, EventArgs e)
        {
            myBoxControl.AddFigure<RectangleComponent>(startDragPoint);
        }

        private void textEditor_Click(object sender, EventArgs e)
        {
            if (myBoxControl.SelectedFigure == null || myBoxControl.SelectedFigure is Line)
                return;
            if (myBoxControl.SelectedFigure is RectangleOneField)
            {
                var createEditorBoxOneFieldfields = new TextBoxOneField(myBoxControl.SelectedFigure);
                createEditorBoxOneFieldfields.ShowDialog();
                return;
            }
            if (myBoxControl.SelectedFigure is RectangleTwoFields)
            {
                var createfromtwofields = new TextBoxTwoFields(myBoxControl.SelectedFigure);
                createfromtwofields.ShowDialog();
                return;
            }
            var createEditorBox = new TextForm(myBoxControl.SelectedFigure);
            createEditorBox.ShowDialog(); 
            
        }

        private void associationLineButton_Click(object sender, EventArgs e)
        {
            myBoxControl.SelectedAddLedgeLine(Arrows.AssociationArrow);
            //myBoxControl.AddFigure<Line>(startDragPoint);
        }

        private void addictionLineButton_Click(object sender, EventArgs e)
        {
            myBoxControl.SelectedAddLedgeLine(Arrows.AddictionArrow);
        }

        private void inheritanceLineButton_Click(object sender, EventArgs e)
        {
            myBoxControl.SelectedAddLedgeLine(Arrows.InheritanceArrow);
        }

        private void realizationLineButton_Click(object sender, EventArgs e)
        {
            myBoxControl.SelectedAddLedgeLine(Arrows.RealizationArrow);
        }

        private void compositionLineButton_Click(object sender, EventArgs e)
        {
            myBoxControl.SelectedAddLedgeLine(Arrows.CompositionArrow);
        }

        private void aggregationLineButton_Click(object sender, EventArgs e)
        {
            myBoxControl.SelectedAddLedgeLine(Arrows.AggregationArrow);
        }

        private void objectOneFieldButton_Click(object sender, EventArgs e)
        {
            myBoxControl.AddFigure<RectangleOneField>(startDragPoint);
        }

        private void objectTwoFieldsButton_Click(object sender, EventArgs e)
        {
            myBoxControl.AddFigure<RectangleTwoFields>(startDragPoint);
        }

        // Тут есть забавный баг, что когда мы закрываем окошко ничего не выбрав,
        // то оно colorDialog1.Reset() отсюда берет дефолтный цвет (или белый как у форм) и получается, 
        // что фигура все равно закрашивается)))))))
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (myBoxControl.SelectedFigure == null)
            {
                return;
            }
            var obj = myBoxControl.SelectedFigure;
            if (obj is SimpleRectangle)
            {
                colorDialog1.Color = Color.White;
                colorDialog1.ShowDialog();
                (obj as SimpleRectangle).Color = colorDialog1.Color;
                colorDialog1.Reset();
            }

            if (obj is Line)
            {
                colorDialog1.ShowDialog();
                (obj as Line).PenColor = colorDialog1.Color;
                colorDialog1.Reset();
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

        private void addictionLineButton_MouseHover(object sender, EventArgs e)
        {
            // Кнопка 4
            pictureBoxHover.Size = new Size(295, 47);
            pictureBoxHover.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxHover.BackgroundImage = Image.FromFile(@"..\..\BaseImages\line1.png");
            pictureBoxHover.Location = new Point(108, 71);
            pictureBoxHover.Visible = true;
        }

        private void addictionLineButton_MouseLeave(object sender, EventArgs e)
        {
            // Кнопка 4
            pictureBoxHover.Visible = false;
        }

        private void realizationLineButton_MouseHover(object sender, EventArgs e)
        {
            // Кнопка 4
            pictureBoxHover.Size = new Size(295, 47);
            pictureBoxHover.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxHover.BackgroundImage = Image.FromFile(@"..\..\BaseImages\line2.png");
            pictureBoxHover.Location = new Point(108, 71);
            pictureBoxHover.Visible = true;
        }

        private void realizationLineButton_MouseLeave(object sender, EventArgs e)
        {
            // Кнопка 4
            pictureBoxHover.Visible = false;
        }

        private void inheritanceLineButton_MouseHover(object sender, EventArgs e)
        {
            // Кнопка 4
            pictureBoxHover.Size = new Size(295, 47);
            pictureBoxHover.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxHover.BackgroundImage = Image.FromFile(@"..\..\BaseImages\line3.png");
            pictureBoxHover.Location = new Point(108, 71);
            pictureBoxHover.Visible = true;
        }

        private void inheritanceLineButton_MouseLeave(object sender, EventArgs e)
        {
            // Кнопка 4
            pictureBoxHover.Visible = false;
        }

        private void aggregationLineButton_MouseHover(object sender, EventArgs e)
        {
            // Кнопка 4
            pictureBoxHover.Size = new Size(295, 47);
            pictureBoxHover.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxHover.BackgroundImage = Image.FromFile(@"..\..\BaseImages\line4.png");
            pictureBoxHover.Location = new Point(108, 71);
            pictureBoxHover.Visible = true;
        }

        private void aggregationLineButton_MouseLeave(object sender, EventArgs e)
        {
            // Кнопка 4
            pictureBoxHover.Visible = false;
        }

        private void compositionLineButton_MouseHover(object sender, EventArgs e)
        {
            // Кнопка 4
            pictureBoxHover.Size = new Size(295, 47);
            pictureBoxHover.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxHover.BackgroundImage = Image.FromFile(@"..\..\BaseImages\line5.png");
            pictureBoxHover.Location = new Point(108, 71);
            pictureBoxHover.Visible = true;
        }

        private void compositionLineButton_MouseLeave(object sender, EventArgs e)
        {
            // Кнопка 4
            pictureBoxHover.Visible = false;
        }

        


        // ******************************************************************
    }
}
