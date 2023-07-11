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
    public partial class Client : MaterialForm
    {
        SqlConnection conn = new SqlConnection();
        String conHome = "Data Source=DESKTOP-HTR0RDL\\GALGAMED;Initial Catalog = АрендаАвтомобилей; Integrated Security = True";
        SqlCommand rentacarCmd;
        SqlCommand returnthecarCmd;
        SqlCommand supportserviceCmd;
        MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;

        public void createNonQueries()
        {

            conn.ConnectionString = conHome;
            conn.Open();
            rentacarCmd = conn.CreateCommand();
            rentacarCmd.CommandType = CommandType.StoredProcedure;
            rentacarCmd.CommandText = "RentACar";

            returnthecarCmd = conn.CreateCommand();
            returnthecarCmd.CommandType = CommandType.StoredProcedure;
            returnthecarCmd.CommandText = "ReturnTheCar";

            supportserviceCmd = conn.CreateCommand();
            supportserviceCmd.CommandType = CommandType.StoredProcedure;
            supportserviceCmd.CommandText = "SupportService";
        }

            public Client()
        {
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
            createNonQueries();

        }

    

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            pictureBox7.Hide();
            pictureBox6.Show();
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            pictureBox6.Hide();
            pictureBox7.Show();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "арендаАвтомобилейDataSet35.Автомобили". При необходимости она может быть перемещена или удалена.
            this.автомобилиTableAdapter8.Fill(this.арендаАвтомобилейDataSet35.Автомобили);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "арендаАвтомобилейDataSet34.Сотрудники". При необходимости она может быть перемещена или удалена.
            this.сотрудникиTableAdapter1.Fill(this.арендаАвтомобилейDataSet34.Сотрудники);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "арендаАвтомобилейDataSet33.Клиенты". При необходимости она может быть перемещена или удалена.
            this.клиентыTableAdapter7.Fill(this.арендаАвтомобилейDataSet33.Клиенты);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "арендаАвтомобилейDataSet32.Клиенты". При необходимости она может быть перемещена или удалена.
            this.клиентыTableAdapter6.Fill(this.арендаАвтомобилейDataSet32.Клиенты);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "арендаАвтомобилейDataSet31.Клиенты". При необходимости она может быть перемещена или удалена.
            this.клиентыTableAdapter5.Fill(this.арендаАвтомобилейDataSet31.Клиенты);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "арендаАвтомобилейDataSet30.Клиенты". При необходимости она может быть перемещена или удалена.
            this.клиентыTableAdapter4.Fill(this.арендаАвтомобилейDataSet30.Клиенты);
            
            
            // TODO: данная строка кода позволяет загрузить данные в таблицу "арендаАвтомобилейDataSet15.Автомобили". При необходимости она может быть перемещена или удалена.
            this.автомобилиTableAdapter7.Fill(this.арендаАвтомобилейDataSet15.Автомобили);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "арендаАвтомобилейDataSet14.Автомобили". При необходимости она может быть перемещена или удалена.
            this.автомобилиTableAdapter6.Fill(this.арендаАвтомобилейDataSet14.Автомобили);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "арендаАвтомобилейDataSet13.Клиенты". При необходимости она может быть перемещена или удалена.
            this.клиентыTableAdapter1.Fill(this.арендаАвтомобилейDataSet13.Клиенты);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "арендаАвтомобилейDataSet12.Клиенты". При необходимости она может быть перемещена или удалена.
            this.клиентыTableAdapter.Fill(this.арендаАвтомобилейDataSet12.Клиенты);
           


            pictureBox7.Visible = false;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Auth frm = new Auth();
            frm.Show();
            this.Hide();
        }

        private void ClearFields()
        {

        }

            private void rentButton_Click(object sender, EventArgs e)
        {
            rentacarCmd.Parameters.Clear();
            rentacarCmd.Parameters.AddWithValue("@car", rentCarComboBox.Text);
            rentacarCmd.Parameters.AddWithValue("@client", rentClientComboBox.Text);
            rentacarCmd.Parameters.AddWithValue("@dateofissue", DateTime.Now);
            rentacarCmd.Parameters.AddWithValue("@dateofreturn", "");




            try
            {
                if (rentacarCmd.ExecuteNonQuery() > 0)
                {
                    MaterialMessageBox.Show("Авто  ");

                    ClearFields();


                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            returnthecarCmd.Parameters.Clear();
            returnthecarCmd.Parameters.AddWithValue("@car", rentCarComboBox.Text);
            returnthecarCmd.Parameters.AddWithValue("@client", rentClientComboBox.Text);
            returnthecarCmd.Parameters.AddWithValue("@dateofreturn", DateTime.Now);




            try
            {
                if (returnthecarCmd.ExecuteNonQuery() > 0)
                {
                    MaterialMessageBox.Show("Авто арендовано ");

                    ClearFields();


                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toApplyButton_Click(object sender, EventArgs e)
        {
            supportserviceCmd.Parameters.Clear();
            supportserviceCmd.Parameters.AddWithValue("@client", clientTextBox.Text);
            supportserviceCmd.Parameters.AddWithValue("@employee", employeeTextBox.Text);
            supportserviceCmd.Parameters.AddWithValue("@dateofapplication", DateTime.Now);
            supportserviceCmd.Parameters.AddWithValue("@problem", problemTextBox.Text);



            try
            {
                if (supportserviceCmd.ExecuteNonQuery() > 0)
                {
                    MaterialMessageBox.Show("Обращение отправлено ");

                    ClearFields();


                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
