using MyExam.Controls;
using MyExam.Helpers;
using MyExam.Models;
using MyExam.Platform;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using Xamarin.Forms.GoogleMaps;

namespace MyExam.ViewModels
{
    public class DoctorDetailPageViewModel : BaseViewModel
	{
        #region Properties
        public ObservableCollection<Pin> UserPin { get; set; }

        private User currentUser;
        public User CurrentUser
        {
            get { return currentUser; }
            set { SetProperty(ref currentUser, value); }
        }
        #endregion

        #region Commands
        public DelegateCommand CallCommand { get; }
        #endregion

        #region Services
        IAppUrl appUrl;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MyExam.ViewModels.DoctorDetailPageViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">Navigation service.</param>
        /// <param name="appUrl">App URL.</param>
        public DoctorDetailPageViewModel(INavigationService navigationService, IAppUrl appUrl) : base(navigationService)
        {
            this.appUrl = appUrl;
            CallCommand = new DelegateCommand(OnCallCommandExecuted);

            UserPin = new ObservableCollection<Pin>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Execute after contructor initialization, get the user list from service or database.
        /// </summary>
        /// <param name="parameters">NavigationParameters from login</param>
        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            var user = parameters.GetValue<User>("User");
            if (user != null)
            {
                CurrentUser = user;
                UserPin.Add(new Pin
                {
                    Type = PinType.Place,
                    Position = Utils.StringToPosition(CurrentUser.Location.UserPosition),
                    Label = CurrentUser.Name.First,
                    Icon = BitmapDescriptorFactory.FromView(new PinControl("icon_red_pin"))
                });
            }
        }

        /// <summary>
        /// Call command executed.
        /// </summary>
        public void OnCallCommandExecuted()
        {
            appUrl.OpenCallPhone(CurrentUser.Phone.Replace("(", "").Replace(")", "").Replace("-", ""));
        }
        #endregion
    }
}
