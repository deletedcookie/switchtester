namespace switchTester
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ComPort_ComboBox = new System.Windows.Forms.ComboBox();
            this.BaudRate_ComboBox = new System.Windows.Forms.ComboBox();
            this.ComPort_Button = new System.Windows.Forms.Button();
            this.GetForce_Button = new System.Windows.Forms.Button();
            this.SaveCSV_Button = new System.Windows.Forms.Button();
            this.Status_TextBox = new System.Windows.Forms.TextBox();
            this.CSV_TextBox = new System.Windows.Forms.TextBox();
            this.SampleDownStroke_Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CommLink_SerialPort = new System.IO.Ports.SerialPort(this.components);
            this.RX_TextBox = new System.Windows.Forms.TextBox();
            this.ComPort2_Button = new System.Windows.Forms.Button();
            this.BaudRate2_ComboBox = new System.Windows.Forms.ComboBox();
            this.ComPort2_ComboBox = new System.Windows.Forms.ComboBox();
            this.MoveUp_Button = new System.Windows.Forms.Button();
            this.MoveLeft_Button = new System.Windows.Forms.Button();
            this.MoveDown_Button = new System.Windows.Forms.Button();
            this.MoveRight_Button = new System.Windows.Forms.Button();
            this.StepAmount_ComboBox = new System.Windows.Forms.ComboBox();
            this.CommLink2_SerialPort = new System.IO.Ports.SerialPort(this.components);
            this.MoveHome_Button = new System.Windows.Forms.Button();
            this.TxSend2_Textbox = new System.Windows.Forms.TextBox();
            this.Tx2_TextBox = new System.Windows.Forms.TextBox();
            this.Rx2_TextBox = new System.Windows.Forms.TextBox();
            this.Start_Button = new System.Windows.Forms.Button();
            this.ZOffset_ComboBox = new System.Windows.Forms.ComboBox();
            this.XOffset_ComboBox = new System.Windows.Forms.ComboBox();
            this.Travel_ComboBox = new System.Windows.Forms.ComboBox();
            this.StepSize_ComboBox = new System.Windows.Forms.ComboBox();
            this.Tare_Button = new System.Windows.Forms.Button();
            this.Samples_ComboBox = new System.Windows.Forms.ComboBox();
            this.Average_Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SampleUpStroke_Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.GetPos_Button = new System.Windows.Forms.Button();
            this.Profile_ComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ProfileSave_Button = new System.Windows.Forms.Button();
            this.CopyCSV_Button = new System.Windows.Forms.Button();
            this.GetComPorts_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SampleDownStroke_Chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Average_Chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SampleUpStroke_Chart)).BeginInit();
            this.SuspendLayout();
            // 
            // ComPort_ComboBox
            // 
            this.ComPort_ComboBox.FormattingEnabled = true;
            this.ComPort_ComboBox.Location = new System.Drawing.Point(12, 24);
            this.ComPort_ComboBox.Name = "ComPort_ComboBox";
            this.ComPort_ComboBox.Size = new System.Drawing.Size(121, 21);
            this.ComPort_ComboBox.TabIndex = 1;
            this.ComPort_ComboBox.Text = "Select COM Port";
            // 
            // BaudRate_ComboBox
            // 
            this.BaudRate_ComboBox.FormattingEnabled = true;
            this.BaudRate_ComboBox.Items.AddRange(new object[] {
            "9600"});
            this.BaudRate_ComboBox.Location = new System.Drawing.Point(12, 56);
            this.BaudRate_ComboBox.Name = "BaudRate_ComboBox";
            this.BaudRate_ComboBox.Size = new System.Drawing.Size(121, 21);
            this.BaudRate_ComboBox.TabIndex = 2;
            this.BaudRate_ComboBox.Text = "115200";
            // 
            // ComPort_Button
            // 
            this.ComPort_Button.Location = new System.Drawing.Point(12, 83);
            this.ComPort_Button.Name = "ComPort_Button";
            this.ComPort_Button.Size = new System.Drawing.Size(121, 33);
            this.ComPort_Button.TabIndex = 3;
            this.ComPort_Button.Text = "Open COM Port";
            this.ComPort_Button.UseVisualStyleBackColor = true;
            this.ComPort_Button.Click += new System.EventHandler(this.ComPort_Button_Click);
            // 
            // GetForce_Button
            // 
            this.GetForce_Button.Location = new System.Drawing.Point(494, 72);
            this.GetForce_Button.Name = "GetForce_Button";
            this.GetForce_Button.Size = new System.Drawing.Size(110, 33);
            this.GetForce_Button.TabIndex = 6;
            this.GetForce_Button.Text = "Get Force";
            this.GetForce_Button.UseVisualStyleBackColor = true;
            this.GetForce_Button.Click += new System.EventHandler(this.GetForce_Button_Click);
            // 
            // SaveCSV_Button
            // 
            this.SaveCSV_Button.Location = new System.Drawing.Point(982, 72);
            this.SaveCSV_Button.Name = "SaveCSV_Button";
            this.SaveCSV_Button.Size = new System.Drawing.Size(110, 33);
            this.SaveCSV_Button.TabIndex = 7;
            this.SaveCSV_Button.Text = "Save";
            this.SaveCSV_Button.UseVisualStyleBackColor = true;
            this.SaveCSV_Button.Click += new System.EventHandler(this.SaveCSV_Button_Click);
            // 
            // Status_TextBox
            // 
            this.Status_TextBox.Location = new System.Drawing.Point(208, 12);
            this.Status_TextBox.Multiline = true;
            this.Status_TextBox.Name = "Status_TextBox";
            this.Status_TextBox.ReadOnly = true;
            this.Status_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Status_TextBox.Size = new System.Drawing.Size(111, 104);
            this.Status_TextBox.TabIndex = 9;
            // 
            // CSV_TextBox
            // 
            this.CSV_TextBox.Location = new System.Drawing.Point(670, 17);
            this.CSV_TextBox.Multiline = true;
            this.CSV_TextBox.Name = "CSV_TextBox";
            this.CSV_TextBox.ReadOnly = true;
            this.CSV_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CSV_TextBox.Size = new System.Drawing.Size(296, 104);
            this.CSV_TextBox.TabIndex = 10;
            // 
            // SampleDownStroke_Chart
            // 
            chartArea1.Name = "ChartArea1";
            this.SampleDownStroke_Chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.SampleDownStroke_Chart.Legends.Add(legend1);
            this.SampleDownStroke_Chart.Location = new System.Drawing.Point(1250, 489);
            this.SampleDownStroke_Chart.Name = "SampleDownStroke_Chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.SampleDownStroke_Chart.Series.Add(series1);
            this.SampleDownStroke_Chart.Size = new System.Drawing.Size(557, 207);
            this.SampleDownStroke_Chart.TabIndex = 11;
            this.SampleDownStroke_Chart.Text = "CSV_Chart";
            // 
            // CommLink_SerialPort
            // 
            this.CommLink_SerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.CommLink_SerialPort_DataReceived);
            // 
            // RX_TextBox
            // 
            this.RX_TextBox.Location = new System.Drawing.Point(344, 12);
            this.RX_TextBox.Multiline = true;
            this.RX_TextBox.Name = "RX_TextBox";
            this.RX_TextBox.ReadOnly = true;
            this.RX_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RX_TextBox.Size = new System.Drawing.Size(111, 104);
            this.RX_TextBox.TabIndex = 12;
            // 
            // ComPort2_Button
            // 
            this.ComPort2_Button.Location = new System.Drawing.Point(1250, 81);
            this.ComPort2_Button.Name = "ComPort2_Button";
            this.ComPort2_Button.Size = new System.Drawing.Size(121, 33);
            this.ComPort2_Button.TabIndex = 15;
            this.ComPort2_Button.Text = "Open COM Port";
            this.ComPort2_Button.UseVisualStyleBackColor = true;
            this.ComPort2_Button.Click += new System.EventHandler(this.ComPort2_Button_Click);
            // 
            // BaudRate2_ComboBox
            // 
            this.BaudRate2_ComboBox.FormattingEnabled = true;
            this.BaudRate2_ComboBox.Items.AddRange(new object[] {
            "9600"});
            this.BaudRate2_ComboBox.Location = new System.Drawing.Point(1250, 54);
            this.BaudRate2_ComboBox.Name = "BaudRate2_ComboBox";
            this.BaudRate2_ComboBox.Size = new System.Drawing.Size(121, 21);
            this.BaudRate2_ComboBox.TabIndex = 14;
            this.BaudRate2_ComboBox.Text = "115200";
            // 
            // ComPort2_ComboBox
            // 
            this.ComPort2_ComboBox.FormattingEnabled = true;
            this.ComPort2_ComboBox.Location = new System.Drawing.Point(1250, 22);
            this.ComPort2_ComboBox.Name = "ComPort2_ComboBox";
            this.ComPort2_ComboBox.Size = new System.Drawing.Size(121, 21);
            this.ComPort2_ComboBox.TabIndex = 13;
            this.ComPort2_ComboBox.Text = "Select COM Port";
            // 
            // MoveUp_Button
            // 
            this.MoveUp_Button.Enabled = false;
            this.MoveUp_Button.Location = new System.Drawing.Point(1490, 146);
            this.MoveUp_Button.Name = "MoveUp_Button";
            this.MoveUp_Button.Size = new System.Drawing.Size(47, 41);
            this.MoveUp_Button.TabIndex = 16;
            this.MoveUp_Button.Text = "Up";
            this.MoveUp_Button.UseVisualStyleBackColor = true;
            this.MoveUp_Button.Click += new System.EventHandler(this.MoveUp_Button_Click);
            // 
            // MoveLeft_Button
            // 
            this.MoveLeft_Button.Enabled = false;
            this.MoveLeft_Button.Location = new System.Drawing.Point(1424, 199);
            this.MoveLeft_Button.Name = "MoveLeft_Button";
            this.MoveLeft_Button.Size = new System.Drawing.Size(47, 41);
            this.MoveLeft_Button.TabIndex = 17;
            this.MoveLeft_Button.Text = "Left";
            this.MoveLeft_Button.UseVisualStyleBackColor = true;
            this.MoveLeft_Button.Click += new System.EventHandler(this.MoveLeft_Button_Click);
            // 
            // MoveDown_Button
            // 
            this.MoveDown_Button.Enabled = false;
            this.MoveDown_Button.Location = new System.Drawing.Point(1490, 247);
            this.MoveDown_Button.Name = "MoveDown_Button";
            this.MoveDown_Button.Size = new System.Drawing.Size(47, 41);
            this.MoveDown_Button.TabIndex = 18;
            this.MoveDown_Button.Text = "Down";
            this.MoveDown_Button.UseVisualStyleBackColor = true;
            this.MoveDown_Button.Click += new System.EventHandler(this.MoveDown_Button_Click);
            // 
            // MoveRight_Button
            // 
            this.MoveRight_Button.Enabled = false;
            this.MoveRight_Button.Location = new System.Drawing.Point(1558, 199);
            this.MoveRight_Button.Name = "MoveRight_Button";
            this.MoveRight_Button.Size = new System.Drawing.Size(47, 41);
            this.MoveRight_Button.TabIndex = 19;
            this.MoveRight_Button.Text = "Right";
            this.MoveRight_Button.UseVisualStyleBackColor = true;
            this.MoveRight_Button.Click += new System.EventHandler(this.MoveRight_Button_Click);
            // 
            // StepAmount_ComboBox
            // 
            this.StepAmount_ComboBox.FormattingEnabled = true;
            this.StepAmount_ComboBox.Items.AddRange(new object[] {
            "0.01",
            "0.1",
            "0.5",
            "1",
            "5",
            "10",
            "50"});
            this.StepAmount_ComboBox.Location = new System.Drawing.Point(1490, 210);
            this.StepAmount_ComboBox.Name = "StepAmount_ComboBox";
            this.StepAmount_ComboBox.Size = new System.Drawing.Size(47, 21);
            this.StepAmount_ComboBox.TabIndex = 20;
            this.StepAmount_ComboBox.Text = "10";
            // 
            // CommLink2_SerialPort
            // 
            this.CommLink2_SerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.CommLink2_SerialPort_DataReceived);
            // 
            // MoveHome_Button
            // 
            this.MoveHome_Button.Enabled = false;
            this.MoveHome_Button.Location = new System.Drawing.Point(1558, 143);
            this.MoveHome_Button.Name = "MoveHome_Button";
            this.MoveHome_Button.Size = new System.Drawing.Size(54, 44);
            this.MoveHome_Button.TabIndex = 21;
            this.MoveHome_Button.Text = "Home";
            this.MoveHome_Button.UseVisualStyleBackColor = true;
            this.MoveHome_Button.Click += new System.EventHandler(this.MoveHome_Button_Click);
            // 
            // TxSend2_Textbox
            // 
            this.TxSend2_Textbox.Location = new System.Drawing.Point(1683, 394);
            this.TxSend2_Textbox.Name = "TxSend2_Textbox";
            this.TxSend2_Textbox.Size = new System.Drawing.Size(139, 20);
            this.TxSend2_Textbox.TabIndex = 22;
            this.TxSend2_Textbox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxSend2_Textbox_KeyUp);
            // 
            // Tx2_TextBox
            // 
            this.Tx2_TextBox.Location = new System.Drawing.Point(1683, 17);
            this.Tx2_TextBox.Multiline = true;
            this.Tx2_TextBox.Name = "Tx2_TextBox";
            this.Tx2_TextBox.ReadOnly = true;
            this.Tx2_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Tx2_TextBox.Size = new System.Drawing.Size(139, 363);
            this.Tx2_TextBox.TabIndex = 23;
            // 
            // Rx2_TextBox
            // 
            this.Rx2_TextBox.Location = new System.Drawing.Point(1406, 17);
            this.Rx2_TextBox.Multiline = true;
            this.Rx2_TextBox.Name = "Rx2_TextBox";
            this.Rx2_TextBox.ReadOnly = true;
            this.Rx2_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Rx2_TextBox.Size = new System.Drawing.Size(248, 97);
            this.Rx2_TextBox.TabIndex = 24;
            // 
            // Start_Button
            // 
            this.Start_Button.Location = new System.Drawing.Point(1406, 367);
            this.Start_Button.Name = "Start_Button";
            this.Start_Button.Size = new System.Drawing.Size(220, 82);
            this.Start_Button.TabIndex = 25;
            this.Start_Button.Text = "Start";
            this.Start_Button.UseVisualStyleBackColor = true;
            this.Start_Button.Click += new System.EventHandler(this.Start_Button_Click);
            // 
            // ZOffset_ComboBox
            // 
            this.ZOffset_ComboBox.FormattingEnabled = true;
            this.ZOffset_ComboBox.Location = new System.Drawing.Point(1250, 162);
            this.ZOffset_ComboBox.Name = "ZOffset_ComboBox";
            this.ZOffset_ComboBox.Size = new System.Drawing.Size(79, 21);
            this.ZOffset_ComboBox.TabIndex = 26;
            this.ZOffset_ComboBox.Text = "15.2";
            // 
            // XOffset_ComboBox
            // 
            this.XOffset_ComboBox.FormattingEnabled = true;
            this.XOffset_ComboBox.Location = new System.Drawing.Point(1250, 279);
            this.XOffset_ComboBox.Name = "XOffset_ComboBox";
            this.XOffset_ComboBox.Size = new System.Drawing.Size(79, 21);
            this.XOffset_ComboBox.TabIndex = 27;
            this.XOffset_ComboBox.Text = "41.5";
            // 
            // Travel_ComboBox
            // 
            this.Travel_ComboBox.FormattingEnabled = true;
            this.Travel_ComboBox.Items.AddRange(new object[] {
            "2",
            "2.1",
            "2.2",
            "2.3",
            "2.4",
            "2.5",
            "2.6",
            "2.7",
            "2.8",
            "2.9",
            "3",
            "3.1",
            "3.2",
            "3.3",
            "3.4",
            "3.5",
            "3.6",
            "3.7",
            "3.8",
            "3.9",
            "4",
            "4.1",
            "4.2",
            "4.3",
            "4.4",
            "4.5",
            "4.6",
            "4.7",
            "4.8",
            "4.9",
            "5"});
            this.Travel_ComboBox.Location = new System.Drawing.Point(1250, 219);
            this.Travel_ComboBox.Name = "Travel_ComboBox";
            this.Travel_ComboBox.Size = new System.Drawing.Size(79, 21);
            this.Travel_ComboBox.TabIndex = 28;
            this.Travel_ComboBox.Text = "3";
            // 
            // StepSize_ComboBox
            // 
            this.StepSize_ComboBox.FormattingEnabled = true;
            this.StepSize_ComboBox.Items.AddRange(new object[] {
            ".01",
            ".02",
            "0.05",
            "0.1"});
            this.StepSize_ComboBox.Location = new System.Drawing.Point(1250, 336);
            this.StepSize_ComboBox.Name = "StepSize_ComboBox";
            this.StepSize_ComboBox.Size = new System.Drawing.Size(79, 21);
            this.StepSize_ComboBox.TabIndex = 29;
            this.StepSize_ComboBox.Text = "0.1";
            // 
            // Tare_Button
            // 
            this.Tare_Button.Location = new System.Drawing.Point(494, 22);
            this.Tare_Button.Name = "Tare_Button";
            this.Tare_Button.Size = new System.Drawing.Size(110, 33);
            this.Tare_Button.TabIndex = 30;
            this.Tare_Button.Text = "Tare";
            this.Tare_Button.UseVisualStyleBackColor = true;
            this.Tare_Button.Click += new System.EventHandler(this.Tare_Button_Click);
            // 
            // Samples_ComboBox
            // 
            this.Samples_ComboBox.FormattingEnabled = true;
            this.Samples_ComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "5",
            "10"});
            this.Samples_ComboBox.Location = new System.Drawing.Point(1250, 399);
            this.Samples_ComboBox.Name = "Samples_ComboBox";
            this.Samples_ComboBox.Size = new System.Drawing.Size(79, 21);
            this.Samples_ComboBox.TabIndex = 31;
            this.Samples_ComboBox.Text = "1";
            // 
            // Average_Chart
            // 
            chartArea2.Name = "ChartArea1";
            this.Average_Chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.Average_Chart.Legends.Add(legend2);
            this.Average_Chart.Location = new System.Drawing.Point(12, 146);
            this.Average_Chart.Name = "Average_Chart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.Average_Chart.Series.Add(series2);
            this.Average_Chart.Size = new System.Drawing.Size(1212, 808);
            this.Average_Chart.TabIndex = 32;
            this.Average_Chart.Text = "chart1";
            // 
            // SampleUpStroke_Chart
            // 
            chartArea3.Name = "ChartArea1";
            this.SampleUpStroke_Chart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.SampleUpStroke_Chart.Legends.Add(legend3);
            this.SampleUpStroke_Chart.Location = new System.Drawing.Point(1250, 712);
            this.SampleUpStroke_Chart.Name = "SampleUpStroke_Chart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.SampleUpStroke_Chart.Series.Add(series3);
            this.SampleUpStroke_Chart.Size = new System.Drawing.Size(557, 207);
            this.SampleUpStroke_Chart.TabIndex = 33;
            this.SampleUpStroke_Chart.Text = "CSV_Chart";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1247, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Z Offset";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1247, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "X Offset";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1247, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Travel";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1247, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Step Size";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1247, 383);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Samples";
            // 
            // GetPos_Button
            // 
            this.GetPos_Button.Enabled = false;
            this.GetPos_Button.Location = new System.Drawing.Point(1417, 141);
            this.GetPos_Button.Name = "GetPos_Button";
            this.GetPos_Button.Size = new System.Drawing.Size(54, 44);
            this.GetPos_Button.TabIndex = 40;
            this.GetPos_Button.Text = "Get Pos";
            this.GetPos_Button.UseVisualStyleBackColor = true;
            this.GetPos_Button.Click += new System.EventHandler(this.GetPos_Button_Click);
            // 
            // Profile_ComboBox
            // 
            this.Profile_ComboBox.FormattingEnabled = true;
            this.Profile_ComboBox.Location = new System.Drawing.Point(1406, 336);
            this.Profile_ComboBox.Name = "Profile_ComboBox";
            this.Profile_ComboBox.Size = new System.Drawing.Size(102, 21);
            this.Profile_ComboBox.TabIndex = 41;
            this.Profile_ComboBox.Text = "Select Profile";
            this.Profile_ComboBox.SelectedIndexChanged += new System.EventHandler(this.Profile_ComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1403, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Profile";
            // 
            // ProfileSave_Button
            // 
            this.ProfileSave_Button.Location = new System.Drawing.Point(1524, 328);
            this.ProfileSave_Button.Name = "ProfileSave_Button";
            this.ProfileSave_Button.Size = new System.Drawing.Size(102, 33);
            this.ProfileSave_Button.TabIndex = 43;
            this.ProfileSave_Button.Text = "Save";
            this.ProfileSave_Button.UseVisualStyleBackColor = true;
            this.ProfileSave_Button.Click += new System.EventHandler(this.ProfileSave_Button_Click);
            // 
            // CopyCSV_Button
            // 
            this.CopyCSV_Button.Location = new System.Drawing.Point(982, 24);
            this.CopyCSV_Button.Name = "CopyCSV_Button";
            this.CopyCSV_Button.Size = new System.Drawing.Size(110, 33);
            this.CopyCSV_Button.TabIndex = 44;
            this.CopyCSV_Button.Text = "Copy";
            this.CopyCSV_Button.UseVisualStyleBackColor = true;
            this.CopyCSV_Button.Click += new System.EventHandler(this.CopyCSV_Button_Click);
            // 
            // GetComPorts_Button
            // 
            this.GetComPorts_Button.Location = new System.Drawing.Point(1129, 17);
            this.GetComPorts_Button.Name = "GetComPorts_Button";
            this.GetComPorts_Button.Size = new System.Drawing.Size(76, 97);
            this.GetComPorts_Button.TabIndex = 45;
            this.GetComPorts_Button.Text = "Get COM Ports";
            this.GetComPorts_Button.UseVisualStyleBackColor = true;
            this.GetComPorts_Button.Click += new System.EventHandler(this.GetComPorts_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1857, 981);
            this.Controls.Add(this.GetComPorts_Button);
            this.Controls.Add(this.CopyCSV_Button);
            this.Controls.Add(this.ProfileSave_Button);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Profile_ComboBox);
            this.Controls.Add(this.GetPos_Button);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SampleUpStroke_Chart);
            this.Controls.Add(this.Average_Chart);
            this.Controls.Add(this.Samples_ComboBox);
            this.Controls.Add(this.Tare_Button);
            this.Controls.Add(this.StepSize_ComboBox);
            this.Controls.Add(this.Travel_ComboBox);
            this.Controls.Add(this.XOffset_ComboBox);
            this.Controls.Add(this.ZOffset_ComboBox);
            this.Controls.Add(this.Start_Button);
            this.Controls.Add(this.Rx2_TextBox);
            this.Controls.Add(this.Tx2_TextBox);
            this.Controls.Add(this.TxSend2_Textbox);
            this.Controls.Add(this.MoveHome_Button);
            this.Controls.Add(this.StepAmount_ComboBox);
            this.Controls.Add(this.MoveRight_Button);
            this.Controls.Add(this.MoveDown_Button);
            this.Controls.Add(this.MoveLeft_Button);
            this.Controls.Add(this.MoveUp_Button);
            this.Controls.Add(this.ComPort2_Button);
            this.Controls.Add(this.BaudRate2_ComboBox);
            this.Controls.Add(this.ComPort2_ComboBox);
            this.Controls.Add(this.RX_TextBox);
            this.Controls.Add(this.SampleDownStroke_Chart);
            this.Controls.Add(this.CSV_TextBox);
            this.Controls.Add(this.Status_TextBox);
            this.Controls.Add(this.SaveCSV_Button);
            this.Controls.Add(this.GetForce_Button);
            this.Controls.Add(this.ComPort_Button);
            this.Controls.Add(this.BaudRate_ComboBox);
            this.Controls.Add(this.ComPort_ComboBox);
            this.Name = "Form1";
            this.Text = "Switch Tester";
            ((System.ComponentModel.ISupportInitialize)(this.SampleDownStroke_Chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Average_Chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SampleUpStroke_Chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox ComPort_ComboBox;
        private System.Windows.Forms.ComboBox BaudRate_ComboBox;
        private System.Windows.Forms.Button ComPort_Button;
        private System.Windows.Forms.Button GetForce_Button;
        private System.Windows.Forms.Button SaveCSV_Button;
        private System.Windows.Forms.TextBox Status_TextBox;
        private System.Windows.Forms.TextBox CSV_TextBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart SampleDownStroke_Chart;
        private System.IO.Ports.SerialPort CommLink_SerialPort;
        private System.Windows.Forms.TextBox RX_TextBox;
        private System.Windows.Forms.Button ComPort2_Button;
        private System.Windows.Forms.ComboBox BaudRate2_ComboBox;
        private System.Windows.Forms.ComboBox ComPort2_ComboBox;
        private System.Windows.Forms.Button MoveUp_Button;
        private System.Windows.Forms.Button MoveLeft_Button;
        private System.Windows.Forms.Button MoveDown_Button;
        private System.Windows.Forms.Button MoveRight_Button;
        private System.Windows.Forms.ComboBox StepAmount_ComboBox;
        private System.IO.Ports.SerialPort CommLink2_SerialPort;
        private System.Windows.Forms.Button MoveHome_Button;
        private System.Windows.Forms.TextBox TxSend2_Textbox;
        private System.Windows.Forms.TextBox Tx2_TextBox;
        private System.Windows.Forms.TextBox Rx2_TextBox;
        private System.Windows.Forms.Button Start_Button;
        private System.Windows.Forms.ComboBox ZOffset_ComboBox;
        private System.Windows.Forms.ComboBox XOffset_ComboBox;
        private System.Windows.Forms.ComboBox Travel_ComboBox;
        private System.Windows.Forms.ComboBox StepSize_ComboBox;
        private System.Windows.Forms.Button Tare_Button;
        private System.Windows.Forms.ComboBox Samples_ComboBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart Average_Chart;
        private System.Windows.Forms.DataVisualization.Charting.Chart SampleUpStroke_Chart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button GetPos_Button;
        private System.Windows.Forms.ComboBox Profile_ComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ProfileSave_Button;
        private System.Windows.Forms.Button CopyCSV_Button;
        private System.Windows.Forms.Button GetComPorts_Button;
    }
}

