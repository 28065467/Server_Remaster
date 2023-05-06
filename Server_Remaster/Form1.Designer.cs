namespace Server_Remaster
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_ServerStart = new System.Windows.Forms.Button();
            this.btn_GameStart = new System.Windows.Forms.Button();
            this.btn_EXIT = new System.Windows.Forms.Button();
            this.IP = new System.Windows.Forms.Label();
            this.PORT = new System.Windows.Forms.Label();
            this.tbx_IP = new System.Windows.Forms.TextBox();
            this.tbx_PORT = new System.Windows.Forms.TextBox();
            this.list_LOG = new System.Windows.Forms.ListBox();
            this.Server_LOG = new System.Windows.Forms.Label();
            this.list_Recv = new System.Windows.Forms.ListBox();
            this.Recv = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_ServerStart
            // 
            this.btn_ServerStart.Location = new System.Drawing.Point(26, 108);
            this.btn_ServerStart.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_ServerStart.Name = "btn_ServerStart";
            this.btn_ServerStart.Size = new System.Drawing.Size(208, 88);
            this.btn_ServerStart.TabIndex = 0;
            this.btn_ServerStart.Text = "Server Start";
            this.btn_ServerStart.UseVisualStyleBackColor = true;
            this.btn_ServerStart.Click += new System.EventHandler(this.btn_ServerStart_Click);
            // 
            // btn_GameStart
            // 
            this.btn_GameStart.Location = new System.Drawing.Point(275, 108);
            this.btn_GameStart.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_GameStart.Name = "btn_GameStart";
            this.btn_GameStart.Size = new System.Drawing.Size(208, 88);
            this.btn_GameStart.TabIndex = 1;
            this.btn_GameStart.Text = "Game Start";
            this.btn_GameStart.UseVisualStyleBackColor = true;
            this.btn_GameStart.Click += new System.EventHandler(this.btn_GameStart_Click);
            // 
            // btn_EXIT
            // 
            this.btn_EXIT.Location = new System.Drawing.Point(522, 108);
            this.btn_EXIT.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btn_EXIT.Name = "btn_EXIT";
            this.btn_EXIT.Size = new System.Drawing.Size(208, 88);
            this.btn_EXIT.TabIndex = 2;
            this.btn_EXIT.Text = "EXIT";
            this.btn_EXIT.UseVisualStyleBackColor = true;
            this.btn_EXIT.Click += new System.EventHandler(this.btn_EXIT_Click);
            // 
            // IP
            // 
            this.IP.AutoSize = true;
            this.IP.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IP.Location = new System.Drawing.Point(1008, 108);
            this.IP.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(154, 37);
            this.IP.TabIndex = 3;
            this.IP.Text = "Server IP";
            // 
            // PORT
            // 
            this.PORT.AutoSize = true;
            this.PORT.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PORT.Location = new System.Drawing.Point(943, 182);
            this.PORT.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.PORT.Name = "PORT";
            this.PORT.Size = new System.Drawing.Size(212, 37);
            this.PORT.TabIndex = 4;
            this.PORT.Text = "Server PORT";
            // 
            // tbx_IP
            // 
            this.tbx_IP.Location = new System.Drawing.Point(1224, 102);
            this.tbx_IP.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tbx_IP.Name = "tbx_IP";
            this.tbx_IP.Size = new System.Drawing.Size(212, 36);
            this.tbx_IP.TabIndex = 5;
            // 
            // tbx_PORT
            // 
            this.tbx_PORT.Location = new System.Drawing.Point(1224, 176);
            this.tbx_PORT.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tbx_PORT.Name = "tbx_PORT";
            this.tbx_PORT.Size = new System.Drawing.Size(212, 36);
            this.tbx_PORT.TabIndex = 6;
            // 
            // list_LOG
            // 
            this.list_LOG.FormattingEnabled = true;
            this.list_LOG.ItemHeight = 24;
            this.list_LOG.Location = new System.Drawing.Point(26, 414);
            this.list_LOG.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.list_LOG.Name = "list_LOG";
            this.list_LOG.Size = new System.Drawing.Size(799, 460);
            this.list_LOG.TabIndex = 7;
            // 
            // Server_LOG
            // 
            this.Server_LOG.AutoSize = true;
            this.Server_LOG.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Server_LOG.Location = new System.Drawing.Point(314, 370);
            this.Server_LOG.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Server_LOG.Name = "Server_LOG";
            this.Server_LOG.Size = new System.Drawing.Size(195, 37);
            this.Server_LOG.TabIndex = 8;
            this.Server_LOG.Text = "Server LOG";
            // 
            // list_Recv
            // 
            this.list_Recv.FormattingEnabled = true;
            this.list_Recv.ItemHeight = 24;
            this.list_Recv.Location = new System.Drawing.Point(875, 414);
            this.list_Recv.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.list_Recv.Name = "list_Recv";
            this.list_Recv.Size = new System.Drawing.Size(799, 460);
            this.list_Recv.TabIndex = 9;
            // 
            // Recv
            // 
            this.Recv.AutoSize = true;
            this.Recv.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Recv.Location = new System.Drawing.Point(1170, 370);
            this.Recv.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Recv.Name = "Recv";
            this.Recv.Size = new System.Drawing.Size(302, 37);
            this.Recv.TabIndex = 10;
            this.Recv.Text = "Received Message";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1733, 900);
            this.Controls.Add(this.Recv);
            this.Controls.Add(this.list_Recv);
            this.Controls.Add(this.Server_LOG);
            this.Controls.Add(this.list_LOG);
            this.Controls.Add(this.tbx_PORT);
            this.Controls.Add(this.tbx_IP);
            this.Controls.Add(this.PORT);
            this.Controls.Add(this.IP);
            this.Controls.Add(this.btn_EXIT);
            this.Controls.Add(this.btn_GameStart);
            this.Controls.Add(this.btn_ServerStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Bomb Game Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ServerStart;
        private System.Windows.Forms.Button btn_GameStart;
        private System.Windows.Forms.Button btn_EXIT;
        private System.Windows.Forms.Label IP;
        private System.Windows.Forms.Label PORT;
        private System.Windows.Forms.TextBox tbx_IP;
        private System.Windows.Forms.TextBox tbx_PORT;
        private System.Windows.Forms.ListBox list_LOG;
        private System.Windows.Forms.Label Server_LOG;
        private System.Windows.Forms.ListBox list_Recv;
        private System.Windows.Forms.Label Recv;
    }
}

