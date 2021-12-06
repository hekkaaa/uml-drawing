using System.Windows.Forms;
using UML_Logic_Library;

namespace UML_drawing
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ObjectButton = new System.Windows.Forms.ToolStripButton();
            this.objectOneFieldButton = new System.Windows.Forms.ToolStripButton();
            this.objectTwoFieldsButton = new System.Windows.Forms.ToolStripButton();
            this.associationLineButton = new System.Windows.Forms.ToolStripButton();
            this.addictionLineButton = new System.Windows.Forms.ToolStripButton();
            this.realizationLineButton = new System.Windows.Forms.ToolStripButton();
            this.inheritanceLineButton = new System.Windows.Forms.ToolStripButton();
            this.compositionLineButton = new System.Windows.Forms.ToolStripButton();
            this.aggregationLineButton = new System.Windows.Forms.ToolStripButton();
            this.textEditor = new System.Windows.Forms.ToolStripButton();
            this.colorEdit = new System.Windows.Forms.ToolStripButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pictureBoxHover = new System.Windows.Forms.PictureBox();
            this.saveImage = new System.Windows.Forms.SaveFileDialog();
            this.myBoxControl = new UML_Logic_Library.MyBoxControl();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.bindingSource1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBoxHover)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.createToolStripMenuItem, this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(984, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.createProjectToolStripMenuItem, this.loadProjectToolStripMenuItem, this.saveProjectToolStripMenuItem, this.saveAsImageToolStripMenuItem, this.exitToolStripMenuItem});
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.createToolStripMenuItem.Text = "File";
            // 
            // createProjectToolStripMenuItem
            // 
            this.createProjectToolStripMenuItem.Image = ((System.Drawing.Image) (resources.GetObject("createProjectToolStripMenuItem.Image")));
            this.createProjectToolStripMenuItem.Name = "createProjectToolStripMenuItem";
            this.createProjectToolStripMenuItem.Size = new System.Drawing.Size(197, 30);
            this.createProjectToolStripMenuItem.Text = "Create Project";
            this.createProjectToolStripMenuItem.Click += new System.EventHandler(this.createProjectToolStripMenuItem_Click);
            // 
            // loadProjectToolStripMenuItem
            // 
            this.loadProjectToolStripMenuItem.Image = ((System.Drawing.Image) (resources.GetObject("loadProjectToolStripMenuItem.Image")));
            this.loadProjectToolStripMenuItem.Name = "loadProjectToolStripMenuItem";
            this.loadProjectToolStripMenuItem.Size = new System.Drawing.Size(197, 30);
            this.loadProjectToolStripMenuItem.Text = "Load Project";
            this.loadProjectToolStripMenuItem.Click += new System.EventHandler(this.loadProjectToolStripMenuItem_Click);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Image = ((System.Drawing.Image) (resources.GetObject("saveProjectToolStripMenuItem.Image")));
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(197, 30);
            this.saveProjectToolStripMenuItem.Text = "Save Project";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
            // 
            // saveAsImageToolStripMenuItem
            // 
            this.saveAsImageToolStripMenuItem.Image = ((System.Drawing.Image) (resources.GetObject("saveAsImageToolStripMenuItem.Image")));
            this.saveAsImageToolStripMenuItem.Name = "saveAsImageToolStripMenuItem";
            this.saveAsImageToolStripMenuItem.Size = new System.Drawing.Size(197, 30);
            this.saveAsImageToolStripMenuItem.Text = "Save as image";
            this.saveAsImageToolStripMenuItem.Click += new System.EventHandler(this.saveAsImageToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image) (resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(197, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(74, 29);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.ObjectButton, this.objectOneFieldButton, this.objectTwoFieldsButton, this.associationLineButton, this.addictionLineButton, this.realizationLineButton, this.inheritanceLineButton, this.compositionLineButton, this.aggregationLineButton, this.textEditor, this.colorEdit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 33);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(984, 31);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ObjectButton
            // 
            this.ObjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ObjectButton.Image = ((System.Drawing.Image) (resources.GetObject("ObjectButton.Image")));
            this.ObjectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ObjectButton.Name = "ObjectButton";
            this.ObjectButton.Size = new System.Drawing.Size(28, 28);
            this.ObjectButton.Text = "Object";
            this.ObjectButton.Click += new System.EventHandler(this.ObjectButton_Click);
            this.ObjectButton.MouseLeave += new System.EventHandler(this.ObjectButton_MouseLeave);
            this.ObjectButton.MouseHover += new System.EventHandler(this.ObjectButton_MouseHover);
            // 
            // objectOneFieldButton
            // 
            this.objectOneFieldButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.objectOneFieldButton.Image = ((System.Drawing.Image) (resources.GetObject("objectOneFieldButton.Image")));
            this.objectOneFieldButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.objectOneFieldButton.Name = "objectOneFieldButton";
            this.objectOneFieldButton.Size = new System.Drawing.Size(28, 28);
            this.objectOneFieldButton.Text = "toolStripButton2";
            this.objectOneFieldButton.Click += new System.EventHandler(this.objectOneFieldButton_Click);
            this.objectOneFieldButton.MouseLeave += new System.EventHandler(this.objectOneFieldButton_MouseLeave);
            this.objectOneFieldButton.MouseHover += new System.EventHandler(this.objectOneFieldButton_MouseHover);
            // 
            // objectTwoFieldsButton
            // 
            this.objectTwoFieldsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.objectTwoFieldsButton.Image = ((System.Drawing.Image) (resources.GetObject("objectTwoFieldsButton.Image")));
            this.objectTwoFieldsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.objectTwoFieldsButton.Name = "objectTwoFieldsButton";
            this.objectTwoFieldsButton.Size = new System.Drawing.Size(28, 28);
            this.objectTwoFieldsButton.Text = "toolStripButton2";
            this.objectTwoFieldsButton.Click += new System.EventHandler(this.objectTwoFieldsButton_Click);
            this.objectTwoFieldsButton.MouseLeave += new System.EventHandler(this.objectTwoFieldsButton_MouseLeave);
            this.objectTwoFieldsButton.MouseHover += new System.EventHandler(this.objectTwoFieldsButton_MouseHover);
            // 
            // associationLineButton
            // 
            this.associationLineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.associationLineButton.Enabled = false;
            this.associationLineButton.Image = ((System.Drawing.Image) (resources.GetObject("associationLineButton.Image")));
            this.associationLineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.associationLineButton.Name = "associationLineButton";
            this.associationLineButton.Size = new System.Drawing.Size(28, 28);
            this.associationLineButton.Text = "toolStripButton1";
            this.associationLineButton.Click += new System.EventHandler(this.associationLineButton_Click);
            this.associationLineButton.MouseLeave += new System.EventHandler(this.associationLineButton_MouseLeave);
            this.associationLineButton.MouseHover += new System.EventHandler(this.associationLineButton_MouseHover);
            // 
            // addictionLineButton
            // 
            this.addictionLineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addictionLineButton.Enabled = false;
            this.addictionLineButton.Image = ((System.Drawing.Image) (resources.GetObject("addictionLineButton.Image")));
            this.addictionLineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addictionLineButton.Name = "addictionLineButton";
            this.addictionLineButton.Size = new System.Drawing.Size(28, 28);
            this.addictionLineButton.Text = "toolStripButton1";
            this.addictionLineButton.Click += new System.EventHandler(this.addictionLineButton_Click);
            this.addictionLineButton.MouseLeave += new System.EventHandler(this.addictionLineButton_MouseLeave);
            this.addictionLineButton.MouseHover += new System.EventHandler(this.addictionLineButton_MouseHover);
            // 
            // realizationLineButton
            // 
            this.realizationLineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.realizationLineButton.Enabled = false;
            this.realizationLineButton.Image = ((System.Drawing.Image) (resources.GetObject("realizationLineButton.Image")));
            this.realizationLineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.realizationLineButton.Name = "realizationLineButton";
            this.realizationLineButton.Size = new System.Drawing.Size(28, 28);
            this.realizationLineButton.Text = "toolStripButton2";
            this.realizationLineButton.Click += new System.EventHandler(this.realizationLineButton_Click);
            this.realizationLineButton.MouseLeave += new System.EventHandler(this.realizationLineButton_MouseLeave);
            this.realizationLineButton.MouseHover += new System.EventHandler(this.realizationLineButton_MouseHover);
            // 
            // inheritanceLineButton
            // 
            this.inheritanceLineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.inheritanceLineButton.Enabled = false;
            this.inheritanceLineButton.Image = ((System.Drawing.Image) (resources.GetObject("inheritanceLineButton.Image")));
            this.inheritanceLineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.inheritanceLineButton.Name = "inheritanceLineButton";
            this.inheritanceLineButton.Size = new System.Drawing.Size(28, 28);
            this.inheritanceLineButton.Text = "toolStripButton2";
            this.inheritanceLineButton.Click += new System.EventHandler(this.inheritanceLineButton_Click);
            this.inheritanceLineButton.MouseLeave += new System.EventHandler(this.inheritanceLineButton_MouseLeave);
            this.inheritanceLineButton.MouseHover += new System.EventHandler(this.inheritanceLineButton_MouseHover);
            // 
            // compositionLineButton
            // 
            this.compositionLineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.compositionLineButton.Enabled = false;
            this.compositionLineButton.Image = ((System.Drawing.Image) (resources.GetObject("compositionLineButton.Image")));
            this.compositionLineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.compositionLineButton.Name = "compositionLineButton";
            this.compositionLineButton.Size = new System.Drawing.Size(28, 28);
            this.compositionLineButton.Text = "toolStripButton3";
            this.compositionLineButton.Click += new System.EventHandler(this.compositionLineButton_Click);
            this.compositionLineButton.MouseLeave += new System.EventHandler(this.compositionLineButton_MouseLeave);
            this.compositionLineButton.MouseHover += new System.EventHandler(this.compositionLineButton_MouseHover);
            // 
            // aggregationLineButton
            // 
            this.aggregationLineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.aggregationLineButton.Enabled = false;
            this.aggregationLineButton.Image = ((System.Drawing.Image) (resources.GetObject("aggregationLineButton.Image")));
            this.aggregationLineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aggregationLineButton.Name = "aggregationLineButton";
            this.aggregationLineButton.Size = new System.Drawing.Size(28, 28);
            this.aggregationLineButton.Text = "toolStripButton4";
            this.aggregationLineButton.Click += new System.EventHandler(this.aggregationLineButton_Click);
            this.aggregationLineButton.MouseLeave += new System.EventHandler(this.aggregationLineButton_MouseLeave);
            this.aggregationLineButton.MouseHover += new System.EventHandler(this.aggregationLineButton_MouseHover);
            // 
            // textEditor
            // 
            this.textEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.textEditor.Enabled = false;
            this.textEditor.Image = ((System.Drawing.Image) (resources.GetObject("textEditor.Image")));
            this.textEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.textEditor.Name = "textEditor";
            this.textEditor.Size = new System.Drawing.Size(28, 28);
            this.textEditor.Text = "toolStripButton2";
            this.textEditor.Click += new System.EventHandler(this.textEditor_Click);
            // 
            // colorEdit
            // 
            this.colorEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.colorEdit.Enabled = false;
            this.colorEdit.Image = ((System.Drawing.Image) (resources.GetObject("colorEdit.Image")));
            this.colorEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.colorEdit.Name = "colorEdit";
            this.colorEdit.Size = new System.Drawing.Size(28, 28);
            this.colorEdit.Text = "toolStripButton1";
            this.colorEdit.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.Color = System.Drawing.Color.Gold;
            // 
            // pictureBoxHover
            // 
            this.pictureBoxHover.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBoxHover.Location = new System.Drawing.Point(15, 89);
            this.pictureBoxHover.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxHover.Name = "pictureBoxHover";
            this.pictureBoxHover.Size = new System.Drawing.Size(42, 35);
            this.pictureBoxHover.TabIndex = 9;
            this.pictureBoxHover.TabStop = false;
            this.pictureBoxHover.Visible = false;
            // 
            // saveImage
            // 
            this.saveImage.Filter = "PNG Image(*.png)|*.png";
            // 
            // myBoxControl
            // 
            this.myBoxControl.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.myBoxControl.AutoScroll = true;
            this.myBoxControl.BackColor = System.Drawing.Color.White;
            this.myBoxControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myBoxControl.Handler = null;
            this.myBoxControl.Location = new System.Drawing.Point(15, 89);
            this.myBoxControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.myBoxControl.Name = "myBoxControl";
            this.myBoxControl.SelectedFigure = null;
            this.myBoxControl.Size = new System.Drawing.Size(957, 589);
            this.myBoxControl.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 692);
            this.Controls.Add(this.pictureBoxHover);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.myBoxControl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(785, 608);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UML Creater \"Red Hot 21\"";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.bindingSource1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBoxHover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label3;
        private MyBoxControl myBoxControl;
        private ToolStrip toolStrip1;
        private ToolStripButton ObjectButton;
        private ToolStripButton associationLineButton;
        private ToolStripButton addictionLineButton;
        private ToolStripButton objectOneFieldButton;
        private ToolStripButton objectTwoFieldsButton;
        private ToolStripMenuItem saveProjectToolStripMenuItem;
        private ToolStripButton colorEdit;
        private ColorDialog colorDialog1;
        private System.Windows.Forms.PictureBox pictureBoxHover;
        private ToolStripButton realizationLineButton;
        private ToolStripButton inheritanceLineButton;
        private ToolStripButton compositionLineButton;
        private ToolStripButton aggregationLineButton;
        private ToolStripButton textEditor;
        private ToolStripMenuItem saveAsImageToolStripMenuItem;
        private SaveFileDialog saveImage;
    }
}