using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace kiosk_movie
{
    public partial class Combo : Form
    {
        // 음식과 수량을 저장할 Dictionary
        private Dictionary<string, NumericUpDown> foodControls = new Dictionary<string, NumericUpDown>();

        // 패널에 동적으로 추가할 위치
        private int yOffset = 10; // Y축 오프셋 (새로운 음식 항목을 추가할 때마다 아래로 배치)

        private int totalPrice;



        public Combo()
        {
            InitializeComponent();
        }
        public Combo(string totalPriceText)
        {
            InitializeComponent();
            this.totalPrice = totalPrice;
            int.TryParse(totalPriceText.Replace(" 원", ""), out totalPrice);
        }


        // 공통 로직을 함수로 분리
        private void AddFoodItem(string foodName, string foodPriceText)
        {
            // 가격을 정수로 변환
            if (!int.TryParse(foodPriceText, out int foodPrice))
            {
                MessageBox.Show("Invalid price format");
                return;
            }

            if (foodControls.ContainsKey(foodName))
            {
                // 이미 선택된 음식이 있으면, 해당 NumericUpDown의 값만 업데이트
                foodControls[foodName].Value++;
            }
            else
            {
                // 음식 이름을 표시할 Label 추가
                Label foodLabel = new Label();
                foodLabel.Text = foodName;
                foodLabel.Location = new System.Drawing.Point(10, yOffset);
                foodLabel.AutoSize = true;

                // 수량을 조절할 NumericUpDown 추가
                NumericUpDown numericUpDown = new NumericUpDown();
                numericUpDown.Location = new System.Drawing.Point(150, yOffset);
                numericUpDown.Size = new System.Drawing.Size(70, 25);
                numericUpDown.Minimum = 1;
                numericUpDown.Maximum = 100;
                numericUpDown.Value = 1;


                // 패널에 Label과 NumericUpDown 추가
                splitContainer1.Panel2.Controls.Add(foodLabel);
                splitContainer1.Panel2.Controls.Add(numericUpDown);

                // Dictionary에 음식 이름과 NumericUpDown을 추가
                foodControls.Add(foodName, numericUpDown);

                // 다음 항목을 위한 Y축 위치 조정
                yOffset += 30;
            }
        }

        // 각 버튼에서 공통 함수 호출
        private void btnLCombo_Click(object sender, EventArgs e)
        {
            AddFoodItem(lbLCombo.Text, lbpLCombo.Text);  // Large Combo 예시
        }

        private void btnDCombo_Click(object sender, EventArgs e)
        {
            AddFoodItem(lbDCombo.Text, lbpDCombo.Text);  // 다른 Combo 예시
        }

        private void btnMCombo_Click(object sender, EventArgs e)
        {
            AddFoodItem(lbMCombo.Text, lbpMCombo.Text);  // 또 다른 Combo 예시
        }

        private void btnSCombo_Click(object sender, EventArgs e)
        {
            AddFoodItem(lbSCombo.Text, lbpSCombo.Text);  // Small Combo 예시
        }

        private void btnOil_Click(object sender, EventArgs e)
        {
            AddFoodItem(lbOil.Text, lbpOil.Text);  // Oil 예시
        }

        private void btnSweet_Click(object sender, EventArgs e)
        {
            AddFoodItem(lbSweet.Text, lbpSweet.Text);  // Sweet 예시
        }

        private void btnCheese_Click(object sender, EventArgs e)
        {
            AddFoodItem(lbCheese.Text, lbpCheese.Text);  // Cheese 예시
        }

        private void btnOnion_Click(object sender, EventArgs e)
        {
            AddFoodItem(lbOnion.Text, lbpOnion.Text);  // Onion 예시
        }

        private void btnNacho_Click(object sender, EventArgs e)
        {
            AddFoodItem(lbNacho.Text, lbpNacho.Text);  // Nacho 예시
        }

        private void btnHotdog_Click(object sender, EventArgs e)
        {
            AddFoodItem(lbHotdog.Text, lbpHotdog.Text);  // Hotdog 예시
        }

        private void btnCola_Click(object sender, EventArgs e)
        {
            AddFoodItem(lbCola.Text, lbpCola.Text);  // Cola 예시
        }

        private void btnAmeice_Click(object sender, EventArgs e)
        {
            AddFoodItem(lbAmeice.Text, lbpAmeice.Text);  // Iced Americano 예시
        }

        private void btnAmehot_Click(object sender, EventArgs e)
        {
            AddFoodItem(lbAmehot.Text, lbpAmehot.Text);  // Hot Americano 예시
        }

        private void btnAde_Click(object sender, EventArgs e)
        {
            AddFoodItem(lbAde.Text, lbpAde.Text);  // Ade 예시
        }

        int totalAmount = 0;
        private void btnOrder_Click(object sender, EventArgs e)
        {
            totalAmount = 0;

            // 각 음식 항목의 수량과 가격을 계산
            foreach (var item in foodControls)
            {
                string foodName = item.Key;  // 음식 이름
                NumericUpDown numericUpDown = item.Value;  // 수량

                // 해당 음식의 가격 Label 가져오기
                Label priceLabel = null;
                switch (foodName)
                {
                    case "라지콤보":
                        priceLabel = lbpLCombo;
                        break;
                    case "더블콤보":
                        priceLabel = lbpDCombo;
                        break;
                    case "MOBLE콤보":
                        priceLabel = lbpMCombo;
                        break;
                    case "스몰콤보":
                        priceLabel = lbpSCombo;
                        break;
                    case "고소팝콘":
                        priceLabel = lbpOil;
                        break;
                    case "달콤팝콘":
                        priceLabel = lbpSweet;
                        break;
                    case "더블치즈팝콘":
                        priceLabel = lbpCheese;
                        break;
                    case "바질어니언팝콘":
                        priceLabel = lbpOnion;
                        break;
                    case "칠리치즈나쵸":
                        priceLabel = lbpNacho;
                        break;
                    case "플레인핫도그":
                        priceLabel = lbpHotdog;
                        break;
                    case "탄산음료":
                        priceLabel = lbpCola;
                        break;
                    case "아메리카노(ICE)":
                        priceLabel = lbpAmeice;
                        break;
                    case "아메리카노(HOT)":
                        priceLabel = lbpAmehot;
                        break;
                    case "에이드":
                        priceLabel = lbpAde;
                        break;
                }

                // 가격이 유효한 경우에만 계산
                if (priceLabel != null && int.TryParse(priceLabel.Text, out int price))
                {
                    totalAmount += price * (int)numericUpDown.Value;
                }
            }

            // 총 주문 금액을 표시할 Label에 금액 업데이트
            lblTotalAmount.Text = "Total: " + totalAmount.ToString("C0"); // C0 포맷은 통화 형식으로 표시
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int finalAmount = totalAmount + totalPrice;
            string totalString = "";
            if(totalPrice > 0)
            {
                totalString += $"티켓값 : {totalPrice}원을 포함하여\n";
            }
            MessageBox.Show($"{totalString}총 금액 : {finalAmount}원을 결제합니다.");
            Close();
        }
    }
}
