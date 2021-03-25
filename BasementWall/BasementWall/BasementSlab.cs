using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;

namespace BasementWall
{
    public class BasementSlab : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the BasementSlab class.
        /// </summary>
        public BasementSlab()
          : base("BasementSlab", "BS",
              "Slab of basement",
              "Basement Wall", "Basement wall caculation")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBrepParameter("Slab", "S", "Slab of basement", GH_ParamAccess.item);
            pManager.AddNumberParameter("Thickness", "T", "Thickness of slab", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddBrepParameter("Slab Brep", "SB", "Slab geometry", GH_ParamAccess.list);
            pManager.AddGenericParameter("Slab", "S", "Slab", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Brep slabBrep = new Brep();
            double slabThickness = 120;

            if (!DA.GetData(0, ref slabBrep)) { return; }
            if (!DA.GetData(1, ref slabThickness)) { return; }

            Slab slab = new Slab();
            slab.SlabSurface = slabBrep;
            slab.Thickness = slabThickness;

            List<Brep> slabGeo= slab.CreateSlabBrep();
            DA.SetDataList(0, slabGeo);
            DA.SetData(1, slab);
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
            get { return new Guid("5b1d4439-860d-4a58-9781-03654222a5c4"); }
        }
    }
}