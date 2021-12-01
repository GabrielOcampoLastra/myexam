using Prism.Mvvm;
using Prism.Navigation;

namespace MyExam.ViewModels
{
    /// <summary>
    /// All viewmodels has to inherit from the BaseViewModel
    /// </summary>
    public class BaseViewModel : BindableBase, INavigationAware, IDestructible
    {
        #region Properties

        private string title;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        public bool IsNotBusy
        {
            get { return !IsBusy; }
        }
        #endregion

        #region Services
        protected INavigationService NavigationService { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for ViewModelBase
        /// </summary>
        /// <param name="navigationService">Interface navigationService</param>
        public BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
        #endregion

        #region Methods
        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
        #endregion
    }
}
