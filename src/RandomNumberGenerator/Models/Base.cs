﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RandomNumberGenerator.Models
{
	public abstract class Base
		: INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public void NotifyPropertyChanged(string propertyName = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		protected void SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
		{
			field = value;
			NotifyPropertyChanged(propertyName);
		}
	}
}
