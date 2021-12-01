using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;
using MyExam.Controls;
using MyExam.Droid.Renderers;
using MyExam.Enumerators;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ImageEntry), typeof(ImageEntryRenderer))]
namespace MyExam.Droid.Renderers
{
    public class ImageEntryRenderer : EntryRenderer
    {
        #region Properties
        ImageEntry element;
        #endregion

        #region Constructor
        /// <summary>
        /// Empty constructor for Xamarin 2.5
        /// </summary>
        /// <param name="context"></param>
        public ImageEntryRenderer(Context context) : base(context)
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Element Change method
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
            {
                return;
            }

            element = (ImageEntry)this.Element;


            var editText = this.Control;
            if (!string.IsNullOrEmpty(element.Image))
            {
                switch (element.ImageAlignment)
                {
                    case ImageAlignment.Left:
                        editText.SetCompoundDrawablesWithIntrinsicBounds(GetDrawable(element.Image), null, null, null);
                        break;
                    case ImageAlignment.Right:
                        editText.SetCompoundDrawablesWithIntrinsicBounds(null, null, GetDrawable(element.Image), null);
                        break;
                }
            }
            editText.SetBackgroundResource(Resource.Drawable.edittext_bg);
            editText.CompoundDrawablePadding = 25;
            Control.Background.SetColorFilter(element.LineColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
        }

        /// <summary>
        /// Property change, when implement show password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var editText = this.Control;
            var imageEntry = sender as ImageEntry;

            if (e.PropertyName == "IsPassword")
            {
                editText.InputType = imageEntry.IsPassword ? Android.Text.InputTypes.TextVariationPassword | Android.Text.InputTypes.ClassText :
                                                             Android.Text.InputTypes.TextVariationVisiblePassword;
                editText.Typeface = Typeface.Default;
                editText.SetSelection(editText.Text.Length);
            }
        }

        /// <summary>
        /// Get the image from resources
        /// </summary>
        /// <param name="imageEntryImage"></param>
        /// <returns></returns>
        private Drawable GetDrawable(string imageEntryImage)
        {
            int resId = ResourceManager.GetDrawableByName(imageEntryImage);
            return ContextCompat.GetDrawable(Context, resId);
        }
        #endregion
    }
}