namespace Recognition
{
    partial class Errors
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
            this.listView = new System.Windows.Forms.ListView();
            this.Метод = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FAR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FRR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Точность = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Метод,
            this.FAR,
            this.FRR,
            this.Точность});
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(12, 55);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(400, 181);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            // 
            // Метод
            // 
            this.Метод.Text = "Метод";
            this.Метод.Width = 200;
            // 
            // FAR
            // 
            this.FAR.Text = "FAR";
            this.FAR.Width = 40;
            // 
            // FRR
            // 
            this.FRR.Text = "FRR";
            this.FRR.Width = 40;
            // 
            // Точность
            // 
            this.Точность.Text = "Точность";
            this.Точность.Width = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Точность методов";
            // 
            // Errors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 251);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView);
            this.Name = "Errors";
            this.Text = "Errors";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader Метод;
        private System.Windows.Forms.ColumnHeader FAR;
        private System.Windows.Forms.ColumnHeader FRR;
        private System.Windows.Forms.ColumnHeader Точность;
    }
}