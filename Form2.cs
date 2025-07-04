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
using System.Xml.Linq;

namespace userApp
{
    public partial class Form2 : Form
    {
        private string connectString = "server=localhost;user=root;password=hardy5963;database=test_schema";
        private int selectedUserId = -1;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
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
                    string query = "SELECT * FROM users";
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

        //ID昇順並び替え関数
        private void buttonSort1_Click(object sender, EventArgs e)
        {
            using (var connection = new MySqlConnection(connectString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM users ORDER BY id ASC"; // ID昇順
                    using (var adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dataGridView1.DataSource = table;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ソートエラー: " + ex.Message);
                }
            }
        }

        //ID降順並び替え関数
        private void buttonSort2_Click(object sender, EventArgs e)
        {
            using (var connection = new MySqlConnection(connectString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM users ORDER BY id DESC"; // ID降順
                    using (var adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dataGridView1.DataSource = table;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ソートエラー: " + ex.Message);
                }
            }
        }

        //名前順並び替え関数
        private void buttonSort3_Click(object sender, EventArgs e)
        {
            using (var connection = new MySqlConnection(connectString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, name, email FROM users ORDER BY name ASC";
                    using (var adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dataGridView1.DataSource = table;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("名前のソートエラー: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
