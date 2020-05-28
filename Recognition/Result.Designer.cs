namespace Recognition
{
    partial class Result
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
            this.label1 = new System.Windows.Forms.Label();
            this.UserLogin = new System.Windows.Forms.TextBox();
            this.listView = new System.Windows.Forms.ListView();
            this.Номер = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Логин = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Расстояние = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Системой идентифицирован пользователь:\r\n";
            // 
            // UserLogin
            // 
            this.UserLogin.Location = new System.Drawing.Point(260, 26);
            this.UserLogin.Name = "UserLogin";
            this.UserLogin.ReadOnly = true;
            this.UserLogin.Size = new System.Drawing.Size(98, 20);
            this.UserLogin.TabIndex = 2;
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Номер,
            this.Логин,
            this.Расстояние});
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(28, 84);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(330, 172);
            this.listView.TabIndex = 3;
            this.listView.UseCompatibleStateImageBehavior = false;
            // 
            // Номер
            // 
            this.Номер.Text = "Номер";
            this.Номер.Width = 50;
            // 
            // Логин
            // 
            this.Логин.Text = "Логин";
            this.Логин.Width = 100;
            // 
            // Расстояние
            // 
            this.Расстояние.Text = "Расстояние";
            this.Расстояние.Width = 175;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Оценка расстояний";
            // 
            // Result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 269);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.UserLogin);
            this.Controls.Add(this.label1);
            this.Name = "Result";
            this.Text = "Result";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserLogin;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader Логин;
        private System.Windows.Forms.ColumnHeader Расстояние;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader Номер;
    }
}