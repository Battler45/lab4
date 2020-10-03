using System;

namespace lab4
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
            this._canvas = new System.Windows.Forms.PictureBox();
            this.polygonDrawingButton = new System.Windows.Forms.Button();
            this.edgeDrawingButton = new System.Windows.Forms.Button();
            this.offsetButton = new System.Windows.Forms.Button();
            this.offsetXTextBox = new System.Windows.Forms.TextBox();
            this.offsetYTextBox = new System.Windows.Forms.TextBox();
            this.primitiveRotationButton = new System.Windows.Forms.Button();
            this.rotationAngleInDegreesTextBox = new System.Windows.Forms.TextBox();
            this.scalingButton = new System.Windows.Forms.Button();
            this.scaleTextBox = new System.Windows.Forms.TextBox();
            this.rotationAroundPointButton = new System.Windows.Forms.Button();
            this.rotationAroundPointAngleDegrees = new System.Windows.Forms.TextBox();
            this.rotationAroundPointOrigin = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // _canvas
            // 
            this._canvas.Location = new System.Drawing.Point(2, 2);
            this._canvas.Name = "_canvas";
            this._canvas.Size = new System.Drawing.Size(587, 444);
            this._canvas.TabIndex = 0;
            this._canvas.TabStop = false;
            this._canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            // 
            // polygonDrawingButton
            // 
            this.polygonDrawingButton.Location = new System.Drawing.Point(595, 41);
            this.polygonDrawingButton.Name = "polygonDrawingButton";
            this.polygonDrawingButton.Size = new System.Drawing.Size(114, 23);
            this.polygonDrawingButton.TabIndex = 1;
            this.polygonDrawingButton.Text = "Многоугольник";
            this.polygonDrawingButton.UseVisualStyleBackColor = true;
            this.polygonDrawingButton.Click += new System.EventHandler(this.primitiveDrawingButton_Click);
            // 
            // edgeDrawingButton
            // 
            this.edgeDrawingButton.Location = new System.Drawing.Point(595, 12);
            this.edgeDrawingButton.Name = "edgeDrawingButton";
            this.edgeDrawingButton.Size = new System.Drawing.Size(114, 23);
            this.edgeDrawingButton.TabIndex = 2;
            this.edgeDrawingButton.Text = "Ребро";
            this.edgeDrawingButton.UseVisualStyleBackColor = true;
            this.edgeDrawingButton.Click += new System.EventHandler(this.primitiveDrawingButton_Click);
            // 
            // offsetButton
            // 
            this.offsetButton.Location = new System.Drawing.Point(595, 70);
            this.offsetButton.Name = "offsetButton";
            this.offsetButton.Size = new System.Drawing.Size(75, 23);
            this.offsetButton.TabIndex = 3;
            this.offsetButton.Text = "Перенос";
            this.offsetButton.UseVisualStyleBackColor = true;
            this.offsetButton.Click += new System.EventHandler(this.offsetButton_Click);
            // 
            // offsetXTextBox
            // 
            this.offsetXTextBox.Location = new System.Drawing.Point(676, 72);
            this.offsetXTextBox.Name = "offsetXTextBox";
            this.offsetXTextBox.Size = new System.Drawing.Size(33, 20);
            this.offsetXTextBox.TabIndex = 4;
            this.offsetXTextBox.Text = "50";
            this.offsetXTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // offsetYTextBox
            // 
            this.offsetYTextBox.Location = new System.Drawing.Point(716, 72);
            this.offsetYTextBox.Name = "offsetYTextBox";
            this.offsetYTextBox.Size = new System.Drawing.Size(31, 20);
            this.offsetYTextBox.TabIndex = 5;
            this.offsetYTextBox.Text = "50";
            this.offsetYTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // primitiveRotationButton
            // 
            this.primitiveRotationButton.Location = new System.Drawing.Point(595, 102);
            this.primitiveRotationButton.Name = "primitiveRotationButton";
            this.primitiveRotationButton.Size = new System.Drawing.Size(75, 23);
            this.primitiveRotationButton.TabIndex = 6;
            this.primitiveRotationButton.Text = "Поворот";
            this.primitiveRotationButton.UseVisualStyleBackColor = true;
            this.primitiveRotationButton.Click += new System.EventHandler(this.primitiveRotationButton_Click);
            // 
            // rotationAngleInDegreesTextBox
            // 
            this.rotationAngleInDegreesTextBox.Location = new System.Drawing.Point(676, 102);
            this.rotationAngleInDegreesTextBox.Name = "rotationAngleInDegreesTextBox";
            this.rotationAngleInDegreesTextBox.Size = new System.Drawing.Size(33, 20);
            this.rotationAngleInDegreesTextBox.TabIndex = 7;
            this.rotationAngleInDegreesTextBox.Text = "90";
            // 
            // scalingButton
            // 
            this.scalingButton.Location = new System.Drawing.Point(595, 132);
            this.scalingButton.Name = "scalingButton";
            this.scalingButton.Size = new System.Drawing.Size(75, 23);
            this.scalingButton.TabIndex = 8;
            this.scalingButton.Text = "Масштаб";
            this.scalingButton.UseVisualStyleBackColor = true;
            this.scalingButton.Click += new System.EventHandler(this.scalingButton_Click);
            // 
            // scaleTextBox
            // 
            this.scaleTextBox.Location = new System.Drawing.Point(676, 132);
            this.scaleTextBox.Name = "scaleTextBox";
            this.scaleTextBox.Size = new System.Drawing.Size(33, 20);
            this.scaleTextBox.TabIndex = 9;
            this.scaleTextBox.Text = "125";
            // 
            // rotationAroundPointButton
            // 
            this.rotationAroundPointButton.Location = new System.Drawing.Point(596, 191);
            this.rotationAroundPointButton.Name = "rotationAroundPointButton";
            this.rotationAroundPointButton.Size = new System.Drawing.Size(113, 23);
            this.rotationAroundPointButton.TabIndex = 11;
            this.rotationAroundPointButton.Text = "Поворот";
            this.rotationAroundPointButton.UseVisualStyleBackColor = true;
            this.rotationAroundPointButton.Click += new System.EventHandler(this.rotationAroundPointButton_Click);
            // 
            // rotationAroundPointAngleDegrees
            // 
            this.rotationAroundPointAngleDegrees.Location = new System.Drawing.Point(716, 193);
            this.rotationAroundPointAngleDegrees.Name = "rotationAroundPointAngleDegrees";
            this.rotationAroundPointAngleDegrees.Size = new System.Drawing.Size(31, 20);
            this.rotationAroundPointAngleDegrees.TabIndex = 12;
            this.rotationAroundPointAngleDegrees.Text = "угол";
            // 
            // rotationAroundPointOrigin
            // 
            this.rotationAroundPointOrigin.Location = new System.Drawing.Point(753, 193);
            this.rotationAroundPointOrigin.Name = "rotationAroundPointOrigin";
            this.rotationAroundPointOrigin.Size = new System.Drawing.Size(35, 20);
            this.rotationAroundPointOrigin.TabIndex = 13;
            this.rotationAroundPointOrigin.Text = "точка";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(596, 221);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(151, 23);
            this.button8.TabIndex = 14;
            this.button8.Text = "Пересечение рёбер";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(596, 251);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(113, 23);
            this.button9.TabIndex = 15;
            this.button9.Text = "Выпуклый мног.";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(596, 281);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(113, 23);
            this.button10.TabIndex = 16;
            this.button10.Text = "Невыпукл. мног.";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(596, 311);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(113, 23);
            this.button11.TabIndex = 17;
            this.button11.Text = "Положение точки";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.rotationAroundPointOrigin);
            this.Controls.Add(this.rotationAroundPointAngleDegrees);
            this.Controls.Add(this.rotationAroundPointButton);
            this.Controls.Add(this.scaleTextBox);
            this.Controls.Add(this.scalingButton);
            this.Controls.Add(this.rotationAngleInDegreesTextBox);
            this.Controls.Add(this.primitiveRotationButton);
            this.Controls.Add(this.offsetYTextBox);
            this.Controls.Add(this.offsetXTextBox);
            this.Controls.Add(this.offsetButton);
            this.Controls.Add(this.edgeDrawingButton);
            this.Controls.Add(this.polygonDrawingButton);
            this.Controls.Add(this._canvas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this._canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _canvas;
        private System.Windows.Forms.Button polygonDrawingButton;
        private System.Windows.Forms.Button edgeDrawingButton;
        private System.Windows.Forms.Button offsetButton;
        private System.Windows.Forms.TextBox offsetXTextBox;
        private System.Windows.Forms.TextBox offsetYTextBox;
        private System.Windows.Forms.Button primitiveRotationButton;
        private System.Windows.Forms.TextBox rotationAngleInDegreesTextBox;
        private System.Windows.Forms.Button scalingButton;
        private System.Windows.Forms.TextBox scaleTextBox;
        private System.Windows.Forms.Button rotationAroundPointButton;
        private System.Windows.Forms.TextBox rotationAroundPointAngleDegrees;
        private System.Windows.Forms.TextBox rotationAroundPointOrigin;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
    }
}

