using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomNumberGenerator.Helpers;
using RandomNumberGenerator.Models;

namespace RandomNumberGenerator.ViewModels
{
	public class MainPageViewModel : ObservableObject
	{
		private readonly static Random Generator = new Random(Guid.NewGuid().GetHashCode());

		public MainPageViewModel()
		{
			if (MinimumValue > MaximumValue)
			{
				MinimumValue = 0;
				MaximumValue = 100;
			}
			GenerateNumber();

			LastValidMinimumValue = MinimumValue;
			LastValidMaximumValue = MaximumValue;
		}

		public int MinimumValue
		{
			get { return AppSettings.Get<int>("MinimumValue", 0); }
			set
			{
				AppSettings.Set<int>("MinimumValue", value);
				OnNotifyPropertyChanged();
			}
		}

		public int MaximumValue
		{
			get { return AppSettings.Get<int>("MaximumValue", 100); }
			set
			{
				AppSettings.Set<int>("MaximumValue", value);
				OnNotifyPropertyChanged();
			}
		}

		public int LastValidMinimumValue
		{
			get { return _lastValidMinimumValue; }
			set { TryChangeValue(ref _lastValidMinimumValue, value); }
		}
		private int _lastValidMinimumValue;

		public int LastValidMaximumValue
		{
			get { return _lastValidMaximumValue; }
			set { TryChangeValue(ref _lastValidMaximumValue, value); }
		}
		private int _lastValidMaximumValue;

		public int Number
		{
			get { return _number; }
			set { TryChangeValue(ref _number, value); }
		}
		private int _number = 53;

		public void GenerateNumber()
		{
			Number = Generator.Next(MinimumValue, MaximumValue + 1);
		}
	}
}
