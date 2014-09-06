using System;
using System.Threading.Tasks;
using Windows.Devices.Sensors;
using Windows.Phone.UI.Input;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using RandomNumberGenerator.Helpers;
using RandomNumberGenerator.ViewModels;

namespace RandomNumberGenerator.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
	{
		public MainPageViewModel ViewModel { get; private set; }

        public MainPage()
        {
            InitializeComponent();

			DataContext = ViewModel = new MainPageViewModel();
			NavigationCacheMode = NavigationCacheMode.Required;
			HardwareButtons.BackPressed += HardwareButtonsOnBackPressed;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

		private void HardwareButtonsOnBackPressed(object sender, BackPressedEventArgs backPressedEventArgs)
		{
			backPressedEventArgs.Handled = true;
			if (App.CurrentFrame.CurrentSourcePageType != typeof(MainPage))
				return;

			//TODO: replace this with an exit prompt
			Application.Current.Exit();
		}

	    private void GenerateNumberButton_OnClick(object sender, RoutedEventArgs e)
	    {
			ViewModel.GenerateNumber();
	    }

		private void MinValueTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			// Fucking updates as soon as number is changed. This circumvents that
			int tmpMin;
			if (int.TryParse(MinValueTextBox.Text, out tmpMin))
			{
				ViewModel.LastValidMinimumValue = tmpMin;
				if (ViewModel.LastValidMinimumValue >= ViewModel.LastValidMaximumValue)
					ViewModel.MaximumValue = ViewModel.LastValidMaximumValue = ViewModel.LastValidMinimumValue + 1;
			}
			else
			{
				ViewModel.MinimumValue = ViewModel.LastValidMinimumValue;
				ViewModel.MaximumValue = ViewModel.LastValidMaximumValue;
			}
			MinValueTextBox.Text = ViewModel.MinimumValue.ToString();
			MaxValueTextBox.Text = ViewModel.MaximumValue.ToString();
		}

		private void MaxValueTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			// Fucking updates as soon as number is changed. This circumvents that
			int tmpMax;
			if (int.TryParse(MaxValueTextBox.Text, out tmpMax))
			{
				ViewModel.LastValidMaximumValue = tmpMax;
				if (ViewModel.LastValidMaximumValue <= ViewModel.LastValidMinimumValue)
					ViewModel.MinimumValue = ViewModel.LastValidMinimumValue = ViewModel.LastValidMaximumValue - 1;
			}
			else
			{
				ViewModel.MinimumValue = ViewModel.LastValidMinimumValue;
				ViewModel.MaximumValue = ViewModel.LastValidMaximumValue;
			}
			MinValueTextBox.Text = ViewModel.MinimumValue.ToString();
			MaxValueTextBox.Text = ViewModel.MaximumValue.ToString();
		}

		private void AboutAppBarButton_Click(object sender, RoutedEventArgs e)
		{
			App.CurrentFrame.Navigate(typeof(AboutPage));
		}
	}
}
