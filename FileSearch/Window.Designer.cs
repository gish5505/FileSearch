
namespace FileSearch
{
    partial class Window
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.targetFileInput = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.fileTreeView = new System.Windows.Forms.TreeView();
            this.regexInputBox = new System.Windows.Forms.GroupBox();
            this.searchPathBox = new System.Windows.Forms.GroupBox();
            this.targetDirectoryInput = new System.Windows.Forms.TextBox();
            this.statusStripFiles = new System.Windows.Forms.StatusStrip();
            this.statusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.countersBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.elapsedTimerLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.foundFilesLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.totalFilesLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pauseButton = new System.Windows.Forms.Button();
            this.regexInputBox.SuspendLayout();
            this.searchPathBox.SuspendLayout();
            this.statusStripFiles.SuspendLayout();
            this.countersBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // targetFileInput
            // 
            this.targetFileInput.Location = new System.Drawing.Point(6, 33);
            this.targetFileInput.Name = "targetFileInput";
            this.targetFileInput.Size = new System.Drawing.Size(183, 20);
            this.targetFileInput.TabIndex = 0;
            this.targetFileInput.Text = "[\\w*]";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(379, 343);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Старт";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // fileTreeView
            // 
            this.fileTreeView.Location = new System.Drawing.Point(60, 60);
            this.fileTreeView.Name = "fileTreeView";
            this.fileTreeView.Size = new System.Drawing.Size(248, 257);
            this.fileTreeView.TabIndex = 2;
            // 
            // regexInputBox
            // 
            this.regexInputBox.Controls.Add(this.targetFileInput);
            this.regexInputBox.Location = new System.Drawing.Point(390, 72);
            this.regexInputBox.Name = "regexInputBox";
            this.regexInputBox.Size = new System.Drawing.Size(200, 100);
            this.regexInputBox.TabIndex = 3;
            this.regexInputBox.TabStop = false;
            this.regexInputBox.Text = "Regex маска файла";
            // 
            // searchPathBox
            // 
            this.searchPathBox.Controls.Add(this.targetDirectoryInput);
            this.searchPathBox.Location = new System.Drawing.Point(390, 189);
            this.searchPathBox.Name = "searchPathBox";
            this.searchPathBox.Size = new System.Drawing.Size(200, 100);
            this.searchPathBox.TabIndex = 4;
            this.searchPathBox.TabStop = false;
            this.searchPathBox.Text = "Путь";
            // 
            // targetDirectoryInput
            // 
            this.targetDirectoryInput.Location = new System.Drawing.Point(6, 29);
            this.targetDirectoryInput.Name = "targetDirectoryInput";
            this.targetDirectoryInput.Size = new System.Drawing.Size(183, 20);
            this.targetDirectoryInput.TabIndex = 0;
            this.targetDirectoryInput.Text = "d:\\downloads";
            // 
            // statusStripFiles
            // 
            this.statusStripFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripLabel});
            this.statusStripFiles.Location = new System.Drawing.Point(0, 422);
            this.statusStripFiles.Name = "statusStripFiles";
            this.statusStripFiles.Size = new System.Drawing.Size(598, 22);
            this.statusStripFiles.SizingGrip = false;
            this.statusStripFiles.TabIndex = 5;
            this.statusStripFiles.Text = "statusStrip1";
            // 
            // statusStripLabel
            // 
            this.statusStripLabel.Name = "statusStripLabel";
            this.statusStripLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // countersBox
            // 
            this.countersBox.Controls.Add(this.label4);
            this.countersBox.Controls.Add(this.elapsedTimerLabel);
            this.countersBox.Controls.Add(this.label2);
            this.countersBox.Controls.Add(this.foundFilesLabel);
            this.countersBox.Controls.Add(this.label3);
            this.countersBox.Controls.Add(this.totalFilesLabel);
            this.countersBox.Controls.Add(this.label1);
            this.countersBox.Location = new System.Drawing.Point(60, 323);
            this.countersBox.Name = "countersBox";
            this.countersBox.Size = new System.Drawing.Size(200, 96);
            this.countersBox.TabIndex = 6;
            this.countersBox.TabStop = false;
            this.countersBox.Text = "Счетчики";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(147, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "сек";
            // 
            // elapsedTimerLabel
            // 
            this.elapsedTimerLabel.AutoSize = true;
            this.elapsedTimerLabel.Location = new System.Drawing.Point(128, 80);
            this.elapsedTimerLabel.Name = "elapsedTimerLabel";
            this.elapsedTimerLabel.Size = new System.Drawing.Size(13, 13);
            this.elapsedTimerLabel.TabIndex = 5;
            this.elapsedTimerLabel.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Времени прошло";
            // 
            // foundFilesLabel
            // 
            this.foundFilesLabel.AutoSize = true;
            this.foundFilesLabel.Location = new System.Drawing.Point(128, 52);
            this.foundFilesLabel.Name = "foundFilesLabel";
            this.foundFilesLabel.Size = new System.Drawing.Size(13, 13);
            this.foundFilesLabel.TabIndex = 3;
            this.foundFilesLabel.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Найдено файлов:";
            // 
            // totalFilesLabel
            // 
            this.totalFilesLabel.AutoSize = true;
            this.totalFilesLabel.Location = new System.Drawing.Point(128, 20);
            this.totalFilesLabel.Name = "totalFilesLabel";
            this.totalFilesLabel.Size = new System.Drawing.Size(13, 13);
            this.totalFilesLabel.TabIndex = 1;
            this.totalFilesLabel.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Обработано файлов:";
            // 
            // pauseButton
            // 
            this.pauseButton.Enabled = false;
            this.pauseButton.Location = new System.Drawing.Point(492, 343);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(87, 23);
            this.pauseButton.TabIndex = 8;
            this.pauseButton.Text = "Пауза";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // Window
            // 
            this.AllowDrop = true;
            this.ClientSize = new System.Drawing.Size(598, 444);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.countersBox);
            this.Controls.Add(this.statusStripFiles);
            this.Controls.Add(this.searchPathBox);
            this.Controls.Add(this.regexInputBox);
            this.Controls.Add(this.fileTreeView);
            this.Controls.Add(this.startButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Window";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Window_FormClosing);
            this.Load += new System.EventHandler(this.Window_Load);
            this.regexInputBox.ResumeLayout(false);
            this.regexInputBox.PerformLayout();
            this.searchPathBox.ResumeLayout(false);
            this.searchPathBox.PerformLayout();
            this.statusStripFiles.ResumeLayout(false);
            this.statusStripFiles.PerformLayout();
            this.countersBox.ResumeLayout(false);
            this.countersBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox targetFileInput;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TreeView fileTreeView;
        private System.Windows.Forms.GroupBox regexInputBox;
        private System.Windows.Forms.GroupBox searchPathBox;
        private System.Windows.Forms.TextBox targetDirectoryInput;
        private System.Windows.Forms.StatusStrip statusStripFiles;
        private System.Windows.Forms.ToolStripStatusLabel statusStripLabel;
        private System.Windows.Forms.GroupBox countersBox;
        private System.Windows.Forms.Label foundFilesLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label totalFilesLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Label elapsedTimerLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}

