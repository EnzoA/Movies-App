using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using BLL.Models;
using SAL.Interfaces;

namespace MoviesApp.Core.ViewModels
{
	public class HomeViewModel : ViewModel
	{
		#region Bindable properties

		private ObservableCollection<MovieGroup> _movieGroups;
		public ObservableCollection<MovieGroup> MovieGroups
		{
			get { return _movieGroups; }
			set { _movieGroups = value; RaisePropertyChanged(() => MovieGroups); }
		}

		private ICommand _loadMovieGroupsCommand;
		public ICommand LoadMovieGroupsCommand
		{
			get
			{
				return _loadMovieGroupsCommand = _loadMovieGroupsCommand ?? new MvxCommand(() => LoadMovieGroups());
			}
		}

		private bool _isBusy;
		public bool IsBusy
		{
			get { return _isBusy; }
			set { _isBusy = value; RaisePropertyChanged(() => IsBusy); }
		}

		private bool _hasThrownError;
		public bool HasThrownError
		{
			get { return _hasThrownError; }
			set { _hasThrownError = value; RaisePropertyChanged(() => HasThrownError); }
		}

		private string _errorMessage;
		public string ErrorMessage
		{
			get { return _errorMessage; }
			set { _errorMessage = value; RaisePropertyChanged(() => ErrorMessage); }
		}

		#endregion

		#region Constructor

		public HomeViewModel(IServicesManager servicesManager) : base(servicesManager)
		{
			MovieGroups = new ObservableCollection<MovieGroup>();
			LoadMovieGroups();
		}

		#endregion

		#region Private methods

		private async void LoadMovieGroups()
		{
			IsBusy = true;
			MovieGroups.Clear();
			HasThrownError = false;
			ErrorMessage = string.Empty;
			
			try
			{
				await _servicesManager.GetMovieGroupsAsync(onEachMovieGroupCallback: movieGroup =>
				{
					if (movieGroup != null && movieGroup.Movies != null && movieGroup.Movies.Any())
					{
						MovieGroups.Add(movieGroup);
						IsBusy = false;
					}
				});
			}
			catch (Exception ex)
			{
				HasThrownError = true;
				ErrorMessage = "An error has occurred while loading some of the movies"; // TODO: Use a Resx file
				IsBusy = false;
			}
		}
		
		#endregion
	}
}
