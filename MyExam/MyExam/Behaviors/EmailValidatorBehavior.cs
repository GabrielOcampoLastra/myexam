using MyExam.Helpers;
using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace MyExam.Behaviors
{
    /// <summary>
    /// Class to validate Email format of input editor
    /// </summary>
    public class EmailValidatorBehavior : Behavior<Entry>
    {
        #region Properties
        private const double TIME_SPAN_TEXT_CHANGED = 250;
        private static string EmailRegex { get; set; }

        private static readonly BindablePropertyKey isValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(EmailValidatorBehavior), false);

        public static BindableProperty IsValidProperty => isValidPropertyKey.BindableProperty;

        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            set { SetValue(isValidPropertyKey, value); }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Validate regex of Email 
        /// </summary>
        public EmailValidatorBehavior()
        {
            if (string.IsNullOrWhiteSpace(EmailRegex))
            {
                EmailRegex = Constants.EmailRegexValidator;
            }
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
            IsValid = true;
        }

        /// <summary>
        /// Validates Email
        /// </summary>
        /// <param name="sender">Object to validate the change</param>
        /// <param name="e">>Text Changed Events Args</param>
        private void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            IsValid = String.IsNullOrEmpty(e.NewTextValue) ? true :
                      (Regex.IsMatch(e.NewTextValue ?? string.Empty, EmailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(TIME_SPAN_TEXT_CHANGED)));
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
