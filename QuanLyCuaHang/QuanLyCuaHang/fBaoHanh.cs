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
    public partial class fBaoHanh : Form
    {
        QLCHLapEntities db = new QLCHLapEntities();

        public fBaoHanh()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            var result = from h in db.HoaDonBaoHanh
                         join p in db.PhieuBaoHanh on h.IDPhieuBaoHanh equals p.ID
                         select new
                         {
                             IDHoaDonBaoHanh = h.ID,
                             IDPhieuBaoHanh = p.ID,
                             p.TenSP,
                             p.ThoiHanBaoHanh,
                             h.LyDoBH,
                             h.TrangThaiBH,
                             p.IDHoaDonBanHang
                         };
            dtgvBH.DataSource = result.ToList();

            var listPBH = from pbh in db.PhieuBaoHanh
                              select pbh;
            cbb_IdPBH.DataSource = listPBH.ToList();
            cbb_IdPBH.DisplayMember = "ID";

            txt_LyDoBH.Text = "";
        }

        private void btn_ThemBH_Click(object sender, EventArgs e)
        {
            cbb_IdPBH.DataSource = db.PhieuBaoHanh;

            db.HoaDonBaoHanh.Add(new HoaDonBaoHanh()
            {
                IDPhieuBaoHanh = cbb_IdPBH.SelectedIndex,
                LyDoBH = txt_LyDoBH.Text,
                TrangThaiBH = cbb_TrangThaiBH.SelectedItem.ToString()
            });
            db.SaveChanges();
            LoadData();
        }

        private void btn_SuaBH_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dtgvBH.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString());
            HoaDonBaoHanh hd = db.HoaDonBaoHanh.Find(id);

            hd.IDPhieuBaoHanh = cbb_IdPBH.SelectedIndex;
            hd.LyDoBH = txt_LyDoBH.Text;
            hd.TrangThaiBH = cbb_TrangThaiBH.SelectedItem.ToString();

            db.SaveChanges();
            LoadData();
        }

        private void btn_XoaBH_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_IdBH.Text);
            HoaDonBaoHanh hd = db.HoaDonBaoHanh.Where(h => h.ID == id).SingleOrDefault();

            db.HoaDonBaoHanh.Remove(hd);
            db.SaveChanges();
            LoadData();
        }

        private void btn_TimPBH_Click(object sender, EventArgs e)
        {
            var result = from p in db.PhieuBaoHanh
                         select new
                         {
                             IDPhieuBaoHanh = p.ID,
                             p.TenSP,
                             p.ThoiHanBaoHanh,
                             p.IDHoaDonBanHang
                         };

            int idPBH = int.Parse(cbb_IdPBH.Text);

            result = result.Where(r => r.IDPhieuBaoHanh == idPBH);

            dtgvBH.DataSource = result.ToList();
        }
    }
}
