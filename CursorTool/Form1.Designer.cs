namespace CursorTool
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lackLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中文ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iCOReplaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genrateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonMake = new System.Windows.Forms.Button();
            this.textBoxTheme = new System.Windows.Forms.TextBox();
            this.labelTheme = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            resources.ApplyResources(this.listBox1, "listBox1");
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.DragLeave += new System.EventHandler(this.listBox1_DragLeave);
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // lackLabel
            // 
            resources.ApplyResources(this.lackLabel, "lackLabel");
            this.lackLabel.Name = "lackLabel";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.otherToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // startToolStripMenuItem
            // 
            resources.ApplyResources(this.startToolStripMenuItem, "startToolStripMenuItem");
            this.startToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectFolderToolStripMenuItem});
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            // 
            // selectFolderToolStripMenuItem
            // 
            this.selectFolderToolStripMenuItem.Name = "selectFolderToolStripMenuItem";
            resources.ApplyResources(this.selectFolderToolStripMenuItem, "selectFolderToolStripMenuItem");
            this.selectFolderToolStripMenuItem.Click += new System.EventHandler(this.selectFolderToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.中文ToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // 中文ToolStripMenuItem
            // 
            this.中文ToolStripMenuItem.Name = "中文ToolStripMenuItem";
            resources.ApplyResources(this.中文ToolStripMenuItem, "中文ToolStripMenuItem");
            this.中文ToolStripMenuItem.Click += new System.EventHandler(this.中文ToolStripMenuItem_Click);
            // 
            // otherToolStripMenuItem
            // 
            resources.ApplyResources(this.otherToolStripMenuItem, "otherToolStripMenuItem");
            this.otherToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iCOReplaceToolStripMenuItem,
            this.genrateToolStripMenuItem});
            this.otherToolStripMenuItem.Name = "otherToolStripMenuItem";
            // 
            // iCOReplaceToolStripMenuItem
            // 
            this.iCOReplaceToolStripMenuItem.Name = "iCOReplaceToolStripMenuItem";
            resources.ApplyResources(this.iCOReplaceToolStripMenuItem, "iCOReplaceToolStripMenuItem");
            this.iCOReplaceToolStripMenuItem.Click += new System.EventHandler(this.iCOReplaceToolStripMenuItem_Click);
            // 
            // genrateToolStripMenuItem
            // 
            this.genrateToolStripMenuItem.Name = "genrateToolStripMenuItem";
            resources.ApplyResources(this.genrateToolStripMenuItem, "genrateToolStripMenuItem");
            this.genrateToolStripMenuItem.Click += new System.EventHandler(this.genrateToolStripMenuItem_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // buttonMake
            // 
            resources.ApplyResources(this.buttonMake, "buttonMake");
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.UseVisualStyleBackColor = true;
            this.buttonMake.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // textBoxTheme
            // 
            resources.ApplyResources(this.textBoxTheme, "textBoxTheme");
            this.textBoxTheme.Name = "textBoxTheme";
            // 
            // labelTheme
            // 
            resources.ApplyResources(this.labelTheme, "labelTheme");
            this.labelTheme.Name = "labelTheme";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelTheme);
            this.Controls.Add(this.textBoxTheme);
            this.Controls.Add(this.buttonMake);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lackLabel);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox listBox1;
        private Label lackLabel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem startToolStripMenuItem;
        private ToolStripMenuItem selectFolderToolStripMenuItem;
        private ToolStripMenuItem languageToolStripMenuItem;
        private ToolStripMenuItem englishToolStripMenuItem;
        private ToolStripMenuItem 中文ToolStripMenuItem;
        private Button button1;
        private Button buttonMake;
        private TextBox textBoxTheme;
        private Label labelTheme;
        private ToolStripMenuItem otherToolStripMenuItem;
        private ToolStripMenuItem iCOReplaceToolStripMenuItem;
        private ToolStripMenuItem genrateToolStripMenuItem;
    }
}