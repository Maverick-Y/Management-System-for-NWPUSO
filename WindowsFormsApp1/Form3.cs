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
    public partial class Form3 : Form
    {
        private string SNO;
        private SqlConnection conn;
        public Form3(string Sno, SqlConnection conn)
        {
            InitializeComponent();
            this.SNO = Sno;
            this.conn = conn;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            string sql = "select * from 演出信息 where 演出序号 in (select 演出序号 from 演出曲目人员 where 参演人员=" + SNO + ");";
            SqlCommand command = new SqlCommand(sql, conn);
            try
            {
                SqlDataReader sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    i++;
                    MessageBox.Show(sdr.GetInt32(0).ToString() + "    " +sdr.GetString(5) +"    " 
                        + sdr.GetString(1) + "    " + sdr.GetString(2) + "    " +
                         ((sdr.IsDBNull(3)) ? "空" : sdr.GetString(3)) + "    " + ((sdr.IsDBNull(4)) ? "空" : sdr.GetString(4)));
                }
                if(i==0)
                {
                    MessageBox.Show("查询结果为空!");
                }
                sdr.Close();
            }
            catch
            {
                MessageBox.Show("意外错误!请联系管理员处理。\nError = 30");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
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
                MessageBox.Show("意外错误!请联系管理员处理。\nError = 31");
            }
        }
    }
}
