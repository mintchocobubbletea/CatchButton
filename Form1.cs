namespace CatchButton
{
    using System;
    using System.Drawing;
    using System.Media;
    using System.IO;
    using System.Windows.Forms;
    public partial class Form1 : Form
    {
        Random rand = new Random();
        int score = 1000;   // 초기 점수 1000점 설정
        int missCount = 0;   // 버튼 놓친 횟수
        // 리셋 버튼 위치 x, y: 780 550, 크기 x, y: 150 50
        // 705 ~ 855, 500~ 550 리셋 버튼 범위
        public Form1()
        {
            InitializeComponent();
        }
        //버튼 위에 마우스가 올라갔을 때 버튼이 랜덤한 위치로 이동하도록 하는 이벤트 핸들러
        private void button_MouseEnter(object sender, EventArgs e)
        {

            // 1. 난수 생성기 준비
            Random rd = new Random();
            // 2. 가용 영역 계산 (버튼이 폼 테두리에 걸리지 않게 보호)
            // ClientSize는 타이틀 바와 테두리를 제외한 실제 흰 도화지 영역임
            int maxX = this.ClientSize.Width - button.Width;        // 폼의 영역에서 버튼이 벗어나지 않도록 x 좌표의 최댓값
            int maxY = this.ClientSize.Height - button.Height;      // 폼의 영역에서 버튼이 벗어나지 않도록 y 좌표의 최댓값
            // 3. 랜덤 좌표 추출 (0 ~ 최대 가용치 사이)
            int nextX = rd.Next(0, maxX);
            int nextY = rd.Next(0, maxY);
            // 4. 위치 할당 (새로운 Point 객체 생성)
            if (nextX >= 705 && nextX <= 855 && nextY >= 500 && nextY <= 550)
            {
                // 리셋 버튼 범위에 들어가는 경우, 다시 랜덤 좌표 생성
                while (nextX >= 705 && nextX <= 855 && nextY >= 500 && nextY <= 550)
                {
                    nextX = rd.Next(0, maxX);
                    nextY = rd.Next(0, maxY);
                }
            }
            button.Location = new Point(nextX, nextY);
            // 5. 시각적 피드백 (폼 제목 표시줄에 좌표 출력)
            this.Text = $"버튼 위치: ({nextX}, {nextY})";

            SystemSounds.Beep.Play();   // 도망 소리


            missCount++;   // 놓친 횟수 증가
            if (missCount >= 20)
            {
                score = 0;  // 게임 오버 시 점수 0점으로 설정
                GameOver();
                return;
            }
            score -= 10; // 못 잡을 때마다 10점씩 감소
            this.Text = $"점수 : {score} | 버튼 위치: ({nextX}, {nextY})"; // 폼의 제목에 점수와 버튼의 현재 좌표를 표시
        }

        private void button_MouseClick(object sender, MouseEventArgs e)     //마우스 잡았을 때 이벤트 핸들러
        {
            SystemSounds.Exclamation.Play();   // 잡기 성공 소리

            score += 100;   // 잡기 성공시 점수 100점 추가

            button.Width = (int)(button.Width * 0.9);        // 버튼 크기 10% 감소
            button.Height = (int)(button.Height * 0.9);

            float newFontSize = button.Font.Size * 0.9f;                       //버튼 크기에 맞춰 글씨 크기 감소
            button.Font = new Font(button.Font.FontFamily, newFontSize);

            missCount = 0; //버튼 클릭 성공시 놏친 횟수 초기화

            MessageBox.Show("축하합니다~!");

            this.Text = $"점수 : {score}"; //점수 표시
        }
        private void GameOver()             //게임 오버 함수
        {
            MessageBox.Show("Game Over"); //게임 오버 알림창

            button.Enabled = false;   // 게임 버튼 비활성화
        }

        private void RestartButton_MouseClick(object sender, MouseEventArgs e)  //다시 시작 버튼 클릭 시 이벤트 핸들러
        {
            score = 1000;
            missCount = 0;

            button.Enabled = true;

            button.Width = 300;  // 버튼 원래 크기 돌아가기
            button.Height = 200;

            // 버튼 초기화시 글씨 원래 크기로 돌아가기
            button.Font = new Font(button.Font.FontFamily, 30);

            // 버튼 위치 초기화
            button.Location = new Point(100, 150);

            this.Text = "숨바꼭질 버튼 게임";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "종료하시겠습니까?",
            "게임 종료",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;   // 창 닫기 취소
            }
        }
    }
}
