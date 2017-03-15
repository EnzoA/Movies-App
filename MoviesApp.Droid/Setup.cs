using Android.Content;
using Android.Widget;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MoviesApp.Core.MVVMSetup;
using MoviesApp.Droid.CustomBindings;

namespace MoviesApp.Droid
{
	public class Setup : MvxAndroidSetup
	{
		public Setup(Context applicationContext) : base(applicationContext)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new App();
		}

		protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
		{
			base.FillTargetFactories(registry);
			registry.RegisterFactory(new MvxCustomBindingFactory<ImageView>("TouchCommand", imageView => new ImageViewTouchCommandCustomBinding(imageView)));
		}
	}
}