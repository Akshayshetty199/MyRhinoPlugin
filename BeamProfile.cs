using Rhino.Geometry;

namespace MyPluginNamespace
{
    public class BeamProfile : IBeamProfileGenerator
    {
        public double FlangeWidth { get; set; }
        public double FlangeThickness { get; set; }
        public double WebHeight { get; set; }
        public double WebThickness { get; set; }

        public BeamProfile(double flangeWidth, double flangeThickness, double webHeight, double webThickness)
        {
            FlangeWidth = flangeWidth;
            FlangeThickness = flangeThickness;
            WebHeight = webHeight;
            WebThickness = webThickness;
        }

        public BeamProfile()
        {
        }

        public Polyline GenerateProfile(double height, Point3d origin, Vector3d direction)
        {
            Polyline profile = new Polyline();

            double halfFlangeWidth = FlangeWidth / 2.0;
            double halfWebHeight = WebHeight / 2.0;

            // Create the points for the top flange
            Point3d topStart = origin + halfFlangeWidth * direction + halfWebHeight * Vector3d.ZAxis;
            Point3d topEnd = origin - halfFlangeWidth * direction + halfWebHeight * Vector3d.ZAxis;

            // Create the points for the bottom flange
            Point3d bottomStart = origin + halfFlangeWidth * direction - halfWebHeight * Vector3d.ZAxis;
            Point3d bottomEnd = origin - halfFlangeWidth * direction - halfWebHeight * Vector3d.ZAxis;

            // Add the points to the polyline in the correct order
            profile.Add(topStart);
            profile.Add(topEnd);
            profile.Add(bottomEnd);
            profile.Add(bottomStart);
            profile.Add(topStart);

            return profile;
        }

        public Curve GenerateProfile(double height, double width, double thickness)
        {
            throw new System.NotImplementedException();
        }
    }
}
