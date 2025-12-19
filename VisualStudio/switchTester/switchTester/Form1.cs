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
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace switchTester
{
    public partial class Form1 : Form
    {
        bool CommOpen = false;
        bool Comm2Open = false;
        bool Stroking = false;
        bool Homed = false;

        float force = 0.0f;

        int upStroke = 0;


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

        private TaskCompletionSource<bool> _homingTcs;
        private TaskCompletionSource<bool> _getForceTcs;
        private CancellationTokenSource _strokeCts;

        // new field to store profiles in-memory (profile name -> (ZOffset, Travel))
        private Dictionary<string, (string ZOffset, string Travel)> _profiles = new Dictionary<string, (string, string)>();

        public Form1()
        {
            InitializeComponent();
            LoadProfiles();
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
                    GetPos_Button.Enabled = true;

                    Homed = false;
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
                GetPos_Button.Enabled = false;
            }
        }

        bool TrySerialWrite(System.IO.Ports.SerialPort port, Action writeAction, string friendlyName)
        {
            if (port == null || !port.IsOpen)
            {
                if (Stroking)
                {
                    _strokeCts?.Cancel();
                    Status_TextBox.AppendText("Port '" + (friendlyName ?? "(unknown)") + "' not open — stopping test." + Environment.NewLine);
                }
                else
                    Status_TextBox.AppendText($"Port '{friendlyName ?? "(unknown)"}' not open — command skipped.{Environment.NewLine}");
                return false;
            }

            try
            {
                writeAction();
                return true;
            }
            catch (UnauthorizedAccessException uaex)
            {
                Status_TextBox.AppendText($"Access error writing to '{friendlyName}': {uaex.Message}{Environment.NewLine}");
            }
            catch (IOException ioex)
            {
                Status_TextBox.AppendText($"I/O error writing to '{friendlyName}': {ioex.Message}{Environment.NewLine}");
            }
            catch (InvalidOperationException invex)
            {
                Status_TextBox.AppendText($"Invalid operation writing to '{friendlyName}': {invex.Message}{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                Status_TextBox.AppendText($"Unexpected error writing to '{friendlyName}': {ex.Message}{Environment.NewLine}");
            }

            return false;
        }

        void MoveRelative(string axis, float distance)
        {
            TrySerialWrite(CommLink2_SerialPort, () =>
            {
                CommLink2_SerialPort.Write("G91" + Environment.NewLine + $"G0 {axis}" + distance + Environment.NewLine);
                Tx2_TextBox.AppendText("G91" + Environment.NewLine + $"G0 {axis}" + distance + Environment.NewLine);
            }, CommLink2_SerialPort?.PortName);
        }

        void MoveAbsolute(string axis, float position)
        {
            TrySerialWrite(CommLink2_SerialPort, () =>
            {
                CommLink2_SerialPort.Write("G90" + Environment.NewLine + $"G0 {axis}" + position + Environment.NewLine);
                Tx2_TextBox.AppendText("G90" + Environment.NewLine + $"G0 {axis}" + position + Environment.NewLine);
            }, CommLink2_SerialPort?.PortName);
        }

        void HomeAxis(string axis)
        {
            if (CommLink2_SerialPort == null || !CommLink2_SerialPort.IsOpen)
            {
                Status_TextBox.AppendText("Printer control port not open — cannot home." + Environment.NewLine);
                return;
            }

            // Drain any pending incoming data before creating the new waiter
            try { CommLink2_SerialPort.DiscardInBuffer(); } catch { /* best-effort */ }

            _homingTcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            TrySerialWrite(CommLink2_SerialPort, () =>
            {
                CommLink2_SerialPort.Write("G28 " + axis + Environment.NewLine);
                Tx2_TextBox.AppendText("G28 " + axis + Environment.NewLine);
            }, CommLink2_SerialPort.PortName);

            Homed = true;
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
            if (e.KeyData != Keys.Enter) return;

            if (CommLink2_SerialPort == null || !CommLink2_SerialPort.IsOpen)
            {
                Status_TextBox.AppendText("Printer control port not open — can't send manual command." + Environment.NewLine);
                TxSend2_Textbox.Clear();
                return;
            }

            TrySerialWrite(CommLink2_SerialPort, () =>
            {
                CommLink2_SerialPort.Write(TxSend2_Textbox.Text + Environment.NewLine);
                Tx2_TextBox.AppendText(TxSend2_Textbox.Text + Environment.NewLine);
                TxSend2_Textbox.Clear();
            }, CommLink2_SerialPort.PortName);
        }

        private void CommLink2_SerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                string rcvstring = CommLink2_SerialPort.ReadLine() + Environment.NewLine;
                // Use BeginInvoke to post the UI update without blocking the background thread
                Rx2_TextBox.BeginInvoke(new Action(() => Rx2_TextBox.AppendText(rcvstring)));

                // Signal homing completion if someone is waiting (use thread-safe exchange)
                var tcs = System.Threading.Interlocked.Exchange(ref _homingTcs, null);
                if (tcs != null)
                {
                    try { tcs.TrySetResult(true); } catch { /* swallow */ }
                }
            }
            catch (IOException ioex)
            {
                // Serial port IO error — log and release any waiting tcs to avoid deadlock
                Rx2_TextBox.BeginInvoke(new Action(() => Rx2_TextBox.AppendText("CommLink2 IO error: " + ioex.Message + Environment.NewLine)));
                var tcs = System.Threading.Interlocked.Exchange(ref _homingTcs, null);
                if (tcs != null)
                {
                    try { tcs.TrySetResult(true); } catch { }
                }
            }
            catch (Exception ex)
            {
                // Unexpected exception in DataReceived should not kill the serial thread — log and release tcs
                Rx2_TextBox.BeginInvoke(new Action(() => Rx2_TextBox.AppendText("CommLink2 DataReceived error: " + ex.Message + Environment.NewLine)));
                var tcs = System.Threading.Interlocked.Exchange(ref _homingTcs, null);
                if (tcs != null)
                {
                    try { tcs.TrySetResult(true); } catch { }
                }
            }
        }

        void GetForce()
        {
            if (CommLink_SerialPort == null || !CommLink_SerialPort.IsOpen)
            {
                // If port closed, create a completed TCS so callers waiting won't hang.
                var immediate = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                immediate.TrySetResult(true);
                _getForceTcs = immediate;
                if (Stroking)
                {
                    _strokeCts?.Cancel();
                    Status_TextBox.AppendText("Scale port not open — stopping test." + Environment.NewLine);
                }
                else
                {
                    Status_TextBox.AppendText("Scale port not open — cannot get force data." + Environment.NewLine);
                }
                
                return;
            }

            try
            {
                CommLink_SerialPort.DiscardInBuffer();
            }
            catch { /* best-effort */ }

            _getForceTcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            byte[] getForceCommand = { 0x01 };
            TrySerialWrite(CommLink_SerialPort, () => CommLink_SerialPort.Write(getForceCommand, 0, 1), CommLink_SerialPort.PortName);

            if (!Stroking)
                Status_TextBox.AppendText("Getting force data" + Environment.NewLine);
        }

        private void Start_Button_Click(object sender, EventArgs e)
        {
            if (Stroking)
            {
                _strokeCts?.Cancel();
            }
            else
            {
                if (CommLink2_SerialPort.IsOpen == false)
                    ComPort2_Button.PerformClick();
                
                if (CommLink_SerialPort.IsOpen == false)
                    ComPort_Button.PerformClick();

                Start_Button.Text = "Stop";
                _strokeCts = new CancellationTokenSource();
                StrokeTest(_strokeCts.Token);
                Stroking = true;
            }
        }

        async void StrokeTest(CancellationToken token)
        {
            try
            {
                float XOffset = float.Parse(XOffset_ComboBox.Text);
                float ZOffset = float.Parse(ZOffset_ComboBox.Text);
                float Travel = float.Parse(Travel_ComboBox.Text);
                float StepSize = float.Parse(StepSize_ComboBox.Text);
                Samples = Int32.Parse(Samples_ComboBox.Text);

                // Use decimal for steps calculation to avoid floating-point rounding errors
                decimal travelDec = decimal.Parse(Travel_ComboBox.Text);
                decimal stepSizeDec = decimal.Parse(StepSize_ComboBox.Text);
                int baseSteps = 0;
                if (stepSizeDec > 0)
                    baseSteps = (int)decimal.Floor(travelDec / stepSizeDec);

                steps = baseSteps + 1;

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

                if (!Homed)
                {
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
                    
                }
                
                MoveAbsolute("Z", ZOffset + 1);
                await Task.Delay((int)Math.Ceiling(700 * ZOffset), token);
                MoveAbsolute("X", XOffset);
                await Task.Delay((int)Math.Ceiling(10 * XOffset), token);
                
                

                for (int sample = 0; sample < Samples; sample++)
                {
                    token.ThrowIfCancellationRequested();

                    TareScale();
                    await Task.Delay(100, token);

                    // start at ZOffset before stepping
                    // we'll move to each step position first, then read force
                    for (int step = 0; step < steps; step++)
                    {
                        token.ThrowIfCancellationRequested();

                        float targetPos = ZOffset - (step * StepSize);

                        // move to the target position, then wait proportional to step size
                        MoveAbsolute("Z", targetPos);
                        await Task.Delay((int)Math.Ceiling(700 * StepSize), token);

                        // record as down stroke
                        upStroke = 0;

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
                    }

                    token.ThrowIfCancellationRequested();

                    // Up stroke: move from deepest point back to start, reading after each move.
                    for (int step = steps - 1; step >= 0; step--)
                    {
                        token.ThrowIfCancellationRequested();

                        float targetPos = ZOffset - (step * StepSize);

                        // move to the target position, wait for settle
                        MoveAbsolute("Z", targetPos);
                        await Task.Delay((int)Math.Ceiling(700 * StepSize), token);

                        // record as up stroke
                        upStroke = 1;

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
                    }

                    // lift a bit between samples
                    MoveAbsolute("Z", ZOffset + 2);
                    await Task.Delay(700 * 2, token);
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
                var avgSeries = Average_Chart.Series.Add("Down Stroke");
                avgSeries.Points.Clear();
                avgSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                avgSeries.BorderWidth = 2;
                avgSeries.Name = "Down Stroke";

                // Pre-populate points so index == step always valid (works with descending upstroke)
                if (steps > 0 && stepPosition != null)
                {
                    for (int s = 0; s < steps; s++)
                    {
                        avgSeries.Points.AddXY(stepPosition[s], 0.0);
                    }
                }

                avgSeries = Average_Chart.Series.Add("Up Stroke");
                avgSeries.Points.Clear();
                avgSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                avgSeries.BorderWidth = 2;
                avgSeries.Name = "Up Stroke";

                if (steps > 0 && stepPosition != null)
                {
                    for (int s = 0; s < steps; s++)
                    {
                        avgSeries.Points.AddXY(stepPosition[s], 0.0);
                    }
                }

                if (Average_Chart.ChartAreas.Count > 0)
                {
                    var area = Average_Chart.ChartAreas[0];
                    area.AxisX.LabelStyle.Format = "F2";

                    // FIXED Y range: 0..100
                    area.AxisY.Minimum = 0;
                    area.AxisY.Maximum = 100;
                    // Optional: set a reasonable interval for ticks
                    area.AxisY.Interval = 10;

                    // keep X auto-scaling (clear to allow dynamic X range)
                    area.AxisX.Minimum = double.NaN;
                    area.AxisX.Maximum = double.NaN;
                }
            }
        }

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

                    // keep Y axis fixed (0..100) — only autoscale X axis
                    area.AxisX.Minimum = double.NaN;
                    area.AxisX.Maximum = double.NaN;
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
            if (CommLink_SerialPort == null || !CommLink_SerialPort.IsOpen)
            {
                Status_TextBox.AppendText("Scale port not open — cannot tare." + Environment.NewLine);
                return;
            }

            byte[] tareCommand = { 0x02 };
            TrySerialWrite(CommLink_SerialPort, () => CommLink_SerialPort.Write(tareCommand, 0, 1), CommLink_SerialPort.PortName);
            Status_TextBox.AppendText("Tareing scale" + Environment.NewLine);
        }


        private void CommLink_SerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                string raw = CommLink_SerialPort.ReadLine();
                // Try parse numeric force value; be tolerant of non-numeric responses
                float parsedForce;
                bool parsed = float.TryParse(raw, out parsedForce);

                // Update force variable only if parse succeeded
                if (parsed)
                    force = parsedForce;

                // Append the raw line to RX textbox (UI thread)
                RX_TextBox.BeginInvoke(new Action(() =>
                    RX_TextBox.AppendText((parsed ? parsedForce.ToString() : raw) + Environment.NewLine)));

                // Signal getForce completion if someone is waiting (thread-safe exchange)
                var tcs = System.Threading.Interlocked.Exchange(ref _getForceTcs, null);
                if (tcs != null)
                {
                    try { tcs.TrySetResult(true); } catch { /* swallow */ }
                }
            }
            catch (IOException ioex)
            {
                // IO exception — log and release waiting tcs to avoid deadlock
                RX_TextBox.BeginInvoke(new Action(() => RX_TextBox.AppendText("CommLink IO error: " + ioex.Message + Environment.NewLine)));
                var tcs = System.Threading.Interlocked.Exchange(ref _getForceTcs, null);
                if (tcs != null)
                {
                    try { tcs.TrySetResult(true); } catch { }
                }
            }
            catch (Exception ex)
            {
                // Any unexpected exception must be logged and should not kill the serial thread.
                RX_TextBox.BeginInvoke(new Action(() => RX_TextBox.AppendText("CommLink DataReceived error: " + ex.Message + Environment.NewLine)));
                var tcs = System.Threading.Interlocked.Exchange(ref _getForceTcs, null);
                if (tcs != null)
                {
                    try { tcs.TrySetResult(true); } catch { }
                }
            }
        }

        private void Tare_Button_Click(object sender, EventArgs e)
        {
            TareScale();
        }


        private void GetPos_Button_Click(object sender, EventArgs e)
        {
            TrySerialWrite(CommLink2_SerialPort, () =>
            {
                CommLink2_SerialPort.Write("M114 " + Environment.NewLine);
                Tx2_TextBox.AppendText("M114 " + Environment.NewLine);
            }, CommLink2_SerialPort?.PortName);
        }

        private void ProfileSave_Button_Click(object sender, EventArgs e)
        {
            // Prompt for a profile name using the existing Prompt class
            string profileName = Prompt.ShowDialog("Enter profile name:", "Save Profile", "");
            if (string.IsNullOrWhiteSpace(profileName))
            {
                // user cancelled or entered nothing
                return;
            }

            string zValue = ZOffset_ComboBox.Text;
            string travelValue = Travel_ComboBox.Text;

            if (_profiles.ContainsKey(profileName))
            {
                var result = MessageBox.Show($"Profile '{profileName}' already exists. Overwrite?", "Confirm Overwrite", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                    return;

                _profiles[profileName] = (zValue, travelValue);
            }
            else
            {
                _profiles.Add(profileName, (zValue, travelValue));
                Profile_ComboBox.Items.Add(profileName);
            }

            // Select the saved profile
            Profile_ComboBox.SelectedItem = profileName;
            Status_TextBox.AppendText($"Profile '{profileName}' saved (ZOffset={zValue}, Travel={travelValue}).{Environment.NewLine}");

            // persist to disk
            SaveProfiles();
        }

        private void Profile_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sel = Profile_ComboBox.SelectedItem;
            if (sel == null) return;

            string profileName = sel.ToString();
            if (!_profiles.TryGetValue(profileName, out var values)) return;

            // Apply profile values to the comboboxes
            ZOffset_ComboBox.Text = values.ZOffset;
            Travel_ComboBox.Text = values.Travel;

            Status_TextBox.AppendText($"Profile '{profileName}' loaded (ZOffset={values.ZOffset}, Travel={values.Travel}).{Environment.NewLine}");
        }

        private string ProfilesFilePath()
        {
            var dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "switchTester");
            try { Directory.CreateDirectory(dir); } catch { /* best-effort */ }
            return Path.Combine(dir, "profiles.xml");
        }

        private void SaveProfiles()
        {
            try
            {
                var list = _profiles.Select(kv => new ProfileEntry(kv.Key, kv.Value.ZOffset, kv.Value.Travel)).ToList();
                var path = ProfilesFilePath();
                using (var fs = File.Create(path))
                {
                    var xs = new System.Xml.Serialization.XmlSerializer(typeof(List<ProfileEntry>));
                    xs.Serialize(fs, list);
                }
            }
            catch (Exception ex)
            {
                Status_TextBox.AppendText("Error saving profiles: " + ex.Message + Environment.NewLine);
            }
        }

        private void LoadProfiles()
        {
            try
            {
                var path = ProfilesFilePath();
                if (!File.Exists(path)) return;

                List<ProfileEntry> list;
                using (var fs = File.OpenRead(path))
                {
                    var xs = new System.Xml.Serialization.XmlSerializer(typeof(List<ProfileEntry>));
                    list = (List<ProfileEntry>)xs.Deserialize(fs);
                }

                _profiles.Clear();
                Profile_ComboBox.Items.Clear();

                foreach (var p in list)
                {
                    if (string.IsNullOrWhiteSpace(p?.Name)) continue;
                    _profiles[p.Name] = (p.ZOffset ?? string.Empty, p.Travel ?? string.Empty);
                    Profile_ComboBox.Items.Add(p.Name);
                }
            }
            catch (Exception ex)
            {
                Status_TextBox.AppendText("Error loading profiles: " + ex.Message + Environment.NewLine);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try { SaveProfiles(); } catch { /* swallow - logging already handled in SaveProfiles */ }
            base.OnFormClosing(e);
        }
    }

    public class ProfileEntry
    {
        public string Name { get; set; }
        public string ZOffset { get; set; }
        public string Travel { get; set; }

        public ProfileEntry() { }

        public ProfileEntry(string name, string z, string t)
        {
            Name = name;
            ZOffset = z;
            Travel = t;
        }
    }

    static class Prompt
    {
        public static string ShowDialog(string text, string caption, string defaultValue = "")
        {
            using (var form = new Form())
            using (var label = new Label())
            using (var textBox = new System.Windows.Forms.TextBox())
            using (var ok = new System.Windows.Forms.Button())
            using (var cancel = new System.Windows.Forms.Button())
            {
                form.Text = caption;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterParent;
                form.ClientSize = new Size(400, 120);
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.ShowInTaskbar = false;
                form.AcceptButton = ok;
                form.CancelButton = cancel;

                label.Text = text;
                label.SetBounds(9, 10, 380, 20);

                textBox.Text = defaultValue;
                textBox.SetBounds(12, 35, 376, 20);
                textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

                ok.Text = "OK";
                ok.DialogResult = DialogResult.OK;
                ok.SetBounds(228, 70, 80, 24);
                ok.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

                cancel.Text = "Cancel";
                cancel.DialogResult = DialogResult.Cancel;
                cancel.SetBounds(312, 70, 80, 24);
                cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

                form.Controls.AddRange(new Control[] { label, textBox, ok, cancel });

                var result = form.ShowDialog();
                return result == DialogResult.OK ? textBox.Text.Trim() : null;
            }
        }
    }
}
