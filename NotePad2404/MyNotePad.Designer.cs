using System.Windows.Forms.Design;

namespace NotePad2404
{
    partial class MyNotePad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyNotePad));
            menuTop = new MenuStrip();
            파일FToolStripMenuItem = new ToolStripMenuItem();
            새로만들기NToolStripMenuItem = new ToolStripMenuItem();
            열기OToolStripMenuItem = new ToolStripMenuItem();
            separator1 = new ToolStripSeparator();
            저장SToolStripMenuItem = new ToolStripMenuItem();
            다른이름으로저장AToolStripMenuItem = new ToolStripMenuItem();
            separator2 = new ToolStripSeparator();
            끝내기XToolStripMenuItem = new ToolStripMenuItem();
            편집EToolStripMenuItem = new ToolStripMenuItem();
            실행취소UToolStripMenuItem = new ToolStripMenuItem();
            다시실행RToolStripMenuItem = new ToolStripMenuItem();
            separator4 = new ToolStripSeparator();
            잘라내기TToolStripMenuItem = new ToolStripMenuItem();
            복사CToolStripMenuItem = new ToolStripMenuItem();
            붙여넣기PToolStripMenuItem = new ToolStripMenuItem();
            separator5 = new ToolStripSeparator();
            모두선택AToolStripMenuItem = new ToolStripMenuItem();
            separator6 = new ToolStripSeparator();
            폰트ToolStripMenuItem = new ToolStripMenuItem();
            fontComboBox = new ToolStripComboBox();
            separator8 = new ToolStripSeparator();
            크기ToolStripMenuItem = new ToolStripMenuItem();
            sizeComboBox = new ToolStripComboBox();
            statusStrip1 = new StatusStrip();
            tabControl = new TabControl();
            listBox1 = new ListBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            folderBtn = new Button();
            menuTop.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuTop
            // 
            menuTop.AutoSize = false;
            menuTop.GripMargin = new Padding(2);
            menuTop.GripStyle = ToolStripGripStyle.Visible;
            menuTop.Items.AddRange(new ToolStripItem[] { 파일FToolStripMenuItem, 편집EToolStripMenuItem, separator6, 폰트ToolStripMenuItem, fontComboBox, separator8, 크기ToolStripMenuItem, sizeComboBox });
            menuTop.Location = new Point(0, 0);
            menuTop.Name = "menuTop";
            menuTop.Size = new Size(808, 32);
            menuTop.TabIndex = 1;
            menuTop.Text = "menuStrip1";
            // 
            // 파일FToolStripMenuItem
            // 
            파일FToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 새로만들기NToolStripMenuItem, 열기OToolStripMenuItem, separator1, 저장SToolStripMenuItem, 다른이름으로저장AToolStripMenuItem, separator2, 끝내기XToolStripMenuItem });
            파일FToolStripMenuItem.Name = "파일FToolStripMenuItem";
            파일FToolStripMenuItem.Size = new Size(57, 28);
            파일FToolStripMenuItem.Text = "파일(&F)";
            // 
            // 새로만들기NToolStripMenuItem
            // 
            새로만들기NToolStripMenuItem.Image = (Image)resources.GetObject("새로만들기NToolStripMenuItem.Image");
            새로만들기NToolStripMenuItem.Name = "새로만들기NToolStripMenuItem";
            새로만들기NToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            새로만들기NToolStripMenuItem.Size = new Size(268, 22);
            새로만들기NToolStripMenuItem.Text = "새로 만들기(&N)";
            새로만들기NToolStripMenuItem.Click += 새로만들기NToolStripMenuItem_Click;
            // 
            // 열기OToolStripMenuItem
            // 
            열기OToolStripMenuItem.Image = (Image)resources.GetObject("열기OToolStripMenuItem.Image");
            열기OToolStripMenuItem.Name = "열기OToolStripMenuItem";
            열기OToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            열기OToolStripMenuItem.Size = new Size(268, 22);
            열기OToolStripMenuItem.Text = "열기(&O)";
            열기OToolStripMenuItem.Click += 열기OToolStripMenuItem_Click;
            // 
            // separator1
            // 
            separator1.Name = "separator1";
            separator1.Size = new Size(265, 6);
            // 
            // 저장SToolStripMenuItem
            // 
            저장SToolStripMenuItem.Image = (Image)resources.GetObject("저장SToolStripMenuItem.Image");
            저장SToolStripMenuItem.Name = "저장SToolStripMenuItem";
            저장SToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            저장SToolStripMenuItem.Size = new Size(268, 22);
            저장SToolStripMenuItem.Text = "저장(&S)";
            저장SToolStripMenuItem.Click += 저장SToolStripMenuItem_Click;
            // 
            // 다른이름으로저장AToolStripMenuItem
            // 
            다른이름으로저장AToolStripMenuItem.Name = "다른이름으로저장AToolStripMenuItem";
            다른이름으로저장AToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            다른이름으로저장AToolStripMenuItem.Size = new Size(268, 22);
            다른이름으로저장AToolStripMenuItem.Text = "다른 이름으로 저장(&A)";
            다른이름으로저장AToolStripMenuItem.Click += 다른이름으로저장AToolStripMenuItem_Click;
            // 
            // separator2
            // 
            separator2.Name = "separator2";
            separator2.Size = new Size(265, 6);
            // 
            // 끝내기XToolStripMenuItem
            // 
            끝내기XToolStripMenuItem.Name = "끝내기XToolStripMenuItem";
            끝내기XToolStripMenuItem.Size = new Size(268, 22);
            끝내기XToolStripMenuItem.Text = "끝내기(&X)";
            끝내기XToolStripMenuItem.Click += 끝내기XToolStripMenuItem_Click;
            // 
            // 편집EToolStripMenuItem
            // 
            편집EToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 실행취소UToolStripMenuItem, 다시실행RToolStripMenuItem, separator4, 잘라내기TToolStripMenuItem, 복사CToolStripMenuItem, 붙여넣기PToolStripMenuItem, separator5, 모두선택AToolStripMenuItem });
            편집EToolStripMenuItem.Name = "편집EToolStripMenuItem";
            편집EToolStripMenuItem.Size = new Size(57, 28);
            편집EToolStripMenuItem.Text = "편집(&E)";
            // 
            // 실행취소UToolStripMenuItem
            // 
            실행취소UToolStripMenuItem.Name = "실행취소UToolStripMenuItem";
            실행취소UToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            실행취소UToolStripMenuItem.Size = new Size(184, 22);
            실행취소UToolStripMenuItem.Text = "실행 취소(&U)";
            실행취소UToolStripMenuItem.Click += 실행취소UToolStripMenuItem_Click;
            // 
            // 다시실행RToolStripMenuItem
            // 
            다시실행RToolStripMenuItem.Name = "다시실행RToolStripMenuItem";
            다시실행RToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
            다시실행RToolStripMenuItem.Size = new Size(184, 22);
            다시실행RToolStripMenuItem.Text = "다시 실행(&R)";
            다시실행RToolStripMenuItem.Click += 다시실행RToolStripMenuItem_Click;
            // 
            // separator4
            // 
            separator4.Name = "separator4";
            separator4.Size = new Size(181, 6);
            // 
            // 잘라내기TToolStripMenuItem
            // 
            잘라내기TToolStripMenuItem.Image = (Image)resources.GetObject("잘라내기TToolStripMenuItem.Image");
            잘라내기TToolStripMenuItem.Name = "잘라내기TToolStripMenuItem";
            잘라내기TToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            잘라내기TToolStripMenuItem.Size = new Size(184, 22);
            잘라내기TToolStripMenuItem.Text = "잘라내기(&T)";
            잘라내기TToolStripMenuItem.Click += 잘라내기TToolStripMenuItem_Click;
            // 
            // 복사CToolStripMenuItem
            // 
            복사CToolStripMenuItem.Image = (Image)resources.GetObject("복사CToolStripMenuItem.Image");
            복사CToolStripMenuItem.Name = "복사CToolStripMenuItem";
            복사CToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            복사CToolStripMenuItem.Size = new Size(184, 22);
            복사CToolStripMenuItem.Text = "복사(&C)";
            복사CToolStripMenuItem.Click += 복사CToolStripMenuItem_Click;
            // 
            // 붙여넣기PToolStripMenuItem
            // 
            붙여넣기PToolStripMenuItem.Image = (Image)resources.GetObject("붙여넣기PToolStripMenuItem.Image");
            붙여넣기PToolStripMenuItem.Name = "붙여넣기PToolStripMenuItem";
            붙여넣기PToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            붙여넣기PToolStripMenuItem.Size = new Size(184, 22);
            붙여넣기PToolStripMenuItem.Text = "붙여넣기(&P)";
            붙여넣기PToolStripMenuItem.Click += 붙여넣기PToolStripMenuItem_Click;
            // 
            // separator5
            // 
            separator5.Name = "separator5";
            separator5.Size = new Size(181, 6);
            // 
            // 모두선택AToolStripMenuItem
            // 
            모두선택AToolStripMenuItem.Name = "모두선택AToolStripMenuItem";
            모두선택AToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            모두선택AToolStripMenuItem.Size = new Size(184, 22);
            모두선택AToolStripMenuItem.Text = "모두 선택(&A)";
            모두선택AToolStripMenuItem.Click += 모두선택AToolStripMenuItem_Click;
            // 
            // separator6
            // 
            separator6.Name = "separator6";
            separator6.Size = new Size(6, 28);
            // 
            // 폰트ToolStripMenuItem
            // 
            폰트ToolStripMenuItem.Name = "폰트ToolStripMenuItem";
            폰트ToolStripMenuItem.Size = new Size(54, 28);
            폰트ToolStripMenuItem.Text = "폰트 : ";
            // 
            // fontComboBox
            // 
            fontComboBox.Name = "fontComboBox";
            fontComboBox.Size = new Size(200, 28);
            // 
            // separator8
            // 
            separator8.Name = "separator8";
            separator8.Size = new Size(6, 28);
            // 
            // 크기ToolStripMenuItem
            // 
            크기ToolStripMenuItem.Name = "크기ToolStripMenuItem";
            크기ToolStripMenuItem.Size = new Size(54, 28);
            크기ToolStripMenuItem.Text = "크기 : ";
            // 
            // sizeComboBox
            // 
            sizeComboBox.Name = "sizeComboBox";
            sizeComboBox.Size = new Size(121, 28);
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 464);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(808, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // tabControl
            // 
            tabControl.AllowDrop = true;
            tabControl.Cursor = Cursors.Hand;
            tabControl.Dock = DockStyle.Fill;
            tabControl.HotTrack = true;
            tabControl.ItemSize = new Size(120, 24);
            tabControl.Location = new Point(253, 3);
            tabControl.Name = "tabControl";
            tabControl.Padding = new Point(16, 4);
            tableLayoutPanel1.SetRowSpan(tabControl, 2);
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(552, 426);
            tabControl.TabIndex = 5;
            tabControl.DrawItem += tabControl_DrawItem;
            tabControl.MouseClick += tabControl_MouseClick;
            // 
            // listBox1
            // 
            listBox1.Cursor = Cursors.Hand;
            listBox1.Dock = DockStyle.Fill;
            listBox1.Enabled = false;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(3, 35);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(244, 394);
            listBox1.TabIndex = 0;
            listBox1.Click += listBox1_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(folderBtn, 0, 0);
            tableLayoutPanel1.Controls.Add(listBox1, 0, 1);
            tableLayoutPanel1.Controls.Add(tabControl, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 32);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(808, 432);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // folderBtn
            // 
            folderBtn.Dock = DockStyle.Fill;
            folderBtn.Location = new Point(3, 3);
            folderBtn.Name = "folderBtn";
            folderBtn.Size = new Size(244, 26);
            folderBtn.TabIndex = 0;
            folderBtn.Text = "폴더 열기";
            folderBtn.Click += forlderBtn_Click;
            // 
            // MyNotePad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(808, 486);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(menuTop);
            Controls.Add(statusStrip1);
            MainMenuStrip = menuTop;
            Name = "MyNotePad";
            Text = "MyNotePad";
            FormClosing += MyNotePad_FormClosing;
            Load += Form1_Load;
            menuTop.ResumeLayout(false);
            menuTop.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuTop;
        private StatusStrip statusStrip1;
        private ToolStripMenuItem 폰트ToolStripMenuItem;
        private ToolStripComboBox fontComboBox;
        private ToolStripMenuItem 크기ToolStripMenuItem;
        private ToolStripComboBox sizeComboBox;
        private ToolStripSeparator separator8;
        private ToolStripSeparator separator6;
        private ToolStripMenuItem 파일FToolStripMenuItem;
        private ToolStripMenuItem 새로만들기NToolStripMenuItem;
        private ToolStripMenuItem 열기OToolStripMenuItem;
        private ToolStripSeparator separator1;
        private ToolStripMenuItem 저장SToolStripMenuItem;
        private ToolStripMenuItem 다른이름으로저장AToolStripMenuItem;
        private ToolStripSeparator separator2;
        private ToolStripMenuItem 끝내기XToolStripMenuItem;
        private ToolStripMenuItem 편집EToolStripMenuItem;
        private ToolStripMenuItem 실행취소UToolStripMenuItem;
        private ToolStripMenuItem 다시실행RToolStripMenuItem;
        private ToolStripSeparator separator4;
        private ToolStripMenuItem 잘라내기TToolStripMenuItem;
        private ToolStripMenuItem 복사CToolStripMenuItem;
        private ToolStripMenuItem 붙여넣기PToolStripMenuItem;
        private ToolStripSeparator separator5;
        private ToolStripMenuItem 모두선택AToolStripMenuItem;
        private TabControl tabControl;
        private ListBox listBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button folderBtn;
        private MyPage defaultPage1;
    }
}
