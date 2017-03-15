using System;
using System.Windows.Input;
using Android.Widget;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;

namespace MoviesApp.Droid.CustomBindings
{
	public class ImageViewTouchCommandCustomBinding : MvxTargetBinding
	{
		private ICommand _command;

		public ImageViewTouchCommandCustomBinding(ImageView target) : base(target)
		{
			target.Touch += Target_Touch;
		}

		private void Target_Touch(object sender, Android.Views.View.TouchEventArgs e)
		{
			_command?.Execute(parameter: null);
		}

		public override Type TargetType
		{
			get { return typeof(ICommand); }
		}

		public override void SetValue(object value)
		{
			_command = value as ICommand;
		}
		
		public override MvxBindingMode DefaultMode
		{
			get { return MvxBindingMode.TwoWay; }
		}

		protected override void Dispose(bool isDisposing)
		{
			if (isDisposing)
			{
				var target = Target as ImageView;
				if (target != null)
				{
					target.Touch -= Target_Touch;
				}
			}
			base.Dispose(isDisposing);
		}
	}
}