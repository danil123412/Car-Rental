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
    public partial class Auth : MaterialForm
    {
        MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
        public Auth()
        {
            InitializeComponent();
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            passOff.Visible = false;
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

        private void clientButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HTR0RDL\GALGAMED;Initial Catalog=АрендаАвтомобилей;Integrated Security=True");
            var cmd = con.CreateCommand();
            con.Open();
            cmd.CommandText = "Select Count (*) From Клиенты Where Логин = @Login and Пароль = @Pass";
            cmd.Parameters.AddWithValue("@Login", TextLogin.Text);
            cmd.Parameters.AddWithValue("@Pass", TextPass.Text);
            //SqlDataAdapter sda = new SqlDataAdapter(cmd, con);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            //sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Client frm = new Client();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Пожалуйста введите логин и пароль ");
            }
            con.Close();
        }

        private void employeesButton_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HTR0RDL\GALGAMED;Initial Catalog=АрендаАвтомобилей;Integrated Security=True");
            var cmd = con.CreateCommand();
            con.Open();
            cmd.CommandText = "Select Count (*) From Сотрудники Where ID = @ID and Пароль = @Pass";
            cmd.Parameters.AddWithValue("@ID", TextLogin.Text);
            cmd.Parameters.AddWithValue("@Pass", TextPass.Text);
            //SqlDataAdapter sda = new SqlDataAdapter(cmd, con);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            //sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Manager frm = new Manager();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Пожалуйста введите логин и пароль ");
            }
            con.Close();
        }

        private void passOn_Click(object sender, EventArgs e)
        {
            TextPass.UseSystemPasswordChar = true;
            passOn.Visible = false;
            passOff.Visible = true;
        }

        private void passOff_Click(object sender, EventArgs e)
        {
            TextPass.UseSystemPasswordChar = false;
            passOn.Visible = true;
            passOff.Visible = false;
        }

        private void registrationButton_Click(object sender, EventArgs e)
        {
            Registration frm = new Registration();
            frm.Show();
            this.Hide();
        }
    }
}
    

