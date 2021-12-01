using MyExam.Models;
using MyExam.Services.User;
using MvvmHelpers;
using Prism.Commands;
using Prism.Navigation;

namespace MyExam.ViewModels
{
    public class DoctorListPageViewModel : BaseViewModel
    {
        #region Properties
        public ObservableRangeCollection<User> UserList { get; }

        private User selectedUser;
        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                if (selectedUser != null)
                {
                    NavigateCommand.Execute("DoctorDetailPage");
                    SelectedUser = null;
                }
            }
        }
        #endregion

        #region Commands
        public DelegateCommand<string> NavigateCommand { get; }
        public DelegateCommand LogoutCommand { get; }
        #endregion

        #region Services
        IUserService userService;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MyExam.ViewModels.DoctorListPageViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">Navigation service.</param>
        /// <param name="userService">User service.</param>
        public DoctorListPageViewModel(INavigationService navigationService, IUserService userService) : base(navigationService)
        {
            this.userService = userService;

            NavigateCommand = new DelegateCommand<string>(OnNavigateCommandExecuted);
            LogoutCommand = new DelegateCommand(OnLogoutCommandExecuted);

            UserList = new ObservableRangeCollection<User>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Execute after contructor initialization, get the user list from service or database.
        /// </summary>
        /// <param name="parameters">NavigationParameters from login</param>
        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            var navigatingFrom = parameters.GetValue<string>("navigatingFrom");
            IsBusy = true;

            if (!string.IsNullOrWhiteSpace(navigatingFrom) && navigatingFrom.Equals("Login"))
            {
                var userList = await userService.GetUsersFromService(5);
                UserList.AddRange(userList);
            }
            else
            {
                var userList = userService.GetUsersFromDatabase();
                UserList.AddRange(userList);
            }
            IsBusy = false;
        }

        /// <summary>
        /// Command for Navigation
        /// </summary>
        /// <param name="path"></param>
        private async void OnNavigateCommandExecuted(string path)
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add("User", selectedUser);

            await NavigationService.NavigateAsync(path, navigationParams);
        }

        /// <summary>
        /// Command for do login
        /// </summary>
        private async void OnLogoutCommandExecuted()
        {
            var logout = userService.Logout();
            if (logout)
            {
                await NavigationService.NavigateAsync("/LoginPage");
             }
        }
        #endregion
    }
}
