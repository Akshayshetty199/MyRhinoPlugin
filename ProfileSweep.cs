using MyRhinoPlugin;
using Rhino.Geometry;
using System;

namespace RhinoPluginProject
{
    internal class ProfileSweep
    {
        private Curve profileCurve;
        private Point3d pt1;
        private Point3d pt2;

        public ProfileSweep(Curve profileCurve, Point3d pt1, Point3d pt2)
        {
            this.profileCurve = profileCurve;
            this.pt1 = pt1;
            this.pt2 = pt2;
        }

        internal static object BakeSweep(Rail rail, object profile)
        {
            throw new NotImplementedException();
        }

        internal Brep BakeSweep()
        {
            throw new NotImplementedException();
        }
    }
}