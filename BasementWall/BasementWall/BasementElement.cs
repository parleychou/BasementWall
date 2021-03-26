using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cgiSolverBlazeCli;
using Rhino.Geometry;
using Rhino.Geometry.Collections;
namespace BasementWall
{
    public class BasementElement
    {
    }
    public class BasementWall : BasementElement
    {
        //
        private Brep wall;
        private double thickness;
        private double offset;
        public Brep WallBrep { get; set; }
        public Brep Wall {
            get { return wall; }
            set { wall = value; }
        }
        public double Thickness
        {
            get { return thickness; }
            set { thickness = value; }
        }
        public double Offset
        {
            get { return offset; }
            set { offset = value; }
        }
        internal RebarClass rebarClass { get; set; }
        internal ConcreteClass concreteClass { get; set; }
        internal double rebarRation { get; set; }
        internal double concreteThickness { get; set; }
        internal double crack { get; set; }
        public List<Brep> CreateWallBrep()
        {
            double offsetDistance1 = this.thickness / 2 + offset;
            double offsetDistance2 = this.thickness / 2 - offset;
            List<Brep> solids = new List<Brep>();
            Brep solid = new Brep();
            for (int i = 0; i < this.wall.Surfaces.Count; i++)
            {              
                Surface offsetSurface1 = this.wall.Surfaces[i].Offset(offsetDistance1, Rhino.RhinoDoc.ActiveDoc.ModelAbsoluteTolerance);
                Surface offsetSurface2 = this.wall.Surfaces[i].Offset(-1 * offsetDistance2, Rhino.RhinoDoc.ActiveDoc.ModelAbsoluteTolerance);

                List<Brep> solidBreps = new List<Brep>();

                Brep wallBrep1 = offsetSurface1.ToBrep();
                BrepEdgeList brepEdges1 = wallBrep1.Edges;

                Brep wallBrep2 = offsetSurface2.ToBrep();
                BrepEdgeList brepEdges2 = wallBrep2.Edges;

                solidBreps.Add(wallBrep1);
                solidBreps.Add(wallBrep2);

                BrepFace wallSurface = wallBrep1.Faces[0];
                solids.Add( Brep.CreateFromOffsetFace(wallSurface, -1 * this.thickness, Rhino.RhinoDoc.ActiveDoc.ModelAbsoluteTolerance, false, true));
            }

            return solids;
        }
    }
    public class Slab : BasementElement
    {
        private Brep slabSurface;
        private double thickness;
        public Brep SlabSurface
        {
            get { return slabSurface; }
            set { slabSurface = value; }
        }
        public double Thickness
        {
            get { return thickness; }
            set { thickness = value; }
        }
        public List<Brep> CreateSlabBrep()
        {
            List<Brep> newBreps = new List<Brep>();
            BrepFaceList faces = this.slabSurface.Faces;
            for (int faceID = 0; faceID < faces.Count; faceID++)
            {
                BrepFace faceItem = faces[faceID];
                Point3d cornerPoint = faceItem.Brep.Vertices[0].Location;
                //Transform transform= Transform.Translation(00, 0, -1 * thickness);
                //cornerPoint.Transform(transform);
                Curve extrudeCurve = new Line(cornerPoint,new Vector3d(0,0,-1*this.thickness)).ToNurbsCurve();
                newBreps.Add( faceItem.CreateExtrusion(extrudeCurve, true));
            }
            return newBreps;
        }
    }
    public class Solid : BasementElement
    {
        private Brep solidSurface;
        private double waterLevel;
        public Brep SolidSurface
        {
            get { return solidSurface; }
            set { solidSurface = value; }
        }
        public double WaterLevel
        {
            get { return waterLevel; }
            set { waterLevel = value; }
        }
    }
    public class BasementModel : BasementElement
    {
        public double solidGravity { get; set; }
        public double waterGravity { get; set; }
        public double solidWaterGravity  { get; set; }
        public double deadLoad { get; set; }
        public double liveLoad { get; set; }
        public double deadLoadParam { get; set; }
        public double liveLoadParam { get; set; }
        public double solidParam { get; set; }
        public BasementModel()
        {
            solids = new List<Solid>();
            slabs = new List<Slab>();
            walls = new List<BasementWall>();
        }

        public List<Solid> solids;
        public List<Slab> slabs;
        public List<BasementWall> walls;
    }
    enum ConcreteClass { C25,C30,C35,C40,C45,C50,C55,C60}
    enum RebarClass {HPB300,HRB335,HRB400}
}
