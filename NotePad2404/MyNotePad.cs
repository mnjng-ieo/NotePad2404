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
        //              ���� ����
        //-----------------------------------

        // close/add ������
        private Point tabBtnSize;
        private int tabBtnMargin;



        //-----------------------------------
        //              �⺻ �޼���
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

        // ��Ʈ, ����ũ�� ����Ʈ ����
        private void setInitFontCombo()
        {
            // ��Ʈ ����Ʈ
            foreach (FontFamily fontfamily in FontFamily.Families)
            {
                fontComboBox.Items.Add(fontfamily.Name);
            }

            // toolStripComboBox�� ComboBox�� �ٷ�
            ComboBox box = (ComboBox)fontComboBox.Control;
            box.DrawMode = DrawMode.OwnerDrawVariable;
            box.DrawItem += new DrawItemEventHandler(box_DrawItem);

            // ����ũ�� ����Ʈ
            for (int i = 8; i <= 72; i++)
            {
                if (i > 12)
                    i++;
                if (i > 30)
                    i += 4;
                sizeComboBox.Items.Add(i.ToString());
            }
        }

        // ����Ʈ�� �ʱ� ����
        private void setInitTabCtrl()
        {
            this.tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.DrawItem += tabControl_DrawItem;
        }



        //-----------------------------------
        //              ��Ʈ ����
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

        // �۲� ��Ͽ� ��Ʈ ����
        private void box_DrawItem(object sender, DrawItemEventArgs e)
        { 
            ComboBox comboBox = (ComboBox)sender;
            string fontFamily = comboBox.Items[e.Index].ToString();
            Font font = new Font(fontFamily, comboBox.Font.SizeInPoints);

            e.DrawBackground();
            e.Graphics.DrawString(font.Name, font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
        }

        //  ��Ʈ ����
        private void fontComboBox_SelectedIndexChanged(object? sender, EventArgs? e)
        {
            MyFont.Name = fontComboBox.SelectedItem.ToString();
            changeFont((MyPage)tabControl.SelectedTab);
        }

        // ���� ũ�� ����
        private void sizeComboBox_SelectedIndexChanged(object? sender, EventArgs? e)
        {
            MyFont.Size = sizeComboBox.SelectedItem.ToString();
            changeFont((MyPage)tabControl.SelectedTab);
        }

        // ���� ũ�� Ű����� �Է�������
        private void sizeComboBox_KeyDown(object? sender, KeyEventArgs e)
        {
            // ���͸� ġ�� ����
            if (e.KeyCode != Keys.Enter)
                return;
            
            // ���� ĥ �� �Ҹ� �ȳ��� �ϴ� ����
            e.SuppressKeyPress = true; 

            // �������� Ȯ��
            if (sizeComboBox.Text != null && float.TryParse(this.sizeComboBox.Text, out _))
            {
                MyFont.Size = sizeComboBox.SelectedItem.ToString();
                changeFont((MyPage)tabControl.SelectedTab);
            }
            
        }


        //  -----------------------------------
        //              �� ��Ʈ��
        //  -----------------------------------

        // # Event Handler

        // �� ����, �ݱ� ��ư �߰�
        private void tabControl_DrawItem(object? sender, DrawItemEventArgs e)
        {
            Rectangle r = e.Bounds;
            r = this.tabControl.GetTabRect(e.Index);

            Image img = Properties.Resources.Close_Black; // �ݱ��ư

            Brush TitleBrush = new SolidBrush(Color.Black);
            Font f = this.Font;

            string title = this.tabControl.TabPages[e.Index].Text;

            tabBtnMargin = (this.tabControl.GetTabRect(e.Index).Height - this.tabControl.TabPages[e.Index].Font.Height) / 2;
            tabBtnSize = new Point(
                this.tabControl.GetTabRect(e.Index).Width - this.tabControl.TabPages[e.Index].Font.Height,
                this.tabControl.TabPages[e.Index].Font.Height / 2);

            r.Offset(tabBtnMargin, tabBtnMargin);

            e.Graphics.DrawString(title, f, TitleBrush, new PointF(r.X, r.Y)); // �� ����
            e.Graphics.DrawImage( // �ݱ��ư
                img,
                r.X + tabBtnSize.X,
                r.Y + (tabBtnSize.Y / 2),
                tabBtnSize.Y,
                tabBtnSize.Y);

            img.Dispose();

        }

        // �ݱ� ��ư ����
        private void tabControl_MouseClick(object sender, MouseEventArgs e)
        {
            MyPage focusPage = (MyPage)tabControl.SelectedTab;
            if (focusPage == null) return;
            // �ݱ� ��ư ��ġ
            Rectangle r = this.tabControl.GetTabRect(tabControl.SelectedIndex);
            r.Offset(tabBtnMargin + tabBtnSize.X, tabBtnMargin + (tabBtnSize.Y / 2));
            r.Width = tabBtnSize.Y;
            r.Height = tabBtnSize.Y;

            if (r.Contains(e.Location))
            {
                if (focusPage.textChange)
                {// ������ ������ �ִٸ� ���� ���� ���
                    DialogResult doSave = MessageBox.Show(
                        "����� ������ ������� �ʾҽ��ϴ�.\n���� �������� �����Ͻðڽ��ϱ�?"
                        , "�����ϱ�"
                        , MessageBoxButtons.YesNoCancel
                        , MessageBoxIcon.Warning);
                    if (doSave == DialogResult.Cancel)
                    { // ��� -> �ݱ� ���
                        return;
                    }
                    else if (doSave == DialogResult.Yes)
                    { // �� -> ���� �� ����
                        ����SToolStripMenuItem_Click(sender, e);
                    } 
                    // �ƴϿ� -> �������� �ʰ� ����
                }
                tabControl.TabPages.Remove(focusPage);
            }

        }


        //  -----------------------------------
        //              ����
        //  -----------------------------------

        // # Event Handler

        private void ���θ����NToolStripMenuItem_Click(object? sender, EventArgs? e)
        {

            MyPage newPage = new MyPage();
            tabControl.TabPages.Add(newPage);
            tabControl.SelectedTab = newPage;
        }


        private void ����OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Text Files|*.txt";
            openFileDialog.Title = "�ؽ�Ʈ ���� ����";

            // Dialog���� ���� ���� ��û�� �������� ��
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                MyPage newPage = new MyPage(openFileDialog.SafeFileName, openFileDialog.FileName);
                tabControl.TabPages.Add(newPage);
                tabControl.SelectedTab = newPage;
            }

            openFileDialog.Dispose();

        }

        private void ����SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyPage focusPage = (MyPage)tabControl.SelectedTab;
            if (!focusPage.textChange)
            {
                MessageBox.Show("����� ������ �����ϴ�.");
                return;
            }
            if (focusPage.filePath == "")
            { // ����� ��ΰ� ���� ���
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text File | *.txt";
                saveFileDialog.Title = "����";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(saveFileDialog.OpenFile());
                    writer.Write(focusPage.textBox.Text);
                    writer.Dispose();
                    writer.Close();

                    focusPage.filePath = saveFileDialog.FileName;
                    focusPage.Text = Path.GetFileName(saveFileDialog.FileName);
                    focusPage.textChange = false;

                    MessageBox.Show($"{saveFileDialog.FileName}�� ����Ǿ����ϴ�.");
                }

                saveFileDialog.Dispose();

            }
            else
            { // ���� �� ���� ���� �ִ� ���
                StreamWriter writer = new StreamWriter(focusPage.filePath);

                writer.Write(focusPage.textBox.Text);
                writer.Dispose();
                writer.Close();

                focusPage.textChange = false;
                focusPage.Text = Path.GetFileName(focusPage.filePath);

                MessageBox.Show("�����Ǿ����ϴ�");

            }

        }

        private void �ٸ��̸���������AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyPage focusPage = (MyPage)tabControl.SelectedTab;
            if (!focusPage.textChange)
            {
                MessageBox.Show("����� ������ �����ϴ�.");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File | *.txt";
            saveFileDialog.Title = "�ٸ� �̸����� ����";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveFileDialog.OpenFile());

                writer.Write(focusPage.textBox.Text);
                writer.Dispose();
                writer.Close();
                focusPage.textChange = false;
                focusPage.Text = Path.GetFileName(saveFileDialog.FileName);

                MessageBox.Show(saveFileDialog.FileName + "�� ����Ǿ����ϴ�.");
            }

            saveFileDialog.Dispose();

        }

        private void ������XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            // ���� FormClosing() - FormClosed() ����
        }
        private void MyNotePad_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (MyPage page in tabControl.TabPages)
            {
                if (page.textChange)
                {
                    // ������ ������ �ִٸ� ���� ���� ���
                    DialogResult doSave = MessageBox.Show(
                            $"{page.Text}\n\n����� ������ ������� �ʾҽ��ϴ�.\n�����Ͻðڽ��ϱ�?"
                            , "�����ϱ�"
                            , MessageBoxButtons.YesNoCancel
                            , MessageBoxIcon.Warning);
                    if (doSave == DialogResult.Cancel)
                    { // ���
                        return;
                    }
                    else if (doSave == DialogResult.Yes)
                    { // ��
                        ����SToolStripMenuItem_Click(sender, e);
                    } // �������� �ʰ� �Ѿ
                }
            }
        }


        //  -----------------------------------
        //              ����
        //  -----------------------------------

        // # Event Handler

        private void �������UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox textBox = ((MyPage)tabControl.SelectedTab).textBox;

            if (textBox.CanUndo)
                textBox.Undo();
        }

        private void �ٽý���RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox textBox = ((MyPage)tabControl.SelectedTab).textBox;

            if (textBox.CanRedo)
                textBox.Redo();
        }

        private void �߶󳻱�TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox textBox = ((MyPage)tabControl.SelectedTab).textBox;
            textBox.Cut();
        }

        private void ����CToolStripMenuItem_Click(object sender, EventArgs e)
        {

            RichTextBox textBox = ((MyPage)tabControl.SelectedTab).textBox;
            textBox.Copy();
        }

        private void �ٿ��ֱ�PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox textBox = ((MyPage)tabControl.SelectedTab).textBox;
            textBox.Paste();
        }

        private void ��μ���AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox textBox = ((MyPage)tabControl.SelectedTab).textBox;
            if (textBox.CanSelect)
                textBox.SelectAll();
        }

        //  -----------------------------------
        //              ���� ���
        //  -----------------------------------

        // # Event Handler

        // ���� ����
        private void forlderBtn_Click(object sender, EventArgs e)
        {
            if (!listBox1.Enabled) listBox1.Enabled = true;

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // ���� ��� ��������
                string folderPath = dialog.SelectedPath;

                this.listBox1.Refresh();

                // ���� ��� ��������
                DirectoryInfo di = new DirectoryInfo(folderPath);

                if (di.Exists)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("FileName", typeof(string));
                    dt.Columns.Add("FilePath", typeof(string));

                    DataRow? ds = null;

                    // �ؽ�Ʈ ���ϸ� �ҷ�����
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

        // ���� ����
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
