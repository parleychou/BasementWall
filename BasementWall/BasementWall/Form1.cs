using Grasshopper.Kernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasementWall
{
    public partial class Form1 : Form
    {
        public IGH_Component component;
        public Form1(IGH_Component component)
        {
            InitializeComponent();
            this.component = component;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            //this.component.ComputeData();
            int rebarItem= this.rebarClass.SelectedIndex;
            //(component as BasementWallComponent).rebarClass ;
            (component as BasementWallComponent).OnPingDocument().ScheduleSolution(1, doc => {
                component.ExpireSolution(false);
            });
            this.Dispose();
        }
    }
}
