namespace MlpProject
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
            this.button1 = new System.Windows.Forms.Button();
            this.radioButtonIris = new System.Windows.Forms.RadioButton();
            this.radioButtonMushroom = new System.Windows.Forms.RadioButton();
            this.radioButtonVine = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxNeuron1 = new System.Windows.Forms.TextBox();
            this.textBoxNeuron2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxLearningRate = new System.Windows.Forms.TextBox();
            this.textBoxMaxError = new System.Windows.Forms.TextBox();
            this.textBoxMaxIteration = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(84, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(228, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Train";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButtonIris
            // 
            this.radioButtonIris.AutoSize = true;
            this.radioButtonIris.Checked = true;
            this.radioButtonIris.Location = new System.Drawing.Point(4, 8);
            this.radioButtonIris.Name = "radioButtonIris";
            this.radioButtonIris.Size = new System.Drawing.Size(38, 17);
            this.radioButtonIris.TabIndex = 1;
            this.radioButtonIris.TabStop = true;
            this.radioButtonIris.Text = "Iris";
            this.radioButtonIris.UseVisualStyleBackColor = true;
            // 
            // radioButtonMushroom
            // 
            this.radioButtonMushroom.AutoSize = true;
            this.radioButtonMushroom.Location = new System.Drawing.Point(4, 38);
            this.radioButtonMushroom.Name = "radioButtonMushroom";
            this.radioButtonMushroom.Size = new System.Drawing.Size(92, 17);
            this.radioButtonMushroom.TabIndex = 2;
            this.radioButtonMushroom.Text = "Breast Cancer";
            this.radioButtonMushroom.UseVisualStyleBackColor = true;
            // 
            // radioButtonVine
            // 
            this.radioButtonVine.AutoSize = true;
            this.radioButtonVine.Location = new System.Drawing.Point(4, 71);
            this.radioButtonVine.Name = "radioButtonVine";
            this.radioButtonVine.Size = new System.Drawing.Size(46, 17);
            this.radioButtonVine.TabIndex = 3;
            this.radioButtonVine.Text = "Vine";
            this.radioButtonVine.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Data Set:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.radioButtonIris);
            this.panel1.Controls.Add(this.radioButtonMushroom);
            this.panel1.Controls.Add(this.radioButtonVine);
            this.panel1.Location = new System.Drawing.Point(28, 51);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(99, 109);
            this.panel1.TabIndex = 5;
            // 
            // textBoxNeuron1
            // 
            this.textBoxNeuron1.Location = new System.Drawing.Point(278, 26);
            this.textBoxNeuron1.Name = "textBoxNeuron1";
            this.textBoxNeuron1.Size = new System.Drawing.Size(100, 20);
            this.textBoxNeuron1.TabIndex = 6;
            this.textBoxNeuron1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNeuron1_KeyPress);
            // 
            // textBoxNeuron2
            // 
            this.textBoxNeuron2.Location = new System.Drawing.Point(278, 65);
            this.textBoxNeuron2.Name = "textBoxNeuron2";
            this.textBoxNeuron2.Size = new System.Drawing.Size(100, 20);
            this.textBoxNeuron2.TabIndex = 7;
            this.textBoxNeuron2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNeuron2_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Hidden Layer 1 Neurons:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Hidden Layer 2 Neurons:";
            // 
            // textBoxLearningRate
            // 
            this.textBoxLearningRate.Location = new System.Drawing.Point(278, 101);
            this.textBoxLearningRate.Name = "textBoxLearningRate";
            this.textBoxLearningRate.Size = new System.Drawing.Size(100, 20);
            this.textBoxLearningRate.TabIndex = 10;
            this.textBoxLearningRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxLearningRate_KeyPress);
            // 
            // textBoxMaxError
            // 
            this.textBoxMaxError.Location = new System.Drawing.Point(278, 139);
            this.textBoxMaxError.Name = "textBoxMaxError";
            this.textBoxMaxError.Size = new System.Drawing.Size(100, 20);
            this.textBoxMaxError.TabIndex = 11;
            this.textBoxMaxError.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMaxError_KeyPress);
            // 
            // textBoxMaxIteration
            // 
            this.textBoxMaxIteration.Location = new System.Drawing.Point(278, 175);
            this.textBoxMaxIteration.Name = "textBoxMaxIteration";
            this.textBoxMaxIteration.Size = new System.Drawing.Size(100, 20);
            this.textBoxMaxIteration.TabIndex = 12;
            this.textBoxMaxIteration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMaxIteration_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Learning Rate:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(217, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Max Error:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(195, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Max Iterations:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 281);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxMaxIteration);
            this.Controls.Add(this.textBoxMaxError);
            this.Controls.Add(this.textBoxLearningRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNeuron2);
            this.Controls.Add(this.textBoxNeuron1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButtonIris;
        private System.Windows.Forms.RadioButton radioButtonMushroom;
        private System.Windows.Forms.RadioButton radioButtonVine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxNeuron1;
        private System.Windows.Forms.TextBox textBoxNeuron2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxLearningRate;
        private System.Windows.Forms.TextBox textBoxMaxError;
        private System.Windows.Forms.TextBox textBoxMaxIteration;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

