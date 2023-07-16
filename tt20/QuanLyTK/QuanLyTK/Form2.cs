using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTK
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 dangNhap = new Form1();
            this.Hide();
            dangNhap.ShowDialog();
        }

        private void picHome_Click(object sender, EventArgs e)
        {
            Form3 frmHome = new Form3();
            this.Hide();
            frmHome.ShowDialog();
        }

        private void picThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picHome_MouseHover(object sender, EventArgs e)
        {
            picHome.BorderStyle = BorderStyle.Fixed3D;
        }
    

        private void picHome_MouseLeave(object sender, EventArgs e)
        {
        picHome.BorderStyle = BorderStyle.None;
    }

        private void picThoat_MouseHover(object sender, EventArgs e)
        {
            picThoat.BorderStyle = BorderStyle.Fixed3D;
        }


        private void picThoat_MouseLeave(object sender, EventArgs e)
        {
            picThoat.BorderStyle = BorderStyle.None;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 dangNhap = new Form1();
            this.Hide();
            dangNhap.ShowDialog();
            
        }
    }
}
