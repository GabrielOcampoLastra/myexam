using Xamarin.Forms;

namespace MyExam.Behaviors
{
    /// <summary>
    /// Class to validate the lenght of entry text
    /// </summary>
    public class MaxLengthValidatorBehavior : Behavior<Entry>
    {
        #region Properties
        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create("MaxLength", typeof(int), typeof(MaxLengthValidatorBehavior), 0);

        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Sets event
        /// </summary>
        /// <param name="bindable">Text Entry</param>
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
        }

        /// <summary>
        /// Event when change text from entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.NewTextValue) && e.NewTextValue.Length > MaxLength)
            {
                ((Entry)sender).Text = e.NewTextValue.Substring(0, MaxLength);
            }
        }

        /// <summary>
        /// Unsuscribes event
        /// </summary>
        /// <param name="bindable">Text Entry</param>
        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;

        }
        #endregion
    }
}
