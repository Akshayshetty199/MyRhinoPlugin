using Rhino.Geometry;

namespace MyRhinoPlugin
{
    internal class Rail
    {
        private Point3d pt1;
        private Point3d pt2;

        public Rail(Point3d pt1, Point3d pt2)
        {
            this.pt1 = pt1;
            this.pt2 = pt2;
        }
    }
}