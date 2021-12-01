using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyExam.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    /// <summary>
    /// Class to show the image on Map
    /// </summary>
    public partial class PinControl : StackLayout
    {
        #region Constructor
        /// <summary>
        /// Constructor for PinControl
        /// </summary>
        /// <param name="pinImage"></param>
        public PinControl(string pinImage)
        {
            InitializeComponent();
            PinImage.Source = pinImage;
        }
        #endregion
    }
}