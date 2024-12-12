using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kiosk_movie
{
    public partial class SeatPay : Form
    {
        private int seatnum;
        private NumericUpDown[] numericUpDowns;
        private int[] ticketPrices;

        public SeatPay(int seatnum)
        {
            InitializeComponent();
            this.seatnum = seatnum;
            label1.Text = $"인원 선택 (최대 {seatnum}명까지 선택가능)";

            // NumericUpDown 배열 및 가격 설정
            numericUpDowns = new NumericUpDown[] { numericUpDown1, numericUpDown2, numericUpDown3, numericUpDown4, numericUpDown5 };
            ticketPrices = new int[] { 12000, 9000, 7000, 8000, 7000 };

            // 모든 NumericUpDown에 ValueChanged 이벤트 핸들러 추가
            foreach (var numericUpDown in numericUpDowns)
            {
                numericUpDown.ValueChanged += UpdateTicketPrices;
            }
        }

        public SeatPay()
        {
            InitializeComponent();

            // NumericUpDown 배열 및 가격 설정
            numericUpDowns = new NumericUpDown[] { numericUpDown1, numericUpDown2, numericUpDown3, numericUpDown4, numericUpDown5 };
            ticketPrices = new int[] { 12000, 9000, 7000, 8000, 7000 };

            // 모든 NumericUpDown에 ValueChanged 이벤트 핸들러 추가
            foreach (var numericUpDown in numericUpDowns)
            {
                numericUpDown.ValueChanged += UpdateTicketPrices;
            }
        }

        private void UpdateTicketPrices(object sender, EventArgs e)
        {
            // 총 티켓 가격 계산
            int totalPrice = 0;
            for (int i = 0; i < numericUpDowns.Length; i++)
            {
                totalPrice += (int)numericUpDowns[i].Value * ticketPrices[i];
            }

            // lbTicketPrices에 총 가격 표시
            lbTicketPrices.Text = $"{totalPrice} 원";
        }
        
        private void btnMpay_Click(object sender, EventArgs e)
        {
            int totalPeople = 0;
            StringBuilder messageBuilder = new StringBuilder();
            

            if (numericUpDown1.Value > 0)
            {
                messageBuilder.AppendLine($"성인 {numericUpDown1.Value}\n");
                totalPeople += (int)numericUpDown1.Value;
            }

            if (numericUpDown2.Value > 0)
            {
                messageBuilder.AppendLine($"청소년 {numericUpDown2.Value}\n");
                totalPeople += (int)numericUpDown2.Value;
            }

            if (numericUpDown3.Value > 0)
            {
                messageBuilder.AppendLine($"아동 {numericUpDown3.Value}\n");
                totalPeople += (int)numericUpDown3.Value;
            }

            if (numericUpDown4.Value > 0)
            {
                messageBuilder.AppendLine($"노약자 {numericUpDown4.Value}\n");
                totalPeople += (int)numericUpDown4.Value;
            }

            if (numericUpDown5.Value > 0)
            {
                messageBuilder.AppendLine($"장애인 {numericUpDown5.Value}\n");
                totalPeople += (int)numericUpDown5.Value;
            }

            if (seatnum > totalPeople)
            {
                MessageBox.Show("인원수가 부족합니다.");
            }
            else if (seatnum < totalPeople)
            {
                MessageBox.Show("좌석수가 부족합니다.");
            }
            else
            {
                MessageBox.Show($"{messageBuilder}\n결제하실 금액은 {lbTicketPrices.Text}입니다.");
                // 팝업 메시지로 예/아니오 선택을 받음
                DialogResult result = MessageBox.Show("팝콘을 구매하시겠습니까?", "팝콘 구매", MessageBoxButtons.YesNo);

                if(DialogResult.Yes == result)
                {
                    Combo combo = new Combo(lbTicketPrices.Text);
                    combo.Show();
                    Close();
                }
                else
                    Close();
            }
        }
    }
}
