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
    public partial class fSanPham : Form
    {
        QLCHLapEntities db = new QLCHLapEntities();

        public fSanPham()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            var result = from s in db.SanPham
                         select new
                         {
                            s.ID,
                            s.TenSP,
                            s.ThongSo,
                            s.Gia,
                            s.SoLuong
                         };
            dtgvSP.DataSource = result.ToList();

            txt_ID.Text = "";
            txt_TenSP.Text = "";
            txt_ThongSo.Text = "";
            txt_Gia.Text = "";
            nbr_SoLuong.Value = 0;
        }

        private void btn_ThemSP_Click(object sender, EventArgs e)
        {
            db.SanPham.Add(new SanPham()
            {
                TenSP = txt_TenSP.Text,
                ThongSo = txt_ThongSo.Text,
                Gia = decimal.Parse(txt_Gia.Text),
                SoLuong = int.Parse(nbr_SoLuong.Value.ToString())
            });
            db.SaveChanges();
            LoadData();
        }

        private void btn_SuaSP_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dtgvSP.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString());
            SanPham sp = db.SanPham.Find(id);

            sp.TenSP = txt_TenSP.Text;
            sp.ThongSo = txt_ThongSo.Text;
            sp.Gia = decimal.Parse(txt_Gia.Text);
            sp.SoLuong = int.Parse(nbr_SoLuong.Value.ToString());

            db.SaveChanges();
            LoadData();
        }

        private void btn_XoaSP_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_ID.Text);
            SanPham sp = db.SanPham.Where(s => s.ID == id).SingleOrDefault();

            db.SanPham.Remove(sp);
            db.SaveChanges();
            LoadData();
        }

        private void btn_TimSP_Click(object sender, EventArgs e)
        {
            var result = from s in db.SanPham
                         select new
                         {
                             s.ID,
                             s.TenSP,
                             s.ThongSo,
                             s.Gia,
                             s.SoLuong
                         };

            String kw = txt_TenSP.Text;

            if (!String.IsNullOrEmpty(kw))
            {
                result = result.Where(r => r.TenSP.Contains(kw));
            }

            dtgvSP.DataSource = result.ToList();
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
