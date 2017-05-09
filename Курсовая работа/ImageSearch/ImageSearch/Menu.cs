using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageSearch
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            textBox1.Visible =true;
            label1.Visible = true;
            textBox2.Visible = false;
            label2.Visible = false;
            textBox3.Visible = false;
            label3.Visible = false;
            textBox4.Visible = false;
            label4.Visible = false;
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            label1.Visible = false;
            textBox2.Visible = false;
            label2.Visible = false;
            textBox3.Visible = false;
            label3.Visible = false;
            textBox4.Visible = false;
            label4.Visible = false;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            textBox2.Visible = true;
            label2.Visible = true;
            textBox1.Visible = false;
            label1.Visible = false;
            textBox4.Visible = false;
            label4.Visible = false;
            textBox3.Visible = false;
            label3.Visible = false;
        }


        private void button3_MouseHover_1(object sender, EventArgs e)
        {
            textBox2.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            label1.Visible = false;
            textBox4.Visible = false;
            label4.Visible = false;
            textBox3.Visible = true;
            label3.Visible = true;
        }

        private void button4_MouseHover_1(object sender, EventArgs e)
        {
            textBox2.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            label1.Visible = false;
            textBox3.Visible = false;
            label3.Visible = false;
            textBox4.Visible = true;
            label4.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Choose_image ch_img = new Choose_image();
            ch_img.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image_calculation img_calc = new Image_calculation();
            img_calc.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Build_gistogramm bulid_gis = new Build_gistogramm();
            bulid_gis.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sort_Images sort_img = new Sort_Images();
            sort_img.Show();
        }
    }
}
