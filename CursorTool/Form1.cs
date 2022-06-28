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
                    lackLabel.Text = "��ϲ�㣬���ڿ��Խ�������inf";
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
                    lackLabel.Text = "��ȱ��:" + lackNumber;
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
            englishToolStripMenuItem.Text = "English  ��";
            ����ToolStripMenuItem.Text = "����";
            SwitchLanguage();
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            en_language = false;
            englishToolStripMenuItem.Text = "English";
            ����ToolStripMenuItem.Text = "����   ��";
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
                    if (lackLabel.Text.StartsWith('��'))
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
                startToolStripMenuItem.Text = "��ʼ";
                selectFolderToolStripMenuItem.Text = "ѡ���ļ���";
                languageToolStripMenuItem.Text = "����";
                labelTheme.Text = "��������(����ΪӢ��)";
                buttonMake.Text = "����";
                if (lackLabel.Text.StartsWith('C') || lackLabel.Text.StartsWith('Y'))
                {
                    if (lackLabel.Text.StartsWith('C'))
                    {
                        lackLabel.Text = "��ϲ�㣬���ڿ��Խ�������inf";
                    }
                    else
                    {
                        lackLabel.Text = "��ȱ��:" + lackNumber;
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
                            MessageBox.Show("δ��д�������ƣ�Ĭ�Ͻ�ΪMyCursor");
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
                          if(C == cursorArrayList.Count - 1)
                            {
                                baseTxt[I] =string.Empty;
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
            System.IO.File.WriteAllLines($"{folderPath}\\this.inf", baseTxt);
            if (en_language)
            {
                MessageBox.Show("Sucess��");
            }
            else
            {
                MessageBox.Show("�ɹ�");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}