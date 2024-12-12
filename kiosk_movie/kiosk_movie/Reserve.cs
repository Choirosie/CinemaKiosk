using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kiosk_movie
{
    public partial class Reserve : Form
    {
        private void MakeButtonSemiOval(Button button)
        {
            System.Drawing.Drawing2D.GraphicsPath graphicsPath = new System.Drawing.Drawing2D.GraphicsPath();

            // 반타원형 경로 정의 (반원 + 직선)
            graphicsPath.AddArc(0, 0, button.Width, button.Height, 180, 180); // 윗쪽 반원을 정의
            graphicsPath.AddLine(0, button.Height / 2, button.Width, button.Height / 2); // 아랫쪽을 직선으로 정의

            // 버튼의 Region을 반타원형으로 설정
            button.Region = new Region(graphicsPath);

            button.Click += (sender, e) =>
        {
            if (button.Enabled)
            {
                button.Enabled = false; // 버튼이 클릭되면 비활성화
                button.BackColor = Color.Gray;
                seatnum++; // 좌석 수 증가
            }
        };
        }

        int seatnum = 0;
        public Reserve()
        {
            InitializeComponent();
            foreach (Control control in this.Controls)
            {
                if (control is Button button && !button.Enabled)
                {
                    seatnum++;
                }
            }
        }

        private void Reserve_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button button && button != butSeat && button != btnSeatRe)
                {
                    MakeButtonSemiOval(button);

                }
            }
            //foreach (Control control in this.Controls)
            //{
            //    if (control is Button button && button != button2)
            //    {
            //        MakeButtonSemiOval(button); // button2를 제외한 모든 버튼을 반타원형으로 설정
            //    }
            //}
        }

        private void butSeat_Click(object sender, EventArgs e)
        {
            if (seatnum == 0)
            {
                MessageBox.Show("좌석을 선택해주세요.");
            }
            else
            {
                //    MessageBox.Show($"{seatnum}개의 좌석이 선택되었습니다.");
                //    SeatPay seatpay = new SeatPay();
                //    SeatPay sp1 = new SeatPay(seatnum);
                //    seatpay.Show();
                //    Close();
                MessageBox.Show($"{seatnum}개의 좌석이 선택되었습니다.");
                SeatPay seatpay = new SeatPay(seatnum); // 좌석 수를 매개변수로 전달하여 생성
                seatpay.Show();
                Close();
            }
        }

        private void btnSeatRe_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button button && !button.Enabled)
                {
                    button.Enabled = true; // 버튼 활성화
                    button.BackColor = SystemColors.Control; // 기본 배경색으로 변경
                    seatnum--; // 좌석 수 감소
                }
            }
        }
    }
}
