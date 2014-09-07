using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Email;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
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

		/// <summary>
		/// Invoked when this page is about to be displayed in a Frame.
		/// </summary>
		/// <param name="e">Event data that describes how this page was reached.
		/// This parameter is typically used to configure the page.</param>
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
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

		private async void VisitWebiteButton_OnClick(object sender, RoutedEventArgs e)
		{
			await Launcher.LaunchUriAsync(new Uri("http://cdillinger.me/simplyrandom/"));
		}
	}
}
