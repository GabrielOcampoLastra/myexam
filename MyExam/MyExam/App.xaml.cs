using MyExam.Services.User;
using MyExam.Views;
using Plugin.SecureStorage;
using Prism;
using Prism.Autofac;
using Prism.Ioc;
using Realms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyExam
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            if (CrossSecureStorage.Current.HasKey("IsLogged"))
            {
                await NavigationService.NavigateAsync("NavigationPage/DoctorListPage");
            }
            else
            {
                await NavigationService.NavigateAsync("LoginPage");
            }

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage>();
            containerRegistry.RegisterForNavigation<DoctorListPage>();
            containerRegistry.RegisterForNavigation<DoctorDetailPage>();

            containerRegistry.Register<IUserService, UserService>();
        }
    }
}
