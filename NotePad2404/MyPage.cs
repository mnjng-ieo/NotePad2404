using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePad2404
{
    // git
    public static class MyFont
    {
        // 초기값
        private static string _name = "맑은 고딕";
        private static string _size = "10";

        public static string Name
        {
            get => _name;
            set => _name = value;
        }
        public static string Size
        {
            get => _size;
            set => _size = value;
        }

        public static Font Font
        {
            get => new Font(_name, float.Parse(_name));
        }
    }

    internal class MyPage : TabPage
    {
        // 입력 상자
        public RichTextBox textBox;
        // 파일 전체 경로
        public string filePath;
        // 변경 여부
        public bool textChange;

        public MyPage() : base("새 메모")
        {
            filePath = "";
            textBox = new RichTextBox();
            setTextBox();
        }

        public MyPage(string title, string filePath) : base(title)
        {
            this.filePath = filePath;

            textBox = new RichTextBox();
            textBox.Text = new StreamReader(filePath).ReadToEnd();
            textBox.SelectionStart = textBox.Text.Length;
            setTextBox();
        }

        private void setTextBox()
        {
            textBox.Dock = DockStyle.Fill;
            textBox.Multiline = true;
            textBox.Font = MyFont.Font;
            textChange = false;
            this.Controls.Add(textBox);
            textBox.TextChanged += textBox_TextChanged;
        }

        private void textBox_TextChanged(object? sender, EventArgs? e)
        {
            if (textChange)
                return;
            // 변경된 내용이 있다면 탭에 * 표시
            this.Text += " *";
            textChange = true;
        }
    }
}
