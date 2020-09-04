namespace ClassManager.BioMonitor
{
    partial class RTEventsMain
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
            this.components = new System.ComponentModel.Container();
            this.lbRTShow = new System.Windows.Forms.ListBox();
            this.rtTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtMachine2Name = new System.Windows.Forms.TextBox();
            this.txtMachine1Name = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblState2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPort2 = new System.Windows.Forms.TextBox();
            this.txtIP2 = new System.Windows.Forms.TextBox();
            this.btnConnect2 = new System.Windows.Forms.Button();
            this.chkTimer = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnRsConnect = new System.Windows.Forms.Button();
            this.txtMachineSN = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtMachineSN2 = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnUSBConnect = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnEnable = new System.Windows.Forms.Button();
            this.btnDisableUser = new System.Windows.Forms.Button();
            this.btnSimAttendence = new System.Windows.Forms.Button();
            this.txtSimEnrollment = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.DGBiom = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFetch = new System.Windows.Forms.Button();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.Log = new System.Windows.Forms.TabPage();
            this.niBioMon = new System.Windows.Forms.NotifyIcon(this.components);
            this.lblConstr = new System.Windows.Forms.Label();
            this.cmdChangeDB = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.AbsentLectureTimer = new System.Windows.Forms.Timer(this.components);
            this.connectionCheckTImer = new System.Windows.Forms.Timer(this.components);
            this.btnStopAutoCommect = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.btnClearIp = new System.Windows.Forms.Button();
            this.cmbfetchDevice = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGBiom)).BeginInit();
            this.Log.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbRTShow
            // 
            this.lbRTShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRTShow.FormattingEnabled = true;
            this.lbRTShow.Location = new System.Drawing.Point(3, 3);
            this.lbRTShow.Name = "lbRTShow";
            this.lbRTShow.Size = new System.Drawing.Size(435, 304);
            this.lbRTShow.TabIndex = 4;
            // 
            // rtTimer
            // 
            this.rtTimer.Interval = 1000;
            this.rtTimer.Tick += new System.EventHandler(this.rtTimer_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Location = new System.Drawing.Point(3, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(466, 362);
            this.groupBox2.TabIndex = 66;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Communication with Device";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.Log);
            this.tabControl1.Location = new System.Drawing.Point(6, 20);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(449, 336);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.txtMachine2Name);
            this.tabPage1.Controls.Add(this.txtMachine1Name);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.lblState2);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.lblState);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.txtPort2);
            this.tabPage1.Controls.Add(this.txtIP2);
            this.tabPage1.Controls.Add(this.btnConnect2);
            this.tabPage1.Controls.Add(this.chkTimer);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtPort);
            this.tabPage1.Controls.Add(this.txtIP);
            this.tabPage1.Controls.Add(this.btnConnect);
            this.tabPage1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage1.ForeColor = System.Drawing.Color.DarkBlue;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(441, 310);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "TCP/IP";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtMachine2Name
            // 
            this.txtMachine2Name.Location = new System.Drawing.Point(136, 167);
            this.txtMachine2Name.Name = "txtMachine2Name";
            this.txtMachine2Name.Size = new System.Drawing.Size(246, 20);
            this.txtMachine2Name.TabIndex = 23;
            // 
            // txtMachine1Name
            // 
            this.txtMachine1Name.Location = new System.Drawing.Point(136, 26);
            this.txtMachine1Name.Name = "txtMachine1Name";
            this.txtMachine1Name.Size = new System.Drawing.Size(246, 20);
            this.txtMachine1Name.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(41, 174);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Machine Name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(41, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Machine Name";
            // 
            // lblState2
            // 
            this.lblState2.AutoSize = true;
            this.lblState2.ForeColor = System.Drawing.Color.Crimson;
            this.lblState2.Location = new System.Drawing.Point(41, 235);
            this.lblState2.Name = "lblState2";
            this.lblState2.Size = new System.Drawing.Size(138, 13);
            this.lblState2.TabIndex = 19;
            this.lblState2.Text = "Current State:Disconnected";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(41, 202);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "IP";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.ForeColor = System.Drawing.Color.Crimson;
            this.lblState.Location = new System.Drawing.Point(41, 104);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(138, 13);
            this.lblState.TabIndex = 2;
            this.lblState.Text = "Current State:Disconnected";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(367, 205);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(328, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Timer";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(205, 206);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Port";
            // 
            // txtPort2
            // 
            this.txtPort2.Location = new System.Drawing.Point(248, 202);
            this.txtPort2.Name = "txtPort2";
            this.txtPort2.Size = new System.Drawing.Size(53, 20);
            this.txtPort2.TabIndex = 14;
            this.txtPort2.Text = "4370";
            // 
            // txtIP2
            // 
            this.txtIP2.Location = new System.Drawing.Point(72, 202);
            this.txtIP2.Name = "txtIP2";
            this.txtIP2.Size = new System.Drawing.Size(95, 20);
            this.txtIP2.TabIndex = 13;
            // 
            // btnConnect2
            // 
            this.btnConnect2.Location = new System.Drawing.Point(304, 230);
            this.btnConnect2.Name = "btnConnect2";
            this.btnConnect2.Size = new System.Drawing.Size(78, 23);
            this.btnConnect2.TabIndex = 12;
            this.btnConnect2.Text = "Connect";
            this.btnConnect2.UseVisualStyleBackColor = true;
            this.btnConnect2.Click += new System.EventHandler(this.btnConnect2_Click);
            // 
            // chkTimer
            // 
            this.chkTimer.AutoSize = true;
            this.chkTimer.Location = new System.Drawing.Point(367, 66);
            this.chkTimer.Name = "chkTimer";
            this.chkTimer.Size = new System.Drawing.Size(15, 14);
            this.chkTimer.TabIndex = 11;
            this.chkTimer.UseVisualStyleBackColor = true;
            this.chkTimer.CheckedChanged += new System.EventHandler(this.chkTimer_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(328, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Timer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "IP";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(248, 63);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(53, 20);
            this.txtPort.TabIndex = 7;
            this.txtPort.Text = "4370";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(72, 63);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(95, 20);
            this.txtIP.TabIndex = 6;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(304, 99);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(78, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.btnRsConnect);
            this.tabPage2.Controls.Add(this.txtMachineSN);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.cbBaudRate);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.cbPort);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.ForeColor = System.Drawing.Color.DarkBlue;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(441, 310);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "RS232/485";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnRsConnect
            // 
            this.btnRsConnect.Location = new System.Drawing.Point(183, 43);
            this.btnRsConnect.Name = "btnRsConnect";
            this.btnRsConnect.Size = new System.Drawing.Size(75, 23);
            this.btnRsConnect.TabIndex = 11;
            this.btnRsConnect.Text = "Connect";
            this.btnRsConnect.UseVisualStyleBackColor = true;
            this.btnRsConnect.Click += new System.EventHandler(this.btnRsConnect_Click);
            // 
            // txtMachineSN
            // 
            this.txtMachineSN.Location = new System.Drawing.Point(356, 10);
            this.txtMachineSN.Name = "txtMachineSN";
            this.txtMachineSN.Size = new System.Drawing.Size(56, 20);
            this.txtMachineSN.TabIndex = 10;
            this.txtMachineSN.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(284, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "MachineSN";
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "115200"});
            this.cbBaudRate.Location = new System.Drawing.Point(206, 10);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(65, 21);
            this.cbBaudRate.TabIndex = 6;
            this.cbBaudRate.Text = "115200";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(140, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "BaudRate";
            // 
            // cbPort
            // 
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9"});
            this.cbPort.Location = new System.Drawing.Point(71, 10);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(56, 21);
            this.cbPort.TabIndex = 5;
            this.cbPort.Text = "COM1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Port";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage3.Controls.Add(this.txtMachineSN2);
            this.tabPage3.Controls.Add(this.label29);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.btnUSBConnect);
            this.tabPage3.ForeColor = System.Drawing.Color.DarkBlue;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(441, 310);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "USBClient";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtMachineSN2
            // 
            this.txtMachineSN2.BackColor = System.Drawing.Color.AliceBlue;
            this.txtMachineSN2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMachineSN2.Location = new System.Drawing.Point(280, 16);
            this.txtMachineSN2.Name = "txtMachineSN2";
            this.txtMachineSN2.Size = new System.Drawing.Size(27, 20);
            this.txtMachineSN2.TabIndex = 9;
            this.txtMachineSN2.Text = "1";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(219, 21);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(63, 13);
            this.label29.TabIndex = 10;
            this.label29.Text = "MachineSN";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Crimson;
            this.label18.Location = new System.Drawing.Point(106, 21);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(87, 13);
            this.label18.TabIndex = 8;
            this.label18.Text = "Virtual USBClient";
            // 
            // btnUSBConnect
            // 
            this.btnUSBConnect.Location = new System.Drawing.Point(169, 43);
            this.btnUSBConnect.Name = "btnUSBConnect";
            this.btnUSBConnect.Size = new System.Drawing.Size(75, 23);
            this.btnUSBConnect.TabIndex = 0;
            this.btnUSBConnect.Text = "Connect";
            this.btnUSBConnect.UseVisualStyleBackColor = true;
            this.btnUSBConnect.Click += new System.EventHandler(this.btnUSBConnect_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnEnable);
            this.tabPage4.Controls.Add(this.btnDisableUser);
            this.tabPage4.Controls.Add(this.btnSimAttendence);
            this.tabPage4.Controls.Add(this.txtSimEnrollment);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(441, 310);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Simulate";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnEnable
            // 
            this.btnEnable.Location = new System.Drawing.Point(342, 27);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(75, 23);
            this.btnEnable.TabIndex = 16;
            this.btnEnable.Text = "Enable";
            this.btnEnable.UseVisualStyleBackColor = true;
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // btnDisableUser
            // 
            this.btnDisableUser.Location = new System.Drawing.Point(251, 27);
            this.btnDisableUser.Name = "btnDisableUser";
            this.btnDisableUser.Size = new System.Drawing.Size(75, 23);
            this.btnDisableUser.TabIndex = 15;
            this.btnDisableUser.Text = "Disable";
            this.btnDisableUser.UseVisualStyleBackColor = true;
            this.btnDisableUser.Click += new System.EventHandler(this.btnDisableUser_Click);
            // 
            // btnSimAttendence
            // 
            this.btnSimAttendence.Location = new System.Drawing.Point(154, 27);
            this.btnSimAttendence.Name = "btnSimAttendence";
            this.btnSimAttendence.Size = new System.Drawing.Size(75, 23);
            this.btnSimAttendence.TabIndex = 14;
            this.btnSimAttendence.Text = "Simulate";
            this.btnSimAttendence.UseVisualStyleBackColor = true;
            this.btnSimAttendence.Click += new System.EventHandler(this.btnSimAttendence_Click);
            // 
            // txtSimEnrollment
            // 
            this.txtSimEnrollment.Location = new System.Drawing.Point(21, 27);
            this.txtSimEnrollment.Name = "txtSimEnrollment";
            this.txtSimEnrollment.Size = new System.Drawing.Size(100, 20);
            this.txtSimEnrollment.TabIndex = 13;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label15);
            this.tabPage5.Controls.Add(this.cmbfetchDevice);
            this.tabPage5.Controls.Add(this.btnSave);
            this.tabPage5.Controls.Add(this.DGBiom);
            this.tabPage5.Controls.Add(this.label8);
            this.tabPage5.Controls.Add(this.label4);
            this.tabPage5.Controls.Add(this.btnFetch);
            this.tabPage5.Controls.Add(this.dtTo);
            this.tabPage5.Controls.Add(this.dtFrom);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(441, 310);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Fetch Data";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(360, 287);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // DGBiom
            // 
            this.DGBiom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGBiom.Location = new System.Drawing.Point(5, 76);
            this.DGBiom.Name = "DGBiom";
            this.DGBiom.Size = new System.Drawing.Size(430, 209);
            this.DGBiom.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(244, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "To Date :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "From Date :";
            // 
            // btnFetch
            // 
            this.btnFetch.Location = new System.Drawing.Point(305, 47);
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.Size = new System.Drawing.Size(75, 23);
            this.btnFetch.TabIndex = 12;
            this.btnFetch.Text = "Fetch";
            this.btnFetch.UseVisualStyleBackColor = true;
            this.btnFetch.Click += new System.EventHandler(this.btnFetch_Click);
            // 
            // dtTo
            // 
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(305, 16);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(103, 20);
            this.dtTo.TabIndex = 1;
            this.dtTo.Value = new System.DateTime(2017, 11, 30, 0, 0, 0, 0);
            // 
            // dtFrom
            // 
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(85, 16);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(104, 20);
            this.dtFrom.TabIndex = 0;
            // 
            // Log
            // 
            this.Log.Controls.Add(this.lbRTShow);
            this.Log.Location = new System.Drawing.Point(4, 22);
            this.Log.Name = "Log";
            this.Log.Padding = new System.Windows.Forms.Padding(3);
            this.Log.Size = new System.Drawing.Size(441, 310);
            this.Log.TabIndex = 5;
            this.Log.Text = "Log";
            this.Log.UseVisualStyleBackColor = true;
            // 
            // niBioMon
            // 
            this.niBioMon.Text = "notifyIcon1";
            this.niBioMon.Visible = true;
            this.niBioMon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.niBioMon_MouseDoubleClick);
            // 
            // lblConstr
            // 
            this.lblConstr.AutoSize = true;
            this.lblConstr.Location = new System.Drawing.Point(15, 9);
            this.lblConstr.Name = "lblConstr";
            this.lblConstr.Size = new System.Drawing.Size(0, 13);
            this.lblConstr.TabIndex = 10;
            // 
            // cmdChangeDB
            // 
            this.cmdChangeDB.Location = new System.Drawing.Point(303, 9);
            this.cmdChangeDB.Name = "cmdChangeDB";
            this.cmdChangeDB.Size = new System.Drawing.Size(75, 23);
            this.cmdChangeDB.TabIndex = 67;
            this.cmdChangeDB.Text = "Config";
            this.cmdChangeDB.UseVisualStyleBackColor = true;
            this.cmdChangeDB.Click += new System.EventHandler(this.cmdChangeDB_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Location = new System.Drawing.Point(394, 9);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(75, 23);
            this.btnMinimize.TabIndex = 68;
            this.btnMinimize.Text = "Minimize";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // AbsentLectureTimer
            // 
            this.AbsentLectureTimer.Interval = 1800000;
            this.AbsentLectureTimer.Tick += new System.EventHandler(this.AbsentLectureTimer_Tick);
            // 
            // connectionCheckTImer
            // 
            this.connectionCheckTImer.Tick += new System.EventHandler(this.connectionCheckTImer_Tick);
            // 
            // btnStopAutoCommect
            // 
            this.btnStopAutoCommect.Location = new System.Drawing.Point(391, 440);
            this.btnStopAutoCommect.Name = "btnStopAutoCommect";
            this.btnStopAutoCommect.Size = new System.Drawing.Size(78, 23);
            this.btnStopAutoCommect.TabIndex = 24;
            this.btnStopAutoCommect.Text = "Stop Autoconnect";
            this.btnStopAutoCommect.UseVisualStyleBackColor = true;
            this.btnStopAutoCommect.Click += new System.EventHandler(this.btnStopAutoCommect_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(300, 445);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 13);
            this.label14.TabIndex = 69;
            this.label14.Text = "Autoconnect";
            // 
            // btnClearIp
            // 
            this.btnClearIp.Location = new System.Drawing.Point(18, 445);
            this.btnClearIp.Name = "btnClearIp";
            this.btnClearIp.Size = new System.Drawing.Size(78, 23);
            this.btnClearIp.TabIndex = 24;
            this.btnClearIp.Text = "Clear IPs";
            this.btnClearIp.UseVisualStyleBackColor = true;
            this.btnClearIp.Click += new System.EventHandler(this.btnClearIp_Click);
            // 
            // cmbfetchDevice
            // 
            this.cmbfetchDevice.FormattingEnabled = true;
            this.cmbfetchDevice.Location = new System.Drawing.Point(85, 49);
            this.cmbfetchDevice.Name = "cmbfetchDevice";
            this.cmbfetchDevice.Size = new System.Drawing.Size(167, 21);
            this.cmbfetchDevice.TabIndex = 17;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 49);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 13);
            this.label15.TabIndex = 18;
            this.label15.Text = "Device :";
            // 
            // RTEventsMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(481, 531);
            this.Controls.Add(this.btnClearIp);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnStopAutoCommect);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.cmdChangeDB);
            this.Controls.Add(this.lblConstr);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RTEventsMain";
            this.Text = "RTEvents";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RTEventsMain_FormClosing);
            this.Load += new System.EventHandler(this.RTEventsMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RTEventsMain_KeyDown);
            this.Resize += new System.EventHandler(this.RTEventsMain_Resize);
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGBiom)).EndInit();
            this.Log.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer rtTimer;
        private System.Windows.Forms.ListBox lbRTShow;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.NotifyIcon niBioMon;
        private System.Windows.Forms.Label lblConstr;
        private System.Windows.Forms.Button cmdChangeDB;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnRsConnect;
        private System.Windows.Forms.TextBox txtMachineSN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtMachineSN2;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnUSBConnect;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnSimAttendence;
        private System.Windows.Forms.TextBox txtSimEnrollment;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.CheckBox chkTimer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFetch;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView DGBiom;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabPage Log;
        private System.Windows.Forms.Timer AbsentLectureTimer;
        private System.Windows.Forms.Button btnEnable;
        private System.Windows.Forms.Button btnDisableUser;
        private System.Windows.Forms.Label lblState2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPort2;
        private System.Windows.Forms.TextBox txtIP2;
        private System.Windows.Forms.Button btnConnect2;
        private System.Windows.Forms.TextBox txtMachine2Name;
        private System.Windows.Forms.TextBox txtMachine1Name;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Timer connectionCheckTImer;
        private System.Windows.Forms.Button btnStopAutoCommect;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnClearIp;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbfetchDevice;
    }
}

