namespace SendMail
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.邮箱配置 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelDes = new System.Windows.Forms.Label();
            this.tbFileExcel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSendMail = new System.Windows.Forms.Button();
            this.openFileDialogExcel = new System.Windows.Forms.OpenFileDialog();
            this.labMes = new System.Windows.Forms.Label();
            this.邮箱配置.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // 邮箱配置
            // 
            this.邮箱配置.Controls.Add(this.tabPage1);
            this.邮箱配置.Location = new System.Drawing.Point(13, 13);
            this.邮箱配置.Name = "邮箱配置";
            this.邮箱配置.SelectedIndex = 0;
            this.邮箱配置.Size = new System.Drawing.Size(583, 230);
            this.邮箱配置.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labMes);
            this.tabPage1.Controls.Add(this.labelDes);
            this.tabPage1.Controls.Add(this.tbFileExcel);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnExit);
            this.tabPage1.Controls.Add(this.btnSendMail);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(575, 204);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "发送工资条邮件";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // labelDes
            // 
            this.labelDes.AutoSize = true;
            this.labelDes.Location = new System.Drawing.Point(59, 119);
            this.labelDes.Name = "labelDes";
            this.labelDes.Size = new System.Drawing.Size(65, 12);
            this.labelDes.TabIndex = 4;
            this.labelDes.Text = "发送结果：";
            // 
            // tbFileExcel
            // 
            this.tbFileExcel.Location = new System.Drawing.Point(131, 57);
            this.tbFileExcel.Name = "tbFileExcel";
            this.tbFileExcel.Size = new System.Drawing.Size(432, 21);
            this.tbFileExcel.TabIndex = 3;
            this.tbFileExcel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tbFileExcel_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "请选择文件：";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(488, 171);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSendMail
            // 
            this.btnSendMail.Location = new System.Drawing.Point(385, 171);
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.Size = new System.Drawing.Size(75, 23);
            this.btnSendMail.TabIndex = 0;
            this.btnSendMail.Text = "发送";
            this.btnSendMail.UseVisualStyleBackColor = true;
            this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
            // 
            // openFileDialogExcel
            // 
            this.openFileDialogExcel.FileName = "openFileDialogExcel";
            // 
            // labMes
            // 
            this.labMes.AutoSize = true;
            this.labMes.ForeColor = System.Drawing.Color.Red;
            this.labMes.Location = new System.Drawing.Point(131, 119);
            this.labMes.MaximumSize = new System.Drawing.Size(600, 0);
            this.labMes.Name = "labMes";
            this.labMes.Size = new System.Drawing.Size(137, 12);
            this.labMes.TabIndex = 5;
            this.labMes.Text = "双击文本框，选择文件！";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 249);
            this.Controls.Add(this.邮箱配置);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工资条邮件发送程序（QQ:326047963）";
            this.邮箱配置.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl 邮箱配置;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSendMail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFileExcel;
        private System.Windows.Forms.OpenFileDialog openFileDialogExcel;
        private System.Windows.Forms.Label labelDes;
        private System.Windows.Forms.Label labMes;

    }
}

