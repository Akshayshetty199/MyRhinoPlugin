
using Rhino.Geometry;

namespace RhinoPluginProject
{
    public interface IProfileGenerator
    {
        Curve GenerateProfile(double height, double width, double thickness);
    }
}
