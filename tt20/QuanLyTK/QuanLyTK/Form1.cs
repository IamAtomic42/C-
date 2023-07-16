using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            Account managerAccount = new Account("Quản lý", "123");
            Account staffAccount = new Account("Nhân viên", "123");
            
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (cbbTK.Text.Equals("") || cbbTK.Text.Equals("--Lựa Chọn--"))
            {
                MessageBox.Show("Chưa chọn loại tài khoản! Vui lòng chọn!");
                cbbTK.Select();
            }
            else if (txtMK.Text.Equals(""))
            {
                MessageBox.Show("Chưa nhập mật khẩu! Vui lòng nhập vào");
                txtMK.Select();
            }
            else
            {
                if (cbbTK.Text.Equals("Quản lý") && txtMK.Text.Equals("123"))
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    Form2 form2 = new Form2();
                    this.Hide();
                    form2.ShowDialog();
                }
                else if (cbbTK.Text.Equals("Nhân viên") && txtMK.Text.Equals("123"))
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    Form2 form2 = new Form2();
                    this.Hide();
                    form2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void chkAnHien_CheckedChanged(object sender, EventArgs e)
        {
            if (txtMK.PasswordChar == '*')
            {
                txtMK.PasswordChar = '\0';
            }
            else
            {
                if (txtMK.PasswordChar == '\0')
                {
                    txtMK.PasswordChar = '*';
                }
            }
        }

        private void btnThoat1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
