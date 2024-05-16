using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHang
{
    public partial class fKhachHang : Form
    {
        QLCHLapEntities db = new QLCHLapEntities();

        public fKhachHang()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            var result = from k in db.KhachHang
                         select new
                         {
                             k.ID,
                             k.TenKH,
                             k.SDT,
                             k.DiaChi,
                             k.HoaDonBanHang
                         };
            dtgvKH.DataSource = result.ToList();

            txt_ID.Text = "";
            txt_TenKH.Text = "";
            txt_Sdt.Text = "";
            txt_DiaChi.Text = "";
        }

        private void btn_ThemKH_Click(object sender, EventArgs e)
        {
            db.KhachHang.Add(new KhachHang()
            {
                TenKH = txt_TenKH.Text,
                SDT = txt_Sdt.Text,
                DiaChi = txt_DiaChi.Text
            });
            db.SaveChanges();
            LoadData();
        }

        private void btn_SuaKH_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dtgvKH.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString());
            KhachHang kh = db.KhachHang.Find(id);

            kh.TenKH = txt_TenKH.Text;
            kh.SDT = txt_Sdt.Text;
            kh.DiaChi = txt_DiaChi.Text;

            db.SaveChanges();
            LoadData();
        }

        private void btn_XoaKH_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_ID.Text);
            KhachHang kh = db.KhachHang.Where(k => k.ID == id).SingleOrDefault();

            db.KhachHang.Remove(kh);
            db.SaveChanges();
            LoadData();
        }

        private void btn_TimKH_Click(object sender, EventArgs e)
        {
            var result = from k in db.KhachHang
                         select new
                         {
                             k.ID,
                             k.TenKH,
                             k.SDT,
                             k.DiaChi,
                             k.HoaDonBanHang
                         };

            String kw = txt_TenKH.Text;

            if (!String.IsNullOrEmpty(kw))
            {
                result = result.Where(r => r.TenKH.Contains(kw));
            }

            dtgvKH.DataSource = result.ToList();
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
