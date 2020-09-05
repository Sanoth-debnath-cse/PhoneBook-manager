using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PhoneBook
{
    public partial class Form1 : Form
    {
        string search_query = "";
        string id = "";
        bool search = false;
        public Form1()
        {
            InitializeComponent();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox3.Text = "";
            textBox4.Clear();
            textBox5.Text = "Search here...";
            comboBox1.SelectedIndex = -1;
            textBox1.Focus();
            id = "";
            display();
        }
        void clear_display()
        {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.SelectedIndex = -1;
            id = "";
            textBox1.Focus();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (empty_check())
                {
                    MessageBox.Show("Please fill up all the fields");
                    return;
                }
                if (id != "")
                {
                    return;
                }
                if (!validation())
                {
                    return;
                }
                string conn = "datasource=localhost;username=root;password=";
                string query = "insert into phonebook.contacts(id,First_Name,Last_Name,Mobile,Email,Category) values(null,'" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.comboBox1.Text + "');";
                MySqlConnection conn2 = new MySqlConnection(conn);


                MySqlCommand command1 = new MySqlCommand(query, conn2);
                MySqlDataReader myReader;
                conn2.Open();
                myReader = command1.ExecuteReader();
                MessageBox.Show("Contact Saved!");
                clear_display();
                while (myReader.Read())
                {

                }
                conn2.Close();
                display();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void display()
        {
            try
            {
                string query = "";
                string conn = "datasource=localhost;username=root;password=";
                if (search == true)
                {
                    query = search_query;
                    search_query = "";
                    search = false;
                }
                else
                {
                    query = ("Select  First_Name,Last_Name,Mobile,Email,Category from phonebook.contacts");
                }

                MySqlConnection conn2 = new MySqlConnection(conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(query, conn2);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            display();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {


                if (empty_check() || id == "")
                {
                    return;
                }

                DialogResult result1 = MessageBox.Show("Are you sure ? ", "Warning!", MessageBoxButtons.OKCancel);
                if (result1 == DialogResult.Cancel)
                {
                    return;
                }
                string conn = "datasource=localhost;username=root;password=";
                string query = "delete from phonebook.contacts where  id = '" + id + "';";
                MySqlConnection conn2 = new MySqlConnection(conn);
                MySqlCommand command1 = new MySqlCommand(query, conn2);
                MySqlDataReader myReader;
                conn2.Open();
                myReader = command1.ExecuteReader();
                MessageBox.Show("Contact Deleted!");

                clear_display();
                while (myReader.Read())
                {

                }
                conn2.Close();
                display();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        bool empty_check()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.SelectedIndex == -1)
            {
                return true;
            }
            else
                return false;

        }
        bool validation()
        {
            string invalid = "";
            string mob = textBox3.Text;
            int flag3 = 0;
            // if (mob.Length == 11 && mob[0] == '0' && mob[1] == '1')
            //{
            for (int i = 0; i < mob.Length; i++)
            {
                if (mob[i] >= '0' && mob[i] <= '9')
                {
                    continue;
                }
                else
                {
                    flag3 = 1;
                    //MessageBox.Show("Invalid Mobile Number");
                    invalid = "Invalid Mobile Number \n";
                    break;
                    // return;
                }
            }

            string email = textBox4.Text;
            int flag = 0, flag2 = 0; ;
            for (int i = 1; i < email.Length; i++)
            {
                if (email[i] == '@' && (i + 3) < email.Length && email[i + 1] != '.')
                {
                    flag = 1;
                }
                if (flag == 1 && email[i] == '.' && i != (email.Length - 1))
                {
                    flag2 = 1;

                }
            }
            if (flag2 != 1)
            {
                invalid += "Invalid email \n";
            }

            if (flag3 == 1 || flag2 != 1)
            {
                MessageBox.Show(invalid);
                return false;
            }
            else
            {
                return true;
            }


        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (id == "")
                {
                    MessageBox.Show("please select an existing contact to update");
                    return;
                }
                else if (empty_check())
                {
                    MessageBox.Show("Please fill up all the fields");
                    return;
                }
                if (!validation())
                {
                    return;
                }
                string conn = "datasource=localhost;username=root;password=";

                string query = "update phonebook.contacts set  First_Name ='" + this.textBox1.Text + "' , Last_Name = '" + this.textBox2.Text + "', Mobile = '" + this.textBox3.Text + "' , Email = '" + this.textBox4.Text + "'  , Category = '" + this.comboBox1.Text + "' where id = '" + this.id + "';";
                //  squery = "";
                id = "";
                MySqlConnection conn2 = new MySqlConnection(conn);
                MySqlCommand command1 = new MySqlCommand(query, conn2);
                MySqlDataReader myReader;
                conn2.Open();
                myReader = command1.ExecuteReader();
                MessageBox.Show("Contact Updated!");
                clear_display();
                while (myReader.Read())
                {

                }
                conn2.Close();
                display();
            }
            catch (Exception ex)
            {
                MessageBox.Show("please select an existing contact to update");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox5.Text != "" && textBox5.Text != "Search here...")
            {
                search_query = ("Select  First_Name,Last_Name,Mobile,Email,Category from phonebook.contacts where First_Name LIKE '%" + this.textBox5.Text + "%' or Last_Name LIKE '%" + this.textBox5.Text + "%' or Mobile LIKE '%" + this.textBox5.Text + "%' or Email LIKE '%" + this.textBox5.Text + "%' or Category LIKE '%" + this.textBox5.Text + "%' ");
                search = true;
                display();
            }
            else
            {
                display();
            }
        }

        private void datagridview(object sender, MouseEventArgs e)
        {
            try
            {

                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                string query_select = "select id from phonebook.contacts  where First_Name ='" + this.textBox1.Text + "' and Last_Name = '" + this.textBox2.Text + "'and Mobile = '" + this.textBox3.Text + "' and Email = '" + this.textBox4.Text + "'  and Category = '" + this.comboBox1.Text + "'";
                // squery = query_select;

                string conn = "datasource=localhost;username=root;password=";
                MySqlConnection conn2 = new MySqlConnection(conn);
                MySqlCommand command1 = new MySqlCommand(query_select, conn2);
                conn2.Open();
                var query_id = command1.ExecuteScalar();
                id = Convert.ToString(query_id);

            }
            catch (Exception ex)
            {
                MessageBox.Show("No Contacts Found");
            }
        }
    }
}
