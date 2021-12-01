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
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.ListLine = new System.Windows.Forms.ListBox();
            this.ObjectList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ObjectButton = new System.Windows.Forms.ToolStripButton();
            this.objectOneFieldButton = new System.Windows.Forms.ToolStripButton();
            this.objectTwoFieldsButton = new System.Windows.Forms.ToolStripButton();
            this.associationLineButton = new System.Windows.Forms.ToolStripButton();
            this.inheritanceLineButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.myBoxControl = new UML_Logic_Library.MyBoxControl();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(984, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createProjectToolStripMenuItem,
            this.loadProjectToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.createToolStripMenuItem.Text = "File";
            // 
            // createProjectToolStripMenuItem
            // 
            this.createProjectToolStripMenuItem.Name = "createProjectToolStripMenuItem";
            this.createProjectToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.createProjectToolStripMenuItem.Text = "Create Project";
            this.createProjectToolStripMenuItem.Click += new System.EventHandler(this.createProjectToolStripMenuItem_Click);
            // 
            // loadProjectToolStripMenuItem
            // 
            this.loadProjectToolStripMenuItem.Name = "loadProjectToolStripMenuItem";
            this.loadProjectToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.loadProjectToolStripMenuItem.Text = "Load Project";
            this.loadProjectToolStripMenuItem.Click += new System.EventHandler(this.loadProjectToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(223, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(78, 29);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(14, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Стрелки";
            // 
            // ListLine
            // 
            this.ListLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListLine.FormattingEnabled = true;
            this.ListLine.ItemHeight = 20;
            this.ListLine.Items.AddRange(new object[] {
            "Линия",
            "Ассоциация",
            "Агрегация",
            "Реализация",
            "Композиция",
            "Наследование"});
            this.ListLine.Location = new System.Drawing.Point(14, 116);
            this.ListLine.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ListLine.Name = "ListLine";
            this.ListLine.Size = new System.Drawing.Size(153, 142);
            this.ListLine.TabIndex = 3;
            this.ListLine.SelectedIndexChanged += new System.EventHandler(this.ListLine_SelectedIndexChanged);
            this.ListLine.Leave += new System.EventHandler(this.ListLine_Leave);
            this.ListLine.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListLine_MouseDoubleClick);
            // 
            // ObjectList
            // 
            this.ObjectList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ObjectList.FormattingEnabled = true;
            this.ObjectList.ItemHeight = 20;
            this.ObjectList.Items.AddRange(new object[] {
            "Обьект",
            "Обьект с полем",
            "Обьект с двумя полями"});
            this.ObjectList.Location = new System.Drawing.Point(14, 330);
            this.ObjectList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ObjectList.Name = "ObjectList";
            this.ObjectList.Size = new System.Drawing.Size(153, 82);
            this.ObjectList.TabIndex = 4;
            this.ObjectList.Leave += new System.EventHandler(this.ObjectList_Leave);
            this.ObjectList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ObjectList_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(14, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Обьекты";
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
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ObjectButton,
            this.objectOneFieldButton,
            this.objectTwoFieldsButton,
            this.associationLineButton,
            this.inheritanceLineButton,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 33);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(984, 33);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ObjectButton
            // 
            this.ObjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ObjectButton.Image = ((System.Drawing.Image)(resources.GetObject("ObjectButton.Image")));
            this.ObjectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ObjectButton.Name = "ObjectButton";
            this.ObjectButton.Size = new System.Drawing.Size(34, 28);
            this.ObjectButton.Text = "Object";
            this.ObjectButton.Click += new System.EventHandler(this.ObjectButton_Click);
            // 
            // objectOneFieldButton
            // 
            this.objectOneFieldButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.objectOneFieldButton.Image = ((System.Drawing.Image)(resources.GetObject("objectOneFieldButton.Image")));
            this.objectOneFieldButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.objectOneFieldButton.Name = "objectOneFieldButton";
            this.objectOneFieldButton.Size = new System.Drawing.Size(34, 28);
            this.objectOneFieldButton.Text = "toolStripButton2";
            this.objectOneFieldButton.Click += new System.EventHandler(this.objectOneFieldButton_Click);
            // 
            // objectTwoFieldsButton
            // 
            this.objectTwoFieldsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.objectTwoFieldsButton.Image = ((System.Drawing.Image)(resources.GetObject("objectTwoFieldsButton.Image")));
            this.objectTwoFieldsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.objectTwoFieldsButton.Name = "objectTwoFieldsButton";
            this.objectTwoFieldsButton.Size = new System.Drawing.Size(34, 28);
            this.objectTwoFieldsButton.Text = "toolStripButton2";
            this.objectTwoFieldsButton.Click += new System.EventHandler(this.objectTwoFieldsButton_Click);
            // 
            // associationLineButton
            // 
            this.associationLineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.associationLineButton.Image = ((System.Drawing.Image)(resources.GetObject("associationLineButton.Image")));
            this.associationLineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.associationLineButton.Name = "associationLineButton";
            this.associationLineButton.Size = new System.Drawing.Size(34, 28);
            this.associationLineButton.Text = "toolStripButton1";
            this.associationLineButton.Click += new System.EventHandler(this.associationLineButton_Click);
            // 
            // inheritanceLineButton
            // 
            this.inheritanceLineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.inheritanceLineButton.Image = ((System.Drawing.Image)(resources.GetObject("inheritanceLineButton.Image")));
            this.inheritanceLineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.inheritanceLineButton.Name = "inheritanceLineButton";
            this.inheritanceLineButton.Size = new System.Drawing.Size(34, 28);
            this.inheritanceLineButton.Text = "toolStripButton1";
            this.inheritanceLineButton.Click += new System.EventHandler(this.inheritanceLineButton_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.BackColor = System.Drawing.Color.Red;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(34, 28);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // myBoxControl
            // 
            this.myBoxControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myBoxControl.AutoScroll = true;
            this.myBoxControl.BackColor = System.Drawing.Color.White;
            this.myBoxControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.myBoxControl.Handler = null;
            this.myBoxControl.Location = new System.Drawing.Point(211, 89);
            this.myBoxControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.myBoxControl.Name = "myBoxControl";
            this.myBoxControl.SelectedFigure = null;
            this.myBoxControl.Size = new System.Drawing.Size(760, 589);
            this.myBoxControl.TabIndex = 7;
            this.myBoxControl.DoubleClick += new System.EventHandler(this.myBoxControl_DoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 692);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.myBoxControl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ObjectList);
            this.Controls.Add(this.ListLine);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(785, 611);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UML Creater \"Red Hot 21\"";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ListBox ListLine;
        private System.Windows.Forms.ListBox ObjectList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label3;
        private MyBoxControl myBoxControl;
        private ToolStrip toolStrip1;
        private ToolStripButton ObjectButton;
        private ToolStripButton associationLineButton;
        private ToolStripButton inheritanceLineButton;
        private ToolStripButton objectOneFieldButton;
        private ToolStripButton objectTwoFieldsButton;
        private ToolStripButton toolStripButton2;
    }
}