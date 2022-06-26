using System.Collections;

namespace CursorTool
{
    public partial class Form1 : Form
    {
        public string[] allFile;
        public static ArrayList FileArrayList = new ArrayList();
        public int lackNumber;
        public bool en_language;
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
                    FileArrayList.Add(allFile[i]);
                    for (int j = 0; j < allCursor.Length; j++)
                    {
                        if (allFile[i].Substring(allFile[i].LastIndexOf("\\") + 1).Contains(allCursor[j]))
                        {
                            break;
                        }
                        else
                        {
                            if (j == allCursor.Length - 1)
                            {
                                lackNumber++;
                                listBox1.Items.Add(allFile[i].Substring(allFile[i].LastIndexOf("\\") + 1));
                            }
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
        }

        private void 中文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            en_language = false;
            englishToolStripMenuItem.Text = "English";
            中文ToolStripMenuItem.Text = "中文   √";
        }
    }
}