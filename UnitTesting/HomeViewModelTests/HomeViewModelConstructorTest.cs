using NUnit.Framework;
using Moq;
using SAL.Interfaces;
using BLL.Models;
using MoviesApp.Core.ViewModels;
using System;

namespace UnitTesting.HomeViewModelTests
{
	[TestFixture]
	public class HomeViewModelConstructorTest
	{
		#region Private fields

		private IServicesManager _servicesManagerMockObject;

		private HomeViewModel _homeViewModel;

		#endregion

		#region SetUp

		[SetUp]
		public void SetUp()
		{
			_servicesManagerMockObject = Mock.Of<IServicesManager>();
		}

		#endregion

		#region Tests

		[Test]
		public void Loads_The_MovieGroups_Once()
		{
			_homeViewModel = new HomeViewModel(_servicesManagerMockObject);
			var servicesManagerMock = Mock.Get<IServicesManager>(_servicesManagerMockObject);
			servicesManagerMock.Verify(m => m.GetMovieGroupsAsync(It.IsAny<Action<MovieGroup>>()), Times.Once);
		}

		#endregion
	}
}
