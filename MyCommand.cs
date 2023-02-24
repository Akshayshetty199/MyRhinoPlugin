using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;
using RhinoPluginProject;

namespace MyRhinoPlugin
{
    public class MyCommand : Command
    {
        public override string EnglishName => "MyCommand";

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            // Ask user to input bottom-left point of rectangle
            var gp = new GetPoint();
            gp.SetCommandPrompt("Select bottom-left point of rectangle");
            gp.Get();
            if (gp.CommandResult() != Result.Success)
                return gp.CommandResult();

            var pt1 = gp.Point();

            // Ask user to input top-right point of rectangle
            gp.SetCommandPrompt("Select top-right point of rectangle");
            gp.SetBasePoint(pt1, true);
            gp.DrawLineFromPoint(pt1, true);
            gp.Get();
            if (gp.CommandResult() != Result.Success)
                return gp.CommandResult();

            var pt2 = gp.Point();

            // Open a simple WPF window where user can set Height, Width, and Thickness of the profile
            var window = new ProfileWindow();
            window.ShowDialog();

            // Create rectangular profile with I-beam profile
            var profileGen = new RectangleBeamProfile(window.WidthValue, window.HeightValue, window.ThicknessValue);
            var profile = profileGen.GenerateProfile();
            var sweep = ProfileSweep.BakeSweep(new Rail(pt1, pt2), profile);

            // Add the geometry to the document
            doc.Objects.AddBrep((Brep)sweep);

            // Redraw the viewports to show the new geometry
            doc.Views.Redraw();

            return Result.Success;
        }
    }
}