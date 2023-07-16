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
using static System.Net.Mime.MediaTypeNames;

namespace QuanLyTK
{
    public partial class Form3 : Form
    {
        private string connectionString = @"Data Source=DESKTOP-6T9JTF7\DAT;Initial Catalog=TaiKhoan;Integrated Security=True";
        private SqlConnection conn;
        private SqlDataAdapter Adapter;
        
        private DataSet ds;
        private DataTable dt;
        public Form3()
        {
            InitializeComponent();
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            
            conn = new SqlConnection(connectionString);
            conn.Open();
            
            Hienthi();
           
            
            
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }


        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 dangNhap = new Form1();
            this.Hide();
            dangNhap.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv1.ReadOnly = true;
            

        }

       
        public void loadgridbykeyword()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();

            string sqlStr = "Select MemberID as N'ID', AccountName as N'Tên tài khoản', Password as N'Mật khẩu', GroupUser as N'Thuộc Nhóm', CurrentTime as N'Thời gian hiện có', CurrentMoney as N'Số  tiền hiện có', StatusAccount as N'Trạng thái' \r\nfrom Member where AccountName like '%" + txtTim.Text+"%'";
            Adapter = new SqlDataAdapter(sqlStr, conn);
            ds = new DataSet();
            Adapter.Fill(ds, "Member");
            dt = ds.Tables["Member"];

