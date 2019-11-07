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
    public partial class Form4 : Form
    {
        private string SNO;
        private SqlConnection conn;
        public Form4(string Sno, SqlConnection conn)
        {
            InitializeComponent();
            this.SNO = Sno;
            this.conn = conn;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            string sql = "select * from 演出信息 where 演出序号 in (select 演出序号 from 演出曲目人员 where 参演人员=" + textBox1.Text.Trim() + ");";
            SqlCommand command = new SqlCommand(sql, conn);
            try
            {
                SqlDataReader sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    i++;
                    MessageBox.Show(sdr.GetInt32(0).ToString() + "    " + sdr.GetString(5) + "    "
                        + sdr.GetString(1) + "    " + sdr.GetString(2) + "    " +
                         ((sdr.IsDBNull(3)) ? "空" : sdr.GetString(3)) + "    " + ((sdr.IsDBNull(4)) ? "空" : sdr.GetString(4)));
                }
                if (i == 0)
                {
                    MessageBox.Show("查询结果为空!");
                }
                sdr.Close();
            }
            catch
            {
                MessageBox.Show("意外错误!请联系管理员处理。\nError = 40");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string sql = "delete from 学生 where 学号=" + textBox1.Text.Trim() + ");";
            SqlCommand command = new SqlCommand(sql, conn);
            try
            {
                SqlDataReader sdr = command.ExecuteReader();
                MessageBox.Show("执行成功!");
                sdr.Close();
            }
            catch
            {
                MessageBox.Show("执行失败!");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            int i = 0;
            string sql = "select * from 学生;";
            SqlCommand command = new SqlCommand(sql, conn);
            try
            {
                SqlDataReader sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    i++;
                    MessageBox.Show(sdr.GetString(0) + "    "+ sdr.GetString(1) + "    " + sdr.GetString(2) + "    " + sdr.GetString(4) + "    " + sdr.GetString(5));
                }
                if (i == 0)
                {
                    MessageBox.Show("查询结果为空!");
                }
                sdr.Close();
            }
            catch
            {
                MessageBox.Show("意外错误!请检查输入。");
            }
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            string sql = textBox1.Text.Trim();
            SqlCommand command = new SqlCommand(sql, conn);
            try
            {
                SqlDataReader sdr = command.ExecuteReader();
                MessageBox.Show("操作成功!");
                sdr.Close();
            }
            catch
            {
                MessageBox.Show("操作失败！");
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            string sql1 = "select Premission from Pwd where Sno=" + textBox1.Text.Trim() + ";";
            string sql2 = "update 首席 set 学号=" + textBox1.Text.Trim() + "where 声部 =(select 声部 from 学生 where 学号 = " + textBox1.Text.Trim() +
                ";)update Pwd set Premission = 1 where Sno=" + textBox1.Text.Trim() + ";";
            string sql3 = "update 首席 set 学号= NULL where 声部 =(select 声部 from 学生 where 学号 = " + textBox1.Text.Trim() +
                           ";)update Pwd set Premission = 0 where Sno=" + textBox1.Text.Trim() + ";";
            int premission = -1;
            SqlCommand command1 = new SqlCommand(sql1, conn);
            try
            {
                SqlDataReader sdr1 = command1.ExecuteReader();
                while (sdr1.Read())
                {
                    premission = sdr1.GetInt32(0);
                }
                sdr1.Close();
            }
            catch
            {
                MessageBox.Show("意外错误!请检查输入。");
            }

            if(premission == 0)
            {
                try
                {
                    SqlCommand command2 = new SqlCommand(sql2, conn);
                    SqlDataReader sdr2 = command2.ExecuteReader();
                    sdr2.Close();
                    MessageBox.Show("成功设置"+ textBox1.Text.Trim()+"为首席!");
                }
                catch
                {
                    MessageBox.Show("执行失败。");
                }
            }
            if (premission == 1)
            {
                try
                {
                    SqlCommand command3 = new SqlCommand(sql3, conn);
                    SqlDataReader sdr3 = command3.ExecuteReader();
                    sdr3.Close();
                    MessageBox.Show("成功撤销" + textBox1.Text.Trim() + "首席身份!");
                }
                catch
                {
                    MessageBox.Show("执行失败。");
                }
            }

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            int i = 0;
            string sql = "select * from 乐谱;";
            SqlCommand command = new SqlCommand(sql, conn);
            try
            {
                SqlDataReader sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    i++;
                    MessageBox.Show(sdr.GetInt32(0).ToString() + "    " +
                       sdr.GetString(7) + "    " + sdr.GetString(1) + "    " + sdr.GetString(2));
                }
                if (i == 0)
                {
                    MessageBox.Show("查询结果为空!");
                }
                sdr.Close();
            }
            catch
            {
                MessageBox.Show("意外错误!请联系管理员处理。\nError = 41");
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            int i = 0;
            string sql = "select * from 乐谱 where 谱子名称 = "+ textBox1.Text.Trim() + "; ";
            SqlCommand command = new SqlCommand(sql, conn);
            try
            {
                SqlDataReader sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    i++;
                    MessageBox.Show(sdr.GetInt32(0).ToString() + "    " +
                       sdr.GetString(7) + "    " + sdr.GetString(1) + "    " + sdr.GetString(2));
                }
                if (i == 0)
                {
                    MessageBox.Show("查询结果为空!");
                }
                sdr.Close();
            }
            catch
            {
                MessageBox.Show("意外错误!请检查输入。");
            }
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            string sql = "delete  from 乐谱 where 谱子名称 = " + textBox1.Text.Trim() + "; ";
            SqlCommand command = new SqlCommand(sql, conn);
            try
            {
                SqlDataReader sdr = command.ExecuteReader();
                MessageBox.Show("删除成功！");
                sdr.Close();
            }
            catch
            {
                MessageBox.Show("删除失败！");
            }
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            int i = 0;
            string sql = "select * from 队内资产;";
            SqlCommand command = new SqlCommand(sql, conn);
            try
            {
                SqlDataReader sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    i++;
                    MessageBox.Show(sdr.GetInt32(0).ToString() + "    " + sdr.GetString(2) + "    "
                        + sdr.GetString(1) + "    " + sdr.GetString(5) + "    " +
                         ((sdr.IsDBNull(3)) ? "空" : sdr.GetString(3)) + "    " + ((sdr.IsDBNull(4)) ? "空" : sdr.GetString(4)));
                }
                if (i == 0)
                {
                    MessageBox.Show("查询结果为空!");
                }
                sdr.Close();
            }
            catch
            {
                MessageBox.Show("意外错误!请联系管理员处理。\nError = 42");
            }
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            int i = 0;
            string sql = "select * from 队内资产 where 乐器=" + textBox1.Text.Trim() +"; ";
            SqlCommand command = new SqlCommand(sql, conn);
            try
            {
                SqlDataReader sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    i++;
                    MessageBox.Show(sdr.GetInt32(0).ToString() + "    " + sdr.GetString(2) + "    "
                        + sdr.GetString(1) + "    " + sdr.GetString(5) + "    " +
                         ((sdr.IsDBNull(3)) ? "空" : sdr.GetString(3)) + "    " + ((sdr.IsDBNull(4)) ? "空" : sdr.GetString(4)));
                }
                if (i == 0)
                {
                    MessageBox.Show("查询结果为空!");
                }
                sdr.Close();
            }
            catch
            {
                MessageBox.Show("意外错误!请检查输入。");
            }
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            int i = 0;
            string sql = "select * from 演出信息";
            SqlCommand command = new SqlCommand(sql, conn);
            try
            {
                SqlDataReader sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    i++;
                    MessageBox.Show(sdr.GetInt32(0).ToString() + "    " + sdr.GetString(5) + "    "
                        + sdr.GetString(1) + "    " + sdr.GetString(2) + "    " +
                         ((sdr.IsDBNull(3)) ? "空" : sdr.GetString(3)) + "    " + ((sdr.IsDBNull(4)) ? "空" : sdr.GetString(4)));
                }
                if (i == 0)
                {
                    MessageBox.Show("查询结果为空!");
                }
                sdr.Close();
            }
            catch
            {
                MessageBox.Show("意外错误!请联系管理员处理。\nError = 43");
            }
        }
    }
}
