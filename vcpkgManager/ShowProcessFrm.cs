using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using vcpkgManager.Common;

namespace vcpkgManager
{
    public partial class ShowProcessFrm : Form
    {
        private ShellCommand shellRun = new ShellCommand();

        private string[] chkClsContxt =
        {
            "remote: Compressing objects:",
            "Receiving objects:",
            "Resolving deltas:"
        };

        public ShowProcessFrm()
        {
            InitializeComponent();
        }

        public static void RunShell(string exec, string args)
        {
            ShowProcessFrm frm = new ShowProcessFrm();
            frm.RunCommand(exec, args);
        }

        public void RunCommand(string exec,string args )
        {
            btnClosed.Text = "取消运行";
            runLogs.Text = ""; // 清理控制台
            shellRun.RunShell(exec, args, new DataReceivedEventHandler(OutputEventHandler),new EventHandler(ExitEventHander));

            this.ShowDialog(); // 启动窗口
        }

        protected void ExitEventHander(object sender, EventArgs e)
        {
            if (runLogs.InvokeRequired)
            {
                runLogs.Invoke(new EventHandler(ExitEventHander), new object[] { sender, e });
            }
            else
            {
                runLogs.AppendText("运行结束，请手动关闭窗口。");
                btnClosed.Text = "关闭窗口";

                timerVal.Enabled = true;
            }

        }

        protected void OutputEventHandler(object sender, DataReceivedEventArgs e)
        {
            //string szTxt = ((Process)sender).StandardOutput.ReadToEnd();
            //if(string.IsNullOrEmpty(e.Data) == false)
            //    runLogs.AppendText(e.Data + "\r\n");

            if (runLogs.InvokeRequired)
            {
                runLogs.Invoke(new DataReceivedEventHandler(OutputEventHandler), new object[]{ sender,e });
            }else
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    // 针对内容做清屏
                    ClearProcess(e.Data);

                    StringBuilder sb = new StringBuilder(this.runLogs.Text);
                    this.runLogs.Text = sb.AppendLine(e.Data).ToString();
                    this.runLogs.SelectionStart = this.runLogs.Text.Length;
                    this.runLogs.ScrollToCaret();
                }
            }
        }

        private void ClearProcess(string inProc)
        {
            foreach(var vcls in chkClsContxt)
            {
                if(inProc.Contains(vcls))
                {
                    var inPos = this.runLogs.Text.IndexOf(vcls);
                    if(inPos != -1)
                    {
                        this.runLogs.Text = this.runLogs.Text.Substring(0, inPos);
                    }

                    break;
                }
            }
        }

        private void btnClosed_Click(object sender, EventArgs e)
        {
            if (shellRun.IsExited() == false)
            {
                if (MessageBox.Show("确定终止当前运行的程序么？", "提示",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    shellRun.Cancel();
                    this.Close();
                }
            }
            else
            {
                   this.Close();
            }
        }

        private void ShowProcessFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            shellRun.Cancel();
        }

        private void timerVal_Tick(object sender, EventArgs e)
        {
            timerVal.Enabled = false;
            this.Close();
        }
    }
}
