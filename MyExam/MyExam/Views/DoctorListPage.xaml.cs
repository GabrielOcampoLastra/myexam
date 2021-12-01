using Xamarin.Forms;

namespace MyExam.Views
{
    public partial class DoctorListPage : ContentPage
    {
        /// <summary>
        /// Constructor for Doctor List Page
        /// </summary>
        public DoctorListPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This event fires when the user select a row of the listview
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        private void DoctorListOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var lv = (ListView)sender;
            lv.SelectedItem = null;
        }
    }
}
