
namespace BasementWall
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
            this.concreteClass = new System.Windows.Forms.Label();
            this.concreteClassValue = new System.Windows.Forms.ComboBox();
            this.concreteThickness = new System.Windows.Forms.Label();
            this.concreteThicknessValue = new System.Windows.Forms.TextBox();
            this.rebar = new System.Windows.Forms.Label();
            this.rebarClass = new System.Windows.Forms.ComboBox();
            this.cancle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.confirm = new System.Windows.Forms.Button();
            this.rebarRataion = new System.Windows.Forms.Label();
            this.minRebarRation = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // concreteClass
            // 
            this.concreteClass.AutoSize = true;
            this.concreteClass.Location = new System.Drawing.Point(15, 15);
            this.concreteClass.Name = "concreteClass";
            this.concreteClass.Size = new System.Drawing.Size(107, 12);
            this.concreteClass.TabIndex = 1;
            this.concreteClass.Text = "       混凝土等级";
            // 
            // concreteClassValue
            // 
            this.concreteClassValue.DisplayMember = "C35";
            this.concreteClassValue.FormattingEnabled = true;
            this.concreteClassValue.Items.AddRange(new object[] {
            "C25",
            "C30",
            "C35",
            "C40",
            "C45",
            "C50",
            "C55",
            "C60"});
            this.concreteClassValue.Location = new System.Drawing.Point(130, 12);
            this.concreteClassValue.Name = "concreteClassValue";
            this.concreteClassValue.Size = new System.Drawing.Size(120, 20);
            this.concreteClassValue.TabIndex = 2;
            this.concreteClassValue.Tag = "";
            this.concreteClassValue.ValueMember = "3";
            // 
            // concreteThickness
            // 
            this.concreteThickness.AutoSize = true;
            this.concreteThickness.Location = new System.Drawing.Point(15, 45);
            this.concreteThickness.Name = "concreteThickness";
            this.concreteThickness.Size = new System.Drawing.Size(107, 12);
            this.concreteThickness.TabIndex = 3;
            this.concreteThickness.Text = "       保护层厚度";
            // 
            // concreteThicknessValue
            // 
            this.concreteThicknessValue.Location = new System.Drawing.Point(130, 42);
            this.concreteThicknessValue.Name = "concreteThicknessValue";
            this.concreteThicknessValue.Size = new System.Drawing.Size(120, 21);
            this.concreteThicknessValue.TabIndex = 4;
            this.concreteThicknessValue.Text = "15";
            // 
            // rebar
            // 
            this.rebar.AutoSize = true;
            this.rebar.Location = new System.Drawing.Point(15, 75);
            this.rebar.Name = "rebar";
            this.rebar.Size = new System.Drawing.Size(101, 12);
            this.rebar.TabIndex = 6;
            this.rebar.Text = "        钢筋等级";
            // 
            // rebarClass
            // 
            this.rebarClass.DisplayMember = "HRB400";
            this.rebarClass.FormattingEnabled = true;
            this.rebarClass.Items.AddRange(new object[] {
            "HPB300",
            "HRB335",
            "HRB400",
            "HRB500"});
            this.rebarClass.Location = new System.Drawing.Point(130, 72);
            this.rebarClass.Name = "rebarClass";
            this.rebarClass.Size = new System.Drawing.Size(120, 20);
            this.rebarClass.TabIndex = 7;
            // 
            // cancle
            // 
            this.cancle.Location = new System.Drawing.Point(41, 165);
            this.cancle.Name = "cancle";
            this.cancle.Size = new System.Drawing.Size(75, 23);
            this.cancle.TabIndex = 8;
            this.cancle.Text = "取消";
            this.cancle.UseVisualStyleBackColor = true;
            this.cancle.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "裂缝宽度限值（mm）";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(130, 100);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 21);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "0.3";
            // 
            // confirm
            // 
            this.confirm.Location = new System.Drawing.Point(160, 165);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(75, 23);
            this.confirm.TabIndex = 11;
            this.confirm.Text = "确定";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // rebarRataion
            // 
            this.rebarRataion.AutoSize = true;
            this.rebarRataion.Location = new System.Drawing.Point(15, 135);
            this.rebarRataion.Name = "rebarRataion";
            this.rebarRataion.Size = new System.Drawing.Size(107, 12);
            this.rebarRataion.TabIndex = 12;
            this.rebarRataion.Text = "  最小配筋率（%）";
            // 
            // minRebarRation
            // 
            this.minRebarRation.Location = new System.Drawing.Point(130, 132);
            this.minRebarRation.Name = "minRebarRation";
            this.minRebarRation.Size = new System.Drawing.Size(120, 21);
            this.minRebarRation.TabIndex = 13;
            this.minRebarRation.Text = "0.2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.minRebarRation);
            this.Controls.Add(this.rebarRataion);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancle);
            this.Controls.Add(this.rebarClass);
            this.Controls.Add(this.rebar);
            this.Controls.Add(this.concreteThicknessValue);
            this.Controls.Add(this.concreteThickness);
            this.Controls.Add(this.concreteClassValue);
            this.Controls.Add(this.concreteClass);
            this.Name = "Form1";
            this.Text = "地下室外墙参数";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label concreteClass;
        private System.Windows.Forms.ComboBox concreteClassValue;
        private System.Windows.Forms.Label concreteThickness;
        private System.Windows.Forms.TextBox concreteThicknessValue;
        private System.Windows.Forms.Label rebar;
        private System.Windows.Forms.ComboBox rebarClass;
        private System.Windows.Forms.Button cancle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Label rebarRataion;
        private System.Windows.Forms.TextBox minRebarRation;
    }
}