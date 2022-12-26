using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        const int t = 30;
        public int zadumano = 0;
        int ostalos = 30;
        int nomer_popitki = 0;
        public Form1()
        {
            InitializeComponent();
            textBox1.Focus();
            toolStripStatusLabel1.Text = "У вас осталось " + Convert.ToString(t) + " сек";
            toolStripStatusLabel2.Text = " Попыток: 0 ";
            timer1.Enabled = true;
            timer1.Interval = 1000;
            progressBar1.Maximum = t;
            progressBar1.Value = t;
            progressBar1.Step = 1;
            Random n = new Random();
            zadumano = n.Next(10);
        }
        public void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }
        public void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }
        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void timer1_Tick(object sender, EventArgs e)
        {
            ostalos--;
            progressBar1.Value--;
            toolStripStatusLabel1.Text = "У вас осталось" + Convert.ToString(ostalos) + "сек";
            if (ostalos == 0)
            {
                timer1.Enabled = false;
                textBox1.Enabled = false;
                progressBar1.Enabled = false;
                label4.Text = "Увы, время истекло...";
            }
        }
        public void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)13))
            {
                try
                {
                    if (Convert.ToInt16(textBox1.Text) == zadumano)
                    {
                        timer1.Enabled = false;
                        textBox1.Enabled = false;
                        label1.Text = "Вы угадали! Задумывалось число " + Convert.ToString(zadumano);
                    };
                    if (Convert.ToInt16(textBox1.Text) > zadumano) label4.Text = "Задуманное число меньше";
                    if (Convert.ToInt16(textBox1.Text) < zadumano) label4.Text = "Задуманное число больше";
                }
                catch { label1.Text = "Некорректные входные данные!"; }
                nomer_popitki++;
                toolStripStatusLabel2.Text = " Попыток:" + Convert.ToString(nomer_popitki);
                textBox1.Text = "";
                textBox1.Focus();
            }
        }

        public void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
