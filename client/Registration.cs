using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Прокат_авто
{
    public partial class Registration : MaterialForm
    {
        SqlConnection conn = new SqlConnection();
        String conHome = "Data Source=DESKTOP-HTR0RDL\\GALGAMED;Initial Catalog = АрендаАвтомобилей; Integrated Security = True";
        SqlCommand addNewUserCmd;
        MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;

        public void createNonQueries()
        {

            conn.ConnectionString = conHome;
            conn.Open();
            addNewUserCmd = conn.CreateCommand();
            addNewUserCmd.CommandType = CommandType.StoredProcedure;
            addNewUserCmd.CommandText = "AddUser";
        }

        public Registration()
        {
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
            createNonQueries();

            birthdayTimePicker.MaxDate = DateTime.Now.AddYears(-21);
        }

        private void registration_Click(object sender, EventArgs e)
        {
            addNewUserCmd.Parameters.Clear();
            addNewUserCmd.Parameters.AddWithValue("@login", loginTextBox.Text.Replace(" ", ""));
            addNewUserCmd.Parameters.AddWithValue("@password", passwordTextBox.Text.Replace(" ", ""));
            addNewUserCmd.Parameters.AddWithValue("@surname", surnameTextBox.Text);
            addNewUserCmd.Parameters.AddWithValue("@name", surnameTextBox.Text);
            addNewUserCmd.Parameters.AddWithValue("@patronymic", patronymicTextBox.Text);
            addNewUserCmd.Parameters.AddWithValue("@birthday", birthdayTimePicker.Value);
            addNewUserCmd.Parameters.AddWithValue("@number", numberTextBox.Text);
            addNewUserCmd.Parameters.AddWithValue("@address", addressTextBox.Text);
            addNewUserCmd.Parameters.AddWithValue("@document", documentTextBox.Text.Replace(" ", ""));
            addNewUserCmd.Parameters.AddWithValue("@выдача", dateissuanceTimePicker.Value);
            addNewUserCmd.Parameters.AddWithValue("@срок",  validTimePicker.Value);
            addNewUserCmd.Parameters.AddWithValue("@experience", experienceTextBox.Text);
            try
            {
                if (addNewUserCmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Запись добавлена ");
                    ClearFields();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearFields()
        {
            loginTextBox.Text = "";
            passwordTextBox.Text = "";
            surnameTextBox.Text = "";
            nameTextBox.Text = "";
            patronymicTextBox.Text = "";
            numberTextBox.Text = "";
            addressTextBox.Text = "";
            documentTextBox.Text = "";
            experienceTextBox.Text = "";
        }

        private void Registration_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            pictureBox7.Visible = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            pictureBox7.Hide();
            pictureBox6.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            pictureBox6.Hide();
            pictureBox7.Show();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Auth frm = new Auth();
            frm.Show();
            this.Hide();
        }

        private void nameTextBox_Validating(object sender, CancelEventArgs e)
        {
            var input = surnameTextBox.Text;
            if (string.IsNullOrEmpty(input))
            {
                errorProvider.SetError(surnameTextBox, "Введите Фамилию!");
                e.Cancel = true;
            } 
            else
            {
                errorProvider.SetError(surnameTextBox, String.Empty);
                e.Cancel = false;
            }
        }

        

    private void addressTextBox_Validating(object sender, CancelEventArgs e)
    {
        var input = addressTextBox.Text;
        if (string.IsNullOrEmpty(input))
        {
            errorProvider.SetError(addressTextBox, "Введите ФИО!");
            e.Cancel = true;
        }
        else
        {
            errorProvider.SetError(addressTextBox, String.Empty);
            e.Cancel = false;

        } 
    }

        private void experienceTextBox_Validating(object sender, CancelEventArgs e)
        {
            int input;
            bool isNumbers = int.TryParse(experienceTextBox.Text, out input);
            if (isNumbers && input < 3)
            {
                errorProvider.SetError(experienceTextBox, "Стаж должен быть не менее 3 лет");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(experienceTextBox, String.Empty);
                e.Cancel = false;
            }
        }

        private void nameTextBox_Validating_1(object sender, CancelEventArgs e)
        {
            var input = nameTextBox.Text;
            if (string.IsNullOrEmpty(input))
            {
                errorProvider.SetError(nameTextBox, "Введите Имя!");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(nameTextBox, String.Empty);
                e.Cancel = false;
            }
        }

        private void patronymicTextBox_Validating(object sender, CancelEventArgs e)
        {
            var input = patronymicTextBox.Text;
            if (string.IsNullOrEmpty(input))
            {
                errorProvider.SetError(patronymicTextBox, "Введите Отчество!");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(patronymicTextBox, String.Empty);
                e.Cancel = false;
            }
        }
    }
}
