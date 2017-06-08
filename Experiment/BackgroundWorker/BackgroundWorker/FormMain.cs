using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackgroundWorker
{
    public partial class FormMain : Form
    {
        private ManualResetEvent manualReset = new ManualResetEvent(true);

        public FormMain()
        {
            InitializeComponent();
            textBox.ScrollBars = ScrollBars.Vertical;
            //backgroundWorker.WorkerReportsProgress = true;
            //backgroundWorker.WorkerSupportsCancellation = true;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            textBox.SelectionStart = textBox.Text.Length;
            textBox.ScrollToCaret();
        }
        private int Run(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                if (backgroundWorker.CancellationPending)
                {
                    for (int j = i; j >= 0; j--)
                    {
                        Thread.Sleep(10);
                    }
                    e.Cancel = true;
                    return -1;
                }
                manualReset.WaitOne();
                Thread.Sleep(50);
                int percent = i;
                backgroundWorker.ReportProgress(percent, i);
            }
            return -1;
        }



        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = Run(backgroundWorker, e);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            label.Text = "当前进度 " + e.ProgressPercentage + "%";
            textBox.Text += e.UserState.ToString() + "\t";
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                MessageBox.Show("Cancelled!");
            else
                MessageBox.Show("Over!");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy != true)
            {
                textBox.Clear();
                btnPause.Text = "暂停";
                progressBar.Value = 0;
                label.Text = "当前进度 0%";
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "暂停" && backgroundWorker.IsBusy == true)
            {
                manualReset.Reset();
                btnPause.Text = "继续";
            }
            else if (((Button)sender).Text == "继续")
            {
                manualReset.Set();
                btnPause.Text = "暂停";
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.WorkerSupportsCancellation == true)
            {
                manualReset.Set();
                backgroundWorker.CancelAsync();

            }
        }


    }
}
