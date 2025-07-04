using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Data;
using System.Windows.Forms;

namespace userApp
{
    public partial class Form1 : Form
    {
        private string connectString = "server=localhost;user=root;password=hardy5963;database=test_schema";
        private int selectedUserId = -1;

        public Form1()
        {
            InitializeComponent();
        }

        // Form3からアクセスするためのプロパティ
        public TextBox CodeTextBox
        {
            get { return textBoxCode; }
        }

        public TextBox DepaTextBox

        {
            get { return textBoxDepa; }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadUsers();
            //dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //セルをデータグリッドサイズに合わせる
        }

        private void ClearForm()
        {
            selectedUserId = -1;
            textBoxName.Text = string.Empty;
            textBoxEmail.Text = string.Empty;
            checkBoxMale.Checked = false;
            checkBoxFemale.Checked = false;
            checkBoxOther.Checked = false;
            dateTimePicker1.Value = DateTime.Today;
        }

        //一覧表示関数
        private void LoadUsers()
        {
            using (var connection = new MySqlConnection(connectString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT U.id,U.name,U.email,U.birth,U.gender,U.code,D.department FROM users as U INNER JOIN departments as D ON U.department = D.id;";
                    using (var adapter = new MySqlDataAdapter(query, connection))//select文を使用
                    {
                        DataTable table = new DataTable(); //テーブルを作る
                        adapter.Fill(table);
                        dataGridViewUsers.DataSource = table; //に文を入れる
                    } 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("読み込みエラー: " + ex.Message);
                }
            }
        }



        //登録ボタン関数
        private void buttonInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("名前が入力されていません");
                return;
            }
            if (string.IsNullOrEmpty(textBoxEmail.Text))
            {
                MessageBox.Show("Emailが入力されていません");
                return;
            }

            //無効なメールアドレスをはじく
            if (!textBoxEmail.Text.Trim().Contains("@"))
            {
                MessageBox.Show("無効なメールアドレスです");
                textBoxEmail.Text = string.Empty;
                return;
            }

