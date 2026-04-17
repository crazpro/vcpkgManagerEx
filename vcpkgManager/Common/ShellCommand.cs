using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace vcpkgManager.Common
{
    /// <summary>
    /// 运行指令并将指令重定向到指定的位置
    /// </summary>
    public class ShellCommand
    {
        private Process ownerProc = null;

        /// <summary>
        /// 运行指令，如果不设置重定向函数则不会进行重定向 仅仅后台运行
        /// </summary>
        /// <param name="exec">运行程序</param>
        /// <param name="args">参数</param>
        /// <param name="recvHander">CALLBACK参数</param>
        /// <param name="exited">结束时通知</param>
        /// <returns>是否运行成功</returns>
        public bool RunShell(string exec, string args, DataReceivedEventHandler recvHander = null,EventHandler exited = null)
        {
           if(ownerProc == null)
            {
                ownerProc = new Process();
                ownerProc.StartInfo.CreateNoWindow = true; // 无窗口
                ownerProc.StartInfo.UseShellExecute = false;
                ownerProc.StartInfo.FileName = exec;
                ownerProc.StartInfo.Arguments = args;
                //ownerProc.StartInfo.WorkingDirectory = ".";

                ownerProc.EnableRaisingEvents = true;
                ownerProc.Exited += exited;
               // ownerProc.StartInfo.RedirectStandardInput = true;

                // 重定向输出
                if (recvHander != null)
                {
                    ownerProc.StartInfo.RedirectStandardOutput = true;
                    ownerProc.OutputDataReceived += recvHander; // 进行重定向

                    ownerProc.StartInfo.RedirectStandardError = true;
                    ownerProc.ErrorDataReceived += recvHander; // 进行重定向

                    ownerProc.StartInfo.StandardOutputEncoding = Encoding.GetEncoding("GBK");
                    ownerProc.StartInfo.StandardErrorEncoding = Encoding.GetEncoding("GBK");
                }

                bool isRet = ownerProc.Start(); // 运行
                ownerProc.BeginOutputReadLine();
                ownerProc.BeginErrorReadLine();

                //ownerProc.StandardInput.WriteLine(exec + " " + args); // 执行语句

                return isRet;
            }

            return false;
        }

        /// <summary>
        /// 是否已经执行完毕
        /// </summary>
        /// <returns>执行完毕否</returns>
        public bool IsExited()
        {
            if(ownerProc != null)
            {
                return ownerProc.HasExited;
            }

            return true;
        }

        /// <summary>
        /// 用于快速分析使用的一次运行数据，不做持续输出行为，会阻塞
        /// </summary>
        /// <param name="exec">执行程序</param>
        /// <param name="args">参数</param>
        /// <returns>控制台输出的文本内容</returns>
        public static string RunShellOnce(string exec, string args)
        {
            Process nowProc = new Process();
            nowProc.StartInfo.CreateNoWindow = true; // 无窗口
            nowProc.StartInfo.UseShellExecute = false;
            nowProc.StartInfo.FileName = exec;
            nowProc.StartInfo.Arguments = args;

            // 重定向输出
            nowProc.StartInfo.RedirectStandardOutput = true;
            nowProc.StartInfo.RedirectStandardError = true;
            nowProc.Start();
            string output = nowProc.StandardOutput.ReadToEnd();
            string error = nowProc.StandardError.ReadToEnd();
            nowProc.WaitForExit();


            nowProc.Close();

            return output;
        }

        /// <summary>
        /// 关闭这个进程，只要运行的话
        /// </summary>
        public void Cancel()
        {
            if (ownerProc != null)
            {
                if(ownerProc.HasExited == false)
                {
                    ownerProc.Kill(); // 关闭程序
                }

                ownerProc.Close();
                ownerProc = null;
            }
        }
    }
}
