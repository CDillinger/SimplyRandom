﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RandomNumberGenerator.Helpers
{
	/// <summary>
	/// Provides a base implementation of <see cref="INotifyPropertyChanged"/> allowing properties
	/// of derived classes to be observed for changes.
	/// </summary>
	public abstract class ObservableObject: INotifyPropertyChanged
	{
		/// <summary>
		/// Occurs when a property value changes.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		protected bool TryChangeValue<T>(ref T field, T value, bool suppressEqualityCheck = false, [CallerMemberName] string propertyName = "")
		{
			if (!suppressEqualityCheck && EqualityComparer<T>.Default.Equals(field, value))
				return false;

			field = value;
			OnNotifyPropertyChanged(propertyName);

			return true;
		}

		protected void OnNotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		public void ExplicitOnNotifyPropertyChanged(string propertyName = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
