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
    public partial class Manager : MaterialSkin.Controls.MaterialForm
    {
        SqlConnection conn = new SqlConnection();
        String conHome = "Data Source=DESKTOP-HTR0RDL\\GALGAMED;Initial Catalog = АрендаАвтомобилей; Integrated Security = True";
        SqlCommand addNewUserCmd;
        SqlCommand deletecarCmd;
        SqlCommand deleteUserCmd;
        SqlCommand handoverforrepairCmd;
        SqlCommand pickupfromtherepairCmd;
        SqlCommand insureacarCmd;

        MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;

        public void createNonQueries()
        {

            conn.ConnectionString = conHome;
            conn.Open();
            addNewUserCmd = conn.CreateCommand();
            addNewUserCmd.CommandType = CommandType.StoredProcedure;
            addNewUserCmd.CommandText = "AddCar";

            deletecarCmd = conn.CreateCommand();
            deletecarCmd.CommandType = CommandType.StoredProcedure;
            deletecarCmd.CommandText = "DeleteCar";

            deleteUserCmd = conn.CreateCommand();
            deleteUserCmd.CommandType = CommandType.StoredProcedure;
            deleteUserCmd.CommandText = "DeleteUser";

            handoverforrepairCmd = conn.CreateCommand();
            handoverforrepairCmd.CommandType = CommandType.StoredProcedure;
            handoverforrepairCmd.CommandText = "HandOverForRepair";

            pickupfromtherepairCmd = conn.CreateCommand();
            pickupfromtherepairCmd.CommandType = CommandType.StoredProcedure;
            pickupfromtherepairCmd.CommandText = "PickUpFromTheRepair";

            insureacarCmd = conn.CreateCommand();
            insureacarCmd.CommandType = CommandType.StoredProcedure;
            insureacarCmd.CommandText = "InsureACar";

            
        }

        public Manager()
        {
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            InitializeComponent();
            materialSkinManager.AddFormToManage(this);
            createNonQueries();
            
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

        private void Manager_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "арендаАвтомобилейDataSet40.Автомобили". При необходимости она может быть перемещена или удалена.
            this.автомобилиTableAdapter2.Fill(this.арендаАвтомобилейDataSet40.Автомобили);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "арендаАвтомобилейDataSet39.Автовремонте". При необходимости она может быть перемещена или удалена.
            this.автовремонтеTableAdapter.Fill(this.арендаАвтомобилейDataSet39.Автовремонте);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "арендаАвтомобилейDataSet38.Автомобили". При необходимости она может быть перемещена или удалена.
            this.автомобилиTableAdapter.Fill(this.арендаАвтомобилейDataSet38.Автомобили);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "арендаАвтомобилейDataSet37.Страховка". При необходимости она может быть перемещена или удалена.
            this.страховкаTableAdapter.Adapter.ContinueUpdateOnError = true;
            this.страховкаTableAdapter.Fill(this.арендаАвтомобилейDataSet37.Страховка);
            
            
            // TODO: данная строка кода позволяет загрузить данные в таблицу "арендаАвтомобилейDataSet23.Автосервис". При необходимости она может быть перемещена или удалена.
            this.автосервисTableAdapter2.Fill(this.арендаАвтомобилейDataSet23.Автосервис);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "арендаАвтомобилейDataSet22.Клиенты". При необходимости она может быть перемещена или удалена.
            this.клиентыTableAdapter1.Fill(this.арендаАвтомобилейDataSet22.Клиенты);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "арендаАвтомобилейDataSet21.Страховая_компания". При необходимости она может быть перемещена или удалена.
            this.страховая_компанияTableAdapter.Fill(this.арендаАвтомобилейDataSet21.Страховая_компания);
            
            // TODO: данная строка кода позволяет загрузить данные в таблицу "арендаАвтомобилейDataSet16.Ремонт". При необходимости она может быть перемещена или удалена.
            this.ремонтTableAdapter.Fill(this.арендаАвтомобилейDataSet16.Ремонт);
            
            // TODO: данная строка кода позволяет загрузить данные в таблицу "арендаАвтомобилейDataSet10.Автомобили". При необходимости она может быть перемещена или удалена.
            this.автомобилиTableAdapter1.Fill(this.арендаАвтомобилейDataSet10.Автомобили);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "арендаАвтомобилейDataSet9.Автосервис". При необходимости она может быть перемещена или удалена.
            
            pictureBox7.Visible = false;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            addNewUserCmd.Parameters.Clear();
            addNewUserCmd.Parameters.AddWithValue("@carnumber", CarNumberTextBox.Text.Replace(" ", ""));
            addNewUserCmd.Parameters.AddWithValue("@brand", BrandTextBox.Text);
            addNewUserCmd.Parameters.AddWithValue("@model", ModelTextBox.Text);
            addNewUserCmd.Parameters.AddWithValue("@class", ClassComboBox.Text);
            addNewUserCmd.Parameters.AddWithValue("@year", YearComboBox.Text);
            addNewUserCmd.Parameters.AddWithValue("@type", TypeComboBox.Text);
            addNewUserCmd.Parameters.AddWithValue("@color", ColorTextBox.Text);
            addNewUserCmd.Parameters.AddWithValue("@gear", GearComboBox.Text);
            try { 
                if (addNewUserCmd.ExecuteNonQuery() > 0) 
                { 
                    MessageBox.Show("Запись добавлена ");
                    ClearFields();
                } 
            } catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearFields()
        {
            
        }

        private void Manager_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
        }

        private void materialComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Auth frm = new Auth();
            frm.Show();
            this.Hide();
        }

        private void BrandTextBox_Validating(object sender, CancelEventArgs e)
        {
            var input = BrandTextBox.Text;
            if (string.IsNullOrEmpty(input))
            {
                errorProvider1.SetError(BrandTextBox, "Введите марку авто!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(BrandTextBox, String.Empty);
                e.Cancel = false;
            }
        }

        private void ModelTextBox_Validating(object sender, CancelEventArgs e)
        {
            var input = ModelTextBox.Text;
            if (string.IsNullOrEmpty(input))
            {
                errorProvider1.SetError(ModelTextBox, "Введите модель авто!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(ModelTextBox, String.Empty);
                e.Cancel = false;
            }
        }

        private void ClassComboBox_Validating(object sender, CancelEventArgs e)
        {
            var input = ClassComboBox.Text;
            if (string.IsNullOrEmpty(input))
            {
                errorProvider1.SetError(ClassComboBox, "Выберите класс авто!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(ClassComboBox, String.Empty);
                e.Cancel = false;
            }
        }

        private void YearComboBox_Validating(object sender, CancelEventArgs e)
        {
            var input = YearComboBox.Text;
            if (string.IsNullOrEmpty(input))
            {
                errorProvider1.SetError(YearComboBox, "выберите год авто");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(YearComboBox, String.Empty);
                e.Cancel = false;
            }
        }

        private void TypeComboBox_Validating(object sender, CancelEventArgs e)
        {
            var input = TypeComboBox.Text;
            if (string.IsNullOrEmpty(input))
            {
                errorProvider1.SetError(TypeComboBox, "Выберите тип кузова!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TypeComboBox, String.Empty);
                e.Cancel = false;
            }
        }

        private void GearComboBox_Validating(object sender, CancelEventArgs e)
        {
            var input = GearComboBox.Text;
            if (string.IsNullOrEmpty(input))
            {
                errorProvider1.SetError(GearComboBox, "Выберите тип трансмиссии!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(GearComboBox, String.Empty);
                e.Cancel = false;
            }
        }

        private void deleteClientButton_Click(object sender, EventArgs e)
        {
            deleteUserCmd.Parameters.Clear();
            deleteUserCmd.Parameters.AddWithValue("@ID", DeleteIDTextBox.Text);
            try
            {
                if (deleteUserCmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Запись удалена ");
                    ClearFields();
                   

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void handOverButton_Click(object sender, EventArgs e)
        {
            handoverforrepairCmd.Parameters.Clear();
            handoverforrepairCmd.Parameters.AddWithValue("@dateofdelivery", DateTime.Now);
            handoverforrepairCmd.Parameters.AddWithValue("@returndate", "");
            handoverforrepairCmd.Parameters.AddWithValue("@carnumber", fixCarComboBox.Text);
            handoverforrepairCmd.Parameters.AddWithValue("@carservice", carServiceComboBox.SelectedIndex);
            try
            {
                if (handoverforrepairCmd.ExecuteNonQuery() > 0)
                {
                    MaterialMessageBox.Show("Авто сдан в ремонт ");
                   
                    ClearFields();


                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pickUpButton_Click(object sender, EventArgs e)
        {
            pickupfromtherepairCmd.Parameters.Clear();
            pickupfromtherepairCmd.Parameters.AddWithValue("@carnumber", carFixedComboBox.Text);
            pickupfromtherepairCmd.Parameters.AddWithValue("@returndate", DateTime.Now);


            try
            {
                if (pickupfromtherepairCmd.ExecuteNonQuery() > 0)
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

        private void insuranceButton_Click(object sender, EventArgs e)
        {
            insureacarCmd.Parameters.Clear();
            insureacarCmd.Parameters.AddWithValue("@numberpolis", insuranceNumberITextBox1.Text);
            insureacarCmd.Parameters.AddWithValue("@car", insuranceCarTextBox.Text);
            insureacarCmd.Parameters.AddWithValue("@company", insuranceCompanyTextBox.SelectedIndex);
            insureacarCmd.Parameters.AddWithValue("@datestart", dateStartTextBox.Value);
            insureacarCmd.Parameters.AddWithValue("@dateand", dateEndTextBox.Value);
            


            try
            {
                if (insureacarCmd.ExecuteNonQuery() > 0)
                {
                    MaterialMessageBox.Show("Авто застраховано ");

                    ClearFields();

                    
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

       

      

        private void deleteCarButton_Click(object sender, EventArgs e)
        {
            {
                deletecarCmd.Parameters.Clear();
                deletecarCmd.Parameters.AddWithValue("@car", CarNumberTextBox.Text);
                try
                {
                    if (deletecarCmd.ExecuteNonQuery() > 0)
                    {
                        MaterialMessageBox.Show("Запись удалена ");
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
    
}
