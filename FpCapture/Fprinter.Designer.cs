namespace FpCapture
{
    partial class Fprinter
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fprinter));
            this.IDC_Device = new System.Windows.Forms.Button();
            this.IDC_Image = new System.Windows.Forms.PictureBox();
            this.IDC_State = new System.Windows.Forms.GroupBox();
            this.IDB_SetBufferEmpty = new System.Windows.Forms.Button();
            this.IDCANCEL = new System.Windows.Forms.Button();
            this.IDC_BTN_LIVESCAN_Close = new System.Windows.Forms.Button();
            this.IDC_Stop = new System.Windows.Forms.Button();
            this.IDC_Capture = new System.Windows.Forms.Button();
            this.timerCapture = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numContrast = new System.Windows.Forms.NumericUpDown();
            this.numBright = new System.Windows.Forms.NumericUpDown();
            this.IDC_SetContrast = new System.Windows.Forms.Button();
            this.IDC_SetBright = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.IDC_Wsq_Save = new System.Windows.Forms.Button();
            this.IDC_EndCapture = new System.Windows.Forms.Button();
            this.IDC_Savebmp = new System.Windows.Forms.Button();
            this.IDC_BTN_GetFPRawData = new System.Windows.Forms.Button();
            this.IDC_BTN_BeginCapture = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.IDC_Channel = new System.Windows.Forms.Button();
            this.IDC_Version = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Button_Save = new System.Windows.Forms.Button();
            this.Button_Split = new System.Windows.Forms.Button();
            this.Text_Status = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.IDC_Image)).BeginInit();
            this.IDC_State.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBright)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // IDC_Device
            // 
            this.IDC_Device.Location = new System.Drawing.Point(19, 25);
            this.IDC_Device.Name = "IDC_Device";
            this.IDC_Device.Size = new System.Drawing.Size(118, 37);
            this.IDC_Device.TabIndex = 0;
            this.IDC_Device.Text = "打开设备";
            this.IDC_Device.UseVisualStyleBackColor = true;
            this.IDC_Device.Click += new System.EventHandler(this.IDC_Device_Click);
            // 
            // IDC_Image
            // 
            this.IDC_Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IDC_Image.ErrorImage = ((System.Drawing.Image)(resources.GetObject("IDC_Image.ErrorImage")));
            this.IDC_Image.InitialImage = null;
            this.IDC_Image.Location = new System.Drawing.Point(3, 12);
            this.IDC_Image.Name = "IDC_Image";
            this.IDC_Image.Size = new System.Drawing.Size(800, 750);
            this.IDC_Image.TabIndex = 1;
            this.IDC_Image.TabStop = false;
            // 
            // IDC_State
            // 
            this.IDC_State.Controls.Add(this.IDB_SetBufferEmpty);
            this.IDC_State.Controls.Add(this.IDCANCEL);
            this.IDC_State.Controls.Add(this.IDC_BTN_LIVESCAN_Close);
            this.IDC_State.Controls.Add(this.IDC_Stop);
            this.IDC_State.Controls.Add(this.IDC_Capture);
            this.IDC_State.Controls.Add(this.IDC_Device);
            this.IDC_State.Location = new System.Drawing.Point(809, 12);
            this.IDC_State.Name = "IDC_State";
            this.IDC_State.Size = new System.Drawing.Size(156, 466);
            this.IDC_State.TabIndex = 2;
            this.IDC_State.TabStop = false;
            this.IDC_State.Text = "Status";
            // 
            // IDB_SetBufferEmpty
            // 
            this.IDB_SetBufferEmpty.Location = new System.Drawing.Point(19, 410);
            this.IDB_SetBufferEmpty.Name = "IDB_SetBufferEmpty";
            this.IDB_SetBufferEmpty.Size = new System.Drawing.Size(118, 37);
            this.IDB_SetBufferEmpty.TabIndex = 0;
            this.IDB_SetBufferEmpty.Text = "Empty Buffer";
            this.IDB_SetBufferEmpty.UseVisualStyleBackColor = true;
            this.IDB_SetBufferEmpty.Click += new System.EventHandler(this.IDB_SetBufferEmpty_Click);
            // 
            // IDCANCEL
            // 
            this.IDCANCEL.Location = new System.Drawing.Point(19, 245);
            this.IDCANCEL.Name = "IDCANCEL";
            this.IDCANCEL.Size = new System.Drawing.Size(118, 37);
            this.IDCANCEL.TabIndex = 0;
            this.IDCANCEL.Text = "Exit";
            this.IDCANCEL.UseVisualStyleBackColor = true;
            this.IDCANCEL.Click += new System.EventHandler(this.IDCANCEL_Click);
            // 
            // IDC_BTN_LIVESCAN_Close
            // 
            this.IDC_BTN_LIVESCAN_Close.Location = new System.Drawing.Point(19, 190);
            this.IDC_BTN_LIVESCAN_Close.Name = "IDC_BTN_LIVESCAN_Close";
            this.IDC_BTN_LIVESCAN_Close.Size = new System.Drawing.Size(118, 37);
            this.IDC_BTN_LIVESCAN_Close.TabIndex = 0;
            this.IDC_BTN_LIVESCAN_Close.Text = "关闭设备";
            this.IDC_BTN_LIVESCAN_Close.UseVisualStyleBackColor = true;
            this.IDC_BTN_LIVESCAN_Close.Click += new System.EventHandler(this.IDC_BTN_LIVESCAN_Close_Click);
            // 
            // IDC_Stop
            // 
            this.IDC_Stop.Enabled = false;
            this.IDC_Stop.Location = new System.Drawing.Point(19, 135);
            this.IDC_Stop.Name = "IDC_Stop";
            this.IDC_Stop.Size = new System.Drawing.Size(118, 37);
            this.IDC_Stop.TabIndex = 0;
            this.IDC_Stop.Text = "停止采集";
            this.IDC_Stop.UseVisualStyleBackColor = true;
            this.IDC_Stop.Click += new System.EventHandler(this.IDC_Stop_Click);
            // 
            // IDC_Capture
            // 
            this.IDC_Capture.Location = new System.Drawing.Point(19, 80);
            this.IDC_Capture.Name = "IDC_Capture";
            this.IDC_Capture.Size = new System.Drawing.Size(118, 37);
            this.IDC_Capture.TabIndex = 0;
            this.IDC_Capture.Text = "四指采集";
            this.IDC_Capture.UseVisualStyleBackColor = true;
            this.IDC_Capture.Click += new System.EventHandler(this.IDC_Capture_Click);
            // 
            // timerCapture
            // 
            this.timerCapture.Tick += new System.EventHandler(this.timerCapture_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numContrast);
            this.groupBox1.Controls.Add(this.numBright);
            this.groupBox1.Controls.Add(this.IDC_SetContrast);
            this.groupBox1.Controls.Add(this.IDC_SetBright);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(809, 484);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 141);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Bright Contrast";
            // 
            // numContrast
            // 
            this.numContrast.Location = new System.Drawing.Point(64, 96);
            this.numContrast.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numContrast.Name = "numContrast";
            this.numContrast.Size = new System.Drawing.Size(86, 21);
            this.numContrast.TabIndex = 5;
            // 
            // numBright
            // 
            this.numBright.Location = new System.Drawing.Point(64, 40);
            this.numBright.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numBright.Name = "numBright";
            this.numBright.Size = new System.Drawing.Size(86, 21);
            this.numBright.TabIndex = 5;
            // 
            // IDC_SetContrast
            // 
            this.IDC_SetContrast.Location = new System.Drawing.Point(156, 93);
            this.IDC_SetContrast.Name = "IDC_SetContrast";
            this.IDC_SetContrast.Size = new System.Drawing.Size(51, 24);
            this.IDC_SetContrast.TabIndex = 2;
            this.IDC_SetContrast.Text = "Set";
            this.IDC_SetContrast.UseVisualStyleBackColor = true;
            this.IDC_SetContrast.Click += new System.EventHandler(this.IDC_SetContrast_Click);
            // 
            // IDC_SetBright
            // 
            this.IDC_SetBright.Location = new System.Drawing.Point(156, 37);
            this.IDC_SetBright.Name = "IDC_SetBright";
            this.IDC_SetBright.Size = new System.Drawing.Size(51, 24);
            this.IDC_SetBright.TabIndex = 2;
            this.IDC_SetBright.Text = "Set";
            this.IDC_SetBright.UseVisualStyleBackColor = true;
            this.IDC_SetBright.Click += new System.EventHandler(this.IDC_SetBright_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Contrast:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bright:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.IDC_Wsq_Save);
            this.groupBox2.Controls.Add(this.IDC_EndCapture);
            this.groupBox2.Controls.Add(this.IDC_Savebmp);
            this.groupBox2.Controls.Add(this.IDC_BTN_GetFPRawData);
            this.groupBox2.Controls.Add(this.IDC_BTN_BeginCapture);
            this.groupBox2.Location = new System.Drawing.Point(988, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(222, 298);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "A frame";
            // 
            // IDC_Wsq_Save
            // 
            this.IDC_Wsq_Save.Location = new System.Drawing.Point(20, 190);
            this.IDC_Wsq_Save.Name = "IDC_Wsq_Save";
            this.IDC_Wsq_Save.Size = new System.Drawing.Size(188, 37);
            this.IDC_Wsq_Save.TabIndex = 1;
            this.IDC_Wsq_Save.Text = "Save Wsq Data";
            this.IDC_Wsq_Save.UseVisualStyleBackColor = true;
            this.IDC_Wsq_Save.Click += new System.EventHandler(this.IDC_Wsq_Save_Click);
            // 
            // IDC_EndCapture
            // 
            this.IDC_EndCapture.Location = new System.Drawing.Point(20, 245);
            this.IDC_EndCapture.Name = "IDC_EndCapture";
            this.IDC_EndCapture.Size = new System.Drawing.Size(188, 37);
            this.IDC_EndCapture.TabIndex = 0;
            this.IDC_EndCapture.Text = "End Capture";
            this.IDC_EndCapture.UseVisualStyleBackColor = true;
            this.IDC_EndCapture.Click += new System.EventHandler(this.IDC_EndCapture_Click);
            // 
            // IDC_Savebmp
            // 
            this.IDC_Savebmp.Location = new System.Drawing.Point(20, 135);
            this.IDC_Savebmp.Name = "IDC_Savebmp";
            this.IDC_Savebmp.Size = new System.Drawing.Size(188, 37);
            this.IDC_Savebmp.TabIndex = 0;
            this.IDC_Savebmp.Text = "保存BMP图像";
            this.IDC_Savebmp.UseVisualStyleBackColor = true;
            this.IDC_Savebmp.Click += new System.EventHandler(this.IDC_Savebmp_Click);
            // 
            // IDC_BTN_GetFPRawData
            // 
            this.IDC_BTN_GetFPRawData.Location = new System.Drawing.Point(20, 80);
            this.IDC_BTN_GetFPRawData.Name = "IDC_BTN_GetFPRawData";
            this.IDC_BTN_GetFPRawData.Size = new System.Drawing.Size(188, 37);
            this.IDC_BTN_GetFPRawData.TabIndex = 0;
            this.IDC_BTN_GetFPRawData.Text = "采集一帧";
            this.IDC_BTN_GetFPRawData.UseVisualStyleBackColor = true;
            this.IDC_BTN_GetFPRawData.Click += new System.EventHandler(this.IDC_BTN_GetFPRawData_Click);
            // 
            // IDC_BTN_BeginCapture
            // 
            this.IDC_BTN_BeginCapture.Location = new System.Drawing.Point(20, 20);
            this.IDC_BTN_BeginCapture.Name = "IDC_BTN_BeginCapture";
            this.IDC_BTN_BeginCapture.Size = new System.Drawing.Size(188, 37);
            this.IDC_BTN_BeginCapture.TabIndex = 0;
            this.IDC_BTN_BeginCapture.Text = "Begin capture";
            this.IDC_BTN_BeginCapture.UseVisualStyleBackColor = true;
            this.IDC_BTN_BeginCapture.Click += new System.EventHandler(this.IDC_BTN_BeginCapture_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.IDC_Channel);
            this.groupBox3.Controls.Add(this.IDC_Version);
            this.groupBox3.Location = new System.Drawing.Point(809, 631);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(328, 64);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "API";
            // 
            // IDC_Channel
            // 
            this.IDC_Channel.Location = new System.Drawing.Point(170, 20);
            this.IDC_Channel.Name = "IDC_Channel";
            this.IDC_Channel.Size = new System.Drawing.Size(118, 29);
            this.IDC_Channel.TabIndex = 0;
            this.IDC_Channel.Text = "Get channel count";
            this.IDC_Channel.UseVisualStyleBackColor = true;
            this.IDC_Channel.Click += new System.EventHandler(this.IDC_Channel_Click);
            // 
            // IDC_Version
            // 
            this.IDC_Version.Location = new System.Drawing.Point(20, 20);
            this.IDC_Version.Name = "IDC_Version";
            this.IDC_Version.Size = new System.Drawing.Size(118, 29);
            this.IDC_Version.TabIndex = 0;
            this.IDC_Version.Text = "Version";
            this.IDC_Version.UseVisualStyleBackColor = true;
            this.IDC_Version.Click += new System.EventHandler(this.IDC_Version_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1105, 470);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "b";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Button_Save
            // 
            this.Button_Save.Location = new System.Drawing.Point(1105, 422);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(75, 23);
            this.Button_Save.TabIndex = 7;
            this.Button_Save.Text = "保存图像";
            this.Button_Save.UseVisualStyleBackColor = true;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // Button_Split
            // 
            this.Button_Split.Location = new System.Drawing.Point(1008, 346);
            this.Button_Split.Name = "Button_Split";
            this.Button_Split.Size = new System.Drawing.Size(192, 48);
            this.Button_Split.TabIndex = 8;
            this.Button_Split.Text = "四指拆分";
            this.Button_Split.UseVisualStyleBackColor = true;
            this.Button_Split.Click += new System.EventHandler(this.Button_Split_Click);
            // 
            // Text_Status
            // 
            this.Text_Status.Enabled = false;
            this.Text_Status.Location = new System.Drawing.Point(809, 701);
            this.Text_Status.Multiline = true;
            this.Text_Status.Name = "Text_Status";
            this.Text_Status.Size = new System.Drawing.Size(387, 50);
            this.Text_Status.TabIndex = 9;
            // 
            // Fprinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 802);
            this.Controls.Add(this.Text_Status);
            this.Controls.Add(this.Button_Split);
            this.Controls.Add(this.Button_Save);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.IDC_State);
            this.Controls.Add(this.IDC_Image);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Fprinter";
            this.Text = "采集软件";
            this.Load += new System.EventHandler(this.Fprinter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IDC_Image)).EndInit();
            this.IDC_State.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBright)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button IDC_Device;
        private System.Windows.Forms.PictureBox IDC_Image;
        private System.Windows.Forms.GroupBox IDC_State;
        private System.Windows.Forms.Button IDB_SetBufferEmpty;
        private System.Windows.Forms.Button IDCANCEL;
        private System.Windows.Forms.Button IDC_BTN_LIVESCAN_Close;
        private System.Windows.Forms.Button IDC_Stop;
        private System.Windows.Forms.Button IDC_Capture;
        private System.Windows.Forms.Timer timerCapture;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button IDC_SetContrast;
        private System.Windows.Forms.Button IDC_SetBright;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button IDC_EndCapture;
        private System.Windows.Forms.Button IDC_Savebmp;
        private System.Windows.Forms.Button IDC_BTN_GetFPRawData;
        private System.Windows.Forms.Button IDC_BTN_BeginCapture;
        private System.Windows.Forms.NumericUpDown numBright;
        private System.Windows.Forms.NumericUpDown numContrast;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button IDC_Version;
        private System.Windows.Forms.Button IDC_Channel;
        private System.Windows.Forms.Button IDC_Wsq_Save;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Button_Save;
        private System.Windows.Forms.Button Button_Split;
        private System.Windows.Forms.TextBox Text_Status;
    }
}

