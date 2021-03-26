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
    public partial class Parameters : Form
    {
        public IGH_Component owner;
        public Parameters(IGH_Component owner)
        {
            this.owner = owner;
            InitializeComponent();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            BasementComponent com = this.owner as BasementComponent;
            com.solidGravity = double.Parse(this.SG.Text);
            com.waterGravity = double.Parse(this.WG.Text);
            com.solidWaterGravity = double.Parse(this.SWG.Text);
            com.deadLoad = double.Parse(this.DL.Text);
            com.liveLoad = double.Parse(this.LL.Text);
            com.deadLoadParam = double.Parse(this.RG.Text);
            com.liveLoadParam = double.Parse(this.RQ.Text);
            com.solidParam = double.Parse(this.textBox1.Text);
            com.OnPingDocument().ScheduleSolution(1, doc => {
                com.ExpireSolution(false);
            });
            this.Close();
            this.Dispose();
        }
    }
}
