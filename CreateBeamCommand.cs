using MyPluginNamespace;
using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;
using System;

namespace RhinoPluginProject
{
    public class CreateBeamCommand : Command
    {
        public CreateBeamCommand()
        {
        }

        public override string EnglishName
        {
            get { return "CreateBeamCommand"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            // Get bottom-left point of rectangle
            GetPoint gp = new GetPoint();
            gp.SetCommandPrompt("Select bottom-left corner of rectangle");
            if (gp.Get() != GetResult.Point)
                return Result.Failure;
            Point3d pt1 = gp.Point();

            // Get top-right point of rectangle
            gp.SetCommandPrompt("Select top-right corner of rectangle");
            gp.SetBasePoint(pt1, false);
            gp.DrawLineFromPoint(pt1, true);
            if (gp.Get() != GetResult.Point)
                return Result.Failure;
            Point3d pt2 = gp.Point();

            // Create beam profile
            BeamProfile beamProfile = new BeamProfile();
            GetDouble getDouble = new GetDouble();
            getDouble.SetLowerLimit(0.0, false);
            getDouble.SetCommandPrompt("Enter height of I-beam");
            if (getDouble.Get() != GetResult.Number)
                return Result.Failure;
            double height = getDouble.Number();
            getDouble.SetCommandPrompt("Enter width of I-beam");
            if (getDouble.Get() != GetResult.Number)
                return Result.Failure;
            double width = getDouble.Number();
            getDouble.SetCommandPrompt("Enter thickness of I-beam");
            if (getDouble.Get() != GetResult.Number)
                return Result.Failure;
            double thickness = getDouble.Number();
            Curve profileCurve = beamProfile.GenerateProfile(height, width, thickness);

            // Create sweep
            ProfileSweep profileSweep = new ProfileSweep(profileCurve, pt1, pt2);
            Brep beam = profileSweep.BakeSweep();
            if (beam != null)
            {
                doc.Objects.AddBrep(beam);
                doc.Views.Redraw();
                return Result.Success;
            }
            else
            {
                return Result.Failure;
            }
        }

        private class GetDouble
        {
            internal GetResult Get()
            {
                throw new NotImplementedException();
            }

            internal double Number()
            {
                throw new NotImplementedException();
            }

            internal void SetCommandPrompt(string v)
            {
                throw new NotImplementedException();
            }

            internal void SetLowerLimit(double v1, bool v2)
            {
                throw new NotImplementedException();
            }
        }
    }
}
