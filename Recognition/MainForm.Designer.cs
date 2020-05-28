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
            this.RecognizeSession = new System.Windows.Forms.Button();
            this.ChooseMethod = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ChooseFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.AllSessions = new System.Windows.Forms.TextBox();
            this.SessionIndex = new System.Windows.Forms.TextBox();
            this.MethodsAccuracy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RecognizeSession
            // 
            this.RecognizeSession.Location = new System.Drawing.Point(90, 253);
            this.RecognizeSession.Name = "RecognizeSession";
            this.RecognizeSession.Size = new System.Drawing.Size(139, 42);
            this.RecognizeSession.TabIndex = 0;
            this.RecognizeSession.Text = "Распознать";
            this.RecognizeSession.UseVisualStyleBackColor = true;
            this.RecognizeSession.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // ChooseMethod
            // 
            this.ChooseMethod.FormattingEnabled = true;
            this.ChooseMethod.Location = new System.Drawing.Point(42, 185);
            this.ChooseMethod.Name = "ChooseMethod";
            this.ChooseMethod.Size = new System.Drawing.Size(235, 21);
            this.ChooseMethod.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Метод распознавания:";
            // 
            // ChooseFile
            // 
            this.ChooseFile.Location = new System.Drawing.Point(39, 54);
            this.ChooseFile.Name = "ChooseFile";
            this.ChooseFile.Size = new System.Drawing.Size(238, 27);
            this.ChooseFile.TabIndex = 5;
            this.ChooseFile.Text = "Выбрать";
            this.ChooseFile.UseVisualStyleBackColor = true;
            this.ChooseFile.Click += new System.EventHandler(this.ChooseFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Путь к файлу:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Сессий в файле:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Выбрать номер сессии:";
            // 
            // AllSessions
            // 
            this.AllSessions.Location = new System.Drawing.Point(173, 101);
            this.AllSessions.Name = "AllSessions";
            this.AllSessions.ReadOnly = true;
            this.AllSessions.Size = new System.Drawing.Size(80, 20);
            this.AllSessions.TabIndex = 16;
            // 
            // SessionIndex
            // 
            this.SessionIndex.Location = new System.Drawing.Point(173, 133);
            this.SessionIndex.Name = "SessionIndex";
            this.SessionIndex.Size = new System.Drawing.Size(80, 20);
            this.SessionIndex.TabIndex = 17;
            // 
            // MethodsAccuracy
            // 
            this.MethodsAccuracy.Location = new System.Drawing.Point(42, 212);
            this.MethodsAccuracy.Name = "MethodsAccuracy";
            this.MethodsAccuracy.Size = new System.Drawing.Size(235, 24);
            this.MethodsAccuracy.TabIndex = 20;
            this.MethodsAccuracy.Text = "Точность методов";
            this.MethodsAccuracy.UseVisualStyleBackColor = true;
            this.MethodsAccuracy.Click += new System.EventHandler(this.MethodsAccuracy_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 310);
            this.Controls.Add(this.MethodsAccuracy);
            this.Controls.Add(this.SessionIndex);
            this.Controls.Add(this.AllSessions);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ChooseFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChooseMethod);
            this.Controls.Add(this.RecognizeSession);
            this.Name = "MainForm";
            this.Text = "Распознавание";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RecognizeSession;
        private System.Windows.Forms.ComboBox ChooseMethod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ChooseFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox AllSessions;
        private System.Windows.Forms.TextBox SessionIndex;
        private System.Windows.Forms.Button MethodsAccuracy;
    }
}

