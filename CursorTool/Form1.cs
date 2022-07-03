using System.Collections;
using System.Drawing.Imaging;

namespace CursorTool
{
    public partial class Form1 : Form
    {
        public string[] allFile;
        public ArrayList cursorArrayList = new ArrayList();
        public ArrayList FileArrayList = new ArrayList();
        public int lackNumber;
        public bool en_language;
        public string folderPath;
        public string basePath = "base.txt";
        public string[] baseTxt;
        public ArrayList allCheckLanguageName = new ArrayList();
        public string[] allCursor = new string[]
        {
            "alternate/候选",
            "busy/忙",
            "cross/精确选择",
            "dgn1/沿对角线调整大小 1",
            "dgn2/沿对角线调整大小 2",
            "handwriting/手写",
            "help/帮助选择",
            "horz/水平调整大小",
            "link/链接选择",
            "loc/位置选择",
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
            SwitchLanguage(en_language);
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
                                if (!IsHanZi(noNameFile[0].ToString()))
                                {
                                    cursorArrayList.Add(allFile[i].Substring(allFile[i].ToString().LastIndexOf("\\") + 1));
                                    allCheckLanguageName.Add((allFile[i].Substring(allFile[i].ToString().LastIndexOf("\\") + 1)));
                                }
                                else
                                {
                                    allCheckLanguageName.Add((allFile[i].Substring(allFile[i].ToString().LastIndexOf("\\") + 1)));
                                    string fileName = allFile[i].Substring(allFile[i].ToString().LastIndexOf("\\") + 1);
                                    for (int V = 0; V < allCursor.Length; V++)
                                    {
                                        if (allCursor[V].Contains(GetName(fileName)))
                                        {
                                            fileName = fileName.Replace(GetName(fileName), allCursor[V].Substring(0, allCursor[V].IndexOf("/")).Replace("/", " ").ToString().Trim());
                                            cursorArrayList.Add(fileName);
                                        }
                                    }
                                }
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
                System.IO.Directory.Delete(folderPath + "/here", true);
            }
            System.IO.Directory.CreateDirectory(folderPath + "/here");
            for (int f = 0; f < allCheckLanguageName.Count; f++)
            {
                if (allCheckLanguageName[f] != string.Empty)
                {
                    if (!IsHanZi(allCheckLanguageName[f].ToString()[0].ToString()))
                    {
                        File.Copy(folderPath + "/" + allCheckLanguageName[f], folderPath + "/here/" + allCheckLanguageName[f]);
                    }
                    else
                    {
                        for (int L = 0; L < allCursor.Length; L++)
                        {
                            if (allCursor[L].Contains(GetName(allCheckLanguageName[f].ToString())))
                            {
                                File.Copy(folderPath + "/" + allCheckLanguageName[f], folderPath + "/here/" +
                                    (allCheckLanguageName[f].ToString().Replace(GetName(allCheckLanguageName[f].ToString()), allCursor[L].Substring(0, allCursor[L].IndexOf("/")))).Replace("/", " ").ToString().Trim());
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
                    lackLabel.Text = "现在可以开始生成inf";
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
                    lackLabel.Text = "您缺少" + lackNumber;
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
            SwitchLanguage(en_language);
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
            SwitchLanguage(en_language);
        }
        /// <summary>
        /// Switch Language
        /// </summary>
        public void SwitchLanguage(bool LanStatus)
        {
            if (LanStatus)
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
                otherToolStripMenuItem.Text = "other";
                iCOReplaceToolStripMenuItem.Text = "ICO-Replace";
                genrateToolStripMenuItem.Text = "Generate ICO INF";

            }
            else
            {
                startToolStripMenuItem.Text = "开始";
                selectFolderToolStripMenuItem.Text = "选择文件夹";
                labelTheme.Text = "主题名称(建议为英文)";
                buttonMake.Text = "生成";
                otherToolStripMenuItem.Text = "其他";
                iCOReplaceToolStripMenuItem.Text = "替换生成ico文件";
                genrateToolStripMenuItem.Text = "生成ico-ing文件";
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
                else
                {
                    lackLabel.Text = "未选择";
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
                    if (elementNumber - 1 < cursorArrayList.Count)
                    {
                        baseTxt[I] = baseTxt[I].Replace($"element{elementNumber}", cursorArrayList[elementNumber - 1].ToString());
                        elementNumber++;
                    }
                    else
                    {
                        baseTxt[I] = string.Empty;
                        elementNumber++;
                    }

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

        public static bool ConvertImageToIcon(string origin, string destination, Size iconSize)
        {
            if (iconSize.Width > 255 || iconSize.Height > 255)
            {
                return false;
            }
            Image image = new Bitmap(new Bitmap(origin), iconSize); //先读取已有的图片为bitmap，并缩放至设定大小
            MemoryStream bitMapStream = new MemoryStream(); //存原图的内存流
            MemoryStream iconStream = new MemoryStream(); //存图标的内存流
            image.Save(bitMapStream, ImageFormat.Png); //将原图读取为png格式并存入原图内存流
            BinaryWriter iconWriter = new BinaryWriter(iconStream); //新建二进制写入器以写入目标图标内存流
            /**
             * 下面是根据原图信息，进行文件头写入
             */
            iconWriter.Write((short)0);
            iconWriter.Write((short)1);
            iconWriter.Write((short)1);
            iconWriter.Write((byte)image.Width);
            iconWriter.Write((byte)image.Height);
            iconWriter.Write((short)0);
            iconWriter.Write((short)0);
            iconWriter.Write((short)32);
            iconWriter.Write((int)bitMapStream.Length);
            iconWriter.Write(22);
            //写入图像体至目标图标内存流
            iconWriter.Write(bitMapStream.ToArray());
            //保存流，并将流指针定位至头部以Icon对象进行读取输出为文件
            iconWriter.Flush();
            iconWriter.Seek(0, SeekOrigin.Begin);
            if (System.IO.File.Exists(destination))
            {
                System.IO.Directory.CreateDirectory(destination);
            }
            Stream iconFileStream = new FileStream(destination, FileMode.Create);
            Icon icon = new Icon(iconStream);
            icon.Save(iconFileStream); //储存图像
            /**
             * 下面开始释放资源
             */
            iconFileStream.Close();
            iconWriter.Close();
            iconStream.Close();
            bitMapStream.Close();
            icon.Dispose();
            image.Dispose();
            return File.Exists(destination);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (folderPath != null)
            {
                cursorArrayList.Clear();
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
            System.IO.File.WriteAllLines($"{folderPath+"/here"}\\右键安装.inf", baseTxt);
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

        private void iCOReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png图片文件|*.png|jpg图片文件|*.jpg";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ConvertImageToIcon(System.IO.Path.GetFullPath(dialog.FileName), System.IO.Path.GetFullPath(dialog.FileName).Substring(0, System.IO.Path.GetFullPath(dialog.FileName).LastIndexOf("\\"))+"\\YourICON.ico", new Size(128, 128));
            }
        }

        private void genrateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string headerText = "[autorun]";
            string bodyText = "ICON=";
        }
    }
}