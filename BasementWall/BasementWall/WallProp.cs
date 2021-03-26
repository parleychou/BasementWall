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
    public partial class WallProp : Form
    {
        public IGH_Component component;
        public WallProp(IGH_Component component)
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
            int rebarItem = this.rebarClass.SelectedIndex;
            int concreteClass = this.concreteClassValue.SelectedIndex;
            double concreteThickness = 15;
            double rebarRation = 0.2;
            double crack = 0.3;
            try
            {
                concreteThickness = double.Parse(this.concreteThicknessValue.Text);
                rebarRation = double.Parse(this.minRebarRation.Text);
                crack = double.Parse(this.crack.Text);
            }
            catch (Exception)
            {
                throw new Exception("输入参数有误");
            }
            BasementWallComponent com = component as BasementWallComponent;
            switch (rebarItem)
            {
                case 0:
                    com.rebarClass = RebarClass.HPB300;
                    break;
                case 1:
                    com.rebarClass = RebarClass.HRB335;
                    break;
                case 2:
                    com.rebarClass = RebarClass.HRB400;
                    break;
                default:
                    break;
            }
            switch (concreteClass)
            {
                case 0:
                    com.concreteClass = ConcreteClass.C25;
                    break;
                case 1:
                    com.concreteClass = ConcreteClass.C30;
                    break;
                case 2:
                    com.concreteClass = ConcreteClass.C35;
                    break;
                case 3:
                    com.concreteClass = ConcreteClass.C40;
                    break;
                case 4:
                    com.concreteClass = ConcreteClass.C45;
                    break;
                case 5:
                    com.concreteClass = ConcreteClass.C50;
                    break;
                case 6:
                    com.concreteClass = ConcreteClass.C55;
                    break;
                case 7:
                    com.concreteClass = ConcreteClass.C60;
                    break;
                default:
                    break;
            }
            com.concreteThickness = concreteThickness;
            com.rebarRation = rebarRation;
            com.crack = crack;
            //(component as BasementWallComponent).rebarClass;
            (component as BasementWallComponent).OnPingDocument().ScheduleSolution(1, doc => {
                component.ExpireSolution(false);
            });
            this.Close();
            this.Dispose();
           
        }
    }
}
