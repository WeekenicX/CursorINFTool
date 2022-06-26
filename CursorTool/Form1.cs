using System.Collections;

namespace CursorTool
{
    public partial class Form1 : Form
    {
        public string[] allFile;
        public  ArrayList FileArrayList = new ArrayList();
        public int lackNumber;
        public bool en_language = true;
        public string[] allCursor = new string[]
        {
            "alt",
            "busy",
            "cross",
            "diag1",
            "diag2",
            "handwriting",
            "help",
            "horiz",
            "link",
            "loc",
            "move",
            "normal",
            "person",
            "text",
            "unavailable",
            "vert",
            "working"
        };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void CheckFile(string path)
        {

            allFile = System.IO.Directory.GetFileSystemEntries(path);
            if (FileArrayList != null)
            {
                FileArrayList.Clear();
            }
            for (int i = 0; i < allFile.Length; i++)
            {
                if (allFile[i].EndsWith("ani") || allFile[i].EndsWith("cur"))
                {
                    if (allFile[i].EndsWith("ani"))
                    {
                        allFile[i] = allFile[i].Replace(".ani", " ");
                    }
                    else
                    {
                        allFile[i] = allFile[i].Replace(".cur", " ");
                    }
                    allFile[i] = allFile[i].Trim();
                    FileArrayList.Add(allFile[i].Substring(allFile[i].ToString().LastIndexOf("\\") + 1));        
                }
            }
            for ( int j = 0; j < allCursor.Length; j++)
            {
                for (int i = 0; i < FileArrayList.Count; i++)
                {
                    if (allCursor[j].Contains(FileArrayList[i].ToString()))
                    {
                        break;
                    }
                    else
                    {
                        if (i == FileArrayList.Count - 1)
                        {
                            lackNumber++;
                            listBox1.Items.Add(allCursor[j]);
                        }
                    }
                }
            }
            if (lackNumber == 0)
            {
                if (en_language)
                {
                    lackLabel.Text = "Congratulations, you can generate inf now!";
                }
                else
                {
                    lackLabel.Text = "恭喜你，现在可以进行生成inf";
                }
            }
            else
            {
                if (en_language)
                {
                    lackLabel.Text = "You Lack:"+lackNumber;
                }
                else
                {
                    lackLabel.Text = "您缺少:" + lackNumber;
                }
            }

        }

        private void selectFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            if (folderBrowserDialog.SelectedPath != null)
            {
                CheckFile(folderBrowserDialog.SelectedPath);
            }
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            en_language = true;
            englishToolStripMenuItem.Text = "English  √";
            中文ToolStripMenuItem.Text = "中文";
            SwitchLanguage();
        }

        private void 中文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            en_language = false;
            englishToolStripMenuItem.Text = "English";
            中文ToolStripMenuItem.Text = "中文   √";
            SwitchLanguage();
        }
        public void SwitchLanguage()
        {
            if (en_language)
            {
                startToolStripMenuItem.Text = "Start";
                selectFolderToolStripMenuItem.Text = "Select Folder";
                languageToolStripMenuItem.Text = "Language";
                if (!lackLabel.Text.StartsWith('C') || !lackLabel.Text.StartsWith('Y'))
                {
                    if (lackLabel.Text.StartsWith('恭'))
                    {
                        lackLabel.Text = "Congratulations, you can generate inf now!";
                    }
                    else
                    {
                        lackLabel.Text = "You Lack:" + lackNumber;
                    }

                }
                

            }
            else
            {
                startToolStripMenuItem.Text = "开始";
                selectFolderToolStripMenuItem.Text = "选择文件夹";
                languageToolStripMenuItem.Text = "语言";
                if (lackLabel.Text.StartsWith('C') || lackLabel.Text.StartsWith('Y'))
                {
                    if (lackLabel.Text.StartsWith('C'))
                    {
                        lackLabel.Text = "恭喜你，现在可以进行生成inf";
                    }
                    else
                    {
                        lackLabel.Text = "您缺少:" + lackNumber;
                    }

                }
            }
        }
    }
}