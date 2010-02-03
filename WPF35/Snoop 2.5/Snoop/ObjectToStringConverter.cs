﻿// Copyright © 2006 Microsoft Corporation.  All Rights Reserved
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Snoop
{
	public class ObjectToStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
				return "{null}";

			FrameworkElement fe = value as FrameworkElement;
			if (fe != null && !String.IsNullOrEmpty(fe.Name))
				return fe.Name + " (" + value.GetType().Name + ")";

			RoutedCommand command = value as RoutedCommand;
			if (command != null && !String.IsNullOrEmpty(command.Name))
				return command.Name + " (" + command.GetType().Name + ")";

			return "(" + value.GetType().Name + ")";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new Exception("The method or operation is not implemented.");
		}
	}
}
