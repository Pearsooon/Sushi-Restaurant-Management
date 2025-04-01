using System;
using System.Windows.Forms;

namespace TestWinform
{
    public partial class ChucNangKH : Form
    {
        public int MaKhachHang { get; set; }
        public ChucNangKH()
        {
            InitializeComponent();
        }

        private void thongTinCaNhan_button_Click(object sender, EventArgs e)
        {
            // Open the XemThongTinKH form
            XemThongTinKH xemThongTinKHForm = new XemThongTinKH();
            xemThongTinKHForm.Show();
            this.Hide();
        }

        private void ChucNangKH_Load(object sender, EventArgs e)
        {

        }

        private void datTrucTuyen_button_Click(object sender, EventArgs e)
        {
            DatTruoc datTruocForm = new DatTruoc(MaKhachHang);
            datTruocForm.Show();
            this.Hide();
        }

        private void datTanNoi_button_Click(object sender, EventArgs e)
        {
            DatGiaoTanNoi datGiaoTanNoiForm = new DatGiaoTanNoi(MaKhachHang);
            datGiaoTanNoiForm.Show();
            this.Hide();
        }

    }
}
