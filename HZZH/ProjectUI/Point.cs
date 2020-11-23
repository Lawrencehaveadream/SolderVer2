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
        /// 加载打磨点
        /// </summary>
        /// <param name="f4s"></param>
        private void LoadtreeViewPolish(List<PolishModel> f4s,int num)
        {
            int count = 0;
            int modelindex = 0;
            foreach (PolishModel p in f4s)
            {
                modelindex++;
                this.treeView1.Nodes[num].Nodes.Add(new TreeNode("模板" + modelindex.ToString()));
                foreach (PolishDef item in p.polishData)
                {
                    count++;
                    this.treeView1.Nodes[num].Nodes[modelindex - 1].Nodes.Add(new TreeNode("点位" + count.ToString()));
                }
            }
        }
        /// <summary>
        /// 焊锡点
        /// </summary>
        /// <param name="f4s"></param>
        /// <param name="num"></param>
        private void LoadtreeViewSolder(List<SolderModel> f4s, int num)
        {
            int count = 0;
            int modelindex = 0;
            foreach (SolderModel p in f4s)
            {
                modelindex++;
                this.treeView1.Nodes[num].Nodes.Add(new TreeNode("模板"));
                foreach (SolderDef item in p.solderdata)
                {
                    count++;
                    this.treeView1.Nodes[num].Nodes[modelindex - 1].Nodes.Add(new TreeNode("点位" + count.ToString()));
                }
            }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int rowcount = treeView1.SelectedNode.Index;
            
            try
            {
                switch (treeView1.SelectedNode.Parent.Parent.Index)
                {
                    case 0:
                        int a = treeView1.SelectedNode.Parent.Index;
                        propertyGrid1.SelectedObject = ProjectData.Instance.SaveData.processdata.LPolishModel[a].polishData[rowcount];
                        break;
                    case 1:
                        int b = treeView1.SelectedNode.Parent.Index;
                        propertyGrid1.SelectedObject = ProjectData.Instance.SaveData.processdata.RPolishModel[b].polishData[rowcount];
                        break;
                    case 2:
                        int c = treeView1.SelectedNode.Parent.Index;
                        propertyGrid1.SelectedObject = ProjectData.Instance.SaveData.processdata.LSolderModel[c].solderdata[rowcount];
                        break;
                    case 3:
                        int d = treeView1.SelectedNode.Parent.Index;
                        propertyGrid1.SelectedObject = ProjectData.Instance.SaveData.processdata.RSolderModel[d].solderdata[rowcount];
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("当前平台没有点位可以编辑");
            }
        }
        /// <summary>
        /// 窗体加载时默认加载左侧打磨模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Point_Load()
        {
            this.treeView1.Nodes.Clear();
            this.treeView1.Nodes.Add(new TreeNode("左打磨"));
            this.treeView1.Nodes.Add(new TreeNode("右打磨"));
            this.treeView1.Nodes.Add(new TreeNode("左焊锡"));
            this.treeView1.Nodes.Add(new TreeNode("右焊锡"));
            LoadtreeViewPolish(ProjectData.Instance.SaveData.processdata.LPolishModel, 0);
            LoadtreeViewPolish(ProjectData.Instance.SaveData.processdata.RPolishModel, 1);
            LoadtreeViewSolder(ProjectData.Instance.SaveData.processdata.LSolderModel, 2);
            LoadtreeViewSolder(ProjectData.Instance.SaveData.processdata.RSolderModel, 3);
            treeView1.ExpandAll();
        }
    }
}
