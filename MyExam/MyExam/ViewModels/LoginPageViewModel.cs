using MyExam.Helpers;
using MyExam.Models;
using MyExam.Services.User;
using Prism.Commands;
using Prism.Navigation;
using System.Text.RegularExpressions;

namespace MyExam.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
	{
        #region Properties
        private string username;
        public string Username
        {
            get { return username; }
            set { SetProperty(ref username, value); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        private string validationErrors;
        public string ValidationErrors
        {
            get { return validationErrors; }
            set { SetProperty(ref validationErrors, value); }
        }
        #endregion

        #region Commands
        public DelegateCommand LoginCommand { get; }
        #endregion

        #region Services
        IUserService userService;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MyExam.ViewModels.LoginPageViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">Navigation service.</param>
        /// <param name="userService">User service.</param>
        public LoginPageViewModel(INavigationService navigationService, IUserService userService) : base(navigationService)
        {
            this.userService = userService;

            LoginCommand = new DelegateCommand(OnLoginCommandExecuted, LoginCommandCanExecute)
               .ObservesProperty(() => Username)
               .ObservesProperty(() => Password);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Command for do login
        /// </summary>
        private async void OnLoginCommandExecuted()
        {
            IsBusy = true;

            var user = new User()
            {
                Password = Password,
                Username = username
            };

            var response = await userService.Login(user);

            IsBusy = false;
            if (response.Success)
            {
                await NavigationService.NavigateAsync("/NavigationPage/DoctorListPage?navigatingFrom=Login");
            }
            else
            {
                ValidationErrors = response.Message;
            }
        }


        /// <summary>
        /// Method for validate if can do login
        /// </summary>
        /// <returns></returns>
        private bool LoginCommandCanExecute() =>
            !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password) && IsNotBusy && Regex.IsMatch(Username, Constants.EmailRegexValidator, RegexOptions.IgnoreCase);

        #endregion
    }
}
