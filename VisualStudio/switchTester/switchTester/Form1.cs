using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace switchTester
{
    public partial class Form1 : Form
    {
        bool CommOpen = false;
        bool Comm2Open = false;
        bool Stroking = false;

        float force = 0.0f;

        private TaskCompletionSource<bool> _homingTcs;
        private TaskCompletionSource<bool> _getForceTcs;
        private CancellationTokenSource _strokeCts;

        public Form1()
        {
            InitializeComponent();

            
        }


        private void ComPort_Button_Click(object sender, EventArgs e)
        {
            if (!CommOpen)
            {
                if (CommLink_SerialPort.IsOpen) // check if serial port is open
                {
                    Status_TextBox.AppendText("Serial port " + CommLink_SerialPort.PortName + " already open!  Can't open "
                        + ComPort_ComboBox.Text + "." + Environment.NewLine); // send message to the status text box
                }
                else
                {
                    CommLink_SerialPort.PortName = ComPort_ComboBox.Text; // set the serial port name to the name in the com port text box
                    CommLink_SerialPort.BaudRate = Int32.Parse(BaudRate_ComboBox.Text);
                    CommLink_SerialPort.Open(); // open the serial port
                    Status_TextBox.AppendText("Serial port " + CommLink_SerialPort.PortName + " opened." + Environment.NewLine); // send message to the status text box

                    CommOpen = true;
                    ComPort_Button.Text = "Close COM Port";
                }
            }
            else
            {
                CommLink_SerialPort.Close();
                CommOpen = false;
                ComPort_Button.Text = "Open COM Port";
                Status_TextBox.AppendText("Serial port " + CommLink_SerialPort.PortName + " closed." + Environment.NewLine); // send message to the status text box
            }
           
        }


        private void Launch_Button_Click(object sender, EventArgs e)
        {
            GetForce();
        }

        private void SaveCSV_Button_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "csv files (*.csv)|*.csv|txt files (*.txt)|*.txt|All files (*.*)|*.*";
                sfd.FilterIndex = 1;
                sfd.DefaultExt = "csv";
                sfd.AddExtension = true;
                sfd.Title = "Save CSV Data";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Get the selected file name
                        string fileName = sfd.FileName;

                        // Write the contents of the TextBox to the file
                        File.WriteAllText(fileName, CSV_TextBox.Text);

                        // Show success message
                        MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Show error message if something went wrong
                        MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ClearCSV_Button_Click(object sender, EventArgs e)
        {
            CSV_TextBox.Clear();
        }



        private void ComPort2_Button_Click(object sender, EventArgs e)
        {
            if (!Comm2Open)
            {
                if (CommLink2_SerialPort.IsOpen) // check if serial port is open
                {
                    Status_TextBox.AppendText("Serial port " + CommLink2_SerialPort.PortName + " already open!  Can't open "
                        + ComPort2_ComboBox.Text + "." + Environment.NewLine); // send message to the status text box
                }
                else
                {
                    CommLink2_SerialPort.PortName = ComPort2_ComboBox.Text; // set the serial port name to the name in the com port text box
                    CommLink2_SerialPort.BaudRate = Int32.Parse(BaudRate2_ComboBox.Text);
                    CommLink2_SerialPort.Open(); // open the serial port
                    Status_TextBox.AppendText("Serial port " + CommLink2_SerialPort.PortName + " opened." + Environment.NewLine); // send message to the status text box


                    Comm2Open = true;
                    ComPort2_Button.Text = "Close COM Port";

                    MoveDown_Button.Enabled = true;
                    MoveUp_Button.Enabled = true;
                    MoveLeft_Button.Enabled = true;
                    MoveRight_Button.Enabled = true;
                    MoveHome_Button.Enabled = true;
                }
            }
            else
            {
                CommLink2_SerialPort.Close();
                Comm2Open = false;
                ComPort2_Button.Text = "Open COM Port";
                Status_TextBox.AppendText("Serial port " + CommLink2_SerialPort.PortName + " closed." + Environment.NewLine); // send message to the status text box

                MoveDown_Button.Enabled = false;
                MoveUp_Button.Enabled = false;
                MoveLeft_Button.Enabled = false;
                MoveRight_Button.Enabled = false;
                MoveHome_Button.Enabled = false;
            }
        }



        void MoveRelative(string axis, float distance)
        {
            CommLink2_SerialPort.Write("G91" + Environment.NewLine + $"G0 {axis}" + distance + Environment.NewLine);
            Tx2_TextBox.AppendText("G91" + Environment.NewLine + $"G0 {axis}" + distance + Environment.NewLine); // send message to the status text box
        }

        void HomeAxis(string axis)
        {
            _homingTcs = new TaskCompletionSource<bool>();
            CommLink2_SerialPort.Write("G28 " + axis + Environment.NewLine);
            Tx2_TextBox.AppendText("G28 " + axis + Environment.NewLine); // send message to the status text box

            
        }

        private void MoveUp_Button_Click(object sender, EventArgs e)
        {
            MoveRelative("Z+", float.Parse(StepAmount_ComboBox.Text));
        }

        private void MoveDown_Button_Click(object sender, EventArgs e)
        {
            MoveRelative("Z-", float.Parse(StepAmount_ComboBox.Text));
        }

        private void MoveLeft_Button_Click(object sender, EventArgs e)
        {
            MoveRelative("X-", float.Parse(StepAmount_ComboBox.Text));
        }

        private void MoveRight_Button_Click(object sender, EventArgs e)
        {
            MoveRelative("X+", float.Parse(StepAmount_ComboBox.Text));
        }

        private void MoveHome_Button_Click(object sender, EventArgs e)
        {
            HomeAxis("X Z");
        }

        void GetComPorts()
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            ComPort_ComboBox.Items.Clear();
            ComPort2_ComboBox.Items.Clear();
            foreach (string port in ports)
            {
                ComPort_ComboBox.Items.Add(port);
                ComPort2_ComboBox.Items.Add(port);
            }
            if (ports.Length > 0)
            {
                ComPort_ComboBox.SelectedIndex = 0;
                ComPort2_ComboBox.SelectedIndex = 0;
            }
        }

        private void ComPort_ComboBox_Click(object sender, EventArgs e)
        {
            GetComPorts();
        }

        private void ComPort2_ComboBox_Click(object sender, EventArgs e)
        {
            GetComPorts();
        }

        private void TxSend2_Textbox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                CommLink2_SerialPort.Write(TxSend2_Textbox.Text + Environment.NewLine);
                Tx2_TextBox.AppendText(TxSend2_Textbox.Text + Environment.NewLine);
                TxSend2_Textbox.Clear();
            }
        }

        private void CommLink2_SerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string rcvstring = CommLink2_SerialPort.ReadLine() + Environment.NewLine;
            // Use BeginInvoke to post the UI update without blocking the background thread
            Rx2_TextBox.BeginInvoke(new Action(() => Rx2_TextBox.AppendText(rcvstring)));

            // Signal homing completion if someone is waiting
            var tcs = _homingTcs;
            if (tcs != null)
            {
                tcs.TrySetResult(true); // non-throwing signal
                _homingTcs = null;
            }

        }

        void MoveAbsolute(string axis, float position)
        {
            CommLink2_SerialPort.Write("G90" + Environment.NewLine + $"G0 {axis}" + position + Environment.NewLine);
            Tx2_TextBox.AppendText("G90" + Environment.NewLine + $"G0 {axis}" + position + Environment.NewLine); // send message to the status text box
        }

        void GetForce()
        {
            byte[] getForceCommand = { 0x01 };
            _getForceTcs = new TaskCompletionSource<bool>();
            CommLink_SerialPort.Write(getForceCommand, 0, 1);
            Status_TextBox.AppendText("Getting Force Data" + Environment.NewLine); // send message to the status text box
        }

        private void Start_Button_Click(object sender, EventArgs e)
        {
            if (Stroking)
            {
                _strokeCts?.Cancel();
            }
            else
            {
                Start_Button.Text = "Stop";
                _strokeCts = new CancellationTokenSource();
                StrokeTest(_strokeCts.Token);
                Stroking = true;
            }
        }


        int steps = 0;
        int Samples = 0;

        struct SampleData_t
        {
            public float[] downForce;
            public float[] upForce;
        }
        SampleData_t[] sampleData;
        SampleData_t averageData;
        float[] stepPosition;

        async void StrokeTest(CancellationToken token)
        {
            try
            {
                float XOffset = float.Parse(XOffset_ComboBox.Text);
                float ZOffset = float.Parse(ZOffset_ComboBox.Text);
                float Travel = float.Parse(Travel_ComboBox.Text);
                float StepSize = float.Parse(StepSize_ComboBox.Text);
                Samples = Int32.Parse(Samples_ComboBox.Text);


                steps = (int)Math.Ceiling(Travel / StepSize) + 1;
                sampleData = new SampleData_t[Samples];
                for (int i = 0; i < Samples; i++)
                {
                    sampleData[i].downForce = new float[steps];
                    sampleData[i].upForce = new float[steps];
                }

                averageData = new SampleData_t();
                averageData.downForce = new float[steps];
                averageData.upForce = new float[steps];

                stepPosition = new float[steps];
                for (int step = 0; step < steps; step++)
                {
                    stepPosition[step] = (float)Math.Round(step * StepSize, 2);
                }

                InitCharts();

                HomeAxis("X Z");
                var tcs = _homingTcs;
                if (tcs != null)
                {
                    var completed = await Task.WhenAny(tcs.Task, Task.Delay(50000, token));
                    if (completed != tcs.Task)
                    {
                        Status_TextBox.AppendText("Homing timed out" + Environment.NewLine);
                        return;
                    }
                }
                
                MoveAbsolute("Z", ZOffset + 5);
                await Task.Delay((int)Math.Ceiling(700 * ZOffset), token);
                MoveAbsolute("X", XOffset);
                await Task.Delay((int)Math.Ceiling(10 * XOffset), token);
                
                

                for (int sample = 0; sample < Samples; sample++)
                {
                    token.ThrowIfCancellationRequested();

                    TareScale();
                    await Task.Delay(100, token);
                    MoveAbsolute("Z", ZOffset);
                    await Task.Delay((int)Math.Ceiling(700 * ZOffset), token);
                    upStroke = 0; // down stroke
                    for (int step = 0; step < steps; step++)
                    {
                        token.ThrowIfCancellationRequested();

                        float nextPos = ZOffset - (step * StepSize);

                        GetForce();
                        var tcs2 = _getForceTcs;
                        if (tcs2 != null)
                        {
                            var completed = await Task.WhenAny(tcs2.Task, Task.Delay(5000, token));
                            if (completed != tcs2.Task)
                            {
                                Status_TextBox.AppendText("getForce timed out" + Environment.NewLine);
                                return;
                            }
                        }
                        ProcessData(sample, step);
                        MoveAbsolute("Z", nextPos);
                        await Task.Delay((int)Math.Ceiling(700 * StepSize), token); // wait time proportional to step size
                    }

                    token.ThrowIfCancellationRequested();

                    upStroke = 1; // up stroke
                    for (int step = steps -1; step >= 0; step--)
                    {
                        token.ThrowIfCancellationRequested();

                        float nextPos = ZOffset - (step * StepSize);

                        GetForce();
                        var tcs2 = _getForceTcs;
                        if (tcs2 != null)
                        {
                            var completed = await Task.WhenAny(tcs2.Task, Task.Delay(5000, token));
                            if (completed != tcs2.Task)
                            {
                                Status_TextBox.AppendText("getForce timed out" + Environment.NewLine);
                                return;
                            }
                        }
                        ProcessData(sample, step);
                        MoveAbsolute("Z", nextPos);
                        await Task.Delay((int)Math.Ceiling(700 * StepSize), token); // wait time proportional to step size
                    }
                    MoveAbsolute("Z", ZOffset + 5);
                    await Task.Delay((int)Math.Ceiling(700 * ZOffset), token);

                }
                GenerateCSV();
            }
            catch (OperationCanceledException)
            {
                // stop requested — swallow and exit gracefully
                Status_TextBox.AppendText("StrokeTest cancelled" + Environment.NewLine);
            }
            finally
            {
                Stroking = false;
                Start_Button.Text = "Start";
                _strokeCts?.Dispose();
                _strokeCts = null;
            }
        }

        void GenerateCSV()
        {
            CSV_TextBox.Clear();
            CSV_TextBox.AppendText("Position, DownForce, UpForce" + Environment.NewLine);
            for (int step = 0; step < steps; step++)
            {
                CSV_TextBox.AppendText((float)Math.Round(stepPosition[step], 2) + ", " + (float)Math.Round(averageData.downForce[step], 2) + ", " + (float)Math.Round(averageData.upForce[step], 2) + Environment.NewLine);
            }
        }

        void InitCharts()
        {
            if (SampleDownStroke_Chart != null)
            {
                // clear any previous series
                SampleDownStroke_Chart.Series.Clear();
                for (int i = 0; i < Samples; i++)
                {
                    var s = SampleDownStroke_Chart.Series.Add("Sample " + i);
                    s.Points.Clear();
                    s.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    s.BorderWidth = 1;
                    s.LegendText = "Sample " + i;
                }

                if (SampleDownStroke_Chart.ChartAreas.Count > 0)
                {
                    SampleDownStroke_Chart.ChartAreas[0].AxisX.LabelStyle.Format = "F2";
                }
            }

            if (SampleUpStroke_Chart != null)
            {
                // clear any previous series
                SampleUpStroke_Chart.Series.Clear();
                for (int i = 0; i < Samples; i++)
                {
                    var s = SampleUpStroke_Chart.Series.Add("Sample " + i);
                    s.Points.Clear();
                    s.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    s.BorderWidth = 1;
                    s.LegendText = "Sample " + i;
                }

                if (SampleUpStroke_Chart.ChartAreas.Count > 0)
                {
                    SampleUpStroke_Chart.ChartAreas[0].AxisX.LabelStyle.Format = "F2";
                }
            }

            // Initialize Average_Chart so we can update points live while collecting samples
            if (Average_Chart != null)
            {
                Average_Chart.Series.Clear();
                var avgSeries = Average_Chart.Series.Add("Average Down Stroke");
                avgSeries.Points.Clear();
                avgSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                avgSeries.BorderWidth = 2;
                avgSeries.Name = "Average Down Stroke";

                // Pre-populate points so index == step always valid (works with descending upstroke)
                if (steps > 0 && stepPosition != null)
                {
                    for (int s = 0; s < steps; s++)
                    {
                        avgSeries.Points.AddXY(stepPosition[s], 0.0);
                    }
                }

                avgSeries = Average_Chart.Series.Add("Average Up Stroke");
                avgSeries.Points.Clear();
                avgSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                avgSeries.BorderWidth = 2;
                avgSeries.Name = "Average Up Stroke";

                if (steps > 0 && stepPosition != null)
                {
                    for (int s = 0; s < steps; s++)
                    {
                        avgSeries.Points.AddXY(stepPosition[s], 0.0);
                    }
                }

                if (Average_Chart.ChartAreas.Count > 0)
                {
                    Average_Chart.ChartAreas[0].AxisX.LabelStyle.Format = "F2";
                }
            }
        }

        int upStroke = 0;

        void ProcessData(int sample, int step)
        {
            // Defensive checks to avoid IndexOutOfRange and to make behavior predictable
            if (sampleData == null) return;
            if (sample < 0 || sample >= sampleData.Length) return;
            if (step < 0 || step >= steps) return;
            if (sampleData[sample].downForce == null || sampleData[sample].upForce == null) return;

            if (upStroke == 1)
            {
                sampleData[sample].upForce[step] = force;

                // update corresponding series on Sample_Chart if present
                if (SampleUpStroke_Chart == null) return;

                if (sample < 0 || sample >= SampleUpStroke_Chart.Series.Count) return;

                var series = SampleUpStroke_Chart.Series[sample];

                // Chart controls must be updated on UI thread
                if (SampleUpStroke_Chart.InvokeRequired)
                {
                    SampleUpStroke_Chart.BeginInvoke(new Action(() => series.Points.AddXY(stepPosition[step], force)));
                }
                else
                {
                    series.Points.AddXY(stepPosition[step], force);
                }
            }
            else
            {
                sampleData[sample].downForce[step] = force;

                // update corresponding series on Sample_Chart if present
                if (SampleDownStroke_Chart == null) return;

                if (sample < 0 || sample >= SampleDownStroke_Chart.Series.Count) return;

                var series = SampleDownStroke_Chart.Series[sample];

                // Chart controls must be updated on UI thread
                if (SampleDownStroke_Chart.InvokeRequired)
                {
                    SampleDownStroke_Chart.BeginInvoke(new Action(() => series.Points.AddXY(stepPosition[step], force)));
                }
                else
                {
                    series.Points.AddXY(stepPosition[step], force);
                }
            }



            // --- Update running average on Average_Chart live ---
            if (Average_Chart == null) return;
            if (Average_Chart.Series.Count == 0) return;

            var avgSeries = Average_Chart.Series[upStroke];

            // compute running average across samples collected so far for this step
            float runningAvg = 0.0f;
            int count = Math.Min(sample + 1, Samples); // samples collected so far for this step
            for (int i = 0; i < count; i++)
            {
                if (upStroke == 1)
                    runningAvg += sampleData[i].upForce[step];
                else
                    runningAvg += sampleData[i].downForce[step];
            }
            if (count > 0)
                runningAvg /= count;
            else
                runningAvg = 0.0f;

            if (upStroke == 1)
                averageData.upForce[step] = runningAvg;
            else
                averageData.downForce[step] = runningAvg;

            // Update the avgSeries point Y value for this step. Points were pre-populated so index == step.
            Action updateAvgPoint = () =>
            {
                if (step < 0) return;

                // Points were pre-populated in InitCharts to ensure index matches step.
                if (step < avgSeries.Points.Count)
                {
                    var pt = avgSeries.Points[step];
                    pt.SetValueY(runningAvg);
                }
                else
                {
                    // fallback: append if series wasn't pre-populated for some reason
                    avgSeries.Points.AddXY(stepPosition[step], runningAvg);
                }

                if (Average_Chart.ChartAreas.Count > 0)
                {
                    var area = Average_Chart.ChartAreas[0];
                    area.AxisX.Minimum = double.NaN;
                    area.AxisX.Maximum = double.NaN;
                    area.AxisY.Minimum = double.NaN;
                    area.AxisY.Maximum = double.NaN;
                    area.RecalculateAxesScale();
                }
            };

            if (Average_Chart.InvokeRequired)
            {
                Average_Chart.BeginInvoke(updateAvgPoint);
            }
            else
            {
                updateAvgPoint();
            }
        }

        void TareScale()
        {
            byte[] tareCommand = { 0x02 };
            CommLink_SerialPort.Write(tareCommand, 0, 1);
            Status_TextBox.AppendText("Tareing scale" + Environment.NewLine); // send message to the status text box
        }


        private void CommLink_SerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            // Signal getForce completion if someone is waiting
            var tcs2 = _getForceTcs;
            if (tcs2 != null)
            {
                tcs2.TrySetResult(true); // non-throwing signal
                _getForceTcs = null;
            }

            force = float.Parse(CommLink_SerialPort.ReadLine());
            RX_TextBox.BeginInvoke(new Action(() => RX_TextBox.AppendText(force + Environment.NewLine)));
        


        }

        private void Tare_Button_Click(object sender, EventArgs e)
        {
            TareScale();
        }

    }
}
