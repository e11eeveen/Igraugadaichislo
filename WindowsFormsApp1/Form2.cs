using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        List<User> list = new List<User>();
        public Form2()
        {
            InitializeComponent();
            if (Serialize.IsFile("users.txt"))
            {
                list = Serialize.LoadFromFile("users.txt");
            }
        }
        private void button_login_Click(object sender, EventArgs e)
        {
            bool user_is_existed = false;
            foreach (var user in list)
            {
                if (textBox_login.Text == user.login && textBox_password.Text == user.password)
                {
                    user_is_existed = true;
                    Form1 Program = new Form1();
                    Program.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль!");
                }
            }
            if (user_is_existed == false)
            {
                MessageBox.Show("Такого польззователя не существует, нужно зарегистрироваться!");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }
        private void button_register_Click(object sender, EventArgs e)//кнопка "регистрация"
        {
            User user = new User();

            foreach (var usr in list)
            {
                if (usr.login == textBox_login.Text)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует!");
                    goto Marker1;
                }

            }
            user.login = textBox_login.Text;
            user.password = textBox_password.Text;
            list.Add(user);
            MessageBox.Show("Вы успешно зарегистрировались, используйте свой пароль и логин для входа в программу!");
            Marker1:
            textBox_login.Text = "";
            textBox_password.Text = "";
        }
        private void button5_Click(object sender, EventArgs e)
        {

        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Serialize.SaveToFile("users.txt", list);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Это игра угадай число. Пройдите регистрацию, а после чего авторизируйтесь. После входа вы сможете сыграть в игру. Игра заключается в угадывании числа в заданном интервале за определенный отрезок времени. Количество попыток неограничено. Введите в верхнее поле угадываемое число, после чего перейдите во второе поле и нажмите Enter. Если вы угадали, то таймер остановится и игра будет окончена, в противном случае программа выдаст сообщение о том, больше или меньше загаданное число.");
        }
    }
}
