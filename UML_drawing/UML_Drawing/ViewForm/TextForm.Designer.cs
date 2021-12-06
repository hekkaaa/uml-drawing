﻿
namespace UML_drawing.ViewForm
{
    partial class TextForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextForm));
            this.OkTextButton = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.fontEditor = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OkTextButton
            // 
            this.OkTextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkTextButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OkTextButton.Location = new System.Drawing.Point(250, 174);
            this.OkTextButton.Name = "OkTextButton";
            this.OkTextButton.Size = new System.Drawing.Size(153, 48);
            this.OkTextButton.TabIndex = 1;
            this.OkTextButton.Text = "OK";
            this.OkTextButton.UseVisualStyleBackColor = true;
            this.OkTextButton.Click += new System.EventHandler(this.OkTextButton_Click);
            // 
            // fontEditor
            // 
            this.fontEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fontEditor.BackColor = System.Drawing.Color.White;
            this.fontEditor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("fontEditor.BackgroundImage")));
            this.fontEditor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.fontEditor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fontEditor.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.fontEditor.FlatAppearance.BorderSize = 0;
            this.fontEditor.Location = new System.Drawing.Point(12, 147);
            this.fontEditor.Name = "fontEditor";
            this.fontEditor.Size = new System.Drawing.Size(42, 42);
            this.fontEditor.TabIndex = 3;
            this.fontEditor.UseVisualStyleBackColor = false;
            this.fontEditor.Click += new System.EventHandler(this.fontEditor_Click);
            // 
            // Title
            // 
            this.Title.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Title.Location = new System.Drawing.Point(153, 20);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(108, 27);
            this.Title.TabIndex = 6;
            this.Title.Text = "Название";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox.Location = new System.Drawing.Point(12, 61);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(391, 80);
            this.textBox.TabIndex = 0;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // TextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 234);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.fontEditor);
            this.Controls.Add(this.OkTextButton);
            this.Controls.Add(this.textBox);
            this.Name = "TextForm";
            this.Text = "Редактирование текста";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button OkTextButton;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button fontEditor;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.TextBox textBox;
    }
}