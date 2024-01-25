
namespace GraphicEditor
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonLine = new System.Windows.Forms.Button();
            this.ButtonRectangle = new System.Windows.Forms.Button();
            this.ButtonEllipse = new System.Windows.Forms.Button();
            this.GroupButton = new System.Windows.Forms.Button();
            this.UnGroupButton = new System.Windows.Forms.Button();
            this.UpLayer = new System.Windows.Forms.Button();
            this.DownLayer = new System.Windows.Forms.Button();
            this.AddLayer = new System.Windows.Forms.Button();
            this.DeleteLayer = new System.Windows.Forms.Button();
            this.VisibilityOff = new System.Windows.Forms.Button();
            this.VisibilityOn = new System.Windows.Forms.Button();
            this.VisibilityLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonLine
            // 
            this.ButtonLine.Location = new System.Drawing.Point(780, 26);
            this.ButtonLine.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonLine.Name = "ButtonLine";
            this.ButtonLine.Size = new System.Drawing.Size(75, 28);
            this.ButtonLine.TabIndex = 0;
            this.ButtonLine.Text = "Line";
            this.ButtonLine.UseVisualStyleBackColor = true;
            this.ButtonLine.Click += new System.EventHandler(this.ButtonLine_Click);
            // 
            // ButtonRectangle
            // 
            this.ButtonRectangle.Location = new System.Drawing.Point(780, 58);
            this.ButtonRectangle.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonRectangle.Name = "ButtonRectangle";
            this.ButtonRectangle.Size = new System.Drawing.Size(75, 28);
            this.ButtonRectangle.TabIndex = 1;
            this.ButtonRectangle.Text = "Rectangle";
            this.ButtonRectangle.UseVisualStyleBackColor = true;
            this.ButtonRectangle.Click += new System.EventHandler(this.ButtonRectangle_Click);
            // 
            // ButtonEllipse
            // 
            this.ButtonEllipse.Location = new System.Drawing.Point(780, 90);
            this.ButtonEllipse.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonEllipse.Name = "ButtonEllipse";
            this.ButtonEllipse.Size = new System.Drawing.Size(75, 28);
            this.ButtonEllipse.TabIndex = 2;
            this.ButtonEllipse.Text = "Ellipse";
            this.ButtonEllipse.UseVisualStyleBackColor = true;
            this.ButtonEllipse.Click += new System.EventHandler(this.ButtonEllipse_Click);
            // 
            // GroupButton
            // 
            this.GroupButton.Location = new System.Drawing.Point(780, 133);
            this.GroupButton.Margin = new System.Windows.Forms.Padding(2);
            this.GroupButton.Name = "GroupButton";
            this.GroupButton.Size = new System.Drawing.Size(75, 28);
            this.GroupButton.TabIndex = 3;
            this.GroupButton.Text = "Group";
            this.GroupButton.UseVisualStyleBackColor = true;
            this.GroupButton.Click += new System.EventHandler(this.GroupButton_Click);
            // 
            // UnGroupButton
            // 
            this.UnGroupButton.Location = new System.Drawing.Point(780, 165);
            this.UnGroupButton.Margin = new System.Windows.Forms.Padding(2);
            this.UnGroupButton.Name = "UnGroupButton";
            this.UnGroupButton.Size = new System.Drawing.Size(75, 28);
            this.UnGroupButton.TabIndex = 4;
            this.UnGroupButton.Text = "Ungroup";
            this.UnGroupButton.UseVisualStyleBackColor = true;
            this.UnGroupButton.Click += new System.EventHandler(this.UnGroupButton_Click);
            // 
            // UpLayer
            // 
            this.UpLayer.Location = new System.Drawing.Point(678, 393);
            this.UpLayer.Name = "UpLayer";
            this.UpLayer.Size = new System.Drawing.Size(43, 23);
            this.UpLayer.TabIndex = 7;
            this.UpLayer.Text = "/\\";
            this.UpLayer.UseVisualStyleBackColor = true;
            this.UpLayer.Click += new System.EventHandler(this.UpLayerButton_Click);
            // 
            // DownLayer
            // 
            this.DownLayer.Location = new System.Drawing.Point(727, 393);
            this.DownLayer.Name = "DownLayer";
            this.DownLayer.Size = new System.Drawing.Size(42, 23);
            this.DownLayer.TabIndex = 8;
            this.DownLayer.Text = "\\/";
            this.DownLayer.UseVisualStyleBackColor = true;
            this.DownLayer.Click += new System.EventHandler(this.DownLayerButton_Click);
            // 
            // AddLayer
            // 
            this.AddLayer.Location = new System.Drawing.Point(775, 393);
            this.AddLayer.Name = "AddLayer";
            this.AddLayer.Size = new System.Drawing.Size(42, 23);
            this.AddLayer.TabIndex = 9;
            this.AddLayer.Text = "Add";
            this.AddLayer.UseVisualStyleBackColor = true;
            this.AddLayer.Click += new System.EventHandler(this.AddLayerButton_Click);
            // 
            // DeleteLayer
            // 
            this.DeleteLayer.Location = new System.Drawing.Point(820, 393);
            this.DeleteLayer.Name = "DeleteLayer";
            this.DeleteLayer.Size = new System.Drawing.Size(42, 23);
            this.DeleteLayer.TabIndex = 10;
            this.DeleteLayer.Text = "Del";
            this.DeleteLayer.UseVisualStyleBackColor = true;
            this.DeleteLayer.Click += new System.EventHandler(this.DeleteLayerButton_Click);
            // 
            // VisibilityOff
            // 
            this.VisibilityOff.Location = new System.Drawing.Point(820, 364);
            this.VisibilityOff.Name = "VisibilityOff";
            this.VisibilityOff.Size = new System.Drawing.Size(42, 23);
            this.VisibilityOff.TabIndex = 12;
            this.VisibilityOff.Text = "Off";
            this.VisibilityOff.UseVisualStyleBackColor = true;
            this.VisibilityOff.Click += new System.EventHandler(this.VisibilityOffButton_Click);
            // 
            // VisibilityOn
            // 
            this.VisibilityOn.Location = new System.Drawing.Point(775, 364);
            this.VisibilityOn.Name = "VisibilityOn";
            this.VisibilityOn.Size = new System.Drawing.Size(42, 23);
            this.VisibilityOn.TabIndex = 13;
            this.VisibilityOn.Text = "On";
            this.VisibilityOn.UseVisualStyleBackColor = true;
            this.VisibilityOn.Click += new System.EventHandler(this.VisibilityOnButton_Click);
            // 
            // VisibilityLabel
            // 
            this.VisibilityLabel.AutoSize = true;
            this.VisibilityLabel.BackColor = System.Drawing.SystemColors.Window;
            this.VisibilityLabel.Location = new System.Drawing.Point(694, 369);
            this.VisibilityLabel.Name = "VisibilityLabel";
            this.VisibilityLabel.Size = new System.Drawing.Size(75, 13);
            this.VisibilityLabel.TabIndex = 14;
            this.VisibilityLabel.Text = "Layer Visibility:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 564);
            this.Controls.Add(this.VisibilityLabel);
            this.Controls.Add(this.VisibilityOn);
            this.Controls.Add(this.VisibilityOff);
            this.Controls.Add(this.DeleteLayer);
            this.Controls.Add(this.AddLayer);
            this.Controls.Add(this.DownLayer);
            this.Controls.Add(this.UpLayer);
            this.Controls.Add(this.UnGroupButton);
            this.Controls.Add(this.GroupButton);
            this.Controls.Add(this.ButtonEllipse);
            this.Controls.Add(this.ButtonRectangle);
            this.Controls.Add(this.ButtonLine);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ButtonLine;
        private System.Windows.Forms.Button ButtonRectangle;
        private System.Windows.Forms.Button ButtonEllipse;
        private System.Windows.Forms.Button GroupButton;
        private System.Windows.Forms.Button UnGroupButton;
        private System.Windows.Forms.Button UpLayer;
        private System.Windows.Forms.Button DownLayer;
        private System.Windows.Forms.Button AddLayer;
        private System.Windows.Forms.Button DeleteLayer;
        private System.Windows.Forms.Button VisibilityOff;
        private System.Windows.Forms.Button VisibilityOn;
        private System.Windows.Forms.Label VisibilityLabel;
    }
}

