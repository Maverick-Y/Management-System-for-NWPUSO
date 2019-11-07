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
    public partial class Form2 : Form
    {
        private SqlConnection conn;
        public Form2(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string sql = "Insert into Pwd values(" + textBox1.Text.Trim() + "," + textBox2.Text.Trim() + ",0);";
            SqlCommand command = new SqlCommand(sql, conn);
            try
            {
                SqlDataReader sdr = command.ExecuteReader();
                MessageBox.Show("注册成功!");
                sdr.Close();
            }
            catch
            {
                MessageBox.Show("注册失败!输入错误或用户名已存在！");
            }
        }
    }
}
