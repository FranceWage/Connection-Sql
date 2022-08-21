using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Phap_SQL_NV
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=PHAP;Initial Catalog=QLCongTy;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void Load_Data()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from ThongTinNhanVien";
            //command.ExecuteNonQuery(); 1 cach 
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        public Form1()
        {
            InitializeComponent();
            cbxGioiTinh.Items.Add("Nam");
            cbxGioiTinh.Items.Add("Nu");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            Load_Data();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbMaNV.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            tbMaNV.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            tbTenNV.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            dtpNS.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            cbxGioiTinh.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            tbChucVu.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            tbTienLuong.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into ThongTinNhanVien values('" + tbMaNV.Text + "', '" + tbTenNV.Text + "', '" + dtpNS.Text + "', '" + cbxGioiTinh.Text + "', '" + tbChucVu.Text + "', '" + tbTienLuong.Text + "')";
            command.ExecuteNonQuery(); //Thuc hien cau lenh Inset Database ( neu co loi se bao lai tai day)
            Load_Data();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from ThongTinNhanVien where MaNV= '"+tbMaNV.Text+"'";
            command.ExecuteNonQuery();
            Load_Data();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update ThongTinNhanVien set TenNV = N'" + tbTenNV.Text + "',NgaySinh = '" + dtpNS.Text + "',GioiTinh = '" + cbxGioiTinh.Text + "',ChucVu = N'" + tbChucVu.Text + "',TienLuong = '" + tbTienLuong.Text + "'where MaNV = '" + tbMaNV.Text + "'";
            command.ExecuteNonQuery();
            Load_Data();
        }

        private void btnKhoiTao_Click(object sender, EventArgs e)
        {
            tbMaNV.Text = "";
            tbTenNV.Text = "";
            dtpNS.Text = "1/1/1990";
            cbxGioiTinh.Text = "";
            tbChucVu.Text = "";
            tbTienLuong.Text = "";
        }
    }
}
