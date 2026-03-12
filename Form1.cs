namespace CatchButton
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
        }
        //버튼 위에 마우스가 올라갔을 때 버튼이 랜덤한 위치로 이동하도록 하는 이벤트 핸들러
        private void button_MouseEnter(object sender, EventArgs e)
        {
            int maxX = this.ClientSize.Width - button.Width;        // 폼의 영역에서 버튼이 벗어나지 않도록 x 좌표의 최댓값
            int maxY = this.ClientSize.Height - button.Height;      // 폼의 영역에서 버튼이 벗어나지 않도록 y 좌표의 최댓값

            int x = rand.Next(0, maxX);
            int y = rand.Next(0, maxY);

            button.Location = new Point(x, y);

            this.Text = $"버튼 좌표 : X={x}, Y={y}";
        }
    }
}
