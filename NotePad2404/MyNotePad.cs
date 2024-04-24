using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NotePad2404
{
    public partial class MyNotePad : Form
    {
        //-----------------------------------
        //              전역 변수
        //-----------------------------------

        // close/add 아이콘
        private Point tabBtnSize;
        private int tabBtnMargin;



        //-----------------------------------
        //              기본 메서드
        //-----------------------------------
        public MyNotePad()
        {
            InitializeComponent();

            setInitTabCtrl();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            setInitFontCombo();
            fontComboBox.SelectedItem = MyFont.Name;
            sizeComboBox.SelectedItem = MyFont.Size;
            fontComboBox.SelectedIndexChanged += fontComboBox_SelectedIndexChanged;
            sizeComboBox.SelectedIndexChanged += sizeComboBox_SelectedIndexChanged;
            sizeComboBox.KeyDown += sizeComboBox_KeyDown;
        }

        // 폰트, 글자크기 리스트 생성
        private void setInitFontCombo()
        {
            // 폰트 리스트
            foreach (FontFamily fontfamily in FontFamily.Families)
            {
                fontComboBox.Items.Add(fontfamily.Name);
            }

            // toolStripComboBox를 ComboBox로 다룸
            ComboBox box = (ComboBox)fontComboBox.Control;
            box.DrawMode = DrawMode.OwnerDrawVariable;
            box.DrawItem += new DrawItemEventHandler(box_DrawItem);

            // 글자크기 리스트
            for (int i = 8; i <= 72; i++)
            {
                if (i > 12)
                    i++;
                if (i > 30)
                    i += 4;
                sizeComboBox.Items.Add(i.ToString());
            }
        }

        // 탭컨트롤 초기 설정
        private void setInitTabCtrl()
        {
            this.tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.DrawItem += tabControl_DrawItem;
        }



        //-----------------------------------
        //              폰트 서식
        //-----------------------------------

        // # Method

        private void changeFont(MyPage page)
        {
            bool before = page.textChange;
            page.textChange = true;
            page.textBox.Font = MyFont.Font;
            page.textChange = before;
        }

        //-----------------------------------

        // # Event Handler

        // 글꼴 목록에 폰트 적용
        private void box_DrawItem(object sender, DrawItemEventArgs e)
        { 
            ComboBox comboBox = (ComboBox)sender;
            string fontFamily = comboBox.Items[e.Index].ToString();
            Font font = new Font(fontFamily, comboBox.Font.SizeInPoints);

            e.DrawBackground();
            e.Graphics.DrawString(font.Name, font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
        }

        //  폰트 변경
        private void fontComboBox_SelectedIndexChanged(object? sender, EventArgs? e)
        {
            MyFont.Name = fontComboBox.SelectedItem.ToString();
            changeFont((MyPage)tabControl.SelectedTab);
        }

        // 글자 크기 변경
        private void sizeComboBox_SelectedIndexChanged(object? sender, EventArgs? e)
        {
            MyFont.Size = sizeComboBox.SelectedItem.ToString();
            changeFont((MyPage)tabControl.SelectedTab);
        }

        // 글자 크기 키보드로 입력했을때
        private void sizeComboBox_KeyDown(object? sender, KeyEventArgs e)
        {
            // 엔터를 치면 동작
            if (e.KeyCode != Keys.Enter)
                return;
            
            // 엔터 칠 때 소리 안나게 하는 구문
            e.SuppressKeyPress = true; 

            // 숫자인지 확인
            if (sizeComboBox.Text != null && float.TryParse(this.sizeComboBox.Text, out _))
            {
                MyFont.Size = sizeComboBox.SelectedItem.ToString();
                changeFont((MyPage)tabControl.SelectedTab);
            }
            
        }


        //  -----------------------------------
        //              탭 컨트롤
        //  -----------------------------------

        // # Event Handler

        // 탭 제목, 닫기 버튼 추가
        private void tabControl_DrawItem(object? sender, DrawItemEventArgs e)
        {
            Rectangle r = e.Bounds;
            r = this.tabControl.GetTabRect(e.Index);

            Image img = Properties.Resources.Close_Black; // 닫기버튼

            Brush TitleBrush = new SolidBrush(Color.Black);
            Font f = this.Font;

            string title = this.tabControl.TabPages[e.Index].Text;

            tabBtnMargin = (this.tabControl.GetTabRect(e.Index).Height - this.tabControl.TabPages[e.Index].Font.Height) / 2;
            tabBtnSize = new Point(
                this.tabControl.GetTabRect(e.Index).Width - this.tabControl.TabPages[e.Index].Font.Height,
                this.tabControl.TabPages[e.Index].Font.Height / 2);

            r.Offset(tabBtnMargin, tabBtnMargin);

            e.Graphics.DrawString(title, f, TitleBrush, new PointF(r.X, r.Y)); // 탭 제목
            e.Graphics.DrawImage( // 닫기버튼
                img,
                r.X + tabBtnSize.X,
                r.Y + (tabBtnSize.Y / 2),
                tabBtnSize.Y,
                tabBtnSize.Y);

            img.Dispose();

        }

        // 닫기 버튼 실행
        private void tabControl_MouseClick(object sender, MouseEventArgs e)
        {
            MyPage focusPage = (MyPage)tabControl.SelectedTab;
            if (focusPage == null) return;
            // 닫기 버튼 위치
            Rectangle r = this.tabControl.GetTabRect(tabControl.SelectedIndex);
            r.Offset(tabBtnMargin + tabBtnSize.X, tabBtnMargin + (tabBtnSize.Y / 2));
            r.Width = tabBtnSize.Y;
            r.Height = tabBtnSize.Y;

            if (r.Contains(e.Location))
            {
                if (focusPage.textChange)
                {// 수정된 내용이 있다면 저장 여부 물어봄
                    DialogResult doSave = MessageBox.Show(
                        "변경된 내용이 저장되지 않았습니다.\n현재 페이지를 저장하시겠습니까?"
                        , "저장하기"
                        , MessageBoxButtons.YesNoCancel
                        , MessageBoxIcon.Warning);
                    if (doSave == DialogResult.Cancel)
                    { // 취소 -> 닫기 취소
                        return;
                    }
                    else if (doSave == DialogResult.Yes)
                    { // 네 -> 저장 후 닫음
                        저장SToolStripMenuItem_Click(sender, e);
                    } 
                    // 아니요 -> 저장하지 않고 닫음
                }
                tabControl.TabPages.Remove(focusPage);
            }

        }


        //  -----------------------------------
        //              파일
        //  -----------------------------------

        // # Event Handler

        private void 새로만들기NToolStripMenuItem_Click(object? sender, EventArgs? e)
        {

            MyPage newPage = new MyPage();
            tabControl.TabPages.Add(newPage);
            tabControl.SelectedTab = newPage;
        }


        private void 열기OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Text Files|*.txt";
            openFileDialog.Title = "텍스트 파일 열기";

            // Dialog에서 파일 열기 요청이 성공했을 때
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                MyPage newPage = new MyPage(openFileDialog.SafeFileName, openFileDialog.FileName);
                tabControl.TabPages.Add(newPage);
                tabControl.SelectedTab = newPage;
            }

            openFileDialog.Dispose();

        }

        private void 저장SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyPage focusPage = (MyPage)tabControl.SelectedTab;
            if (!focusPage.textChange)
            {
                MessageBox.Show("변경된 내용이 없습니다.");
                return;
            }
            if (focusPage.filePath == "")
            { // 저장될 경로가 없는 경우
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text File | *.txt";
                saveFileDialog.Title = "저장";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(saveFileDialog.OpenFile());
                    writer.Write(focusPage.textBox.Text);
                    writer.Dispose();
                    writer.Close();

                    focusPage.filePath = saveFileDialog.FileName;
                    focusPage.Text = Path.GetFileName(saveFileDialog.FileName);
                    focusPage.textChange = false;

                    MessageBox.Show($"{saveFileDialog.FileName}에 저장되었습니다.");
                }

                saveFileDialog.Dispose();

            }
            else
            { // 저장 될 파일 명이 있는 경우
                StreamWriter writer = new StreamWriter(focusPage.filePath);

                writer.Write(focusPage.textBox.Text);
                writer.Dispose();
                writer.Close();

                focusPage.textChange = false;
                focusPage.Text = Path.GetFileName(focusPage.filePath);

                MessageBox.Show("수정되었습니다");

            }

        }

        private void 다른이름으로저장AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyPage focusPage = (MyPage)tabControl.SelectedTab;
            if (!focusPage.textChange)
            {
                MessageBox.Show("변경된 내용이 없습니다.");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File | *.txt";
            saveFileDialog.Title = "다른 이름으로 저장";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveFileDialog.OpenFile());

                writer.Write(focusPage.textBox.Text);
                writer.Dispose();
                writer.Close();
                focusPage.textChange = false;
                focusPage.Text = Path.GetFileName(saveFileDialog.FileName);

                MessageBox.Show(saveFileDialog.FileName + "에 저장되었습니다.");
            }

            saveFileDialog.Dispose();

        }

        private void 끝내기XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            // 이후 FormClosing() - FormClosed() 실행
        }
        private void MyNotePad_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (MyPage page in tabControl.TabPages)
            {
                if (page.textChange)
                {
                    // 수정된 내용이 있다면 저장 여부 물어봄
                    DialogResult doSave = MessageBox.Show(
                            $"{page.Text}\n\n변경된 내용이 저장되지 않았습니다.\n저장하시겠습니까?"
                            , "저장하기"
                            , MessageBoxButtons.YesNoCancel
                            , MessageBoxIcon.Warning);
                    if (doSave == DialogResult.Cancel)
                    { // 취소
                        return;
                    }
                    else if (doSave == DialogResult.Yes)
                    { // 네
                        저장SToolStripMenuItem_Click(sender, e);
                    } // 저장하지 않고 넘어감
                }
            }
        }


        //  -----------------------------------
        //              편집
        //  -----------------------------------

        // # Event Handler

        private void 실행취소UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox textBox = ((MyPage)tabControl.SelectedTab).textBox;

            if (textBox.CanUndo)
                textBox.Undo();
        }

        private void 다시실행RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox textBox = ((MyPage)tabControl.SelectedTab).textBox;

            if (textBox.CanRedo)
                textBox.Redo();
        }

        private void 잘라내기TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox textBox = ((MyPage)tabControl.SelectedTab).textBox;
            textBox.Cut();
        }

        private void 복사CToolStripMenuItem_Click(object sender, EventArgs e)
        {

            RichTextBox textBox = ((MyPage)tabControl.SelectedTab).textBox;
            textBox.Copy();
        }

        private void 붙여넣기PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox textBox = ((MyPage)tabControl.SelectedTab).textBox;
            textBox.Paste();
        }

        private void 모두선택AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox textBox = ((MyPage)tabControl.SelectedTab).textBox;
            if (textBox.CanSelect)
                textBox.SelectAll();
        }

        //  -----------------------------------
        //              파일 목록
        //  -----------------------------------

        // # Event Handler

        // 폴더 열기
        private void forlderBtn_Click(object sender, EventArgs e)
        {
            if (!listBox1.Enabled) listBox1.Enabled = true;

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // 폴더 경로 가져오기
                string folderPath = dialog.SelectedPath;

                this.listBox1.Refresh();

                // 파일 목록 가져오기
                DirectoryInfo di = new DirectoryInfo(folderPath);

                if (di.Exists)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("FileName", typeof(string));
                    dt.Columns.Add("FilePath", typeof(string));

                    DataRow? ds = null;

                    // 텍스트 파일만 불러오기
                    foreach (FileInfo file in di.GetFiles("*.txt"))
                    {
                        ds = dt.NewRow();
                        ds["FileName"] = file.Name;
                        ds["FilePath"] = file.FullName;
                        dt.Rows.Add(ds);
                    }

                    listBox1.DataSource = dt;
                    listBox1.DisplayMember = "FileName";
                    listBox1.ValueMember = "FilePath";
                }
            }
        }

        // 파일 선택
        private void listBox1_Click(object sender, EventArgs e)
        {
            DataRowView? selected = listBox1.SelectedItem as DataRowView;

            if(selected != null)
            {

                MyPage page = new MyPage(selected[0].ToString(), selected[1].ToString());
                tabControl.TabPages.Add(page);
                tabControl.SelectedTab = page;
            }


        }
    }
}
