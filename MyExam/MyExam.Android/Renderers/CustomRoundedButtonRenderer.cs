using Android.Content;
using Android.Graphics.Drawables;
using MyExam.Controls;
using MyExam.Droid.Renderers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomRoundedButton), typeof(CustomRoundedButtonRenderer))]
namespace MyExam.Droid.Renderers
{
    public class CustomRoundedButtonRenderer : ButtonRenderer
    {
        #region Properties
        private GradientDrawable normal;
        private GradientDrawable pressed;
        #endregion

        #region Constructor
        public CustomRoundedButtonRenderer(Context context) : base(context)
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Fires when element change 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null || Element == null)
            {
                return;
            }

            if (Control != null)
            {
                var button = (CustomRoundedButton)e.NewElement;

                button.SizeChanged += (s, args) =>
                {
                    var radius = (float)Math.Min(button.Width, button.Height);

                    // Create a drawable for the button's normal state
                    normal = new GradientDrawable();

                    if (button.BackgroundColor.R == -1.0 && button.BackgroundColor.G == -1.0 && button.BackgroundColor.B == -1.0)
                        normal.SetColor(Element.BackgroundColor.ToAndroid());
                    else
                        normal.SetColor(button.BackgroundColor.ToAndroid());

                    normal.SetCornerRadius(radius);

                    // Create a drawable for the button's pressed state
                    pressed = new GradientDrawable();
                    var highlight = Context.ObtainStyledAttributes(new int[] { Android.Resource.Attribute.ColorActivatedHighlight }).GetColor(0, Android.Graphics.Color.Gray);
                    pressed.SetColor(highlight);
                    pressed.SetCornerRadius(radius);

                    // Add the drawables to a state list and assign the state list to the button
                    var sld = new StateListDrawable();
                    sld.AddState(new int[] { Android.Resource.Attribute.StatePressed }, pressed);
                    sld.AddState(new int[] { }, normal);
                    Control.SetBackgroundDrawable(sld);
                };
            }
        }
        #endregion
    }
}