using MyExam.Controls;
using MyExam.Enumerators;
using MyExam.iOS.Renderers;
using System.Drawing;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ImageEntry), typeof(ImageEntryRenderer))]
namespace MyExam.iOS.Renderers
{
    /// <summary>
    /// Implementation of renderer
    /// </summary>
    public class ImageEntryRenderer : EntryRenderer
    {
        #region Methods
        /// <summary>
        /// OnElementChanged override for custom entry
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
            {
                return;
            }

            var element = (ImageEntry)this.Element;
            var textField = this.Control;
            if (!string.IsNullOrEmpty(element.Image))
            {
                switch (element.ImageAlignment)
                {
                    case ImageAlignment.Left:
                        textField.LeftViewMode = UITextFieldViewMode.Always;
                        textField.LeftView = GetImageView(element.Image, element.ImageHeight, element.ImageWidth);
                        break;
                    case ImageAlignment.Right:
                        textField.RightViewMode = UITextFieldViewMode.Always;
                        textField.RightView = GetImageView(element.Image, element.ImageHeight, element.ImageWidth);
                        break;
                }
            }

            textField.BorderStyle = UITextBorderStyle.RoundedRect;
            textField.Layer.BorderColor = Xamarin.Forms.Color.White.ToCGColor();
            textField.Layer.BorderWidth = 1.0f;
            textField.Layer.CornerRadius = 5f;

            textField.BackgroundColor = UIColor.Clear;
            textField.Layer.MasksToBounds = true;
        }

        /// <summary>
        /// Get the image from the bundle
        /// </summary>
        /// <param name="imagePath">Path of the image</param>
        /// <param name="height">Height of the image</param>
        /// <param name="width">Width of the image</param>
        /// <returns>Image</returns>
        private UIView GetImageView(string imagePath, int height, int width)
        {
            var uiImageView = new UIImageView(UIImage.FromBundle(imagePath))
            {
                Frame = new RectangleF(10, 0, width, height)
            };
            UIView objLeftView = new UIView(new System.Drawing.Rectangle(0, 0, width + 15, height));
            objLeftView.AddSubview(uiImageView);

            return objLeftView;
        }
        #endregion
    }
}