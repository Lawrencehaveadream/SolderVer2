using HZZH.Logic.Data;
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
            init();
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
        private void LoadtreeView1(List<PolishModel> f4s)
        {
            int count = 0;
            this.treeView1.Nodes.Clear();
            foreach (PolishModel p in f4s)
            {
                foreach (PolishDef item in p.polishData)
                {
                    count++;
                    this.treeView1.Nodes.Add(new TreeNode("点位" + count.ToString()));
                }
            }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
           int RowCount = this.treeView1.SelectedNode.Index;
            propertyGrid1.SelectedObject = ProjectData.Instance.SaveData.processdata.LPolishModel[0].polishData[RowCount];

        }
        /// <summary>
        /// 窗体加载时默认加载左侧打磨模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Point_Load(object sender, EventArgs e)
        {
            LoadtreeView1(ProjectData.Instance.SaveData.processdata.LPolishModel);
        }
    }
}
