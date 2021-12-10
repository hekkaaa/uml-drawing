using System;
using System.Drawing;
using System.Windows.Forms;
using UML_drawing.ViewForm;
using UML_Logic_Library.AdditionalClasses;
using UML_Logic_Library.Arrows;
using UML_Logic_Library.StructuralEntities;

namespace UML_drawing
{
    public partial class Form1 : Form
    {
        private ToolStripButton[] _arrowButtons;
        internal bool _boolName = false;

        public Form1()
        {
            InitializeComponent();
            Form1_Load(null, null);
            this.Text = "UML Creater" + " - DefaultProject";
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

            if(_boolName)
            {
                DialogResult dialog = MessageBox.Show(
                "Сохранить изменения перед выходом?",
                "Изменения не сохранены",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning
               );
                if (dialog == DialogResult.Yes)
                {
                    myBoxControl.Handler.SaveProject(myBoxControl.Handler.NameProj, myBoxControl.Handler.ComponentsInProj);
                    Application.Exit();
                }
                else if (dialog == DialogResult.No)
                {   
                    Application.Exit();
                }
               
            }
            else
            {
                DialogResult dialog = MessageBox.Show(
                "Вы действительно хотите выйти из программы?",
                "Завершение программы",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
               );
                if (dialog == DialogResult.Yes)
                {
                    Application.Exit();
                }
               
            }
        }

        // ЗАКРЫТИЕ ЧЕРЕЗ КРЕСТИК
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (_boolName)
            {
                DialogResult dialog = MessageBox.Show(
                "Сохранить изменения перед выходом?",
                "Изменения не сохранены",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning
               );
                if (dialog == DialogResult.Yes)
                {
                    myBoxControl.Handler.SaveProject(myBoxControl.Handler.NameProj, myBoxControl.Handler.ComponentsInProj);
                    e.Cancel = false;
                }
                else if (dialog == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }

            }
            else
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
            
            var createform = new CreateForm(myBoxControl);
            if (createform.ShowDialog() == DialogResult.OK)
            {
              
                myBoxControl.Handler = createform.Handler;
            }
            this.Text = "UML Creater" + $" - {myBoxControl.Handler.NameProj}";
        }

        private void loadProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var createform = new LoadProject(myBoxControl, this);
            createform.ShowDialog();
        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var createform = new SavesInfoFrom(myBoxControl.Handler.NameProj, myBoxControl.Handler.ComponentsInProj, this);
            createform.ShowDialog(this);
        }

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

        Point startDragPoint = new Point(90, 50);

        // для показа * о редактировании
        private void RenameTextEdit()
        {
            if (!_boolName) { this.Text = this.Text + "*"; _boolName = true; }
        }

        // ******************
        private void ObjectButton_Click(object sender, EventArgs e)
        {
            myBoxControl.AddFigure<RectangleComponent>(startDragPoint);
            RenameTextEdit();
        }

        private void textEditor_Click(object sender, EventArgs e)
        {
            if (myBoxControl.SelectedFigure == null || myBoxControl.SelectedFigure is Arrows)
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
            myBoxControl.SelectedAddLedgeLine(ArrowsTypes.AssociationArrow);
            RenameTextEdit();
        }

        private void addictionLineButton_Click(object sender, EventArgs e)
        {
            myBoxControl.SelectedAddLedgeLine(ArrowsTypes.AddictionArrow);
            RenameTextEdit();
        }

        private void inheritanceLineButton_Click(object sender, EventArgs e)
        {
            myBoxControl.SelectedAddLedgeLine(ArrowsTypes.InheritanceArrow);
            RenameTextEdit();
        }

        private void realizationLineButton_Click(object sender, EventArgs e)
        {
            myBoxControl.SelectedAddLedgeLine(ArrowsTypes.RealizationArrow);
            RenameTextEdit();
        }

        private void compositionLineButton_Click(object sender, EventArgs e)
        {
            myBoxControl.SelectedAddLedgeLine(ArrowsTypes.CompositionArrow);
            RenameTextEdit();
        }

        private void aggregationLineButton_Click(object sender, EventArgs e)
        {
            myBoxControl.SelectedAddLedgeLine(ArrowsTypes.AggregationArrow);
            RenameTextEdit();
        }

        private void objectOneFieldButton_Click(object sender, EventArgs e)
        {
            myBoxControl.AddFigure<RectangleOneField>(startDragPoint);
            RenameTextEdit();
        }

        private void objectTwoFieldsButton_Click(object sender, EventArgs e)
        {
            myBoxControl.AddFigure<RectangleTwoFields>(startDragPoint);
            RenameTextEdit();
        }

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
                RenameTextEdit();
            }

            if (obj is Arrows)
            {
                colorDialog1.ShowDialog();
                (obj as Arrows).PenColor = colorDialog1.Color;
                colorDialog1.Reset();
                RenameTextEdit();
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
