using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace userApp
{
    public partial class Form3 : Form
    {
        private string connectString = "server=localhost;user=root;password=hardy5963;database=test_schema";
        private int selectedUserId = -1;


        private Form1 mainForm; // Form1への参照を保持する
        public Form3(Form1 form1) //Form1のインスタンスを受け取るコンストラクタ
        {
            InitializeComponent();
            this.mainForm = form1;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadUsers();
            //dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadUsers() //一覧表示関数定義
        {
            using (var connection = new MySqlConnection(connectString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, department FROM departments";
                    using (var adapter = new MySqlDataAdapter(query, connection))//select文を使用
                    {
                        DataTable table = new DataTable(); //テーブルを作る
                        adapter.Fill(table);
                        dataGridView1.DataSource = table; //に文を入れる
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("読み込みエラー: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // クリックした行の「id」列の値を取得
                string selectedId = dataGridView1.Rows[e.RowIndex].Cells["id"].Value?.ToString()??"";
                string selectedDEPARTMENT = dataGridView1.Rows[e.RowIndex].Cells["department"].Value?.ToString() ?? "";

                // Form1のテキストボックスに表示
                mainForm.CodeTextBox.Text = selectedId;
                mainForm.DepaTextBox.Text = selectedDEPARTMENT;

                // 閉じる
                this.Hide();
            }
        }
    }
}
