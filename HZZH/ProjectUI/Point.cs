using ProVisionEbd.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HZZH.ProjectUI
{
    public partial class Point : Form
    {
        public Point()
        {
            InitializeComponent();
        }
        private void init()
        {
            treeView1.HideSelection = false;
            treeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;
            treeView1.DrawNode += new DrawTreeNodeEventHandler(treeView1_DrawNode);
        }
        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = true;
            return;
        }
        /// <summary>
        /// 加载点位
        /// </summary>
        /// <param name="f4s"></param>
        private void LoadtreeView1(VisisonData f4s)
        {
            int count = 0;
            this.treeView1.Nodes.Clear();
            foreach (Model p in f4s.model)
            {
                foreach (var item in p.Pos)
                {
                    count++;
                    this.treeView1.Nodes[0].Nodes.Add(new TreeNode("点位" + count.ToString() +
                        ":X:" + item.X.ToString("f2") +
                        ";\r\n" + "Y:" + item.Y.ToString("f2") +
                        ";\r\n" + "R:" + item.R.ToString("f2") + ";"));
                    this.treeView1.Nodes[1].Nodes.Add(new TreeNode("点位" + count.ToString() +
                        ":X:" + item.X.ToString("f2") +
                        ";\r\n" + "Y:" + item.Y.ToString("f2") +
                        ";\r\n" + "R:" + item.R.ToString("f2") + ";"));
                }
            }
        }
        int count = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            count++;
            treeView1.Nodes[0].Nodes.Add(new TreeNode("点位" + count.ToString() + ";"));
            treeView1.Nodes[1].Nodes.Add(new TreeNode("点位" + count.ToString() + ";"));
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
           int RowCount = this.treeView1.SelectedNode.Index;
            //propertyGrid1.SelectedObject = _polishPos[OperShapeIndex].pos[RowCount].polishDef;

        }
    }
}
