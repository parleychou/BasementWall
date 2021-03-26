using Grasshopper;
using Grasshopper.GUI;
using Grasshopper.GUI.Canvas;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Attributes;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BasementWall
{
    public class BasementComponent : GH_Component
    {
        public double solidGravity = 18;
        public double waterGravity = 10;
        public double solidWaterGravity = 11;
        public double deadLoad = 0;
        public double liveLoad = 8;
        public double deadLoadParam = 1.3;
        public double liveLoadParam = 1.5;
        public double solidParam = 0.3;

        /// <summary>
        /// Initializes a new instance of the BasementComponent class.
        /// </summary>
        public BasementComponent()
          : base("Basement", "BS",
              "Basement Model",
              "Basement Wall", "Basement wall caculation")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Elements", "E", "Basement elements", GH_ParamAccess.list);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Model", "M", "Model elements", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<object> objects = new List<object>();
            DA.GetDataList(0, objects);

            BasementModel model = new BasementModel();
            model.solidGravity = this.solidGravity;
            model.waterGravity = this.waterGravity;
            model.solidWaterGravity = this.solidWaterGravity;
            model.deadLoad = this.deadLoad;
            model.liveLoad = this.liveLoad;
            model.deadLoadParam = this.deadLoadParam;
            model.liveLoadParam = this.liveLoadParam;
            model.solidParam = this.solidParam;
            foreach (GH_ObjectWrapper output in objects)
            {
                if (output == null) { continue; }
                var objectList = output.Value;
                Type type = objectList.GetType();
                if (type==typeof(BasementWall))
                {                  
                      model.walls.Add((BasementWall)objectList);
                }
                else if (type==typeof(Slab))
                {                 
                    model.slabs.Add((Slab)objectList);
                }
                else if (type==typeof(Solid))
                {
                    model.solids.Add((Solid)objectList);
                }
            }
            DA.SetData(0, model);
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
            get { return new Guid("c91f4c8f-f02c-47ec-be59-e07fca83c3e1"); }
        }
        public override void CreateAttributes()
        {
            m_attributes = new BasementComponentAtrribute(this);
        }
    }
    public class BasementComponentAtrribute : GH_ComponentAttributes
    {
        public BasementComponentAtrribute(BasementComponent owner) : base(owner)
        {
        }
        public override GH_ObjectResponse RespondToMouseDoubleClick(GH_Canvas sender, GH_CanvasMouseEvent e)
        {
            if (IsMenuRegion(e.CanvasLocation))
            {
                Parameters form = new Parameters(this.Owner);
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