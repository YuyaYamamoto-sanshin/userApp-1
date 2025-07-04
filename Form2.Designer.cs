namespace userApp
{
    partial class Form2
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
            dataGridView1 = new DataGridView();
            buttonSort1 = new Button();
            buttonSort2 = new Button();
            buttonSort3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(42, 15);
            dataGridView1.Margin = new Padding(4, 4, 4, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1036, 599);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // buttonSort1
            // 
            buttonSort1.Location = new Point(42, 631);
            buttonSort1.Margin = new Padding(4, 4, 4, 4);
            buttonSort1.Name = "buttonSort1";
            buttonSort1.Size = new Size(118, 36);
            buttonSort1.TabIndex = 1;
            buttonSort1.Text = "ID昇順";
            buttonSort1.UseVisualStyleBackColor = true;
            buttonSort1.Click += buttonSort1_Click;
            // 
            // buttonSort2
            // 
            buttonSort2.Location = new Point(179, 631);
            buttonSort2.Margin = new Padding(4, 4, 4, 4);
            buttonSort2.Name = "buttonSort2";
            buttonSort2.Size = new Size(118, 36);
            buttonSort2.TabIndex = 2;
            buttonSort2.Text = "ID降順";
            buttonSort2.UseVisualStyleBackColor = true;
            buttonSort2.Click += buttonSort2_Click;
            // 
            // buttonSort3
            // 
            buttonSort3.Location = new Point(318, 631);
            buttonSort3.Margin = new Padding(4, 4, 4, 4);
            buttonSort3.Name = "buttonSort3";
            buttonSort3.Size = new Size(118, 36);
            buttonSort3.TabIndex = 3;
            buttonSort3.Text = "名前順";
            buttonSort3.UseVisualStyleBackColor = true;
            buttonSort3.Click += buttonSort3_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1124, 706);
            Controls.Add(buttonSort3);
            Controls.Add(buttonSort2);
            Controls.Add(buttonSort1);
            Controls.Add(dataGridView1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "Form2";
            Text = "ユーザ一覧";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button buttonSort1;
        private Button buttonSort2;
        private Button buttonSort3;
    }
}