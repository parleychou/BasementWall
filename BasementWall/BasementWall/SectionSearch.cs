using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using System.Collections.Generic;

namespace BasementWall
{
    public class SectionSearch : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the SectionSearch class.
        /// </summary>
        public SectionSearch()
          : base("SectionSearch", "SS",
              "Search section categorie",
              "Basement Wall", "Basement wall caculation")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Model", "M", "Model elements", GH_ParamAccess.item);
            pManager.AddCurveParameter("Rail", "R", "Search rail", GH_ParamAccess.list);
            pManager.AddNumberParameter("Search Length", "SL", "Section distance of section in rail", GH_ParamAccess.item);
            pManager.AddNumberParameter("Section Height", "SH", "Height of section", GH_ParamAccess.item, 10000);
            //pManager.AddNumberParameter();
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Sections", "S", "Sections of walls", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            BasementModel model = new BasementModel();
            List<Curve> rails = new List<Curve>();
            double searchLength = 0;
            double searchHeight = 0;

            if (!DA.GetData(0, ref model)) { return; }
            if (!DA.GetData(1, ref rails)) { return; }
            if (!DA.GetData(2, ref searchLength)) { return; }

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
            get { return new Guid("7e19db5a-b07c-494e-92e3-583005e9b627"); }
        }
    }
}