using System;
using Xamarin.Forms;

namespace MyExam.Controls
{
    /// <summary>
    /// Class for hold the loading animation
    /// </summary>
    public class LoadingHolderControlView : ContentView
    {
        #region Properties
        /// <summary>
        /// The content
        /// </summary>
        private View content;

        /// <summary>
        /// The RelativeLayout
        /// </summary>
        private readonly Grid layout;

        private Lottie.Forms.AnimationView activityIndicator;

        /// <summary>
        /// Bindable property for Content
        /// </summary>
        public new static BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(View), typeof(LoadingHolderControlView), propertyChanged: OnContentChanged);

        public static BindableProperty IsBusyProperty = BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(LoadingHolderControlView), false);

        public new View Content
        {
            get
            {
                return GetValue(ContentProperty) as View;
            }
            set
            {
                SetValue(ContentProperty, value);
            }
        }

        public bool IsBusy
        {
            get
            {
                return (bool)GetValue(IsBusyProperty);
            }
            set
            {
                SetValue(IsBusyProperty, value);
            }
        }


        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the LoadingHolderControlView class.
        /// </summary>
        public LoadingHolderControlView()
        {
            base.Content = layout = new Grid();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Set Content
        /// </summary>
        /// <param name="view"></param>
        private void SetContent(View view)
        {
            try
            {
                if (view != null)
                {
                    layout.Children.Remove(view);
                }

                content = view;
                if (content != null)
                {
                    layout.Children.Add(content, 0, 0);
                }

                SetLoadingControls();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Sets the seccondary controls
        /// </summary>
        public void SetLoadingControls()
        {
            activityIndicator = new Lottie.Forms.AnimationView
            {
                Animation = "loading_animation.json",
                RepeatMode = Lottie.Forms.RepeatMode.Infinite,
                IsEnabled = true,
                AutoPlay = true,
                IsVisible = false,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(60, 0)
            };

            var backLoader = new BoxView { Opacity = 0.6, BackgroundColor = Color.Black };
            layout.Children.Add(backLoader, 0, 0);

            activityIndicator.SetBinding(IsVisibleProperty, "IsBusy");
            backLoader.SetBinding(BoxView.IsVisibleProperty, "IsBusy");

            layout.Children.Add(activityIndicator, 0, 0);
        }

        /// <summary>
        /// Fire when Content is Changed
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private static void OnContentChanged(BindableObject bindable, object oldValue, object newValue)
        {
            try
            {
                var obj = bindable as LoadingHolderControlView;
                obj.SetContent(newValue as View);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
