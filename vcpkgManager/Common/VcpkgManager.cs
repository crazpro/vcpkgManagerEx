using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;

namespace vcpkgManager.Common
{
    public class lVcpkgManager
    {
        #region 单件部分
        private static volatile lVcpkgManager _instance = null;
        private static object objLock = new Object();
        public static lVcpkgManager Ins
        {
            get
            {
                if (_instance == null)
                {
                    lock (objLock)
                    {
                        _instance = new lVcpkgManager();
                    }
                }
                return _instance;
            }
        }
        #endregion

        // 远端路径
        private string GitVcpkgUrl = "https://github.com/Microsoft/vcpkg.git";
        private string GitPath = "C:\\Program Files\\Git\\cmd\\git.exe"; // 动态获得Git路径

        // Vcpkg的路径
        private string VcpkgPath = "";

        /// <summary>
        /// 安装Git路径 自动检测以及其他数据
        /// </summary>
        /// <param name="vcpkgDir">vcpkg路径</param>
        /// <returns>安装是否成功</returns>
        public bool setupGit()
        {
            GitPath = SoftwareChecker.getGitPath(); // 获得本地git路径

            return SoftwareChecker.checkGit();
        }

        public bool setupVcpkg(string vcpkgDir)
        {
            if (SoftwareChecker.checkTargetVcpkg(vcpkgDir) == false)
            {
                return false;
            }

            VcpkgPath = vcpkgDir + "\\vcpkg.exe";
            return true;
        }

        /// <summary>
        /// 是否安装过git，否则提示他安装
        /// </summary>
        /// <returns>是否安装</returns>
        public bool IsGitSetup()
        {
            return SoftwareChecker.checkGit();
        }

        /// <summary>
        /// 根据git代码克隆对应的vcpkg路径
        /// </summary>
        /// <param name="targetPath">clone到哪里</param>
        /// <param name="recvHander">重定向的控制台数据</param>
        /// <returns>返回是否克隆成功</returns>
        public bool gitCloneVcpkg(string targetPath,bool useDialog = true,DataReceivedEventHandler recvHander = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("clone --progress -v \"{0}\" \"{1}\"", GitVcpkgUrl, targetPath);

            if(useDialog == false)
            {
                // Git安装源码
                ShellCommand shellRun = new ShellCommand();

                return shellRun.RunShell(GitPath, sb.ToString(), recvHander);
            }else
            {
                ShowProcessFrm.RunShell(GitPath, sb.ToString());

                return true;
            }
        }

        /// <summary>
        /// 安装setupVcpkg代码并编译
        /// </summary>
        /// <param name="recvHander">接收数据重定向</param>
        /// <returns>是否安装成功</returns>
        public bool buildVcpkg(string targetPath, bool useDialog = true, DataReceivedEventHandler recvHander = null)
        {
            if (useDialog == false)
            {
                // Git安装源码
                ShellCommand shellRun = new ShellCommand();

                return shellRun.RunShell(targetPath + "\\bootstrap-vcpkg.bat", "", recvHander);
            }
            else
            {
                ShowProcessFrm.RunShell(targetPath + "\\bootstrap-vcpkg.bat", "");

                return true;
            }
        }

        public void InstallToAll(bool useDialog = true, DataReceivedEventHandler recvHander = null)
        {
            if (useDialog == false)
            {
                ShellCommand shellRun = new ShellCommand();

                shellRun.RunShell(VcpkgPath, "integrate install", recvHander);
            }
            else
            {
                ShowProcessFrm.RunShell(VcpkgPath, "integrate install");
            }
        }

        public void RemovePackage(string pkname)
        {
            ShowProcessFrm.RunShell(VcpkgPath, "remove " + pkname);
        }

        public void InstallPackage(string pkname)
        {
            ShowProcessFrm.RunShell(VcpkgPath, "install " + pkname);
        }


        /// <summary>
        /// 检索VCPKG
        /// </summary>
        /// <param name="searchKey"></param>
        /// <returns></returns>
        public async Task<ArrayList> searchVcpkg(string searchKey)
        {
            ArrayList ctxt = new ArrayList();
            var context = await runVcpkg("search " + searchKey);
            var lines = context.Split(new string[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

            if (lines.Length <= 2)
            {
                return ctxt;
            }

            foreach (var inLine in lines)
            {
                string strName = "";  //类库名称
                string strversion = "";  //版本号
                string strDesc = "";  //描述

                var varData = inLine.Split(new string[] { "  " }, StringSplitOptions.RemoveEmptyEntries);
                if (varData.Length >= 3)
                {
                    strName = varData[0].Trim();
                    strversion = varData[1].Trim();
                    strDesc = varData[2].Trim();
                }
                else if (varData.Length == 2)
                {
                    strName = varData[0].Trim();
                    strversion = "";
                    strDesc = varData[1].Trim();
                }
                else
                {
                    continue;
                }

                ctxt.Add(new[] { strName, strversion, strDesc });

            }

            return ctxt;
        }

        public async Task<string> runVcpkg(string args)
        {
            return await Task.Run(
              () =>
              {
                  return ShellCommand.RunShellOnce(VcpkgPath, args);
              });
        }

        public async Task<string> getVcpkgList()
        {
            return await runVcpkg("list");
        }


        public async Task<ArrayList> getVcpkgArray()
        {
            ArrayList ctxt = new ArrayList();
            var context = await getVcpkgList();

            if (context.Contains("No packages are installed"))
            {
                return ctxt;
            }

            var lines = context.Split(new string[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
            if(lines.Length > 0)
            {
                foreach(var inLine in lines)
                {
                    var varData = inLine.Split(new string[] { "  " }, StringSplitOptions.RemoveEmptyEntries);
                    if (varData.Length >= 3)
                    {
                        ctxt.Add(varData);
                    }
                }
            }

            return ctxt;
        }
    }
}
