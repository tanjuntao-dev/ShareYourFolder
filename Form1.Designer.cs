namespace ShareYourFolder
{
    partial class FolderShare_Connect
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
            Title = new Label();
            Func1_HostName = new Label();
            Func1_HostName_Input = new TextBox();
            Func1_exc = new Button();
            Func1_ShareName = new Label();
            Func1_ShareName_Input = new TextBox();
            label1 = new Label();
            Func1_UserName_Input = new TextBox();
            label2 = new Label();
            Func1_Password_Input = new TextBox();
            label3 = new Label();
            Func1_IP_Label = new Label();
            panel1 = new Panel();
            linkLabel2 = new LinkLabel();
            linkLabel1 = new LinkLabel();
            panel2 = new Panel();
            label4 = new Label();
            Connect = new Label();
            panel3 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 134);
            Title.ForeColor = SystemColors.ButtonFace;
            Title.Location = new Point(50, 19);
            Title.Name = "Title";
            Title.Size = new Size(254, 31);
            Title.TabIndex = 0;
            Title.Text = "系统文件夹共享与连接";
            // 
            // Func1_HostName
            // 
            Func1_HostName.AutoSize = true;
            Func1_HostName.Location = new Point(50, 123);
            Func1_HostName.Name = "Func1_HostName";
            Func1_HostName.Size = new Size(116, 17);
            Func1_HostName.TabIndex = 1;
            Func1_HostName.Text = "需要连接的主机名：";
            // 
            // Func1_HostName_Input
            // 
            Func1_HostName_Input.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Func1_HostName_Input.Location = new Point(220, 120);
            Func1_HostName_Input.Name = "Func1_HostName_Input";
            Func1_HostName_Input.Size = new Size(427, 23);
            Func1_HostName_Input.TabIndex = 2;
            // 
            // Func1_exc
            // 
            Func1_exc.Location = new Point(220, 360);
            Func1_exc.Name = "Func1_exc";
            Func1_exc.Size = new Size(75, 23);
            Func1_exc.TabIndex = 3;
            Func1_exc.Text = "连接";
            Func1_exc.UseVisualStyleBackColor = true;
            Func1_exc.Click += Func1_exc_Click;
            // 
            // Func1_ShareName
            // 
            Func1_ShareName.AutoSize = true;
            Func1_ShareName.Location = new Point(50, 183);
            Func1_ShareName.Name = "Func1_ShareName";
            Func1_ShareName.Size = new Size(104, 17);
            Func1_ShareName.TabIndex = 4;
            Func1_ShareName.Text = "共享文件夹名称：";
            // 
            // Func1_ShareName_Input
            // 
            Func1_ShareName_Input.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Func1_ShareName_Input.Location = new Point(220, 180);
            Func1_ShareName_Input.Name = "Func1_ShareName_Input";
            Func1_ShareName_Input.Size = new Size(427, 23);
            Func1_ShareName_Input.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 243);
            label1.Name = "label1";
            label1.Size = new Size(97, 17);
            label1.TabIndex = 6;
            label1.Text = "用户名/账户名：";
            // 
            // Func1_UserName_Input
            // 
            Func1_UserName_Input.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Func1_UserName_Input.Location = new Point(220, 240);
            Func1_UserName_Input.Name = "Func1_UserName_Input";
            Func1_UserName_Input.Size = new Size(427, 23);
            Func1_UserName_Input.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 303);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 8;
            label2.Text = "密码：";
            // 
            // Func1_Password_Input
            // 
            Func1_Password_Input.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Func1_Password_Input.Location = new Point(220, 300);
            Func1_Password_Input.Name = "Func1_Password_Input";
            Func1_Password_Input.Size = new Size(427, 23);
            Func1_Password_Input.TabIndex = 9;
            Func1_Password_Input.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(673, 102);
            label3.Name = "label3";
            label3.Size = new Size(0, 17);
            label3.TabIndex = 10;
            // 
            // Func1_IP_Label
            // 
            Func1_IP_Label.AutoSize = true;
            Func1_IP_Label.Location = new Point(220, 146);
            Func1_IP_Label.Name = "Func1_IP_Label";
            Func1_IP_Label.Size = new Size(86, 17);
            Func1_IP_Label.TabIndex = 11;
            Func1_IP_Label.Text = "IP: （未探测）";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightGray;
            panel1.Controls.Add(linkLabel2);
            panel1.Controls.Add(linkLabel1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 409);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 41);
            panel1.TabIndex = 12;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.LinkColor = Color.DimGray;
            linkLabel2.Location = new Point(179, 15);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(32, 17);
            linkLabel2.TabIndex = 1;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "关于";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.DimGray;
            linkLabel1.Location = new Point(50, 15);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(32, 17);
            linkLabel1.TabIndex = 0;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "帮助";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkGray;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(Connect);
            panel2.Controls.Add(Title);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 90);
            panel2.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(230, 67);
            label4.Name = "label4";
            label4.Size = new Size(79, 20);
            label4.TabIndex = 2;
            label4.Text = "创建共享盘";
            label4.Click += lblFutureFeature_Click;
            // 
            // Connect
            // 
            Connect.AutoSize = true;
            Connect.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Connect.ForeColor = SystemColors.ButtonFace;
            Connect.Location = new Point(53, 67);
            Connect.Name = "Connect";
            Connect.Size = new Size(79, 20);
            Connect.TabIndex = 1;
            Connect.Text = "连接共享盘";
            // 
            // panel3
            // 
            panel3.BackColor = Color.RosyBrown;
            panel3.Location = new Point(56, 90);
            panel3.Name = "panel3";
            panel3.Size = new Size(75, 5);
            panel3.TabIndex = 14;
            // 
            // FolderShare_Connect
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(Func1_IP_Label);
            Controls.Add(label3);
            Controls.Add(Func1_Password_Input);
            Controls.Add(label2);
            Controls.Add(Func1_UserName_Input);
            Controls.Add(label1);
            Controls.Add(Func1_ShareName_Input);
            Controls.Add(Func1_ShareName);
            Controls.Add(Func1_exc);
            Controls.Add(Func1_HostName_Input);
            Controls.Add(Func1_HostName);
            Controls.Add(panel2);
            Name = "FolderShare_Connect";
            Text = "FolderBridge";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Title;
        private Label Func1_HostName;
        private TextBox Func1_HostName_Input;
        private Button Func1_exc;
        private Label Func1_ShareName;
        private TextBox Func1_ShareName_Input;
        private Label label1;
        private TextBox Func1_UserName_Input;
        private Label label2;
        private TextBox Func1_Password_Input;
        private Label label3;
        private Label Func1_IP_Label;
        private Panel panel1;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private Panel panel2;
        private Label Connect;
        private Panel panel3;
        private Label label4;
    }
}
