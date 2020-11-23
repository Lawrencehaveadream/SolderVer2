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
                foreach (PolishDef item in p.polishData)
                {
                    count++;
                    this.treeView1.Nodes[num].Nodes.Add(new TreeNode( "模板" + modelindex.ToString() + "点位" + count.ToString()));
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
                foreach (SolderDef item in p.solderdata)
                {
                    count++;
                    this.treeView1.Nodes[num].Nodes.Add(new TreeNode("模板" + modelindex.ToString() + "点位" + count.ToString()));
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
        public void Point_Load(object sender, EventArgs e)
        {
            this.treeView1.Nodes.Clear();
            LoadtreeViewPolish(ProjectData.Instance.SaveData.processdata.LPolishModel, 0);
            LoadtreeViewPolish(ProjectData.Instance.SaveData.processdata.RPolishModel, 1);
            LoadtreeViewSolder(ProjectData.Instance.SaveData.processdata.LSolderModel, 2);
            LoadtreeViewSolder(ProjectData.Instance.SaveData.processdata.RSolderModel, 3);


        }
    }
}
