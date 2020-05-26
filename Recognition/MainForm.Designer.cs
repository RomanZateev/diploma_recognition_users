namespace Recognition
{
    partial class MainForm
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
            this.calculate = new System.Windows.Forms.Button();
            this.method = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.user = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chooseFile = new System.Windows.Forms.Button();
            this.far = new System.Windows.Forms.TextBox();
            this.frr = new System.Windows.Forms.TextBox();
            this.correctness = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // calculate
            // 
            this.calculate.Location = new System.Drawing.Point(356, 222);
            this.calculate.Name = "calculate";
            this.calculate.Size = new System.Drawing.Size(139, 32);
            this.calculate.TabIndex = 0;
            this.calculate.Text = "Рассчитать";
            this.calculate.UseVisualStyleBackColor = true;
            this.calculate.Click += new System.EventHandler(this.calculate_Click);
            // 
            // method
            // 
            this.method.FormattingEnabled = true;
            this.method.Location = new System.Drawing.Point(39, 199);
            this.method.Name = "method";
            this.method.Size = new System.Drawing.Size(235, 21);
            this.method.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Метод распознавания:";
            // 
            // user
            // 
            this.user.FormattingEnabled = true;
            this.user.Location = new System.Drawing.Point(39, 132);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(235, 21);
            this.user.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Пользователь системы:";
            // 
            // chooseFile
            // 
            this.chooseFile.Location = new System.Drawing.Point(39, 54);
            this.chooseFile.Name = "chooseFile";
            this.chooseFile.Size = new System.Drawing.Size(235, 27);
            this.chooseFile.TabIndex = 5;
            this.chooseFile.Text = "Выбрать";
            this.chooseFile.UseVisualStyleBackColor = true;
            this.chooseFile.Click += new System.EventHandler(this.chooseFile_Click);
            // 
            // far
            // 
            this.far.Location = new System.Drawing.Point(413, 76);
            this.far.Name = "far";
            this.far.Size = new System.Drawing.Size(82, 20);
            this.far.TabIndex = 6;
            // 
            // frr
            // 
            this.frr.Location = new System.Drawing.Point(413, 129);
            this.frr.Name = "frr";
            this.frr.Size = new System.Drawing.Size(82, 20);
            this.frr.TabIndex = 7;
            // 
            // correctness
            // 
            this.correctness.Location = new System.Drawing.Point(413, 180);
            this.correctness.Name = "correctness";
            this.correctness.Size = new System.Drawing.Size(82, 20);
            this.correctness.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Пусть к файлу:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(353, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "FAR:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(353, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "FRR:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(353, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Точность:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(410, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Ошибки";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 274);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.correctness);
            this.Controls.Add(this.frr);
            this.Controls.Add(this.far);
            this.Controls.Add(this.chooseFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.user);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.method);
            this.Controls.Add(this.calculate);
            this.Name = "MainForm";
            this.Text = "Распознавание";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button calculate;
        private System.Windows.Forms.ComboBox method;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox user;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button chooseFile;
        private System.Windows.Forms.TextBox far;
        private System.Windows.Forms.TextBox frr;
        private System.Windows.Forms.TextBox correctness;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

