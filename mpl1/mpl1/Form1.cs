using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.IO;

namespace mpl1
{
    
    public partial class Form1 : Form
    {

        double a, b, c;
        /// <summary>
        /// главная формв
        /// </summary>
        const string userRoot = "HKEY_CURRENT_USER";
        const string subkey = "RegistrySetValueExample";
        const string keyName = userRoot + "\\" + subkey;

        /// <summary>
        /// Инициализация компонентов и установка размеров окна заданное предыдущим пользоватлем
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.Width = Convert.ToInt32(Registry.GetValue(keyName, "idth", 100)); 
            this.Height = Convert.ToInt32(Registry.GetValue(keyName, "eight", 100)); 
            
            
            
        }

        /// <summary>
        /// main function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
               disc();
        }

        /// <summary>
        /// проверка нажатия клавиш при вводе a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && (e.KeyChar <= 43 || e.KeyChar >= 46) ) //калькулятор
            {
                e.Handled = true;
                
            }
        }

        /// <summary>
        /// проверка нажатия клавиш при вводе b
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && (e.KeyChar <= 43 || e.KeyChar >= 46)) //калькулятор
            {
                e.Handled = true;

            }
        }

        /// <summary>
        /// проверка нажатия клавиш при вводе с
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && (e.KeyChar <= 43 || e.KeyChar >= 46) ) //калькулятор
            {
                e.Handled = true;

            }
        }

        /// <summary>
        /// обработка нажатия textBox1_Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || textBox1.Text=="." || textBox1.Text == ",")
            {
                // Условие при NULL в боксе.
                a = 0;
            }
            else 
            {

                a = Convert.ToDouble(textBox1.Text);
            }
           
        }

        /// <summary>
        /// обработка нажатия textBox2_Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) || textBox2.Text == "." || textBox2.Text == ",")
            {
                // Условие при NULL в боксе.
                b = 0;
            }
            else 
            {

                b = Convert.ToDouble(textBox2.Text);
            }
           
        }

        /// <summary>
        /// обработка нажатия textBox13_Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text) || textBox3.Text == "." || textBox3.Text == ",")
            {
                // Условие при NULL в боксе.
                c = 0;
            }
            else 
            {

                c = Convert.ToDouble(textBox3.Text);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            
            label5.Text = "Ответ2";
            label6.Text = "Ответ2";
            
        }

        double d;

        /// <summary>
        /// Определяет есть ли ошибка
        /// </summary>
        public void disc()
        {
            d = b * b - 4 * a * c;

            if (d<0)
            {

                error();
            }
            else 
            {

                ras();
            }
        }

        /// <summary>
        /// Отвечате за вывод ошибки
        /// </summary>
        public void error()
        {
            MessageBox.Show("Дискриминант меньше нуля, решайте сами");

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
           
        }

        /// <summary>
        /// выполняет основной расчет
        /// </summary>
        public  void ras()
        {
            if (d == 0)
            {
                var x = (-b) / (2 * a);

                label5.Text = "x1= " + x.ToString();
                label6.Text = "x2= " + x.ToString();
            }
            else
            {
                var x1 = (-b + Math.Sqrt(d)) / (2 * a);
                var x2 = (-b - Math.Sqrt(d)) / (2 * a);


                label5.Text = "x1= " + x1.ToString();
                label6.Text = "x2= " + x2.ToString();
                
                
                
            }
        }

        
        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            int w = this.Width;
            int h = this.Height;
            Registry.SetValue(keyName, "idth", w);
            Registry.SetValue(keyName, "eight", h);
        }

        RijndaelManaged rmCrypto = new RijndaelManaged();
        byte[] key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
        byte[] iv = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
        string path = @"C:\TEMP\crypt.txt";
        
        /// <summary>
        /// registr
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e) { 
            
                Registry.SetValue(keyName, "login", login.Text);
                FileStream potokfile = File.OpenWrite(path);
                CryptoStream cr = new CryptoStream(potokfile, rmCrypto.CreateEncryptor(key, iv), CryptoStreamMode.Write);
                StreamWriter sw = new StreamWriter(cr);
                sw.Write(password.Text);
                sw.Close();
                cr.Close();
                potokfile.Close();
                password.Clear();
                login.Clear();
                
            
        }

        /// <summary>
        /// vhod
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {

            if (File.Exists(path))
            {

                FileStream potok = File.OpenRead(path);
                CryptoStream p = new CryptoStream(potok, rmCrypto.CreateDecryptor(key, iv), CryptoStreamMode.Read);
                StreamReader p1 = new StreamReader(p);
                var d = Convert.ToString(p1.ReadLine());

                p1.Close();
                p.Close();
                potok.Close();

                if (password.Text == d && Convert.ToString(Registry.GetValue(keyName, "login", 0)) == login.Text)
                {
                    MessageBox.Show("все хорошо?");
                }
                else
                {
                    MessageBox.Show("не знаешь пароля (либо логинa)");
                    password.Clear();
                    login.Clear();
                }
            }else
            {
                MessageBox.Show("Никто еще не регистрировался, будьте первыми");
            }
            
        }



       
        

        
    }
    
 
}
