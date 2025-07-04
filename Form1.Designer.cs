namespace userApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxName = new TextBox();
            textBoxEmail = new TextBox();
            label1 = new Label();
            label2 = new Label();
            dataGridViewUsers = new DataGridView();
            buttonInsert = new Button();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            buttonSearch = new Button();
            buttonList = new Button();
            label3 = new Label();
            label4 = new Label();
            checkBoxMale = new CheckBox();
            checkBoxFemale = new CheckBox();
            checkBoxOther = new CheckBox();
            dateTimePicker1 = new DateTimePicker();
            labelCode = new Label();
            buttonDepartment = new Button();
            textBoxCode = new TextBox();
            textBoxDepa = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(195, 59);
            textBoxName.Margin = new Padding(4);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(252, 31);
            textBoxName.TabIndex = 0;
            textBoxName.KeyDown += textBoxName_KeyDown;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(195, 114);
            textBoxEmail.Margin = new Padding(4);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(252, 31);
            textBoxEmail.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(95, 58);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(48, 25);
            label1.TabIndex = 2;
            label1.Text = "名前";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(95, 117);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(54, 25);
            label2.TabIndex = 3;
            label2.Text = "email";
            // 
            // dataGridViewUsers
            // 
            dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsers.Location = new Point(95, 348);
            dataGridViewUsers.Margin = new Padding(4);
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.RowHeadersWidth = 51;
            dataGridViewUsers.Size = new Size(1008, 235);
            dataGridViewUsers.TabIndex = 4;
            dataGridViewUsers.CellClick += dataGridViewUsers_CellClick;
            // 
            // buttonInsert
            // 
            buttonInsert.BackColor = Color.White;
            buttonInsert.Location = new Point(604, 625);
            buttonInsert.Margin = new Padding(4);
            buttonInsert.Name = "buttonInsert";
            buttonInsert.Size = new Size(140, 71);
            buttonInsert.TabIndex = 5;
            buttonInsert.Text = "登録";
            buttonInsert.UseVisualStyleBackColor = false;
            buttonInsert.Click += buttonInsert_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(784, 625);
            buttonUpdate.Margin = new Padding(4);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(140, 71);
            buttonUpdate.TabIndex = 6;
            buttonUpdate.Text = "変更";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(963, 625);
            buttonDelete.Margin = new Padding(4);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(140, 71);
            buttonDelete.TabIndex = 7;
            buttonDelete.Text = "削除";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(464, 58);
            buttonSearch.Margin = new Padding(4);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(118, 36);
            buttonSearch.TabIndex = 8;
            buttonSearch.Text = "検索";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // buttonList
            // 
            buttonList.Location = new Point(95, 591);
            buttonList.Margin = new Padding(4);
            buttonList.Name = "buttonList";
            buttonList.Size = new Size(136, 48);
            buttonList.TabIndex = 9;
            buttonList.Text = "ユーザ一覧";
            buttonList.UseVisualStyleBackColor = true;
            buttonList.Click += buttonList_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(95, 178);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(84, 25);
            label3.TabIndex = 13;
            label3.Text = "生年月日";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(95, 235);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(48, 25);
            label4.TabIndex = 14;
            label4.Text = "性別";
            // 
            // checkBoxMale
            // 
            checkBoxMale.AutoSize = true;
            checkBoxMale.Location = new Point(195, 235);
            checkBoxMale.Name = "checkBoxMale";
            checkBoxMale.Size = new Size(56, 29);
            checkBoxMale.TabIndex = 15;
            checkBoxMale.Text = "男";
            checkBoxMale.UseVisualStyleBackColor = true;
            checkBoxMale.CheckedChanged += checkBoxMale_CheckedChanged;
            // 
            // checkBoxFemale
            // 
            checkBoxFemale.AutoSize = true;
            checkBoxFemale.Location = new Point(280, 235);
            checkBoxFemale.Name = "checkBoxFemale";
            checkBoxFemale.Size = new Size(56, 29);
            checkBoxFemale.TabIndex = 16;
            checkBoxFemale.Text = "女";
            checkBoxFemale.UseVisualStyleBackColor = true;
            checkBoxFemale.CheckedChanged += checkBoxFemale_CheckedChanged;
            // 
            // checkBoxOther
            // 
            checkBoxOther.AutoSize = true;
            checkBoxOther.Location = new Point(361, 234);
            checkBoxOther.Name = "checkBoxOther";
            checkBoxOther.Size = new Size(84, 29);
            checkBoxOther.TabIndex = 17;
            checkBoxOther.Text = "その他";
            checkBoxOther.UseVisualStyleBackColor = true;
            checkBoxOther.CheckedChanged += checkBoxOther_CheckedChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(195, 178);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(252, 31);
            dateTimePicker1.TabIndex = 18;
            // 
            // labelCode
            // 
            labelCode.AutoSize = true;
            labelCode.Location = new Point(95, 299);
            labelCode.Margin = new Padding(4, 0, 4, 0);
            labelCode.Name = "labelCode";
            labelCode.Size = new Size(86, 25);
            labelCode.TabIndex = 19;
            labelCode.Text = "所属コード";
            // 
            // buttonDepartment
            // 
            buttonDepartment.Location = new Point(470, 292);
            buttonDepartment.Name = "buttonDepartment";
            buttonDepartment.Size = new Size(112, 35);
            buttonDepartment.TabIndex = 21;
            buttonDepartment.Text = "部署一覧";
            buttonDepartment.UseVisualStyleBackColor = true;
            buttonDepartment.Click += buttonDepartment_Click;
            // 
            // textBoxCode
            // 
            textBoxCode.Location = new Point(195, 292);
            textBoxCode.Name = "textBoxCode";
            textBoxCode.Size = new Size(82, 31);
            textBoxCode.TabIndex = 22;
            // 
            // textBoxDepa
            // 
            textBoxDepa.Location = new Point(276, 292);
            textBoxDepa.Name = "textBoxDepa";
            textBoxDepa.Size = new Size(150, 31);
            textBoxDepa.TabIndex = 23;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1192, 728);
            Controls.Add(textBoxDepa);
            Controls.Add(textBoxCode);
            Controls.Add(buttonDepartment);
            Controls.Add(labelCode);
            Controls.Add(dateTimePicker1);
            Controls.Add(checkBoxOther);
            Controls.Add(checkBoxFemale);
            Controls.Add(checkBoxMale);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(buttonList);
            Controls.Add(buttonSearch);
            Controls.Add(buttonDelete);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonInsert);
            Controls.Add(dataGridViewUsers);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxName);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "ユーザマスタ";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxName;
        private TextBox textBoxEmail;
        private Label label1;
        private Label label2;
        private DataGridView dataGridViewUsers;
        private Button buttonInsert;
        private Button buttonUpdate;
        private Button buttonDelete;
        private Button buttonSearch;
        private Button buttonList;
        private Label label3;
        private Label label4;
        private CheckBox checkBoxMale;
        private CheckBox checkBoxFemale;
        private CheckBox checkBoxOther;
        private DateTimePicker dateTimePicker1;
        private Label labelCode;
        private Button buttonDepartment;
        private TextBox textBoxCode;
        private TextBox textBoxDepa;
    }
}
