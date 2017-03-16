using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace SliderDrawer.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
			AppProperties.ScreenWidth = (int)UIScreen.MainScreen.Bounds.Width;
			AppProperties.ScreenHeight = (int)UIScreen.MainScreen.Bounds.Height;
			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}
