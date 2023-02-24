
using Rhino.Geometry;

namespace MyPluginNamespace
{
    public interface IBeamProfileGenerator : RhinoPluginProject.IProfileGenerator
    {
        double FlangeWidth { get; set; }
        double FlangeThickness { get; set; }
        double WebHeight { get; set; }
        double WebThickness { get; set; }
    }
}
