using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;

namespace BasementWall
{
    public class SolidComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the SolidComponent class.
        /// </summary>
        public SolidComponent()
          : base("BasementSolid", "S",
              "Out door solid level",
              "Basement Wall", "Basement wall caculation")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBrepParameter("Ground Surface", "GS", "Outdoor ground surface", GH_ParamAccess.item);
            pManager.AddNumberParameter("Water Level", "WL", "Water level of ground", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Ground", "G", "Ground ", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Brep surface = null;
            double waterLevel = 0;
            if (!DA.GetData(0, ref surface)) { return; }
            if (!DA.GetData(1, ref waterLevel)) { return; }

            Solid solid = new Solid();

            solid.SolidSurface = surface;
            solid.WaterLevel = waterLevel;
            DA.SetData(0, solid);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("fd1972c2-76d5-4ebb-93e5-d069e9230758"); }
        }
    }
}