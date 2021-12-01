using MyExam.Controls;
using MyExam.iOS.Renderers;
using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomRoundedButton), typeof(CustomRoundedButtonRenderer))]
namespace MyExam.iOS.Renderers
{
    public class CustomRoundedButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
            {
                return;
            }

            if (Control != null && Element != null)
            {
                var button = this.Control;
                button.BackgroundColor = Element.BackgroundColor.ToUIColor();
                button.Layer.CornerRadius = 25;
                button.ClipsToBounds = true;
            }
        }
    }
}