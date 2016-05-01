using System;
using Windows.ApplicationModel.Email;
using Windows.Phone.UI.Input;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace RandomNumberGenerator.Pages
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class AboutPage : Page
	{
		public AboutPage()
		{
			this.InitializeComponent();
			NavigationCacheMode = NavigationCacheMode.Required;
			HardwareButtons.BackPressed += HardwareButtonsOnBackPressed;
		}

		private void HardwareButtonsOnBackPressed(object sender, BackPressedEventArgs backPressedEventArgs)
		{
			backPressedEventArgs.Handled = true;
			if (App.CurrentFrame.CurrentSourcePageType != typeof(AboutPage))
				return;

			App.CurrentFrame.GoBack();
		}
		
		private async void EmailButton_OnClick(object sender, RoutedEventArgs e)
		{
			var sendTo = new EmailRecipient()
			{
				Name = "Collin Dillinger",
				Address = "collin.dillinger@gmail.com"
			};

			var mail = new EmailMessage {Subject = "SimplyRandom", Body = "\n\n\nApp Version: " + App.Version};
			mail.To.Add(sendTo);
			await EmailManager.ShowComposeNewEmailAsync(mail);
		}

		private async void ViewSourceCodeButton_OnClick(object sender, RoutedEventArgs e)
		{
			await Launcher.LaunchUriAsync(new Uri("https://github.com/CDillinger/SimplyRandom"));
		}
	}
}
