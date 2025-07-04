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

        // Form3����A�N�Z�X���邽�߂̃v���p�e�B
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
            dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //�Z�����f�[�^�O���b�h�T�C�Y�ɍ��킹��
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

        //�ꗗ�\���֐�
        private void LoadUsers()
        {
            using (var connection = new MySqlConnection(connectString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT U.id,U.name,U.email,U.birth,U.gender,U.code,D.department FROM users as U INNER JOIN departments as D ON U.department = D.id;";
                    using (var adapter = new MySqlDataAdapter(query, connection))//select�����g�p
                    {
                        DataTable table = new DataTable(); //�e�[�u�������
                        adapter.Fill(table);
                        dataGridViewUsers.DataSource = table; //�ɕ�������
                    } 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("�ǂݍ��݃G���[: " + ex.Message);
                }
            }
        }



        //�o�^�{�^���֐�
        private void buttonInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("���O�����͂���Ă��܂���");
                return;
            }
            if (string.IsNullOrEmpty(textBoxEmail.Text))
            {
                MessageBox.Show("Email�����͂���Ă��܂���");
                return;
            }

            //�����ȃ��[���A�h���X���͂���
            if (!textBoxEmail.Text.Trim().Contains("@"))
            {
                MessageBox.Show("�����ȃ��[���A�h���X�ł�");
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
                gender = "�j";
            else if (checkBoxFemale.Checked)
                gender = "��";
            else if (checkBoxOther.Checked)
                gender = "���̑�";
            int code = int.Parse(textBoxCode.Text);
            int department = int.Parse(textBoxCode.Text);


            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(gender))
            {
                MessageBox.Show("���ׂĂ̍��ڂ���͂��Ă��������B");
                return;
            }


            using (var connection = new MySqlConnection(connectString)) //�f�[�^�x�[�X�ɐڑ�
            {
                try
                {
                    connection.Open(); //�ڑ�
                    string sql = "INSERT INTO users (name, email, birth, gender, code, department) VALUES (@name, @email, @birth, @gender, @code, @department)";�@//�e�[�u���Ƀf�[�^��ǉ�
                    using (var command = new MySqlCommand(sql, connection)) //���s
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
                        MessageBox.Show($"{rows} ���̃��[�U�[��o�^���܂����B");
                    }
                }
                catch (Exception ex) //��O�G���[
                {
                    MessageBox.Show("�G���[: " + ex.Message);
                }
            }
        }


        //�폜�{�^���֐�
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("���[�U�[��I�����Ă�������");
                return;
            }

            using (var connection = new MySqlConnection(connectString)) //�f�[�^�x�[�X�ɐڑ�
            {
                try
                {
                    connection.Open(); //�ڑ�
                    string sql = "DELETE FROM users where id=@id";
                    using (var command = new MySqlCommand(sql, connection)) //���s
                    {
                        command.Parameters.AddWithValue("@id", selectedUserId);

                        int rows = command.ExecuteNonQuery(); //sql���s
                        LoadUsers();
                        ClearForm();
                        MessageBox.Show($"{rows} ���̃��[�U�[���폜���܂����B");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("�G���[: " + ex.Message);
                }
            }
        }

        private void dataGridViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)//�w�b�_�[���N���b�N����� RowIndex��-1�ɂȂ邽�߁A��������O
            {
                selectedUserId = Convert.ToInt32(dataGridViewUsers.Rows[e.RowIndex].Cells["id"].Value);
                textBoxName.Text = dataGridViewUsers.Rows[e.RowIndex].Cells["name"].Value?.ToString()??""; 
                textBoxEmail.Text = dataGridViewUsers.Rows[e.RowIndex].Cells["email"].Value?.ToString() ?? "";
                textBoxDepa.Text = dataGridViewUsers.Rows[e.RowIndex].Cells["department"].Value?.ToString() ?? "";
                textBoxCode.Text = dataGridViewUsers.Rows[e.RowIndex].Cells["code"].Value?.ToString() ?? "";
                dateTimePicker1.Text = dataGridViewUsers.Rows[e.RowIndex].Cells["birth"].Value?.ToString() ?? "";
                //Value.ToString()�̓Z���̒l�����o���ĕ�����̕ϊ�
                
                // �܂����ׂẴ`�F�b�N���O���Ă���A�K�v�ȂƂ��낾�� true �ɂ���
                checkBoxMale.Checked = false;
                checkBoxFemale.Checked = false;
                checkBoxOther.Checked = false;

                string gender = dataGridViewUsers.Rows[e.RowIndex].Cells["gender"].Value?.ToString()??"";
                if (gender == "�j")
                    checkBoxMale.Checked = true;
                if (gender == "��")
                    checkBoxFemale.Checked = true;
                if (gender == "���̑�")
                    checkBoxOther.Checked = true;


            }
        }


        //�ύX�{�^���֐�
        private void buttonUpdate_Click(object sender, EventArgs e)
        {

            if (selectedUserId == -1)
            {
                MessageBox.Show("���[�U�[��I�����Ă�������");
                return;
            }

            //�����ȃ��[���A�h���X���͂���
            if (!textBoxEmail.Text.Trim().Contains("@"))
            {
                MessageBox.Show("�����ȃ��[���A�h���X�ł�");
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
                gender = "�j";
            else if (checkBoxFemale.Checked)
                gender = "��";
            else if (checkBoxOther.Checked)
                gender = "���̑�";
            int department = int.Parse(textBoxCode.Text);
            int code = int.Parse(textBoxCode.Text);

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(gender))
            {
                MessageBox.Show("���ׂĂ̍��ڂ���͂��Ă��������B");
                return;
            }

            using (var connection = new MySqlConnection(connectString)) //�f�[�^�x�[�X�ɐڑ�
            {
                try
                {
                    connection.Open(); //�ڑ�
                    string sql = "UPDATE users SET name=@name, email=@email, birth=@birth, gender=@gender, code=@code, department=@department where id=@id";
                    using (var command = new MySqlCommand(sql, connection)) //���s
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@birth", birth);
                        command.Parameters.AddWithValue("@gender", gender);
                        command.Parameters.AddWithValue("@department", department);
                        command.Parameters.AddWithValue("@code", code);
                        command.Parameters.AddWithValue("@id", selectedUserId);
                        

                        int rows = command.ExecuteNonQuery(); //sql���s
                        LoadUsers();
                        ClearForm();

                        MessageBox.Show($"{rows} ���̃��[�U�[��ύX���܂����B");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("�G���[: " + ex.Message);
                }
            }
        }

        //�����{�^���֐�
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                //MessageBox.Show("���O�����͂���Ă��܂���");
                LoadUsers();
                ClearForm();
                return;
            }

            string name = textBoxName.Text;
            //string email = textBoxEmail.Text;
            using (var connection = new MySqlConnection(connectString)) //�f�[�^�x�[�X�ɐڑ�
            {
                try
                {
                    connection.Open(); //�ڑ�
                    string sql = "SELECT * FROM users WHERE name LIKE @name ";
                    using (var adapter = new MySqlDataAdapter(sql, connection))//���s
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@name", "%" + name + "%");

                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        dataGridViewUsers.DataSource = table; // �������ʂ�\��
                        if (table.Rows.Count == 0)
                        {
                            MessageBox.Show("�Y�����[�U�Ȃ�");
                            //textBoxEmail.Text = string.Empty;
                            LoadUsers();
                            ClearForm();
                            return;
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("�G���[: " + ex.Message);
                }
            }
        }

        //�G���^�[�œ��͈ړ�
        private void textBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; //����炳�Ȃ�
                textBoxEmail.Focus(); // Email�̃e�L�X�g�{�b�N�X�ֈړ�
            }
        }

        //���[�U�ꗗ�\���֐�
        private void buttonList_Click(object sender, EventArgs e)
        {
            // Form2�̃C���X�^���X�𐶐�
            Form2 form2 = new Form2();
            // form2��\��
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

        //�����ꗗ
        private void buttonDepartment_Click(object sender, EventArgs e)
        {
            // Form3�̃C���X�^���X�𐶐�
            Form3 form3 = new Form3(this);
            // form3��\��
            form3.Show();

        }
    }
}
