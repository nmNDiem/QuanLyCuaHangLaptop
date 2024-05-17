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
    public partial class fBanHang : Form
    {
        QLCHLapEntities db = new QLCHLapEntities();

        public fBanHang()
        {
            InitializeComponent();
            LoadDataSP();
            LoadDataDH();
        }

        void LoadDataSP()
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
        }

        void LoadDataDH()
        {
            var result = from sp in db.SanPham
                         join sp_hd in db.SanPham_HoaDonBanHang on sp.ID equals sp_hd.IDSanPham
                         join hd in db.HoaDonBanHang on sp_hd.IDHoaDonBanHang equals hd.ID
                         where(sp_hd.HoanThanh == 0)
                         select new
                         {
                             IDHoaDon = hd.ID,
                             hd.IDKhachHang,
                             IDSanPham = sp.ID,
                             TenSP = sp.TenSP,
                             sp.ThongSo,
                             sp.Gia,
                             hd.SoLuong,
                             ThanhTien = sp.Gia * hd.SoLuong
                         };
            dtgvDH.DataSource = result.ToList();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fSanPham f = new fSanPham();
            f.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fKhachHang f = new fKhachHang();
            f.Show();
        }

        private void bảoHànhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fBaoHanh f = new fBaoHanh();
            f.Show();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThongKe f = new fThongKe();
            f.Show();
        }

        private void txt_TimSP_TextChanged(object sender, EventArgs e)
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

            String kw = txt_TimSP.Text;

            if (!String.IsNullOrEmpty(kw))
            {
                result = result.Where(r => r.TenSP.Contains(kw));
            }

            dtgvSP.DataSource = result.ToList();
        }

        private void btn_ThemDon_Click(object sender, EventArgs e)
        {
            if (dtgvSP.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm.");
                return;
            }

            DataGridViewRow row = dtgvSP.SelectedRows[0];
            if (!int.TryParse(row.Cells["ID"].Value?.ToString(), out int idSP))
            {
                MessageBox.Show("ID sản phẩm không hợp lệ.");
                return;
            }

            if (!decimal.TryParse(row.Cells["Gia"].Value?.ToString(), out decimal gia))
            {
                MessageBox.Show("Giá sản phẩm không hợp lệ.");
                return;
            }

            if (!int.TryParse(nbr_SoLuong.Value.ToString(), out int int_soLuongMua) ||
                !decimal.TryParse(nbr_SoLuong.Value.ToString(), out decimal deci_soLuongMua))
            {
                MessageBox.Show("Số lượng mua không hợp lệ.");
                return;
            }

            if (!int.TryParse(txt_IdKH.Text, out int idKhachHang))
            {
                MessageBox.Show("ID Khách hàng không hợp lệ.");
                return;
            }

            try
            {
                AddSanPhamToHoaDon(idSP, gia, int_soLuongMua, deci_soLuongMua, idKhachHang);
                UpdateTongTien();
                LoadDataDH();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
            }
        }

        private void AddSanPhamToHoaDon(int idSP, decimal gia, int int_soLuongMua, decimal deci_soLuongMua, int idKhachHang)
        {
            var sanPhamHoaDon = new SanPham_HoaDonBanHang()
            {
                IDSanPham = idSP,
                NgayTao = DateTime.Now,
                HoanThanh = 0
            };

            var hoaDonBanHang = new HoaDonBanHang()
            {
                SoLuong = int_soLuongMua,
                IDKhachHang = idKhachHang,
                TongTien = gia * deci_soLuongMua
            };

            db.SanPham_HoaDonBanHang.Add(sanPhamHoaDon);
            db.HoaDonBanHang.Add(hoaDonBanHang);
            db.SaveChanges();
        }

        void UpdateTongTien()
        {
            var tongTien = db.HoaDonBanHang.Sum(hd => hd.TongTien);
            var tienNhan = decimal.Parse(txt_TienNhan.Text);
            var tienThua = tongTien - tienNhan;

            txt_TongTien.Text = tongTien.ToString();
            txt_TienThua.Text = tienThua.ToString();
        }

        void tinhTienThua()
        {
            var tongTien = db.HoaDonBanHang.Sum(hd => hd.TongTien);
            var tienNhan = decimal.Parse(txt_TienNhan.Text);
            var tienThua = tienNhan - tongTien;

            txt_TienThua.Text = tienThua.ToString();
        }

        private void txt_TienNhan_TextChanged(object sender, EventArgs e)
        {
            tinhTienThua();
        }

        void xoaSpTrongDon()
        {
            if (dtgvDH.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng.");
                return;
            }

            DataGridViewRow row = dtgvDH.SelectedRows[0];

            var idDH = int.Parse(row.Cells["IDHoaDon"].Value.ToString());

            HoaDonBanHang hd = db.HoaDonBanHang.Where(h => h.ID == idDH).SingleOrDefault();
            SanPham_HoaDonBanHang sp_hd = db.SanPham_HoaDonBanHang.Where(h => h.IDHoaDonBanHang == idDH).SingleOrDefault();

            db.HoaDonBanHang.Remove(hd);
            db.SanPham_HoaDonBanHang.Remove(sp_hd);

            db.SaveChanges();
            LoadDataDH();
        }

        private void btn_XoaSP_Click(object sender, EventArgs e)
        {
            xoaSpTrongDon();
        }

        private void btn_XuatHD_Click(object sender, EventArgs e)
        {
            if (dtgvDH.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng.");
                return;
            }
            DataGridViewRow row = dtgvDH.SelectedRows[0];

            var tenSP = row.Cells["TenSP"].Value.ToString();
            var idHoaDon = int.Parse(row.Cells["IDHoaDon"].Value.ToString());
            var idSP = int.Parse(row.Cells["IDSanPham"].Value.ToString());

            db.PhieuBaoHanh.Add(new PhieuBaoHanh()
            {
                TenSP = tenSP,
                ThoiHanBaoHanh = int.Parse(nbr_HanBH.Value.ToString()),
                IDHoaDonBanHang = idHoaDon
            });

            SanPham_HoaDonBanHang sp_hd = db.SanPham_HoaDonBanHang.Find(idSP, idHoaDon);
            sp_hd.HoanThanh = 1;

            db.SaveChanges();
            LoadDataDH();

            MessageBox.Show("Hoàn tất đơn hàng!");
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

            MessageBox.Show("Thêm thành công!");
        }
    }
}
