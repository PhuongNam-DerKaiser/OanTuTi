using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OanTuTi
{
    public partial class OanTuTi : Form
    {
        // Một enum định nghĩa các lựa chọn trong trò chơi
        enum LuaChon { Keo, Bua, Bao };

        // Một mảng chứa các button của đối thủ
        Button[] opponentButtons;

        // Một biến để lưu lựa chọn của người chơi
        LuaChon NguoiChoi;
        public OanTuTi()
        {
            InitializeComponent();
            opponentButtons = new Button[] { btnMayKeo, btnMayBua, btnMayBao };
        }

        private void btnBanKeo_Click(object sender, EventArgs e)
        {
            NguoiChoi = LuaChon.Keo;
            ChoiGame();
        }

        private void btnBanBua_Click(object sender, EventArgs e)
        {
            NguoiChoi = LuaChon.Bua;
            ChoiGame();
        }

        private void btnBanBao_Click(object sender, EventArgs e)
        {
            NguoiChoi = LuaChon.Bao;
            ChoiGame();

        }
        private void ChoiGame()
        {
            // Tạo một lựa chọn ngẫu nhiên cho máy tính
            Random random = new Random();
            LuaChon MayTinh = (LuaChon)random.Next(0, 3);

            // Ẩn tất cả các button của đối thủ trước khi hiển thị lựa chọn của máy tính
            foreach (Button button in opponentButtons)
            {
                button.Visible = false;
            }

            // Hiển thị hình ảnh tương ứng với lựa chọn của máy tính
            opponentButtons[(int)MayTinh].Visible = true;

            // So sánh lựa chọn của cả hai và hiển thị kết quả
            if (NguoiChoi == MayTinh)
            {
                lbResult.Text = "Hòa nhau!";
            }
            else if ((NguoiChoi == LuaChon.Bua && MayTinh == LuaChon.Keo) ||
                     (NguoiChoi == LuaChon.Bao && MayTinh == LuaChon.Bua) ||
                     (NguoiChoi == LuaChon.Keo && MayTinh == LuaChon.Bao))
            {
                lbResult.Text = "Bạn thắng!";
            }
            else
            {
                lbResult.Text = "Bạn thua!";
            }
        }
    }

}
