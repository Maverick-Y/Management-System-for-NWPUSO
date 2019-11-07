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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private SqlConnection conn;
        public Form1()
        {
            InitializeComponent();
            try
            {
                SqlConnection conn = new SqlConnection("Server=(local);Database=club;Trusted_Connection=True;");
                conn.Open();
                this.conn = conn;
            }
            catch
            {
                MessageBox.Show("数据库连接失败！");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string pwd = "1";
            int premission = -1;
            string sql = "select Pwd,Premission from Pwd where Sno=" + textBox1.Text.Trim() + ";";
            SqlCommand command = new SqlCommand(sql, conn);
            try
            {
                SqlDataReader sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    pwd = sdr.GetString(0).Trim();
                    premission = sdr.GetInt32(1);

                };
                if (pwd == textBox2.Text.Trim())
                {
                    if (premission == 0)
                    {
                        Form3 form3 = new Form3(textBox1.Text.Trim(),conn);
                        form3.Show();
                    }
                    else
                    {
                        Form4 form4 = new Form4(textBox1.Text.Trim(),conn);
                        form4.Show();
                    }
                }
                else
                {
                    //MessageBox.Show("用户名不存在或密码错误！");
                    MessageBox.Show("密码错误！");
                }
                sdr.Close();
            }
            catch
            {
                MessageBox.Show("用户名不存在或密码错误！");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(conn);
            form2.Show();
        }
    }
}
