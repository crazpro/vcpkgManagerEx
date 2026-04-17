using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace vcpkgManager.Common
{
    /// <summary>
    /// 软件环境检测程序
    /// </summary>
    public class SoftwareChecker
    {
        public static string getGitPath()
        {
            string szPath = Environment.GetEnvironmentVariable("Path");
            string[] szPathList = szPath.Split(';');

            foreach (var val in szPathList)
            {
                int nPos = val.IndexOf("\\Git\\");
                if (nPos != -1)
                {
                    if (File.Exists(val + "\\git.exe"))
                    {
                        return val + "\\git.exe";
                    }
                }
            }

            return "";
        }


        // 检测Git是否安装
        public static bool checkGit()
        {
            if (getGitPath() != "")
            {
                return true;
            }

            return false;
        }

        // 检测目标目录下是否存在Vcpkg
        public static bool checkTargetVcpkg(string szTargetPath)
        {
            string szTmpFile = szTargetPath.Replace("/", "\\");
            if (szTmpFile[szTmpFile.Length - 1] == '\\')
                szTmpFile = szTmpFile.Substring(0, szTmpFile.Length - 1);
            return File.Exists(szTmpFile + "\\vcpkg.exe"); 
        }
    }
}
