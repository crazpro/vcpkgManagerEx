using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vcpkgManager.Common;

namespace vcpkgManager
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private async void GetVcpkg()
        {
            btnReflush.Enabled = false;
            btnRemovePkg.Enabled = false;
            var pkgList = await lVcpkgManager.Ins.getVcpkgArray();

            pkglistView.Items.Clear();
            if (pkgList.Count > 0)
            {
                foreach(string[] inVal in pkgList)
                {
                    var lvitem = pkglistView.Items.Add(inVal[0].Trim());
                    lvitem.SubItems.Add(inVal[1].Trim());
                    lvitem.SubItems.Add(inVal[2].Trim());
                }
            }

            btnReflush.Enabled = true;
            btnRemovePkg.Enabled = true;
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            SetupVcpkgFrm frm = new SetupVcpkgFrm();
            if (frm.ShowDialog() != DialogResult.OK)
            {
                this.Close();
                return;
            }

            // 刷新一次数据
            GetVcpkg();
        }


        /// <summary>
        /// 刷新已安装列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReflush_Click(object sender, EventArgs e)
        {
            GetVcpkg();
        }


        /// <summary>
        /// 移除指定的安装包
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnRemovePkg_Click(object sender, EventArgs e)
        {
            if(pkglistView.SelectedItems.Count > 0)
            {
                foreach(ListViewItem sel in pkglistView.SelectedItems)
                {
                    lVcpkgManager.Ins.RemovePackage(sel.Text);
                    break;
                }
            }

            GetVcpkg();
        }


        /// <summary>
        /// 检索按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            searchlistView.Items.Clear();
            btnSearch.Enabled = false;
            var vpPkg = await lVcpkgManager.Ins.searchVcpkg(this.txtSearchKey.Text);

            if(vpPkg.Count > 0)
            {
                foreach(string[] var in vpPkg)
                {
                    var lvitem = searchlistView.Items.Add(var[0].Trim());
                    lvitem.SubItems.Add(var[1].Trim());
                    lvitem.SubItems.Add(var[2].Trim());
                }
            }

            btnSearch.Enabled = true;
        }

        private void btnInstallAll_Click(object sender, EventArgs e)
        {
            lVcpkgManager.Ins.InstallToAll();
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            if(searchlistView.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择一个需要安装的包。");
                return;
            }

            ArrayList platformArr = new ArrayList();
            for(int i = 0;i < platformChkBox.Items.Count; i++)
            {
                if (platformChkBox.GetItemChecked(i))
                {
                    ListViewItem lvItem = searchlistView.SelectedItems[0];
                    platformArr.Add(lvItem.Text + ":" + platformChkBox.Items[i].ToString());
                }
            }

            if(platformArr.Count ==0 )
            {
                MessageBox.Show("请至少选择一个目标平台。");
                return;
            }

            string szPackage = string.Join(" ", platformArr.ToArray());

            lVcpkgManager.Ins.InstallPackage(szPackage);

            GetVcpkg();
        }
    }
}