            string name = textBoxName.Text;
            string email = textBoxEmail.Text;
            DateTime date = dateTimePicker1.Value;
            DateTime dateOnly = date.Date;
            string birth = dateOnly.ToString("yyyy-MM-dd");
            string gender = "";
            if (checkBoxMale.Checked)
                gender = "男";
            else if (checkBoxFemale.Checked)
                gender = "女";
            else if (checkBoxOther.Checked)
                gender = "その他";
            int code = int.Parse(textBoxCode.Text);
            int department = int.Parse(textBoxCode.Text);


            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(gender))
            {
                MessageBox.Show("すべての項目を入力してください。");
                return;
            }


            using (var connection = new MySqlConnection(connectString)) //データベースに接続
            {
                try
                {
                    connection.Open(); //接続
                    string sql = "INSERT INTO users (name, email, birth, gender, code, department) VALUES (@name, @email, @birth, @gender, @code, @department)";　//テーブルにデータを追加
                    using (var command = new MySqlCommand(sql, connection)) //実行
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@birth", birth);
                        command.Parameters.AddWithValue("@gender", gender);
                        command.Parameters.AddWithValue("@code", code);
                        command.Parameters.AddWithValue("@department", department);
                        int rows = command.ExecuteNonQuery();
                        LoadUsers();
                        ClearForm();
                        MessageBox.Show($"{rows} 件のユーザーを登録しました。");
                    }
                }
                catch (Exception ex) //例外エラー
                {
                    MessageBox.Show("エラー: " + ex.Message);
                }
            }
        }


        //削除ボタン関数
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("ユーザーを選択してください");
                return;
            }

            using (var connection = new MySqlConnection(connectString)) //データベースに接続
            {
                try
                {
                    connection.Open(); //接続
                    string sql = "DELETE FROM users where id=@id";
                    using (var command = new MySqlCommand(sql, connection)) //実行
                    {
                        command.Parameters.AddWithValue("@id", selectedUserId);

                        int rows = command.ExecuteNonQuery(); //sql実行
                        LoadUsers();
                        ClearForm();
                        MessageBox.Show($"{rows} 件のユーザーを削除しました。");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("エラー: " + ex.Message);
                }
            }
        }

        private void dataGridViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)//ヘッダーをクリックすると RowIndexが-1になるため、それを除外
            {
                selectedUserId = Convert.ToInt32(dataGridViewUsers.Rows[e.RowIndex].Cells["id"].Value);
                textBoxName.Text = dataGridViewUsers.Rows[e.RowIndex].Cells["name"].Value?.ToString()??""; 
                textBoxEmail.Text = dataGridViewUsers.Rows[e.RowIndex].Cells["email"].Value?.ToString() ?? "";
                textBoxDepa.Text = dataGridViewUsers.Rows[e.RowIndex].Cells["department"].Value?.ToString() ?? "";
                textBoxCode.Text = dataGridViewUsers.Rows[e.RowIndex].Cells["code"].Value?.ToString() ?? "";
                dateTimePicker1.Text = dataGridViewUsers.Rows[e.RowIndex].Cells["birth"].Value?.ToString() ?? "";
                //Value.ToString()はセルの値を取り出して文字列の変換
                
                // まずすべてのチェックを外してから、必要なところだけ true にする
                checkBoxMale.Checked = false;
                checkBoxFemale.Checked = false;
                checkBoxOther.Checked = false;

                string gender = dataGridViewUsers.Rows[e.RowIndex].Cells["gender"].Value?.ToString()??"";
                if (gender == "男")
                    checkBoxMale.Checked = true;
                if (gender == "女")
                    checkBoxFemale.Checked = true;
                if (gender == "その他")
                    checkBoxOther.Checked = true;


            }
        }


        //変更ボタン関数
        private void buttonUpdate_Click(object sender, EventArgs e)
        {

            if (selectedUserId == -1)
            {
                MessageBox.Show("ユーザーを選択してください");
                return;
            }

            //無効なメールアドレスをはじく
            if (!textBoxEmail.Text.Trim().Contains("@"))
            {
                MessageBox.Show("無効なメールアドレスです");
                textBoxEmail.Text = string.Empty;
                return;
            }

            string name = textBoxName.Text;
            string email = textBoxEmail.Text;
            DateTime date = dateTimePicker1.Value;
            DateTime dateOnly = date.Date;
            string birth = dateOnly.ToString("yyyy-MM-dd");
            string gender = "";
            if (checkBoxMale.Checked)
                gender = "男";
            else if (checkBoxFemale.Checked)
                gender = "女";
            else if (checkBoxOther.Checked)
                gender = "その他";
            int department = int.Parse(textBoxCode.Text);
            int code = int.Parse(textBoxCode.Text);

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(gender))
            {
                MessageBox.Show("すべての項目を入力してください。");
                return;
            }

            using (var connection = new MySqlConnection(connectString)) //データベースに接続
            {
                try
                {
                    connection.Open(); //接続
                    string sql = "UPDATE users SET name=@name, email=@email, birth=@birth, gender=@gender, code=@code, department=@department where id=@id";
                    using (var command = new MySqlCommand(sql, connection)) //実行
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@birth", birth);
                        command.Parameters.AddWithValue("@gender", gender);
                        command.Parameters.AddWithValue("@department", department);
                        command.Parameters.AddWithValue("@code", code);
                        command.Parameters.AddWithValue("@id", selectedUserId);
                        

                        int rows = command.ExecuteNonQuery(); //sql実行
                        LoadUsers();
                        ClearForm();

                        MessageBox.Show($"{rows} 件のユーザーを変更しました。");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("エラー: " + ex.Message);
                }
            }
        }

        //検索ボタン関数
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                //MessageBox.Show("名前が入力されていません");
                LoadUsers();
                ClearForm();
                return;
            }

            string name = textBoxName.Text;
            //string email = textBoxEmail.Text;
            using (var connection = new MySqlConnection(connectString)) //データベースに接続
            {
                try
                {
                    connection.Open(); //接続
                    string sql = "SELECT * FROM users WHERE name LIKE @name ";
                    using (var adapter = new MySqlDataAdapter(sql, connection))//実行
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@name", "%" + name + "%");

                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        dataGridViewUsers.DataSource = table; // 検索結果を表示
                        if (table.Rows.Count == 0)
                        {
                            MessageBox.Show("該当ユーザなし");
                            //textBoxEmail.Text = string.Empty;
                            LoadUsers();
                            ClearForm();
                            return;
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("エラー: " + ex.Message);
                }
            }
        }

        //エンターで入力移動
        private void textBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; //音を鳴らさない
                textBoxEmail.Focus(); // Emailのテキストボックスへ移動
            }
        }

        //ユーザ一覧表示関数
        private void buttonList_Click(object sender, EventArgs e)
        {
            // Form2のインスタンスを生成
            Form2 form2 = new Form2();
            // form2を表示
            form2.Show();
        }

        private void checkBoxMale_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMale.Checked)
            {
                checkBoxFemale.Checked = false;
                checkBoxOther.Checked = false;
            }
        }

        private void checkBoxFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFemale.Checked)
            {
                checkBoxMale.Checked = false;
                checkBoxOther.Checked = false;
            }
        }

        private void checkBoxOther_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOther.Checked)
            {
                checkBoxMale.Checked = false;
                checkBoxFemale.Checked = false;
            }
        }

        //部署一覧
        private void buttonDepartment_Click(object sender, EventArgs e)
        {
            // Form3のインスタンスを生成
            Form3 form3 = new Form3(this);
            // form3を表示
            form3.Show();

        }
    }
}
