using System;

namespace MyRhinoPlugin
{
    internal class RectangleBeamProfile
    {
        private double widthValue;
        private double heightValue;
        private double thicknessValue;

        public RectangleBeamProfile(double widthValue, double heightValue, double thicknessValue)
        {
            this.widthValue = widthValue;
            this.heightValue = heightValue;
            this.thicknessValue = thicknessValue;
        }

        internal object GenerateProfile()
        {
            throw new NotImplementedException();
        }
    }
}