            //dgv1.AutoGenerateColumns = false;
            dgv1.DataSource = dt;
            conn.Close();
        }

        public void loadgridbykeyword1()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();

            string sqlStr = "Select AccountName as N'Tên tài khoản', Password as N'Mật khẩu', MoneyT as N'Nạp tiền'\r\nfrom TK  where AccountName like '%" + txtTim1.Text + "%'";
            Adapter = new SqlDataAdapter(sqlStr, conn);
            ds = new DataSet();
            Adapter.Fill(ds, "TK");
            dt = ds.Tables["TK"];

            //dgv1.AutoGenerateColumns = false;
            dgv2.DataSource = dt;
            conn.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            loadgridbykeyword();
        }

        private void btnHien_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();

            string sqlStr = "Select MemberID as N'ID', AccountName as N'Tên tài khoản', Password as N'Mật khẩu', GroupUser as N'Thuộc Nhóm', CurrentTime as N'Thời gian hiện có', CurrentMoney as N'Số  tiền hiện có', StatusAccount as N'Trạng thái' \r\nfrom Member";
            Adapter = new SqlDataAdapter(sqlStr, conn);
            ds = new DataSet();
            Adapter.Fill(ds, "Member");
            dt = ds.Tables["Member"];

            //dgv1.AutoGenerateColumns = false;
            dgv1.DataSource = dt;
            conn.Close();
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            loadgridbykeyword();
           
        }

        private void xóaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                int CurrentIndex = dgv1.CurrentCell.RowIndex;
                string ID = Convert.ToString(dgv1.Rows[CurrentIndex].Cells[0].Value.ToString());
                string deletedStr = "Delete from Member where MemberID='" + ID + "'";
                SqlCommand deletedCmd = new SqlCommand(deletedStr, conn);
                deletedCmd.CommandType = CommandType.Text;
                deletedCmd.ExecuteNonQuery();
                Adapter.Update(ds, "Member");
                string sqlStr = "Select MemberID as N'ID', AccountName as N'Tên tài khoản', Password as N'Mật khẩu', GroupUser as N'Thuộc Nhóm', CurrentTime as N'Thời gian hiện có', CurrentMoney as N'Số  tiền hiện có', StatusAccount as N'Trạng thái' \r\nfrom Member";
                Adapter = new SqlDataAdapter(sqlStr, conn);
                ds = new DataSet();
                Adapter.Fill(ds, "Member");
                dt = ds.Tables["Member"];

                //dgv1.AutoGenerateColumns = false;
                dgv1.DataSource = dt;
                MessageBox.Show("Bạn đã xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        public void Hienthi1()
        {
            string sqlStr = "Select MemberID as N'ID', AccountName as N'Tên tài khoản', Password as N'Mật khẩu', GroupUser as N'Thuộc Nhóm', CurrentTime as N'Thời gian hiện có', CurrentMoney as N'Số  tiền hiện có', StatusAccount as N'Trạng thái' \r\nfrom Member";
            Adapter = new SqlDataAdapter(sqlStr, conn);
            ds = new DataSet();
            Adapter.Fill(ds, "Member");
            dt = ds.Tables["Member"];

            //dgv1.AutoGenerateColumns = false;
            dgv1.DataSource = dt;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }
        public void Hienthi()
        {
            string sqlSelect = "Select AccountName as N'Tên tài khoản', Password as N'Mật khẩu', MoneyT as N'Nạp tiền'\r\nfrom TK ";
            SqlCommand command = new SqlCommand(sqlSelect, conn);
            SqlDataReader dr = command.ExecuteReader();
            DataTable dt= new DataTable();
            dt.Load(dr);
            dgv2.DataSource = dt;
        }

        private void btnXem1_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            Hienthi();
            conn.Close();
        }

        private void btnThem1_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            string sqlINSET = "INSERT INTO TK VALUES (@AccountName, @Password, @MoneyT )";
            SqlCommand cmd = new SqlCommand(sqlINSET, conn);
            cmd.Parameters.AddWithValue("AccountName", txtTen.Text);
            cmd.Parameters.AddWithValue("Password", txtMatKhau.Text);
            cmd.Parameters.AddWithValue("MoneyT", txtNapThem.Text);
            cmd.ExecuteNonQuery();
            Hienthi();
            conn.Close();
        }

        private int indexOfContent;
        private void btnSua1_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            DataGridViewRow dtgv = dgv2.Rows[indexOfContent];

            if (dtgv.Index >= 0)
            {
                dtgv.Cells[0].Value = txtTen.Text;
                dtgv.Cells[1].Value = txtMatKhau.Text;
                dtgv.Cells[2].Value = txtNapThem.Text;
            }
            
            conn.Close();
        }

        private void btnXoa1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                int CurrentIndex = dgv2.CurrentCell.RowIndex;
                string ID1 = Convert.ToString(dgv2.Rows[CurrentIndex].Cells[0].Value.ToString());
                string deletedStr = "Delete from TK where AccountName ='" + ID1 + "'";
                SqlCommand deletedCmd = new SqlCommand(deletedStr, conn);
                deletedCmd.CommandType = CommandType.Text;
                deletedCmd.ExecuteNonQuery();
                
                string sqlStr = "Select AccountName as N'Tên tài khoản', Password as N'Mật khẩu', MoneyT as N'Nạp tiền'\r\nfrom TK ";
                Adapter = new SqlDataAdapter(sqlStr, conn);
                ds = new DataSet();
                Adapter.Fill(ds, "TK");
                dt = ds.Tables["TK"];

                //dgv1.AutoGenerateColumns = false;
                dgv2.DataSource = dt;
                MessageBox.Show("Bạn đã xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTim1_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            string sqlTIMKIEM= "Select AccountName as N'Tên tài khoản', Password as N'Mật khẩu', MoneyT as N'Nạp tiền'\r\nfrom TK   where AccountName = @AccountName";
            SqlCommand cmd = new SqlCommand(sqlTIMKIEM, conn);
            cmd.Parameters.AddWithValue("AccountName", txtTim1.Text);
            cmd.Parameters.AddWithValue("Password", txtMatKhau.Text);
            cmd.Parameters.AddWithValue("MoneyT", txtNapThem.Text);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgv2.DataSource = dt;
            conn.Close();
        }

        private void txtTim1_TextChanged(object sender, EventArgs e)
        {
            loadgridbykeyword1();
        }

        private void dgv2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgv2.Rows[e.RowIndex];
                txtTen.Text = row.Cells[0].Value.ToString();
                txtMatKhau.Text = row.Cells[1].Value.ToString();
                txtNapThem.Text = row.Cells[2].Value.ToString();


            }
            catch (Exception)
            {


            }
        }
    }
}
