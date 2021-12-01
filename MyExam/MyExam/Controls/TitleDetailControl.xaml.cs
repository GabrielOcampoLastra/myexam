
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyExam.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TitleDetailControl : ContentView
	{
        #region Properties
        public static readonly BindableProperty TitleTextProperty =
                        BindableProperty.Create(nameof(TitleText), typeof(string), typeof(TitleDetailControl), string.Empty, BindingMode.TwoWay, propertyChanged: TitlePropertyChanged);

        public static readonly BindableProperty DetailTextProperty =
                        BindableProperty.Create(nameof(DetailText), typeof(string), typeof(TitleDetailControl), string.Empty, BindingMode.TwoWay, propertyChanged: DetailPropertyChanged);

        public string TitleText
        {
            get { return base.GetValue(TitleTextProperty).ToString(); }
            set { base.SetValue(TitleTextProperty, value); }
        }

        public string DetailText
        {
            get { return base.GetValue(DetailTextProperty).ToString(); }
            set { base.SetValue(DetailTextProperty, value); }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MyExam.Controls.TitleDetailControl"/> class.
        /// </summary>
        public TitleDetailControl ()
		{
			InitializeComponent ();
		}
        #endregion

        #region Methods
        /// <summary>
        /// Title property changed.
        /// </summary>
        /// <param name="bindable">Bindable.</param>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>
        private static void TitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (TitleDetailControl)bindable;
            control.Title.Text = string.Format("{0}:", newValue.ToString());
        }

        /// <summary>
        /// Detail property changed.
        /// </summary>
        /// <param name="bindable">Bindable.</param>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>
        private static void DetailPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (TitleDetailControl)bindable;
            control.Detail.Text = newValue.ToString();
        }
        #endregion
    }
}