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
        public ArrayList allCheckLanguageName = new ArrayList();
        public string[] allCursor = new string[]
        {
            "alternate/候选",
            "busy/忙",
            "cross/精准选择",
            "dgn1/沿对角线调整大小 1",
            "dgn2/沿对角线调整大小 2",
            "handwriting/手写",
            "help/帮助选择",
            "horz/水平调整大小",
            "link/链接选择",
            "loc/位置大小",
            "move/移动",
            "pointer/正常选择",
            "person/个人选择",
            "text/文本选择",
            "unavailable/不可用",
            "vert/垂直调整大小",
            "working/后台运行"
        };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Find cursor you lack
        /// </summary>
        /// <param name="path"></param>
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
                    string noNameFile = allFile[i].Substring(allFile[i].ToString().LastIndexOf("\\") + 1).Replace(".ani", " ").ToString().Trim();
                    if (allFile[i].EndsWith(".ani"))
                    {
                        for (int R = 0; R < allCursor.Length; R++)
                        {
                            if (allCursor[R].Contains(noNameFile))
                            {
                                cursorArrayList.Add(allFile[i].Substring(allFile[i].ToString().LastIndexOf("\\") + 1));
                                break;
                            }
                            else
                            {
                                if (R == allCursor.Length - 1)
                                {
                                    cursorArrayList.Add(string.Empty);
                                }
                            }
                        }
                    }
                    if (allFile[i].EndsWith(".cur"))
                    {
                        if (allFile[i].EndsWith(".cur"))
                        {
                            for (int R = 0; R < allCursor.Length; R++)
                            {
                                if (allCursor[R].Contains(noNameFile))
                                {
                                    cursorArrayList.Add(allFile[i].Substring(allFile[i].ToString().LastIndexOf("\\") + 1));
                                    break;
                                }
                                else
                                {
                                    if (R == allCursor.Length - 1)
                                    {
                                        cursorArrayList.Add(string.Empty);
                                    }
                                }
                            }
                        }
                    }

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
            if (System.IO.Directory.Exists(folderPath + "/here"))
            {
                System.IO.Directory.Delete(folderPath + "/here");
            }
            System.IO.Directory.CreateDirectory(folderPath + "/here");
            for (int f = 0; f < cursorArrayList.Count; f++)
            {
                if (cursorArrayList[f] != string.Empty)
                {
                    if (!IsHanZi(cursorArrayList[f].ToString()[0].ToString()))
                    {
                        File.Copy(folderPath + "/" + cursorArrayList[f], folderPath + "/here/");
                    }
                }

            }
            for (int K = 0; K < cursorArrayList.Count; K++)
            {
                if (cursorArrayList[K] == string.Empty)
                {
                    allCheckLanguageName.Add(cursorArrayList[K]);
                    continue;
                }
                if (!IsHanZi(cursorArrayList[K].ToString()[0].ToString()))
                {
                    allCheckLanguageName.Add(cursorArrayList[K]);
                }
                else
                {
                    for (int L = 0; L < allCursor.Length; L++)
                    {
                        if (allCursor[L].Contains(GetName(cursorArrayList[K].ToString())))
                        {
                            allCheckLanguageName.Add(allCursor[L].Substring(0, allCursor[L].IndexOf("/")) + 1);
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
        private static bool IsHanZi(string ch)
        {
            byte[] byte_len = System.Text.Encoding.Default.GetBytes(ch);
            if (byte_len.Length == 3) { return true; }

            return false;
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

        private string GetName(string name)
        {
            if (name.EndsWith(".ani"))
            {
                return name.Replace(".ani", " ").Trim();
            }
            else
            {
                return name.Replace(".cur", " ").Trim();
            }
        }

        private void 中文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            en_language = false;
            englishToolStripMenuItem.Text = "English";
            中文ToolStripMenuItem.Text = "中文   √";
            SwitchLanguage();
        }
        /// <summary>
        /// Switch Language
        /// </summary>
        public void SwitchLanguage()
        {
            if (en_language)
            {
                startToolStripMenuItem.Text = "Start";
                selectFolderToolStripMenuItem.Text = "Select Folder";
                languageToolStripMenuItem.Text = "Language";
                labelTheme.Text = "Theme Name(English is recommended)";
                buttonMake.Text = "Go";
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
                labelTheme.Text = "主题名称(建议为英文)";
                buttonMake.Text = "生成";
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
        /// <summary>
        /// Replace Element
        /// </summary>
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
                    if (textBoxTheme.Text == String.Empty)
                    {
                        if (en_language)
                        {
                            MessageBox.Show("The pointer subject name is not filled in, and the default is MyCursor");
                        }
                        else
                        {
                            MessageBox.Show("未填写主题名称，默认将为MyCursor");
                        }
                        textBoxTheme.Text = "MyCursor";
                    }
                    baseTxt[I] = baseTxt[I].Replace("elementName", textBoxTheme.Text);
                }
                if (baseTxt[I].Contains($"element{elementNumberTwo}{elementStringTwo}"))
                {
                    for (int C = 0; C < cursorArrayList.Count; C++)
                    {
                        if (cursorArrayList[C].ToString().Contains(baseTxt[I].Substring(0, baseTxt[I].IndexOf(" "))))
                        {
                            baseTxt[I] = baseTxt[I].Replace($"element{elementNumberTwo}{elementStringTwo}", cursorArrayList[C].ToString());
                            elementNumberTwo++;
                            break;
                        }
                        else
                        {
                            if (C == cursorArrayList.Count - 1)
                            {
                                baseTxt[I] = string.Empty;
                                elementNumberTwo++;
                            }
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
            if (folderPath == null)
            {
                return;
            }
            baseTxt = File.ReadAllLines(basePath);
            ReplaceElement();
            CreateInfFile();
        }
        public void CreateInfFile()
        {
            System.IO.File.WriteAllLines($"{folderPath}\\右键安装.inf", baseTxt);
            if (en_language)
            {
                MessageBox.Show("Sucess！");
            }
            else
            {
                MessageBox.Show("成功");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void listBox1_DragLeave(object sender, EventArgs e)
        {

        }
    }
}