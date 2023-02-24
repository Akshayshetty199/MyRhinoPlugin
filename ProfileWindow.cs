using System;
using System.Windows;
using Windows.UI.Xaml;
using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;
using RhinoPluginProject;
using Eto.Forms;

namespace MyRhinoPlugin
{
    public partial class ProfileWindow : Eto.Forms.Window
    {
        public double WidthValue { get; set; }
        public double HeightValue { get; set; }
        public double ThicknessValue { get; set; }
        public object HeightTextBox { get; private set; }
        public object ThicknessTextBox { get; private set; }
        public object WidthTextBox { get; private set; }
        public bool DialogResult { get; private set; }

        public ProfileWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse((string)WidthTextBox , out double width))
                WidthValue = width;
            else
                WidthValue = 1.0;

            if (double.TryParse((string)HeightTextBox, out double height))
                HeightValue = height;
            else
                HeightValue = 1.0;

            if (double.TryParse((string)ThicknessTextBox, out double thickness))
                ThicknessValue = thickness;
            else
                ThicknessValue = 0.1;

            DialogResult = true;
        }

        internal void ShowDialog()
        {
            throw new NotImplementedException();
        }
    }
}
