using Grasshopper.GUI;
using Grasshopper.GUI.Canvas;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Attributes;
using Rhino.Geometry;
using Rhino.Geometry.Collections;
using System;
using System.Collections.Generic;
using System.Drawing;


// In order to load the result of this wizard, you will also need to
// add the output bin/ folder of this project to the list of loaded
// folder in Grasshopper.
// You can use the _GrasshopperDeveloperSettings Rhino command for that.

namespace BasementWall
{
    public class BasementWallComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        internal RebarClass rebarClass = RebarClass.HRB400;
        internal ConcreteClass concreteClass = ConcreteClass.C40;
        internal double rebarRation = 0.2;
        internal double concreteThickness = 15;
        internal double crack = 0.3;
        public BasementWallComponent()
          : base("BasementWall", "BW",
              "Basement wall caculation",
              "Basement Wall", "Basement wall caculation")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBrepParameter("Wall", "W", "Wall element", GH_ParamAccess.item);
            pManager.AddNumberParameter("Thickness", "T", "Wall thickness", GH_ParamAccess.item);
            pManager.AddNumberParameter("Offset", "O", "Offset of wall", GH_ParamAccess.item);
            pManager[2].Optional = true;
            
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddBrepParameter("Wall Brep", "WB", "3D wall", GH_ParamAccess.list);
            pManager.AddGenericParameter("Wall", "W", "Wall element", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Brep wallSurface = null ;
            double thickness = 0;
            double offset = 0;
            if (!DA.GetData(0, ref wallSurface)) { return; }
            if (!DA.GetData(1, ref thickness)) { return; }
            DA.GetData(2, ref offset);

            BasementWall wall = new BasementWall();
            wall.Wall = wallSurface;
            wall.Offset = offset;
            wall.Thickness = thickness;
            wall.concreteClass = this.concreteClass;
            wall.rebarClass = this.rebarClass;
            wall.crack = this.crack;
            wall.concreteThickness = this.concreteThickness;
            wall.rebarRation = this.rebarRation;
            List<Brep> wallItem = wall.CreateWallBrep();
            
            DA.SetDataList(0,wallItem);
            DA.SetData(1, wall);
            
        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("74c9321d-15a8-4c94-8fd6-325016501636"); }
        }

        public override void CreateAttributes()
        {
            m_attributes = new BasementWallAtrribute(this);
        }
    }

    public class BasementWallAtrribute : GH_ComponentAttributes
    {
        public BasementWallAtrribute(BasementWallComponent owner) :base(owner)
        { }
        public override GH_ObjectResponse RespondToMouseDoubleClick(GH_Canvas sender, GH_CanvasMouseEvent e)
        {
            if (IsMenuRegion(e.CanvasLocation))
            {
                WallProp form = new WallProp(this.Owner);
                form.Show();

                return GH_ObjectResponse.Handled;
            }
            else
            {
                return GH_ObjectResponse.Ignore;
            }
        }
    }
}
