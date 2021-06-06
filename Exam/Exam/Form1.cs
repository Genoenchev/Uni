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


namespace Exam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=127.0.0.1;Initial Catalog=task;");
            //string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=task";
            //MySqlConnection con = new MySqlConnection(MySQLConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT into music values (@idSong,@Title,@Singer)", con);
            cmd.Parameters.AddWithValue("@idSong", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Title", (textBox2.Text));
            cmd.Parameters.AddWithValue("@Singer", (textBox3.Text));
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Successfully Saved");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=127.0.0.1;Initial Catalog=task;");
            con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE music set Title=@Title, Singer=@Singer WHERE Id=idSong",con);
            cmd.Parameters.AddWithValue("@idSong", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Title", (textBox2.Text));
            cmd.Parameters.AddWithValue("@Singer", (textBox3.Text));
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Successfully updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=127.0.0.1;Initial Catalog=task;");
            con.Open();

            SqlCommand cmd = new SqlCommand("DELETE music WHERE Id=@idSong",con);
            cmd.Parameters.AddWithValue("@idSong",int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=127.0.0.1;Initial Catalog=task;");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * from music WHERE Id=@idSong",con);
            cmd.Parameters.AddWithValue("Id", int.Parse(textBox1.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
