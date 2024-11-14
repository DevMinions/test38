using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test38
{
    public partial class Form1 : Form
    {
        Form frm2, frm3, frm4;

        public Form1()
        {
            InitializeComponent();

            // 为所有菜单项（包括子菜单项）绑定统一的点击事件
            BindMenuItems(menuStrip1.Items);
        }

        // 递归绑定点击事件
        private void BindMenuItems(ToolStripItemCollection menuItems)
        {
            foreach (ToolStripItem item in menuItems)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    // 为每个菜单项绑定点击事件
                    menuItem.Click += MenuItem_Click;

                    // 如果该菜单项有子菜单（下拉菜单），递归绑定子菜单项
                    if (menuItem.DropDownItems.Count > 0)
                    {
                        BindMenuItems(menuItem.DropDownItems);
                    }
                }
            }
        }

        // 统一的菜单项点击事件处理方法
        private void MenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = sender as ToolStripMenuItem;
            if (clickedItem != null)
            {
                // 根据菜单项的名称或文本来判断是哪个菜单项被点击了
                switch (clickedItem.Text)
                {
                    case "退出":
                        MessageBox.Show("File menu clicked!");
                        break;
                    case "修改密码":
                        if(frm2==null|| frm2.IsDisposed)
                        {
                            frm2 = new Form2();
                            frm2.TopLevel = false;
                            frm2.Parent = toolStripContainer1.ContentPanel;
                            frm2.Show();
                        }
                        break;
                    case "药品清单":
                        if (frm3 == null || frm3.IsDisposed)
                        {
                            frm3 = new Form3();
                            frm3.MdiParent = this;
                            frm3.Parent = toolStripContainer1.ContentPanel;
                            frm3.Show();
                        }
                        break;
                    case "药品信息输入":
                        MessageBox.Show("View menu clicked!");
                        break;
                }
            }
        }
    }
}
