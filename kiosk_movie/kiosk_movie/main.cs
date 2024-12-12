using kiosk_movie;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace kiosk_movie
{
    public partial class main : Form
    {
        private int imageIndex = 0; // 현재 이미지 인덱스
        private string[] imageFiles; // 이미지 경로 배열

        public main()
        {
            InitializeComponent();

            imageFiles = new string[]
                {
                    @"C:\Users\mo\Desktop\123\kiosk_movie\kiosk_movie\bin\구룡성채.jpg",
                    @"C:\Users\mo\Desktop\123\kiosk_movie\kiosk_movie\bin\너의 색.jpg",
                    @"C:\Users\mo\Desktop\123\kiosk_movie\kiosk_movie\bin\보통의 가족.jpg",
                    @"C:\Users\mo\Desktop\123\kiosk_movie\kiosk_movie\bin\스마일2.jpg",
                    @"C:\Users\mo\Desktop\123\kiosk_movie\kiosk_movie\bin\오후4시.jpg"
                };
            // 첫 번째 이미지를 수동으로 로드
            if (File.Exists(imageFiles[imageIndex]))
            {
                pictureBox1.Image = System.Drawing.Image.FromFile(imageFiles[imageIndex]);
            }
            else
            {
                MessageBox.Show($"이미지 파일을 찾을 수 없습니다: {imageFiles[imageIndex]}");
            }
            // 타이머 시작
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (imageIndex >= imageFiles.Length) // 이미지 인덱스가 배열 길이를 넘어가면 처음으로 돌아감
                imageIndex = 0;
            pictureBox1.Image = System.Drawing.Image.FromFile(imageFiles[imageIndex]);

            // 기존 이미지 해제
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            // 파일이 존재하는지 확인
            if (File.Exists(imageFiles[imageIndex]))
            {
                pictureBox1.Image = System.Drawing.Image.FromFile(imageFiles[imageIndex]);
            }
            else
            {
                MessageBox.Show($"이미지 파일을 찾을 수 없습니다: {imageFiles[imageIndex]}");
            }
            imageIndex++;
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            // 마우스가 들어오면 버튼을 보이기
            button1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Choice choice = new Choice();
            choice.Show();
        }
    }
}
