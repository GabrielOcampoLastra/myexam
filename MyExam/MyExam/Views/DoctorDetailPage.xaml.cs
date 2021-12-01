using MyExam.Helpers;
using MyExam.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace MyExam.Views
{
    public partial class DoctorDetailPage : ContentPage
    {
        DoctorDetailPageViewModel viewModel;

        /// <summary>
        /// Constructor
        /// </summary>
        public DoctorDetailPage()
        {
            InitializeComponent();
            viewModel = (DoctorDetailPageViewModel)BindingContext;
        }

        /// <summary>
        /// Override for onAppearing
        /// </summary>
        protected override void OnAppearing()
        {
            MoveMap();
        }

        /// <summary>
        /// Center camera on the pin
        /// </summary>
        private void MoveMap()
        {
            var location = Utils.StringToPosition(viewModel.CurrentUser.Location.UserPosition);
            UserPositionMap.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(1)));
        }
    }
}
