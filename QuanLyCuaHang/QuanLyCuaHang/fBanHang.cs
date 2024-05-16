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
                         select new
                         {
                             IDSanPham = sp.ID,
                             sp.TenSP,
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
            if (dtgvSP.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dtgvSP.SelectedRows[0];
                int idSP;
                decimal gia;

                if (int.TryParse(row.Cells["ID"].Value?.ToString(), out idSP) &&
                    decimal.TryParse(row.Cells["Gia"].Value?.ToString(), out gia))
                {
                    int int_soLuongMua;
                    decimal deci_soLuongMua;

                    if (int.TryParse(nbr_SoLuong.Value.ToString(), out int_soLuongMua) &&
                        decimal.TryParse(nbr_SoLuong.Value.ToString(), out deci_soLuongMua))
                    {
                        int idKhachHang;
                        if (int.TryParse(txt_IdKH.Text, out idKhachHang))
                        {
                            var sanPhamHoaDon = new SanPham_HoaDonBanHang()
                            {
                                IDSanPham = idSP,
                                NgayTao = DateTime.Now
                            };

                            var hoaDonBanHang = new HoaDonBanHang()
                            {
                                SoLuong = int_soLuongMua,
                                IDKhachHang = idKhachHang,
                                Tien = gia * deci_soLuongMua
                            };

                            db.SanPham_HoaDonBanHang.Add(sanPhamHoaDon);
                            db.HoaDonBanHang.Add(hoaDonBanHang);
                            db.SaveChanges();

                            UpdateTongTien();

                            LoadDataDH();
                        }
                        else
                        {
                            MessageBox.Show("ID Khách hàng không hợp lệ.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Số lượng mua không hợp lệ.");
                    }
                }
                else
                {
                    MessageBox.Show("Dữ liệu sản phẩm không hợp lệ.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm.");
            }
        }

        void UpdateTongTien()
        {
            var tongTien = db.HoaDonBanHang.Sum(hd => hd.Tien);
            var tienNhan = decimal.Parse(txt_TienNhan.Text);
            var tienThua = tongTien - tienNhan;

            txt_TongTien.Text = tongTien.ToString();
            txt_TienThua.Text = tienThua.ToString();
        }

        void tinhTienThua()
        {
            var tongTien = db.HoaDonBanHang.Sum(hd => hd.Tien);
            var tienNhan = decimal.Parse(txt_TienNhan.Text);
            var tienThua = tienNhan - tongTien;

            txt_TienThua.Text = tienThua.ToString();
        }

        private void txt_TienNhan_TextChanged(object sender, EventArgs e)
        {
            tinhTienThua();
        }
    }
}
