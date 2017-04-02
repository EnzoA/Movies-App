using System;
using System.Globalization;
using MvvmCross.Platform.Converters;

namespace MoviesApp.Core.Converters
{
	public class ReleaseDateValueConverter : MvxValueConverter<DateTime, string>
	{
		protected override string Convert(DateTime releaseDate, Type targetType, object parameter, CultureInfo culture)
		{
			var isDefaultDate = DateTime.Compare(releaseDate, default(DateTime)) == 0;
			var releaseDateText = !isDefaultDate ? releaseDate.ToString(DateTimeFormatInfo.InvariantInfo.ShortDatePattern) : "Unknown";
			return $"Release Date: {releaseDateText}";
		}
	}
}
