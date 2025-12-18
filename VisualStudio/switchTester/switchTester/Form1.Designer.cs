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
            this.Launch_Button = new System.Windows.Forms.Button();
            this.SaveCSV_Button = new System.Windows.Forms.Button();
            this.ClearCSV_Button = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.SampleDownStroke_Chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Average_Chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SampleUpStroke_Chart)).BeginInit();
            this.SuspendLayout();
            // 
            // ComPort_ComboBox
            // 
            this.ComPort_ComboBox.FormattingEnabled = true;
            this.ComPort_ComboBox.Location = new System.Drawing.Point(61, 56);
            this.ComPort_ComboBox.Name = "ComPort_ComboBox";
            this.ComPort_ComboBox.Size = new System.Drawing.Size(121, 21);
            this.ComPort_ComboBox.TabIndex = 1;
            this.ComPort_ComboBox.Text = "COM10";
            this.ComPort_ComboBox.Click += new System.EventHandler(this.ComPort_ComboBox_Click);
            // 
            // BaudRate_ComboBox
            // 
            this.BaudRate_ComboBox.FormattingEnabled = true;
            this.BaudRate_ComboBox.Items.AddRange(new object[] {
            "9600"});
            this.BaudRate_ComboBox.Location = new System.Drawing.Point(61, 94);
            this.BaudRate_ComboBox.Name = "BaudRate_ComboBox";
            this.BaudRate_ComboBox.Size = new System.Drawing.Size(121, 21);
            this.BaudRate_ComboBox.TabIndex = 2;
            this.BaudRate_ComboBox.Text = "115200";
            // 
            // ComPort_Button
            // 
            this.ComPort_Button.Location = new System.Drawing.Point(61, 141);
            this.ComPort_Button.Name = "ComPort_Button";
            this.ComPort_Button.Size = new System.Drawing.Size(110, 33);
            this.ComPort_Button.TabIndex = 3;
            this.ComPort_Button.Text = "Open COM Port";
            this.ComPort_Button.UseVisualStyleBackColor = true;
            this.ComPort_Button.Click += new System.EventHandler(this.ComPort_Button_Click);
            // 
            // Launch_Button
            // 
            this.Launch_Button.Location = new System.Drawing.Point(503, 159);
            this.Launch_Button.Name = "Launch_Button";
            this.Launch_Button.Size = new System.Drawing.Size(110, 33);
            this.Launch_Button.TabIndex = 6;
            this.Launch_Button.Text = "Launch";
            this.Launch_Button.UseVisualStyleBackColor = true;
            this.Launch_Button.Click += new System.EventHandler(this.Launch_Button_Click);
            // 
            // SaveCSV_Button
            // 
            this.SaveCSV_Button.Location = new System.Drawing.Point(415, 435);
            this.SaveCSV_Button.Name = "SaveCSV_Button";
            this.SaveCSV_Button.Size = new System.Drawing.Size(110, 33);
            this.SaveCSV_Button.TabIndex = 7;
            this.SaveCSV_Button.Text = "Save";
            this.SaveCSV_Button.UseVisualStyleBackColor = true;
            this.SaveCSV_Button.Click += new System.EventHandler(this.SaveCSV_Button_Click);
            // 
            // ClearCSV_Button
            // 
            this.ClearCSV_Button.Location = new System.Drawing.Point(415, 474);
            this.ClearCSV_Button.Name = "ClearCSV_Button";
            this.ClearCSV_Button.Size = new System.Drawing.Size(110, 33);
            this.ClearCSV_Button.TabIndex = 8;
            this.ClearCSV_Button.Text = "Clear";
            this.ClearCSV_Button.UseVisualStyleBackColor = true;
            this.ClearCSV_Button.Click += new System.EventHandler(this.ClearCSV_Button_Click);
            // 
            // Status_TextBox
            // 
            this.Status_TextBox.Location = new System.Drawing.Point(61, 273);
            this.Status_TextBox.Multiline = true;
            this.Status_TextBox.Name = "Status_TextBox";
            this.Status_TextBox.ReadOnly = true;
            this.Status_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Status_TextBox.Size = new System.Drawing.Size(111, 156);
            this.Status_TextBox.TabIndex = 9;
            // 
            // CSV_TextBox
            // 
            this.CSV_TextBox.Location = new System.Drawing.Point(414, 260);
            this.CSV_TextBox.Multiline = true;
            this.CSV_TextBox.Name = "CSV_TextBox";
            this.CSV_TextBox.ReadOnly = true;
            this.CSV_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CSV_TextBox.Size = new System.Drawing.Size(111, 156);
            this.CSV_TextBox.TabIndex = 10;
            // 
            // SampleDownStroke_Chart
            // 
            chartArea1.Name = "ChartArea1";
            this.SampleDownStroke_Chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.SampleDownStroke_Chart.Legends.Add(legend1);
            this.SampleDownStroke_Chart.Location = new System.Drawing.Point(61, 559);
            this.SampleDownStroke_Chart.Name = "SampleDownStroke_Chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.SampleDownStroke_Chart.Series.Add(series1);
            this.SampleDownStroke_Chart.Size = new System.Drawing.Size(441, 300);
            this.SampleDownStroke_Chart.TabIndex = 11;
            this.SampleDownStroke_Chart.Text = "CSV_Chart";
            // 
            // CommLink_SerialPort
            // 
            this.CommLink_SerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.CommLink_SerialPort_DataReceived);
            // 
            // RX_TextBox
            // 
            this.RX_TextBox.Location = new System.Drawing.Point(240, 273);
            this.RX_TextBox.Multiline = true;
            this.RX_TextBox.Name = "RX_TextBox";
            this.RX_TextBox.ReadOnly = true;
            this.RX_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RX_TextBox.Size = new System.Drawing.Size(111, 156);
            this.RX_TextBox.TabIndex = 12;
            // 
            // ComPort2_Button
            // 
            this.ComPort2_Button.Location = new System.Drawing.Point(980, 168);
            this.ComPort2_Button.Name = "ComPort2_Button";
            this.ComPort2_Button.Size = new System.Drawing.Size(110, 38);
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
            this.BaudRate2_ComboBox.Location = new System.Drawing.Point(980, 121);
            this.BaudRate2_ComboBox.Name = "BaudRate2_ComboBox";
            this.BaudRate2_ComboBox.Size = new System.Drawing.Size(121, 21);
            this.BaudRate2_ComboBox.TabIndex = 14;
            this.BaudRate2_ComboBox.Text = "115200";
            // 
            // ComPort2_ComboBox
            // 
            this.ComPort2_ComboBox.FormattingEnabled = true;
            this.ComPort2_ComboBox.Location = new System.Drawing.Point(980, 83);
            this.ComPort2_ComboBox.Name = "ComPort2_ComboBox";
            this.ComPort2_ComboBox.Size = new System.Drawing.Size(121, 21);
            this.ComPort2_ComboBox.TabIndex = 13;
            this.ComPort2_ComboBox.Text = "COM9";
            this.ComPort2_ComboBox.Click += new System.EventHandler(this.ComPort2_ComboBox_Click);
            // 
            // MoveUp_Button
            // 
            this.MoveUp_Button.Enabled = false;
            this.MoveUp_Button.Location = new System.Drawing.Point(949, 308);
            this.MoveUp_Button.Name = "MoveUp_Button";
            this.MoveUp_Button.Size = new System.Drawing.Size(98, 69);
            this.MoveUp_Button.TabIndex = 16;
            this.MoveUp_Button.Text = "Up";
            this.MoveUp_Button.UseVisualStyleBackColor = true;
            this.MoveUp_Button.Click += new System.EventHandler(this.MoveUp_Button_Click);
            // 
            // MoveLeft_Button
            // 
            this.MoveLeft_Button.Enabled = false;
            this.MoveLeft_Button.Location = new System.Drawing.Point(828, 380);
            this.MoveLeft_Button.Name = "MoveLeft_Button";
            this.MoveLeft_Button.Size = new System.Drawing.Size(98, 69);
            this.MoveLeft_Button.TabIndex = 17;
            this.MoveLeft_Button.Text = "Left";
            this.MoveLeft_Button.UseVisualStyleBackColor = true;
            this.MoveLeft_Button.Click += new System.EventHandler(this.MoveLeft_Button_Click);
            // 
            // MoveDown_Button
            // 
            this.MoveDown_Button.Enabled = false;
            this.MoveDown_Button.Location = new System.Drawing.Point(949, 474);
            this.MoveDown_Button.Name = "MoveDown_Button";
            this.MoveDown_Button.Size = new System.Drawing.Size(98, 69);
            this.MoveDown_Button.TabIndex = 18;
            this.MoveDown_Button.Text = "Down";
            this.MoveDown_Button.UseVisualStyleBackColor = true;
            this.MoveDown_Button.Click += new System.EventHandler(this.MoveDown_Button_Click);
            // 
            // MoveRight_Button
            // 
            this.MoveRight_Button.Enabled = false;
            this.MoveRight_Button.Location = new System.Drawing.Point(1072, 380);
            this.MoveRight_Button.Name = "MoveRight_Button";
            this.MoveRight_Button.Size = new System.Drawing.Size(98, 69);
            this.MoveRight_Button.TabIndex = 19;
            this.MoveRight_Button.Text = "Right";
            this.MoveRight_Button.UseVisualStyleBackColor = true;
            this.MoveRight_Button.Click += new System.EventHandler(this.MoveRight_Button_Click);
            // 
            // StepAmount_ComboBox
            // 
            this.StepAmount_ComboBox.FormattingEnabled = true;
            this.StepAmount_ComboBox.Location = new System.Drawing.Point(958, 405);
            this.StepAmount_ComboBox.Name = "StepAmount_ComboBox";
            this.StepAmount_ComboBox.Size = new System.Drawing.Size(79, 21);
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
            this.MoveHome_Button.Location = new System.Drawing.Point(1129, 260);
            this.MoveHome_Button.Name = "MoveHome_Button";
            this.MoveHome_Button.Size = new System.Drawing.Size(81, 44);
            this.MoveHome_Button.TabIndex = 21;
            this.MoveHome_Button.Text = "Home";
            this.MoveHome_Button.UseVisualStyleBackColor = true;
            this.MoveHome_Button.Click += new System.EventHandler(this.MoveHome_Button_Click);
            // 
            // TxSend2_Textbox
            // 
            this.TxSend2_Textbox.Location = new System.Drawing.Point(1280, 578);
            this.TxSend2_Textbox.Name = "TxSend2_Textbox";
            this.TxSend2_Textbox.Size = new System.Drawing.Size(121, 20);
            this.TxSend2_Textbox.TabIndex = 22;
            this.TxSend2_Textbox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxSend2_Textbox_KeyUp);
            // 
            // Tx2_TextBox
            // 
            this.Tx2_TextBox.Location = new System.Drawing.Point(1280, 192);
            this.Tx2_TextBox.Multiline = true;
            this.Tx2_TextBox.Name = "Tx2_TextBox";
            this.Tx2_TextBox.ReadOnly = true;
            this.Tx2_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Tx2_TextBox.Size = new System.Drawing.Size(121, 363);
            this.Tx2_TextBox.TabIndex = 23;
            // 
            // Rx2_TextBox
            // 
            this.Rx2_TextBox.Location = new System.Drawing.Point(1425, 192);
            this.Rx2_TextBox.Multiline = true;
            this.Rx2_TextBox.Name = "Rx2_TextBox";
            this.Rx2_TextBox.ReadOnly = true;
            this.Rx2_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Rx2_TextBox.Size = new System.Drawing.Size(230, 406);
            this.Rx2_TextBox.TabIndex = 24;
            // 
            // Start_Button
            // 
            this.Start_Button.Location = new System.Drawing.Point(1452, 69);
            this.Start_Button.Name = "Start_Button";
            this.Start_Button.Size = new System.Drawing.Size(98, 69);
            this.Start_Button.TabIndex = 25;
            this.Start_Button.Text = "Start";
            this.Start_Button.UseVisualStyleBackColor = true;
            this.Start_Button.Click += new System.EventHandler(this.Start_Button_Click);
            // 
            // ZOffset_ComboBox
            // 
            this.ZOffset_ComboBox.FormattingEnabled = true;
            this.ZOffset_ComboBox.Location = new System.Drawing.Point(1240, 141);
            this.ZOffset_ComboBox.Name = "ZOffset_ComboBox";
            this.ZOffset_ComboBox.Size = new System.Drawing.Size(79, 21);
            this.ZOffset_ComboBox.TabIndex = 26;
            this.ZOffset_ComboBox.Text = "5";
            // 
            // XOffset_ComboBox
            // 
            this.XOffset_ComboBox.FormattingEnabled = true;
            this.XOffset_ComboBox.Location = new System.Drawing.Point(1337, 141);
            this.XOffset_ComboBox.Name = "XOffset_ComboBox";
            this.XOffset_ComboBox.Size = new System.Drawing.Size(79, 21);
            this.XOffset_ComboBox.TabIndex = 27;
            this.XOffset_ComboBox.Text = "30";
            // 
            // Travel_ComboBox
            // 
            this.Travel_ComboBox.FormattingEnabled = true;
            this.Travel_ComboBox.Location = new System.Drawing.Point(1471, 144);
            this.Travel_ComboBox.Name = "Travel_ComboBox";
            this.Travel_ComboBox.Size = new System.Drawing.Size(79, 21);
            this.Travel_ComboBox.TabIndex = 28;
            this.Travel_ComboBox.Text = "3.8";
            // 
            // StepSize_ComboBox
            // 
            this.StepSize_ComboBox.FormattingEnabled = true;
            this.StepSize_ComboBox.Location = new System.Drawing.Point(1576, 141);
            this.StepSize_ComboBox.Name = "StepSize_ComboBox";
            this.StepSize_ComboBox.Size = new System.Drawing.Size(79, 21);
            this.StepSize_ComboBox.TabIndex = 29;
            this.StepSize_ComboBox.Text = "0.1";
            // 
            // Tare_Button
            // 
            this.Tare_Button.Location = new System.Drawing.Point(544, 62);
            this.Tare_Button.Name = "Tare_Button";
            this.Tare_Button.Size = new System.Drawing.Size(110, 33);
            this.Tare_Button.TabIndex = 30;
            this.Tare_Button.Text = "tare";
            this.Tare_Button.UseVisualStyleBackColor = true;
            this.Tare_Button.Click += new System.EventHandler(this.Tare_Button_Click);
            // 
            // Samples_ComboBox
            // 
            this.Samples_ComboBox.FormattingEnabled = true;
            this.Samples_ComboBox.Location = new System.Drawing.Point(1576, 69);
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
            this.Average_Chart.Location = new System.Drawing.Point(527, 559);
            this.Average_Chart.Name = "Average_Chart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.Average_Chart.Series.Add(series2);
            this.Average_Chart.Size = new System.Drawing.Size(441, 300);
            this.Average_Chart.TabIndex = 32;
            this.Average_Chart.Text = "chart1";
            // 
            // SampleUpStroke_Chart
            // 
            chartArea3.Name = "ChartArea1";
            this.SampleUpStroke_Chart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.SampleUpStroke_Chart.Legends.Add(legend3);
            this.SampleUpStroke_Chart.Location = new System.Drawing.Point(1032, 619);
            this.SampleUpStroke_Chart.Name = "SampleUpStroke_Chart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.SampleUpStroke_Chart.Series.Add(series3);
            this.SampleUpStroke_Chart.Size = new System.Drawing.Size(441, 300);
            this.SampleUpStroke_Chart.TabIndex = 33;
            this.SampleUpStroke_Chart.Text = "CSV_Chart";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1667, 931);
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
            this.Controls.Add(this.ClearCSV_Button);
            this.Controls.Add(this.SaveCSV_Button);
            this.Controls.Add(this.Launch_Button);
            this.Controls.Add(this.ComPort_Button);
            this.Controls.Add(this.BaudRate_ComboBox);
            this.Controls.Add(this.ComPort_ComboBox);
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.Button Launch_Button;
        private System.Windows.Forms.Button SaveCSV_Button;
        private System.Windows.Forms.Button ClearCSV_Button;
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
    }
}

