using System;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



namespace ImageSearch
{
    public partial class Choose_image : Form
    {
        public Choose_image()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.Description = "Choose directory with images";
            fbd.ShowNewFolderButton = false;

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // Создание подключения
            SqlConnection connection = new SqlConnection(connectionString);    

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                //Получения всех файлов с расширением .jpg из директории и поддиректорий выбраных пользователем 
                string[] files = Directory.GetFiles(fbd.SelectedPath, "*jpg", SearchOption.AllDirectories);
                connection.Open();
                foreach (string file in files)
                {
                    //Получение имя изображения формата Name.jpg. Если только для имени без расширения то использовать 
                    //метод GetFileNameWithoutExtension 
                    string s = Path.GetFileName(file);
                    //Получение пути изображения. 
                    string path = file.Substring(0, file.Length - s.Length);
                    listBox1.Items.Add(path);
                    listBox2.Items.Add(s);

                    string sql = "INSERT INTO PathToFile (path, imgname) VALUES ('"+ path + "' , '" + s + "')";
                    //string sqlSelect = "SELECT * FROM PathToFile";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                    //Создаем дата-адаптер
                    //SqlDataAdapter adapter = new SqlDataAdapter(sqlSelect, connection);
                    //DataSet ds = new DataSet();
                    //adapter.Fill(ds);
                }
                connection.Close();
            }

         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
