using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ImageSearch
{
    public partial class Image_calculation : Form
    {
        public Image_calculation()
        {
            InitializeComponent();
        }

        private void Image_calculation_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // Создание подключения
            SqlConnection connection = new SqlConnection(connectionString);

            string sql = "SELECT * FROM PathToFile";
            //List<string> images = new List<string>();
            connection.Open();
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string path = reader.GetString(1);
                    string name = reader.GetString(2);
                    string tmp = path + " " + name;
                    listBox1.Items.Add(tmp);
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Picture_properties pic_pt = new Picture_properties();
            pic_pt.Show();
        }

    }
}
