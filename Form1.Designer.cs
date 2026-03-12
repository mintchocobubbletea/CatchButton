namespace CatchButton
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button = new Button();
            RestartButton = new Button();
            SuspendLayout();
            // 
            // button
            // 
            button.BackColor = SystemColors.GradientActiveCaption;
            button.Font = new Font("맑은 고딕", 30F);
            button.Location = new Point(100, 150);
            button.Name = "button";
            button.Size = new Size(300, 200);
            button.TabIndex = 0;
            button.Text = "나를 잡아봐";
            button.UseVisualStyleBackColor = false;
            button.MouseClick += button_MouseClick;
            button.MouseEnter += button_MouseEnter;
            // 
            // RestartButton
            // 
            RestartButton.BackColor = SystemColors.ActiveBorder;
            RestartButton.Font = new Font("맑은 고딕", 15F);
            RestartButton.Location = new Point(757, 552);
            RestartButton.Name = "RestartButton";
            RestartButton.Size = new Size(177, 53);
            RestartButton.TabIndex = 1;
            RestartButton.Text = "다시 시작";
            RestartButton.UseVisualStyleBackColor = false;
            RestartButton.MouseClick += RestartButton_MouseClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(946, 617);
            Controls.Add(RestartButton);
            Controls.Add(button);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private Button button;
        private Button RestartButton;
    }
}
