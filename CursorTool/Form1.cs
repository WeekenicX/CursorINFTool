using System.Collections;

namespace CursorTool
{
    public partial class Form1 : Form
    {
        public string[] allFile;
        public ArrayList cursorArrayList = new ArrayList();
        public ArrayList FileArrayList = new ArrayList();
        public int lackNumber;
        public bool en_language = true;
        public string folderPath;
        public string basePath = "base.txt";
        public string[] baseTxt;
        public string[] allCursor = new string[]
        {
            "alternate",
            "busy",
            "cross",
            "dgn1",
            "dgn2",
            "handwriting",
            "help",
            "horz",
            "link",
            "loc",
            "move",
            "pointer",
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
        //Find cursor you lack
        public void CheckFile(string path)
        {

            allFile = System.IO.Directory.GetFileSystemEntries(path);
            //Reset number
            if (FileArrayList != null)
            {
                FileArrayList.Clear();
            }
            listBox1.Items.Clear();
            lackNumber = 0;
            for (int i = 0; i < allFile.Length; i++)
            {
                if (allFile[i].EndsWith("ani") || allFile[i].EndsWith("cur"))
                {
                    cursorArrayList.Add(allFile[i].Substring(allFile[i].ToString().LastIndexOf("\\") + 1));
                }
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
            for (int j = 0; j < allCursor.Length; j++)
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
                    lackLabel.Text = "You Lack:" + lackNumber;
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
                folderPath = folderBrowserDialog.SelectedPath;
                CheckFile(folderPath);
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
        public void ReplaceElement()
        {
            int elementNumber = 1;
            int elementNumberTwo = 1;
            string elementStringTwo = "st";
            for (int I = 0; I < baseTxt.Length; I++)
            {
                if (baseTxt[I] == "element" + elementNumber)
                {
                    baseTxt[I] = baseTxt[I].Replace($"element{elementNumber}", cursorArrayList[elementNumber - 1].ToString());
                    elementNumber++;
                }
                switch (elementNumberTwo)
                {
                    case 1:
                        elementStringTwo = "st";
                        break;
                    case 2:
                        elementStringTwo = "nd";
                        break;
                    default:
                        elementStringTwo = "th";
                        break;
                }
                if (baseTxt[I].Contains("elementName"))
                {

                }
                if (baseTxt[I].Contains($"element{elementNumberTwo}{elementStringTwo}"))
                {
                    for (int C = 0; C < cursorArrayList.Count; C++)
                    {
                        if (cursorArrayList[C].ToString().Contains(baseTxt[I].Substring(0, baseTxt[I].IndexOf(" "))))
                        {
                            baseTxt[I] = baseTxt[I].Replace($"element{elementNumberTwo}{elementStringTwo}", cursorArrayList[C].ToString());
                            elementNumberTwo++;
                        }
                    }

                }

            }
            elementNumber = 0;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (folderPath != null)
            {
                CheckFile(folderPath);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            baseTxt = File.ReadAllLines(basePath);
            ReplaceElement();
        }
    }
}